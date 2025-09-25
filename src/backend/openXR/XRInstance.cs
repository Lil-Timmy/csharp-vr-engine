using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace Engine;


public unsafe class XRInstance : Disposable
{
    public readonly XrInstance instance;

    public readonly string appName   ;
    public readonly string engineName;
    
    private readonly Delegate debugCallback = DebugCallback;

    private readonly List<string> extensions = new List<string>()
    {
        "XR_KHR_opengl_enable",
    };

    private readonly List<string> apiLayers = new List<string>()
    {
        
    };

    private readonly XrApplicationInfo    applicationInfo   ;
    private readonly XrInstanceCreateInfo instanceCreateInfo;

    private readonly XrDebugUtilsMessengerCreateInfoEXT debugMessengerCreateInfo;



    public XRInstance(string _appName, string _engineName)
    {
        appName    = _appName;
        engineName = _engineName;


        # if DEBUG

        extensions.Add("XR_EXT_debug_utils"                );
        apiLayers .Add("XR_APILAYER_LUNARG_core_validation");

        debugMessengerCreateInfo = new XrDebugUtilsMessengerCreateInfoEXT()
        {
            type = XrStructureType.XR_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT,
            next = null,

            userData     = null,
            userCallback = Marshal.GetFunctionPointerForDelegate(debugCallback),
            
            messageSeverities = (ulong)
            (
                XrDebugUtilsMessageSeverityFlagsEXT.XR_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT |
                XrDebugUtilsMessageSeverityFlagsEXT.XR_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT   |
                XrDebugUtilsMessageSeverityFlagsEXT.XR_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT
            ),
            messageTypes      = (ulong)
            (
                XrDebugUtilsMessageTypeFlagsEXT.XR_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT |
                XrDebugUtilsMessageTypeFlagsEXT.XR_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT  |
                XrDebugUtilsMessageTypeFlagsEXT.XR_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT
            ),
        };

        # endif


        applicationInfo = new XrApplicationInfo()
        {
            apiVersion = (1UL << 48) | (0UL << 32) | (42UL),
            
            applicationVersion  = 1                        ,
            engineVersion       = 1                        ,
        };

        fixed (XrApplicationInfo* _applicationInfoPtr = &applicationInfo)
        {
            Program.StringToBuffer(appName   , _applicationInfoPtr -> applicationName, 128);
            Program.StringToBuffer(engineName, _applicationInfoPtr -> engineName     , 128);
        }
        
        
        byte*[] _extensionNames = AllocateBytes(extensions);
        byte*[] _apiLayerNames  = AllocateBytes(apiLayers );

        fixed(byte** _extensionNamesPtr = &_extensionNames[0])
        fixed(byte** _apiLayerNamesPtr  = &_apiLayerNames [0])
        fixed (XrDebugUtilsMessengerCreateInfoEXT* _debugMessengerCreateInfoPtr = &debugMessengerCreateInfo)
        {
            instanceCreateInfo = new XrInstanceCreateInfo()
            {
                type                    = XrStructureType.XR_TYPE_INSTANCE_CREATE_INFO,
                createFlags             = (ulong)XrInstanceCreateFlags.None           ,

                # if DEBUG
                next                    = _debugMessengerCreateInfoPtr                ,
                # else
                next                    = null                                        ,
                # endif
                
                applicationInfo         = applicationInfo                             ,

                enabledExtensionCount   = (uint)extensions.Count                      ,
                enabledExtensionNames   = _extensionNamesPtr                          ,
                
                enabledApiLayerCount    = (uint)apiLayers.Count                       ,
                enabledApiLayerNames    = _apiLayerNamesPtr                           ,
            };
        }


        fixed (XrInstanceCreateInfo* _instanceCreateInfoPtr = &instanceCreateInfo)
        fixed (XrInstance*           _instancePtr           = &instance          )
        {
            TimmyXR.xrCreateInstance(_instanceCreateInfoPtr, _instancePtr);
            TimmyXR.xrInstance = instance;
        }
        
        
        FreeBytes(_extensionNames);
        FreeBytes(_apiLayerNames );
    }

    protected override void OnDispose()
    {
        TimmyXR.xrDestroyInstance(instance);
    }


    private static uint DebugCallback(XrDebugUtilsMessageSeverityFlagsEXT _messageSeverity, XrDebugUtilsMessageTypeFlagsEXT _messageType, XrDebugUtilsMessengerCallbackDataEXT* _callbackDataPtr, void* _userDataPtr)
    {
        string       _message = Marshal.PtrToStringAnsi((nint)_callbackDataPtr->message);
        ConsoleColor _color   = ConsoleColor.White                                   ;

        switch (_messageSeverity)
        {
            case XrDebugUtilsMessageSeverityFlagsEXT.XR_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT:
            {
                _color = ConsoleColor.Magenta;
                break;
            }
            case XrDebugUtilsMessageSeverityFlagsEXT.XR_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT:
            {
                _color = ConsoleColor.Magenta;
                break;
            }
            case XrDebugUtilsMessageSeverityFlagsEXT.XR_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT:
            {
                _color = ConsoleColor.Gray;
                break;
            }
            case XrDebugUtilsMessageSeverityFlagsEXT.XR_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT:
            {
                _color = ConsoleColor.Gray;
                break;
            }
        }

        Debug.Log($"OpenXR:\n  {_message}", _color);

        return XrBool32.False;
    }
    
    
    private static byte*[] AllocateBytes(List<string> _array)
    {
        byte*[] _bytes = new byte*[_array.Count];
        
        for (int i = 0; i < _array.Count; i++)
        {
            byte[] _text   = Encoding.UTF8.GetBytes(_array[i] + "\0");
            IntPtr _memory = Marshal.AllocHGlobal(_text.Length);
            
            Marshal.Copy(_text, 0, _memory, _text.Length);
            _bytes[i] = (byte*)_memory;
        }
        
        return _bytes;
    }
    private static void FreeBytes(byte*[] _bytes)
    {
        for (int i = 0; i < _bytes.Length; i++)
        {
            Marshal.FreeHGlobal((IntPtr)_bytes[i]);
        }
    }
}