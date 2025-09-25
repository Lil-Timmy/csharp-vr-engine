using System;
using System.Runtime.InteropServices;
using System.Text;


namespace Engine;


public static unsafe class TimmyXR
{
    public static XrInstance xrInstance = new XrInstance(0);


    [DllImport("openxr_loader.dll", EntryPoint = "xrGetInstanceProcAddr", CallingConvention = CallingConvention.Cdecl)]
    private static extern int xrGetInstanceProcAddr(ulong instance, byte* name, void** function);

    private static unsafe T LoadFunction<T>(string _name) where T : Delegate
    {
        byte[] _nameBytes = Encoding.UTF8.GetBytes(_name + "\0");

        fixed (byte* pName = _nameBytes)
        {
            void* _funcPtr = null;
            int _result = xrGetInstanceProcAddr(xrInstance.Handle, pName, &_funcPtr);
            if (_result != 0 || _funcPtr == null)
                throw new InvalidOperationException($"Failed to load {_name}, result {_result}");

            return (T)Marshal.GetDelegateForFunctionPointer((IntPtr)_funcPtr, typeof(T));
        }
    }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetInstanceProcAddrDelegate(XrInstance instance, byte* name, IntPtr function);
		private static xrGetInstanceProcAddrDelegate xrGetInstanceProcAddr_ptr;
		public static XrResult xrGetInstanceProcAddr(XrInstance instance, byte* name, IntPtr function)
        {
            xrGetInstanceProcAddr_ptr ??= LoadFunction<xrGetInstanceProcAddrDelegate>("xrGetInstanceProcAddr");
            XrResult _result = xrGetInstanceProcAddr_ptr(instance, name, function);
            Debug.Result(_result, "xrGetInstanceProcAddr");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateApiLayerPropertiesDelegate(uint propertyCapacityInput, uint* propertyCountOutput, XrApiLayerProperties* properties);
		private static xrEnumerateApiLayerPropertiesDelegate xrEnumerateApiLayerProperties_ptr;
		public static XrResult xrEnumerateApiLayerProperties(uint propertyCapacityInput, uint* propertyCountOutput, XrApiLayerProperties* properties)
        {
            xrEnumerateApiLayerProperties_ptr ??= LoadFunction<xrEnumerateApiLayerPropertiesDelegate>("xrEnumerateApiLayerProperties");
            XrResult _result = xrEnumerateApiLayerProperties_ptr(propertyCapacityInput, propertyCountOutput, properties);
            Debug.Result(_result, "xrEnumerateApiLayerProperties");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateInstanceExtensionPropertiesDelegate(byte* layerName, uint propertyCapacityInput, uint* propertyCountOutput, XrExtensionProperties* properties);
		private static xrEnumerateInstanceExtensionPropertiesDelegate xrEnumerateInstanceExtensionProperties_ptr;
		public static XrResult xrEnumerateInstanceExtensionProperties(byte* layerName, uint propertyCapacityInput, uint* propertyCountOutput, XrExtensionProperties* properties)
        {
            xrEnumerateInstanceExtensionProperties_ptr ??= LoadFunction<xrEnumerateInstanceExtensionPropertiesDelegate>("xrEnumerateInstanceExtensionProperties");
            XrResult _result = xrEnumerateInstanceExtensionProperties_ptr(layerName, propertyCapacityInput, propertyCountOutput, properties);
            Debug.Result(_result, "xrEnumerateInstanceExtensionProperties");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateInstanceDelegate(XrInstanceCreateInfo* createInfo, XrInstance* instance);
		private static xrCreateInstanceDelegate xrCreateInstance_ptr;
		public static XrResult xrCreateInstance(XrInstanceCreateInfo* createInfo, XrInstance* instance)
        {
            xrCreateInstance_ptr ??= LoadFunction<xrCreateInstanceDelegate>("xrCreateInstance");
            XrResult _result = xrCreateInstance_ptr(createInfo, instance);
            Debug.Result(_result, "xrCreateInstance");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyInstanceDelegate(XrInstance instance);
		private static xrDestroyInstanceDelegate xrDestroyInstance_ptr;
		public static XrResult xrDestroyInstance(XrInstance instance)
        {
            xrDestroyInstance_ptr ??= LoadFunction<xrDestroyInstanceDelegate>("xrDestroyInstance");
            XrResult _result = xrDestroyInstance_ptr(instance);
            Debug.Result(_result, "xrDestroyInstance");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetInstancePropertiesDelegate(XrInstance instance, XrInstanceProperties* instanceProperties);
		private static xrGetInstancePropertiesDelegate xrGetInstanceProperties_ptr;
		public static XrResult xrGetInstanceProperties(XrInstance instance, XrInstanceProperties* instanceProperties)
        {
            xrGetInstanceProperties_ptr ??= LoadFunction<xrGetInstancePropertiesDelegate>("xrGetInstanceProperties");
            XrResult _result = xrGetInstanceProperties_ptr(instance, instanceProperties);
            Debug.Result(_result, "xrGetInstanceProperties");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPollEventDelegate(XrInstance instance, XrEventDataBuffer* eventData);
		private static xrPollEventDelegate xrPollEvent_ptr;
		public static XrResult xrPollEvent(XrInstance instance, XrEventDataBuffer* eventData)
        {
            xrPollEvent_ptr ??= LoadFunction<xrPollEventDelegate>("xrPollEvent");
            XrResult _result = xrPollEvent_ptr(instance, eventData);
            Debug.Result(_result, "xrPollEvent");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrResultToStringDelegate(XrInstance instance, XrResult value, byte buffer);
		private static xrResultToStringDelegate xrResultToString_ptr;
		public static XrResult xrResultToString(XrInstance instance, XrResult value, byte buffer)
        {
            xrResultToString_ptr ??= LoadFunction<xrResultToStringDelegate>("xrResultToString");
            XrResult _result = xrResultToString_ptr(instance, value, buffer);
            Debug.Result(_result, "xrResultToString");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStructureTypeToStringDelegate(XrInstance instance, XrStructureType value, byte buffer);
		private static xrStructureTypeToStringDelegate xrStructureTypeToString_ptr;
		public static XrResult xrStructureTypeToString(XrInstance instance, XrStructureType value, byte buffer)
        {
            xrStructureTypeToString_ptr ??= LoadFunction<xrStructureTypeToStringDelegate>("xrStructureTypeToString");
            XrResult _result = xrStructureTypeToString_ptr(instance, value, buffer);
            Debug.Result(_result, "xrStructureTypeToString");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSystemDelegate(XrInstance instance, XrSystemGetInfo* getInfo, ulong* systemId);
		private static xrGetSystemDelegate xrGetSystem_ptr;
		public static XrResult xrGetSystem(XrInstance instance, XrSystemGetInfo* getInfo, ulong* systemId)
        {
            xrGetSystem_ptr ??= LoadFunction<xrGetSystemDelegate>("xrGetSystem");
            XrResult _result = xrGetSystem_ptr(instance, getInfo, systemId);
            Debug.Result(_result, "xrGetSystem");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSystemPropertiesDelegate(XrInstance instance, ulong systemId, XrSystemProperties* properties);
		private static xrGetSystemPropertiesDelegate xrGetSystemProperties_ptr;
		public static XrResult xrGetSystemProperties(XrInstance instance, ulong systemId, XrSystemProperties* properties)
        {
            xrGetSystemProperties_ptr ??= LoadFunction<xrGetSystemPropertiesDelegate>("xrGetSystemProperties");
            XrResult _result = xrGetSystemProperties_ptr(instance, systemId, properties);
            Debug.Result(_result, "xrGetSystemProperties");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateEnvironmentBlendModesDelegate(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint environmentBlendModeCapacityInput, uint* environmentBlendModeCountOutput, XrEnvironmentBlendMode* environmentBlendModes);
		private static xrEnumerateEnvironmentBlendModesDelegate xrEnumerateEnvironmentBlendModes_ptr;
		public static XrResult xrEnumerateEnvironmentBlendModes(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint environmentBlendModeCapacityInput, uint* environmentBlendModeCountOutput, XrEnvironmentBlendMode* environmentBlendModes)
        {
            xrEnumerateEnvironmentBlendModes_ptr ??= LoadFunction<xrEnumerateEnvironmentBlendModesDelegate>("xrEnumerateEnvironmentBlendModes");
            XrResult _result = xrEnumerateEnvironmentBlendModes_ptr(instance, systemId, viewConfigurationType, environmentBlendModeCapacityInput, environmentBlendModeCountOutput, environmentBlendModes);
            Debug.Result(_result, "xrEnumerateEnvironmentBlendModes");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSessionDelegate(XrInstance instance, XrSessionCreateInfo* createInfo, XrSession* session);
		private static xrCreateSessionDelegate xrCreateSession_ptr;
		public static XrResult xrCreateSession(XrInstance instance, XrSessionCreateInfo* createInfo, XrSession* session)
        {
            xrCreateSession_ptr ??= LoadFunction<xrCreateSessionDelegate>("xrCreateSession");
            XrResult _result = xrCreateSession_ptr(instance, createInfo, session);
            Debug.Result(_result, "xrCreateSession");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySessionDelegate(XrSession session);
		private static xrDestroySessionDelegate xrDestroySession_ptr;
		public static XrResult xrDestroySession(XrSession session)
        {
            xrDestroySession_ptr ??= LoadFunction<xrDestroySessionDelegate>("xrDestroySession");
            XrResult _result = xrDestroySession_ptr(session);
            Debug.Result(_result, "xrDestroySession");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateReferenceSpacesDelegate(XrSession session, uint spaceCapacityInput, uint* spaceCountOutput, XrReferenceSpaceType* spaces);
		private static xrEnumerateReferenceSpacesDelegate xrEnumerateReferenceSpaces_ptr;
		public static XrResult xrEnumerateReferenceSpaces(XrSession session, uint spaceCapacityInput, uint* spaceCountOutput, XrReferenceSpaceType* spaces)
        {
            xrEnumerateReferenceSpaces_ptr ??= LoadFunction<xrEnumerateReferenceSpacesDelegate>("xrEnumerateReferenceSpaces");
            XrResult _result = xrEnumerateReferenceSpaces_ptr(session, spaceCapacityInput, spaceCountOutput, spaces);
            Debug.Result(_result, "xrEnumerateReferenceSpaces");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateReferenceSpaceDelegate(XrSession session, XrReferenceSpaceCreateInfo* createInfo, XrSpace* space);
		private static xrCreateReferenceSpaceDelegate xrCreateReferenceSpace_ptr;
		public static XrResult xrCreateReferenceSpace(XrSession session, XrReferenceSpaceCreateInfo* createInfo, XrSpace* space)
        {
            xrCreateReferenceSpace_ptr ??= LoadFunction<xrCreateReferenceSpaceDelegate>("xrCreateReferenceSpace");
            XrResult _result = xrCreateReferenceSpace_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateReferenceSpace");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetReferenceSpaceBoundsRectDelegate(XrSession session, XrReferenceSpaceType referenceSpaceType, XrExtent2Df* bounds);
		private static xrGetReferenceSpaceBoundsRectDelegate xrGetReferenceSpaceBoundsRect_ptr;
		public static XrResult xrGetReferenceSpaceBoundsRect(XrSession session, XrReferenceSpaceType referenceSpaceType, XrExtent2Df* bounds)
        {
            xrGetReferenceSpaceBoundsRect_ptr ??= LoadFunction<xrGetReferenceSpaceBoundsRectDelegate>("xrGetReferenceSpaceBoundsRect");
            XrResult _result = xrGetReferenceSpaceBoundsRect_ptr(session, referenceSpaceType, bounds);
            Debug.Result(_result, "xrGetReferenceSpaceBoundsRect");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateActionSpaceDelegate(XrSession session, XrActionSpaceCreateInfo* createInfo, XrSpace* space);
		private static xrCreateActionSpaceDelegate xrCreateActionSpace_ptr;
		public static XrResult xrCreateActionSpace(XrSession session, XrActionSpaceCreateInfo* createInfo, XrSpace* space)
        {
            xrCreateActionSpace_ptr ??= LoadFunction<xrCreateActionSpaceDelegate>("xrCreateActionSpace");
            XrResult _result = xrCreateActionSpace_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateActionSpace");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateSpaceDelegate(XrSpace space, XrSpace baseSpace, long time, XrSpaceLocation* location);
		private static xrLocateSpaceDelegate xrLocateSpace_ptr;
		public static XrResult xrLocateSpace(XrSpace space, XrSpace baseSpace, long time, XrSpaceLocation* location)
        {
            xrLocateSpace_ptr ??= LoadFunction<xrLocateSpaceDelegate>("xrLocateSpace");
            XrResult _result = xrLocateSpace_ptr(space, baseSpace, time, location);
            Debug.Result(_result, "xrLocateSpace");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpaceDelegate(XrSpace space);
		private static xrDestroySpaceDelegate xrDestroySpace_ptr;
		public static XrResult xrDestroySpace(XrSpace space)
        {
            xrDestroySpace_ptr ??= LoadFunction<xrDestroySpaceDelegate>("xrDestroySpace");
            XrResult _result = xrDestroySpace_ptr(space);
            Debug.Result(_result, "xrDestroySpace");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateViewConfigurationsDelegate(XrInstance instance, ulong systemId, uint viewConfigurationTypeCapacityInput, uint* viewConfigurationTypeCountOutput, XrViewConfigurationType* viewConfigurationTypes);
		private static xrEnumerateViewConfigurationsDelegate xrEnumerateViewConfigurations_ptr;
		public static XrResult xrEnumerateViewConfigurations(XrInstance instance, ulong systemId, uint viewConfigurationTypeCapacityInput, uint* viewConfigurationTypeCountOutput, XrViewConfigurationType* viewConfigurationTypes)
        {
            xrEnumerateViewConfigurations_ptr ??= LoadFunction<xrEnumerateViewConfigurationsDelegate>("xrEnumerateViewConfigurations");
            XrResult _result = xrEnumerateViewConfigurations_ptr(instance, systemId, viewConfigurationTypeCapacityInput, viewConfigurationTypeCountOutput, viewConfigurationTypes);
            Debug.Result(_result, "xrEnumerateViewConfigurations");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetViewConfigurationPropertiesDelegate(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, XrViewConfigurationProperties* configurationProperties);
		private static xrGetViewConfigurationPropertiesDelegate xrGetViewConfigurationProperties_ptr;
		public static XrResult xrGetViewConfigurationProperties(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, XrViewConfigurationProperties* configurationProperties)
        {
            xrGetViewConfigurationProperties_ptr ??= LoadFunction<xrGetViewConfigurationPropertiesDelegate>("xrGetViewConfigurationProperties");
            XrResult _result = xrGetViewConfigurationProperties_ptr(instance, systemId, viewConfigurationType, configurationProperties);
            Debug.Result(_result, "xrGetViewConfigurationProperties");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateViewConfigurationViewsDelegate(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint viewCapacityInput, uint* viewCountOutput, XrViewConfigurationView* views);
		private static xrEnumerateViewConfigurationViewsDelegate xrEnumerateViewConfigurationViews_ptr;
		public static XrResult xrEnumerateViewConfigurationViews(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint viewCapacityInput, uint* viewCountOutput, XrViewConfigurationView* views)
        {
            xrEnumerateViewConfigurationViews_ptr ??= LoadFunction<xrEnumerateViewConfigurationViewsDelegate>("xrEnumerateViewConfigurationViews");
            XrResult _result = xrEnumerateViewConfigurationViews_ptr(instance, systemId, viewConfigurationType, viewCapacityInput, viewCountOutput, views);
            Debug.Result(_result, "xrEnumerateViewConfigurationViews");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSwapchainFormatsDelegate(XrSession session, uint formatCapacityInput, uint* formatCountOutput, long* formats);
		private static xrEnumerateSwapchainFormatsDelegate xrEnumerateSwapchainFormats_ptr;
		public static XrResult xrEnumerateSwapchainFormats(XrSession session, uint formatCapacityInput, uint* formatCountOutput, long* formats)
        {
            xrEnumerateSwapchainFormats_ptr ??= LoadFunction<xrEnumerateSwapchainFormatsDelegate>("xrEnumerateSwapchainFormats");
            XrResult _result = xrEnumerateSwapchainFormats_ptr(session, formatCapacityInput, formatCountOutput, formats);
            Debug.Result(_result, "xrEnumerateSwapchainFormats");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSwapchainDelegate(XrSession session, XrSwapchainCreateInfo* createInfo, XrSwapchain* swapchain);
		private static xrCreateSwapchainDelegate xrCreateSwapchain_ptr;
		public static XrResult xrCreateSwapchain(XrSession session, XrSwapchainCreateInfo* createInfo, XrSwapchain* swapchain)
        {
            xrCreateSwapchain_ptr ??= LoadFunction<xrCreateSwapchainDelegate>("xrCreateSwapchain");
            XrResult _result = xrCreateSwapchain_ptr(session, createInfo, swapchain);
            Debug.Result(_result, "xrCreateSwapchain");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySwapchainDelegate(XrSwapchain swapchain);
		private static xrDestroySwapchainDelegate xrDestroySwapchain_ptr;
		public static XrResult xrDestroySwapchain(XrSwapchain swapchain)
        {
            xrDestroySwapchain_ptr ??= LoadFunction<xrDestroySwapchainDelegate>("xrDestroySwapchain");
            XrResult _result = xrDestroySwapchain_ptr(swapchain);
            Debug.Result(_result, "xrDestroySwapchain");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSwapchainImagesDelegate(XrSwapchain swapchain, uint imageCapacityInput, uint* imageCountOutput, XrSwapchainImageBaseHeader* images);
		private static xrEnumerateSwapchainImagesDelegate xrEnumerateSwapchainImages_ptr;
		public static XrResult xrEnumerateSwapchainImages(XrSwapchain swapchain, uint imageCapacityInput, uint* imageCountOutput, XrSwapchainImageBaseHeader* images)
        {
            xrEnumerateSwapchainImages_ptr ??= LoadFunction<xrEnumerateSwapchainImagesDelegate>("xrEnumerateSwapchainImages");
            XrResult _result = xrEnumerateSwapchainImages_ptr(swapchain, imageCapacityInput, imageCountOutput, images);
            Debug.Result(_result, "xrEnumerateSwapchainImages");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrAcquireSwapchainImageDelegate(XrSwapchain swapchain, XrSwapchainImageAcquireInfo* acquireInfo, uint* index);
		private static xrAcquireSwapchainImageDelegate xrAcquireSwapchainImage_ptr;
		public static XrResult xrAcquireSwapchainImage(XrSwapchain swapchain, XrSwapchainImageAcquireInfo* acquireInfo, uint* index)
        {
            xrAcquireSwapchainImage_ptr ??= LoadFunction<xrAcquireSwapchainImageDelegate>("xrAcquireSwapchainImage");
            XrResult _result = xrAcquireSwapchainImage_ptr(swapchain, acquireInfo, index);
            Debug.Result(_result, "xrAcquireSwapchainImage");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrWaitSwapchainImageDelegate(XrSwapchain swapchain, XrSwapchainImageWaitInfo* waitInfo);
		private static xrWaitSwapchainImageDelegate xrWaitSwapchainImage_ptr;
		public static XrResult xrWaitSwapchainImage(XrSwapchain swapchain, XrSwapchainImageWaitInfo* waitInfo)
        {
            xrWaitSwapchainImage_ptr ??= LoadFunction<xrWaitSwapchainImageDelegate>("xrWaitSwapchainImage");
            XrResult _result = xrWaitSwapchainImage_ptr(swapchain, waitInfo);
            Debug.Result(_result, "xrWaitSwapchainImage");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrReleaseSwapchainImageDelegate(XrSwapchain swapchain, XrSwapchainImageReleaseInfo* releaseInfo);
		private static xrReleaseSwapchainImageDelegate xrReleaseSwapchainImage_ptr;
		public static XrResult xrReleaseSwapchainImage(XrSwapchain swapchain, XrSwapchainImageReleaseInfo* releaseInfo)
        {
            xrReleaseSwapchainImage_ptr ??= LoadFunction<xrReleaseSwapchainImageDelegate>("xrReleaseSwapchainImage");
            XrResult _result = xrReleaseSwapchainImage_ptr(swapchain, releaseInfo);
            Debug.Result(_result, "xrReleaseSwapchainImage");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrBeginSessionDelegate(XrSession session, XrSessionBeginInfo* beginInfo);
		private static xrBeginSessionDelegate xrBeginSession_ptr;
		public static XrResult xrBeginSession(XrSession session, XrSessionBeginInfo* beginInfo)
        {
            xrBeginSession_ptr ??= LoadFunction<xrBeginSessionDelegate>("xrBeginSession");
            XrResult _result = xrBeginSession_ptr(session, beginInfo);
            Debug.Result(_result, "xrBeginSession");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEndSessionDelegate(XrSession session);
		private static xrEndSessionDelegate xrEndSession_ptr;
		public static XrResult xrEndSession(XrSession session)
        {
            xrEndSession_ptr ??= LoadFunction<xrEndSessionDelegate>("xrEndSession");
            XrResult _result = xrEndSession_ptr(session);
            Debug.Result(_result, "xrEndSession");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestExitSessionDelegate(XrSession session);
		private static xrRequestExitSessionDelegate xrRequestExitSession_ptr;
		public static XrResult xrRequestExitSession(XrSession session)
        {
            xrRequestExitSession_ptr ??= LoadFunction<xrRequestExitSessionDelegate>("xrRequestExitSession");
            XrResult _result = xrRequestExitSession_ptr(session);
            Debug.Result(_result, "xrRequestExitSession");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrWaitFrameDelegate(XrSession session, XrFrameWaitInfo* frameWaitInfo, XrFrameState* frameState);
		private static xrWaitFrameDelegate xrWaitFrame_ptr;
		public static XrResult xrWaitFrame(XrSession session, XrFrameWaitInfo* frameWaitInfo, XrFrameState* frameState)
        {
            xrWaitFrame_ptr ??= LoadFunction<xrWaitFrameDelegate>("xrWaitFrame");
            XrResult _result = xrWaitFrame_ptr(session, frameWaitInfo, frameState);
            Debug.Result(_result, "xrWaitFrame");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrBeginFrameDelegate(XrSession session, XrFrameBeginInfo* frameBeginInfo);
		private static xrBeginFrameDelegate xrBeginFrame_ptr;
		public static XrResult xrBeginFrame(XrSession session, XrFrameBeginInfo* frameBeginInfo)
        {
            xrBeginFrame_ptr ??= LoadFunction<xrBeginFrameDelegate>("xrBeginFrame");
            XrResult _result = xrBeginFrame_ptr(session, frameBeginInfo);
            Debug.Result(_result, "xrBeginFrame");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEndFrameDelegate(XrSession session, XrFrameEndInfo* frameEndInfo);
		private static xrEndFrameDelegate xrEndFrame_ptr;
		public static XrResult xrEndFrame(XrSession session, XrFrameEndInfo* frameEndInfo)
        {
            xrEndFrame_ptr ??= LoadFunction<xrEndFrameDelegate>("xrEndFrame");
            XrResult _result = xrEndFrame_ptr(session, frameEndInfo);
            Debug.Result(_result, "xrEndFrame");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateViewsDelegate(XrSession session, XrViewLocateInfo* viewLocateInfo, XrViewState* viewState, uint viewCapacityInput, uint* viewCountOutput, XrView* views);
		private static xrLocateViewsDelegate xrLocateViews_ptr;
		public static XrResult xrLocateViews(XrSession session, XrViewLocateInfo* viewLocateInfo, XrViewState* viewState, uint viewCapacityInput, uint* viewCountOutput, XrView* views)
        {
            xrLocateViews_ptr ??= LoadFunction<xrLocateViewsDelegate>("xrLocateViews");
            XrResult _result = xrLocateViews_ptr(session, viewLocateInfo, viewState, viewCapacityInput, viewCountOutput, views);
            Debug.Result(_result, "xrLocateViews");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStringToPathDelegate(XrInstance instance, byte* pathString, ulong* path);
		private static xrStringToPathDelegate xrStringToPath_ptr;
		public static XrResult xrStringToPath(XrInstance instance, byte* pathString, ulong* path)
        {
            xrStringToPath_ptr ??= LoadFunction<xrStringToPathDelegate>("xrStringToPath");
            XrResult _result = xrStringToPath_ptr(instance, pathString, path);
            Debug.Result(_result, "xrStringToPath");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPathToStringDelegate(XrInstance instance, ulong path, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrPathToStringDelegate xrPathToString_ptr;
		public static XrResult xrPathToString(XrInstance instance, ulong path, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrPathToString_ptr ??= LoadFunction<xrPathToStringDelegate>("xrPathToString");
            XrResult _result = xrPathToString_ptr(instance, path, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrPathToString");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateActionSetDelegate(XrInstance instance, XrActionSetCreateInfo* createInfo, XrActionSet* actionSet);
		private static xrCreateActionSetDelegate xrCreateActionSet_ptr;
		public static XrResult xrCreateActionSet(XrInstance instance, XrActionSetCreateInfo* createInfo, XrActionSet* actionSet)
        {
            xrCreateActionSet_ptr ??= LoadFunction<xrCreateActionSetDelegate>("xrCreateActionSet");
            XrResult _result = xrCreateActionSet_ptr(instance, createInfo, actionSet);
            Debug.Result(_result, "xrCreateActionSet");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyActionSetDelegate(XrActionSet actionSet);
		private static xrDestroyActionSetDelegate xrDestroyActionSet_ptr;
		public static XrResult xrDestroyActionSet(XrActionSet actionSet)
        {
            xrDestroyActionSet_ptr ??= LoadFunction<xrDestroyActionSetDelegate>("xrDestroyActionSet");
            XrResult _result = xrDestroyActionSet_ptr(actionSet);
            Debug.Result(_result, "xrDestroyActionSet");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateActionDelegate(XrActionSet actionSet, XrActionCreateInfo* createInfo, XrAction* action);
		private static xrCreateActionDelegate xrCreateAction_ptr;
		public static XrResult xrCreateAction(XrActionSet actionSet, XrActionCreateInfo* createInfo, XrAction* action)
        {
            xrCreateAction_ptr ??= LoadFunction<xrCreateActionDelegate>("xrCreateAction");
            XrResult _result = xrCreateAction_ptr(actionSet, createInfo, action);
            Debug.Result(_result, "xrCreateAction");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyActionDelegate(XrAction action);
		private static xrDestroyActionDelegate xrDestroyAction_ptr;
		public static XrResult xrDestroyAction(XrAction action)
        {
            xrDestroyAction_ptr ??= LoadFunction<xrDestroyActionDelegate>("xrDestroyAction");
            XrResult _result = xrDestroyAction_ptr(action);
            Debug.Result(_result, "xrDestroyAction");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSuggestInteractionProfileBindingsDelegate(XrInstance instance, XrInteractionProfileSuggestedBinding* suggestedBindings);
		private static xrSuggestInteractionProfileBindingsDelegate xrSuggestInteractionProfileBindings_ptr;
		public static XrResult xrSuggestInteractionProfileBindings(XrInstance instance, XrInteractionProfileSuggestedBinding* suggestedBindings)
        {
            xrSuggestInteractionProfileBindings_ptr ??= LoadFunction<xrSuggestInteractionProfileBindingsDelegate>("xrSuggestInteractionProfileBindings");
            XrResult _result = xrSuggestInteractionProfileBindings_ptr(instance, suggestedBindings);
            Debug.Result(_result, "xrSuggestInteractionProfileBindings");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrAttachSessionActionSetsDelegate(XrSession session, XrSessionActionSetsAttachInfo* attachInfo);
		private static xrAttachSessionActionSetsDelegate xrAttachSessionActionSets_ptr;
		public static XrResult xrAttachSessionActionSets(XrSession session, XrSessionActionSetsAttachInfo* attachInfo)
        {
            xrAttachSessionActionSets_ptr ??= LoadFunction<xrAttachSessionActionSetsDelegate>("xrAttachSessionActionSets");
            XrResult _result = xrAttachSessionActionSets_ptr(session, attachInfo);
            Debug.Result(_result, "xrAttachSessionActionSets");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetCurrentInteractionProfileDelegate(XrSession session, ulong topLevelUserPath, XrInteractionProfileState* interactionProfile);
		private static xrGetCurrentInteractionProfileDelegate xrGetCurrentInteractionProfile_ptr;
		public static XrResult xrGetCurrentInteractionProfile(XrSession session, ulong topLevelUserPath, XrInteractionProfileState* interactionProfile)
        {
            xrGetCurrentInteractionProfile_ptr ??= LoadFunction<xrGetCurrentInteractionProfileDelegate>("xrGetCurrentInteractionProfile");
            XrResult _result = xrGetCurrentInteractionProfile_ptr(session, topLevelUserPath, interactionProfile);
            Debug.Result(_result, "xrGetCurrentInteractionProfile");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetActionStateBooleanDelegate(XrSession session, XrActionStateGetInfo* getInfo, XrActionStateBoolean* state);
		private static xrGetActionStateBooleanDelegate xrGetActionStateBoolean_ptr;
		public static XrResult xrGetActionStateBoolean(XrSession session, XrActionStateGetInfo* getInfo, XrActionStateBoolean* state)
        {
            xrGetActionStateBoolean_ptr ??= LoadFunction<xrGetActionStateBooleanDelegate>("xrGetActionStateBoolean");
            XrResult _result = xrGetActionStateBoolean_ptr(session, getInfo, state);
            Debug.Result(_result, "xrGetActionStateBoolean");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetActionStateFloatDelegate(XrSession session, XrActionStateGetInfo* getInfo, XrActionStateFloat* state);
		private static xrGetActionStateFloatDelegate xrGetActionStateFloat_ptr;
		public static XrResult xrGetActionStateFloat(XrSession session, XrActionStateGetInfo* getInfo, XrActionStateFloat* state)
        {
            xrGetActionStateFloat_ptr ??= LoadFunction<xrGetActionStateFloatDelegate>("xrGetActionStateFloat");
            XrResult _result = xrGetActionStateFloat_ptr(session, getInfo, state);
            Debug.Result(_result, "xrGetActionStateFloat");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetActionStateVector2fDelegate(XrSession session, XrActionStateGetInfo* getInfo, XrActionStateVector2f* state);
		private static xrGetActionStateVector2fDelegate xrGetActionStateVector2f_ptr;
		public static XrResult xrGetActionStateVector2f(XrSession session, XrActionStateGetInfo* getInfo, XrActionStateVector2f* state)
        {
            xrGetActionStateVector2f_ptr ??= LoadFunction<xrGetActionStateVector2fDelegate>("xrGetActionStateVector2f");
            XrResult _result = xrGetActionStateVector2f_ptr(session, getInfo, state);
            Debug.Result(_result, "xrGetActionStateVector2f");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetActionStatePoseDelegate(XrSession session, XrActionStateGetInfo* getInfo, XrActionStatePose* state);
		private static xrGetActionStatePoseDelegate xrGetActionStatePose_ptr;
		public static XrResult xrGetActionStatePose(XrSession session, XrActionStateGetInfo* getInfo, XrActionStatePose* state)
        {
            xrGetActionStatePose_ptr ??= LoadFunction<xrGetActionStatePoseDelegate>("xrGetActionStatePose");
            XrResult _result = xrGetActionStatePose_ptr(session, getInfo, state);
            Debug.Result(_result, "xrGetActionStatePose");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSyncActionsDelegate(XrSession session, XrActionsSyncInfo* syncInfo);
		private static xrSyncActionsDelegate xrSyncActions_ptr;
		public static XrResult xrSyncActions(XrSession session, XrActionsSyncInfo* syncInfo)
        {
            xrSyncActions_ptr ??= LoadFunction<xrSyncActionsDelegate>("xrSyncActions");
            XrResult _result = xrSyncActions_ptr(session, syncInfo);
            Debug.Result(_result, "xrSyncActions");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateBoundSourcesForActionDelegate(XrSession session, XrBoundSourcesForActionEnumerateInfo* enumerateInfo, uint sourceCapacityInput, uint* sourceCountOutput, ulong* sources);
		private static xrEnumerateBoundSourcesForActionDelegate xrEnumerateBoundSourcesForAction_ptr;
		public static XrResult xrEnumerateBoundSourcesForAction(XrSession session, XrBoundSourcesForActionEnumerateInfo* enumerateInfo, uint sourceCapacityInput, uint* sourceCountOutput, ulong* sources)
        {
            xrEnumerateBoundSourcesForAction_ptr ??= LoadFunction<xrEnumerateBoundSourcesForActionDelegate>("xrEnumerateBoundSourcesForAction");
            XrResult _result = xrEnumerateBoundSourcesForAction_ptr(session, enumerateInfo, sourceCapacityInput, sourceCountOutput, sources);
            Debug.Result(_result, "xrEnumerateBoundSourcesForAction");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetInputSourceLocalizedNameDelegate(XrSession session, XrInputSourceLocalizedNameGetInfo* getInfo, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetInputSourceLocalizedNameDelegate xrGetInputSourceLocalizedName_ptr;
		public static XrResult xrGetInputSourceLocalizedName(XrSession session, XrInputSourceLocalizedNameGetInfo* getInfo, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetInputSourceLocalizedName_ptr ??= LoadFunction<xrGetInputSourceLocalizedNameDelegate>("xrGetInputSourceLocalizedName");
            XrResult _result = xrGetInputSourceLocalizedName_ptr(session, getInfo, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetInputSourceLocalizedName");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrApplyHapticFeedbackDelegate(XrSession session, XrHapticActionInfo* hapticActionInfo, XrHapticBaseHeader* hapticFeedback);
		private static xrApplyHapticFeedbackDelegate xrApplyHapticFeedback_ptr;
		public static XrResult xrApplyHapticFeedback(XrSession session, XrHapticActionInfo* hapticActionInfo, XrHapticBaseHeader* hapticFeedback)
        {
            xrApplyHapticFeedback_ptr ??= LoadFunction<xrApplyHapticFeedbackDelegate>("xrApplyHapticFeedback");
            XrResult _result = xrApplyHapticFeedback_ptr(session, hapticActionInfo, hapticFeedback);
            Debug.Result(_result, "xrApplyHapticFeedback");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStopHapticFeedbackDelegate(XrSession session, XrHapticActionInfo* hapticActionInfo);
		private static xrStopHapticFeedbackDelegate xrStopHapticFeedback_ptr;
		public static XrResult xrStopHapticFeedback(XrSession session, XrHapticActionInfo* hapticActionInfo)
        {
            xrStopHapticFeedback_ptr ??= LoadFunction<xrStopHapticFeedbackDelegate>("xrStopHapticFeedback");
            XrResult _result = xrStopHapticFeedback_ptr(session, hapticActionInfo);
            Debug.Result(_result, "xrStopHapticFeedback");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateApiLayerInstanceDelegate(XrInstanceCreateInfo* info, XrApiLayerCreateInfo* layerInfo, XrInstance* instance);
		private static xrCreateApiLayerInstanceDelegate xrCreateApiLayerInstance_ptr;
		public static XrResult xrCreateApiLayerInstance(XrInstanceCreateInfo* info, XrApiLayerCreateInfo* layerInfo, XrInstance* instance)
        {
            xrCreateApiLayerInstance_ptr ??= LoadFunction<xrCreateApiLayerInstanceDelegate>("xrCreateApiLayerInstance");
            XrResult _result = xrCreateApiLayerInstance_ptr(info, layerInfo, instance);
            Debug.Result(_result, "xrCreateApiLayerInstance");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrNegotiateLoaderRuntimeInterfaceDelegate(XrNegotiateLoaderInfo* loaderInfo, XrNegotiateRuntimeRequest* runtimeRequest);
		private static xrNegotiateLoaderRuntimeInterfaceDelegate xrNegotiateLoaderRuntimeInterface_ptr;
		public static XrResult xrNegotiateLoaderRuntimeInterface(XrNegotiateLoaderInfo* loaderInfo, XrNegotiateRuntimeRequest* runtimeRequest)
        {
            xrNegotiateLoaderRuntimeInterface_ptr ??= LoadFunction<xrNegotiateLoaderRuntimeInterfaceDelegate>("xrNegotiateLoaderRuntimeInterface");
            XrResult _result = xrNegotiateLoaderRuntimeInterface_ptr(loaderInfo, runtimeRequest);
            Debug.Result(_result, "xrNegotiateLoaderRuntimeInterface");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrNegotiateLoaderApiLayerInterfaceDelegate(XrNegotiateLoaderInfo* loaderInfo, byte* layerName, XrNegotiateApiLayerRequest* apiLayerRequest);
		private static xrNegotiateLoaderApiLayerInterfaceDelegate xrNegotiateLoaderApiLayerInterface_ptr;
		public static XrResult xrNegotiateLoaderApiLayerInterface(XrNegotiateLoaderInfo* loaderInfo, byte* layerName, XrNegotiateApiLayerRequest* apiLayerRequest)
        {
            xrNegotiateLoaderApiLayerInterface_ptr ??= LoadFunction<xrNegotiateLoaderApiLayerInterfaceDelegate>("xrNegotiateLoaderApiLayerInterface");
            XrResult _result = xrNegotiateLoaderApiLayerInterface_ptr(loaderInfo, layerName, apiLayerRequest);
            Debug.Result(_result, "xrNegotiateLoaderApiLayerInterface");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateSpacesDelegate(XrSession session, XrSpacesLocateInfo* locateInfo, XrSpaceLocations* spaceLocations);
		private static xrLocateSpacesDelegate xrLocateSpaces_ptr;
		public static XrResult xrLocateSpaces(XrSession session, XrSpacesLocateInfo* locateInfo, XrSpaceLocations* spaceLocations)
        {
            xrLocateSpaces_ptr ??= LoadFunction<xrLocateSpacesDelegate>("xrLocateSpaces");
            XrResult _result = xrLocateSpaces_ptr(session, locateInfo, spaceLocations);
            Debug.Result(_result, "xrLocateSpaces");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetAndroidApplicationThreadKHRDelegate(XrSession session, XrAndroidThreadTypeKHR threadType, uint threadId);
		private static xrSetAndroidApplicationThreadKHRDelegate xrSetAndroidApplicationThreadKHR_ptr;
		public static XrResult xrSetAndroidApplicationThreadKHR(XrSession session, XrAndroidThreadTypeKHR threadType, uint threadId)
        {
            xrSetAndroidApplicationThreadKHR_ptr ??= LoadFunction<xrSetAndroidApplicationThreadKHRDelegate>("xrSetAndroidApplicationThreadKHR");
            XrResult _result = xrSetAndroidApplicationThreadKHR_ptr(session, threadType, threadId);
            Debug.Result(_result, "xrSetAndroidApplicationThreadKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSwapchainAndroidSurfaceKHRDelegate(XrSession session, XrSwapchainCreateInfo* info, XrSwapchain* swapchain, IntPtr surface);
		private static xrCreateSwapchainAndroidSurfaceKHRDelegate xrCreateSwapchainAndroidSurfaceKHR_ptr;
		public static XrResult xrCreateSwapchainAndroidSurfaceKHR(XrSession session, XrSwapchainCreateInfo* info, XrSwapchain* swapchain, IntPtr surface)
        {
            xrCreateSwapchainAndroidSurfaceKHR_ptr ??= LoadFunction<xrCreateSwapchainAndroidSurfaceKHRDelegate>("xrCreateSwapchainAndroidSurfaceKHR");
            XrResult _result = xrCreateSwapchainAndroidSurfaceKHR_ptr(session, info, swapchain, surface);
            Debug.Result(_result, "xrCreateSwapchainAndroidSurfaceKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPerfSettingsSetPerformanceLevelEXTDelegate(XrSession session, XrPerfSettingsDomainEXT domain, XrPerfSettingsLevelEXT level);
		private static xrPerfSettingsSetPerformanceLevelEXTDelegate xrPerfSettingsSetPerformanceLevelEXT_ptr;
		public static XrResult xrPerfSettingsSetPerformanceLevelEXT(XrSession session, XrPerfSettingsDomainEXT domain, XrPerfSettingsLevelEXT level)
        {
            xrPerfSettingsSetPerformanceLevelEXT_ptr ??= LoadFunction<xrPerfSettingsSetPerformanceLevelEXTDelegate>("xrPerfSettingsSetPerformanceLevelEXT");
            XrResult _result = xrPerfSettingsSetPerformanceLevelEXT_ptr(session, domain, level);
            Debug.Result(_result, "xrPerfSettingsSetPerformanceLevelEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrThermalGetTemperatureTrendEXTDelegate(XrSession session, XrPerfSettingsDomainEXT domain, XrPerfSettingsNotificationLevelEXT* notificationLevel, float* tempHeadroom, float* tempSlope);
		private static xrThermalGetTemperatureTrendEXTDelegate xrThermalGetTemperatureTrendEXT_ptr;
		public static XrResult xrThermalGetTemperatureTrendEXT(XrSession session, XrPerfSettingsDomainEXT domain, XrPerfSettingsNotificationLevelEXT* notificationLevel, float* tempHeadroom, float* tempSlope)
        {
            xrThermalGetTemperatureTrendEXT_ptr ??= LoadFunction<xrThermalGetTemperatureTrendEXTDelegate>("xrThermalGetTemperatureTrendEXT");
            XrResult _result = xrThermalGetTemperatureTrendEXT_ptr(session, domain, notificationLevel, tempHeadroom, tempSlope);
            Debug.Result(_result, "xrThermalGetTemperatureTrendEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetDebugUtilsObjectNameEXTDelegate(XrInstance instance, XrDebugUtilsObjectNameInfoEXT* nameInfo);
		private static xrSetDebugUtilsObjectNameEXTDelegate xrSetDebugUtilsObjectNameEXT_ptr;
		public static XrResult xrSetDebugUtilsObjectNameEXT(XrInstance instance, XrDebugUtilsObjectNameInfoEXT* nameInfo)
        {
            xrSetDebugUtilsObjectNameEXT_ptr ??= LoadFunction<xrSetDebugUtilsObjectNameEXTDelegate>("xrSetDebugUtilsObjectNameEXT");
            XrResult _result = xrSetDebugUtilsObjectNameEXT_ptr(instance, nameInfo);
            Debug.Result(_result, "xrSetDebugUtilsObjectNameEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateDebugUtilsMessengerEXTDelegate(XrInstance instance, XrDebugUtilsMessengerCreateInfoEXT* createInfo, XrDebugUtilsMessengerEXT* messenger);
		private static xrCreateDebugUtilsMessengerEXTDelegate xrCreateDebugUtilsMessengerEXT_ptr;
		public static XrResult xrCreateDebugUtilsMessengerEXT(XrInstance instance, XrDebugUtilsMessengerCreateInfoEXT* createInfo, XrDebugUtilsMessengerEXT* messenger)
        {
            xrCreateDebugUtilsMessengerEXT_ptr ??= LoadFunction<xrCreateDebugUtilsMessengerEXTDelegate>("xrCreateDebugUtilsMessengerEXT");
            XrResult _result = xrCreateDebugUtilsMessengerEXT_ptr(instance, createInfo, messenger);
            Debug.Result(_result, "xrCreateDebugUtilsMessengerEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyDebugUtilsMessengerEXTDelegate(XrDebugUtilsMessengerEXT messenger);
		private static xrDestroyDebugUtilsMessengerEXTDelegate xrDestroyDebugUtilsMessengerEXT_ptr;
		public static XrResult xrDestroyDebugUtilsMessengerEXT(XrDebugUtilsMessengerEXT messenger)
        {
            xrDestroyDebugUtilsMessengerEXT_ptr ??= LoadFunction<xrDestroyDebugUtilsMessengerEXTDelegate>("xrDestroyDebugUtilsMessengerEXT");
            XrResult _result = xrDestroyDebugUtilsMessengerEXT_ptr(messenger);
            Debug.Result(_result, "xrDestroyDebugUtilsMessengerEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSubmitDebugUtilsMessageEXTDelegate(XrInstance instance, ulong messageSeverity, ulong messageTypes, XrDebugUtilsMessengerCallbackDataEXT* callbackData);
		private static xrSubmitDebugUtilsMessageEXTDelegate xrSubmitDebugUtilsMessageEXT_ptr;
		public static XrResult xrSubmitDebugUtilsMessageEXT(XrInstance instance, ulong messageSeverity, ulong messageTypes, XrDebugUtilsMessengerCallbackDataEXT* callbackData)
        {
            xrSubmitDebugUtilsMessageEXT_ptr ??= LoadFunction<xrSubmitDebugUtilsMessageEXTDelegate>("xrSubmitDebugUtilsMessageEXT");
            XrResult _result = xrSubmitDebugUtilsMessageEXT_ptr(instance, messageSeverity, messageTypes, callbackData);
            Debug.Result(_result, "xrSubmitDebugUtilsMessageEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSessionBeginDebugUtilsLabelRegionEXTDelegate(XrSession session, XrDebugUtilsLabelEXT* labelInfo);
		private static xrSessionBeginDebugUtilsLabelRegionEXTDelegate xrSessionBeginDebugUtilsLabelRegionEXT_ptr;
		public static XrResult xrSessionBeginDebugUtilsLabelRegionEXT(XrSession session, XrDebugUtilsLabelEXT* labelInfo)
        {
            xrSessionBeginDebugUtilsLabelRegionEXT_ptr ??= LoadFunction<xrSessionBeginDebugUtilsLabelRegionEXTDelegate>("xrSessionBeginDebugUtilsLabelRegionEXT");
            XrResult _result = xrSessionBeginDebugUtilsLabelRegionEXT_ptr(session, labelInfo);
            Debug.Result(_result, "xrSessionBeginDebugUtilsLabelRegionEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSessionEndDebugUtilsLabelRegionEXTDelegate(XrSession session);
		private static xrSessionEndDebugUtilsLabelRegionEXTDelegate xrSessionEndDebugUtilsLabelRegionEXT_ptr;
		public static XrResult xrSessionEndDebugUtilsLabelRegionEXT(XrSession session)
        {
            xrSessionEndDebugUtilsLabelRegionEXT_ptr ??= LoadFunction<xrSessionEndDebugUtilsLabelRegionEXTDelegate>("xrSessionEndDebugUtilsLabelRegionEXT");
            XrResult _result = xrSessionEndDebugUtilsLabelRegionEXT_ptr(session);
            Debug.Result(_result, "xrSessionEndDebugUtilsLabelRegionEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSessionInsertDebugUtilsLabelEXTDelegate(XrSession session, XrDebugUtilsLabelEXT* labelInfo);
		private static xrSessionInsertDebugUtilsLabelEXTDelegate xrSessionInsertDebugUtilsLabelEXT_ptr;
		public static XrResult xrSessionInsertDebugUtilsLabelEXT(XrSession session, XrDebugUtilsLabelEXT* labelInfo)
        {
            xrSessionInsertDebugUtilsLabelEXT_ptr ??= LoadFunction<xrSessionInsertDebugUtilsLabelEXTDelegate>("xrSessionInsertDebugUtilsLabelEXT");
            XrResult _result = xrSessionInsertDebugUtilsLabelEXT_ptr(session, labelInfo);
            Debug.Result(_result, "xrSessionInsertDebugUtilsLabelEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetOpenGLGraphicsRequirementsKHRDelegate(XrInstance instance, ulong systemId, XrGraphicsRequirementsOpenGLKHR* graphicsRequirements);
		private static xrGetOpenGLGraphicsRequirementsKHRDelegate xrGetOpenGLGraphicsRequirementsKHR_ptr;
		public static XrResult xrGetOpenGLGraphicsRequirementsKHR(XrInstance instance, ulong systemId, XrGraphicsRequirementsOpenGLKHR* graphicsRequirements)
        {
            xrGetOpenGLGraphicsRequirementsKHR_ptr ??= LoadFunction<xrGetOpenGLGraphicsRequirementsKHRDelegate>("xrGetOpenGLGraphicsRequirementsKHR");
            XrResult _result = xrGetOpenGLGraphicsRequirementsKHR_ptr(instance, systemId, graphicsRequirements);
            Debug.Result(_result, "xrGetOpenGLGraphicsRequirementsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetOpenGLESGraphicsRequirementsKHRDelegate(XrInstance instance, ulong systemId, XrGraphicsRequirementsOpenGLESKHR* graphicsRequirements);
		private static xrGetOpenGLESGraphicsRequirementsKHRDelegate xrGetOpenGLESGraphicsRequirementsKHR_ptr;
		public static XrResult xrGetOpenGLESGraphicsRequirementsKHR(XrInstance instance, ulong systemId, XrGraphicsRequirementsOpenGLESKHR* graphicsRequirements)
        {
            xrGetOpenGLESGraphicsRequirementsKHR_ptr ??= LoadFunction<xrGetOpenGLESGraphicsRequirementsKHRDelegate>("xrGetOpenGLESGraphicsRequirementsKHR");
            XrResult _result = xrGetOpenGLESGraphicsRequirementsKHR_ptr(instance, systemId, graphicsRequirements);
            Debug.Result(_result, "xrGetOpenGLESGraphicsRequirementsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVulkanInstanceExtensionsKHRDelegate(XrInstance instance, ulong systemId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetVulkanInstanceExtensionsKHRDelegate xrGetVulkanInstanceExtensionsKHR_ptr;
		public static XrResult xrGetVulkanInstanceExtensionsKHR(XrInstance instance, ulong systemId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetVulkanInstanceExtensionsKHR_ptr ??= LoadFunction<xrGetVulkanInstanceExtensionsKHRDelegate>("xrGetVulkanInstanceExtensionsKHR");
            XrResult _result = xrGetVulkanInstanceExtensionsKHR_ptr(instance, systemId, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetVulkanInstanceExtensionsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVulkanDeviceExtensionsKHRDelegate(XrInstance instance, ulong systemId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetVulkanDeviceExtensionsKHRDelegate xrGetVulkanDeviceExtensionsKHR_ptr;
		public static XrResult xrGetVulkanDeviceExtensionsKHR(XrInstance instance, ulong systemId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetVulkanDeviceExtensionsKHR_ptr ??= LoadFunction<xrGetVulkanDeviceExtensionsKHRDelegate>("xrGetVulkanDeviceExtensionsKHR");
            XrResult _result = xrGetVulkanDeviceExtensionsKHR_ptr(instance, systemId, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetVulkanDeviceExtensionsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVulkanGraphicsDeviceKHRDelegate(XrInstance instance, ulong systemId, IntPtr vkInstance, IntPtr vkPhysicalDevice);
		private static xrGetVulkanGraphicsDeviceKHRDelegate xrGetVulkanGraphicsDeviceKHR_ptr;
		public static XrResult xrGetVulkanGraphicsDeviceKHR(XrInstance instance, ulong systemId, IntPtr vkInstance, IntPtr vkPhysicalDevice)
        {
            xrGetVulkanGraphicsDeviceKHR_ptr ??= LoadFunction<xrGetVulkanGraphicsDeviceKHRDelegate>("xrGetVulkanGraphicsDeviceKHR");
            XrResult _result = xrGetVulkanGraphicsDeviceKHR_ptr(instance, systemId, vkInstance, vkPhysicalDevice);
            Debug.Result(_result, "xrGetVulkanGraphicsDeviceKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVulkanGraphicsRequirementsKHRDelegate(XrInstance instance, ulong systemId, XrGraphicsRequirementsVulkanKHR* graphicsRequirements);
		private static xrGetVulkanGraphicsRequirementsKHRDelegate xrGetVulkanGraphicsRequirementsKHR_ptr;
		public static XrResult xrGetVulkanGraphicsRequirementsKHR(XrInstance instance, ulong systemId, XrGraphicsRequirementsVulkanKHR* graphicsRequirements)
        {
            xrGetVulkanGraphicsRequirementsKHR_ptr ??= LoadFunction<xrGetVulkanGraphicsRequirementsKHRDelegate>("xrGetVulkanGraphicsRequirementsKHR");
            XrResult _result = xrGetVulkanGraphicsRequirementsKHR_ptr(instance, systemId, graphicsRequirements);
            Debug.Result(_result, "xrGetVulkanGraphicsRequirementsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetD3D11GraphicsRequirementsKHRDelegate(XrInstance instance, ulong systemId, XrGraphicsRequirementsD3D11KHR* graphicsRequirements);
		private static xrGetD3D11GraphicsRequirementsKHRDelegate xrGetD3D11GraphicsRequirementsKHR_ptr;
		public static XrResult xrGetD3D11GraphicsRequirementsKHR(XrInstance instance, ulong systemId, XrGraphicsRequirementsD3D11KHR* graphicsRequirements)
        {
            xrGetD3D11GraphicsRequirementsKHR_ptr ??= LoadFunction<xrGetD3D11GraphicsRequirementsKHRDelegate>("xrGetD3D11GraphicsRequirementsKHR");
            XrResult _result = xrGetD3D11GraphicsRequirementsKHR_ptr(instance, systemId, graphicsRequirements);
            Debug.Result(_result, "xrGetD3D11GraphicsRequirementsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetD3D12GraphicsRequirementsKHRDelegate(XrInstance instance, ulong systemId, XrGraphicsRequirementsD3D12KHR* graphicsRequirements);
		private static xrGetD3D12GraphicsRequirementsKHRDelegate xrGetD3D12GraphicsRequirementsKHR_ptr;
		public static XrResult xrGetD3D12GraphicsRequirementsKHR(XrInstance instance, ulong systemId, XrGraphicsRequirementsD3D12KHR* graphicsRequirements)
        {
            xrGetD3D12GraphicsRequirementsKHR_ptr ??= LoadFunction<xrGetD3D12GraphicsRequirementsKHRDelegate>("xrGetD3D12GraphicsRequirementsKHR");
            XrResult _result = xrGetD3D12GraphicsRequirementsKHR_ptr(instance, systemId, graphicsRequirements);
            Debug.Result(_result, "xrGetD3D12GraphicsRequirementsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMetalGraphicsRequirementsKHRDelegate(XrInstance instance, ulong systemId, XrGraphicsRequirementsMetalKHR* graphicsRequirements);
		private static xrGetMetalGraphicsRequirementsKHRDelegate xrGetMetalGraphicsRequirementsKHR_ptr;
		public static XrResult xrGetMetalGraphicsRequirementsKHR(XrInstance instance, ulong systemId, XrGraphicsRequirementsMetalKHR* graphicsRequirements)
        {
            xrGetMetalGraphicsRequirementsKHR_ptr ??= LoadFunction<xrGetMetalGraphicsRequirementsKHRDelegate>("xrGetMetalGraphicsRequirementsKHR");
            XrResult _result = xrGetMetalGraphicsRequirementsKHR_ptr(instance, systemId, graphicsRequirements);
            Debug.Result(_result, "xrGetMetalGraphicsRequirementsKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVisibilityMaskKHRDelegate(XrSession session, XrViewConfigurationType viewConfigurationType, uint viewIndex, XrVisibilityMaskTypeKHR visibilityMaskType, XrVisibilityMaskKHR* visibilityMask);
		private static xrGetVisibilityMaskKHRDelegate xrGetVisibilityMaskKHR_ptr;
		public static XrResult xrGetVisibilityMaskKHR(XrSession session, XrViewConfigurationType viewConfigurationType, uint viewIndex, XrVisibilityMaskTypeKHR visibilityMaskType, XrVisibilityMaskKHR* visibilityMask)
        {
            xrGetVisibilityMaskKHR_ptr ??= LoadFunction<xrGetVisibilityMaskKHRDelegate>("xrGetVisibilityMaskKHR");
            XrResult _result = xrGetVisibilityMaskKHR_ptr(session, viewConfigurationType, viewIndex, visibilityMaskType, visibilityMask);
            Debug.Result(_result, "xrGetVisibilityMaskKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrConvertWin32PerformanceCounterToTimeKHRDelegate(XrInstance instance, IntPtr performanceCounter, long* time);
		private static xrConvertWin32PerformanceCounterToTimeKHRDelegate xrConvertWin32PerformanceCounterToTimeKHR_ptr;
		public static XrResult xrConvertWin32PerformanceCounterToTimeKHR(XrInstance instance, IntPtr performanceCounter, long* time)
        {
            xrConvertWin32PerformanceCounterToTimeKHR_ptr ??= LoadFunction<xrConvertWin32PerformanceCounterToTimeKHRDelegate>("xrConvertWin32PerformanceCounterToTimeKHR");
            XrResult _result = xrConvertWin32PerformanceCounterToTimeKHR_ptr(instance, performanceCounter, time);
            Debug.Result(_result, "xrConvertWin32PerformanceCounterToTimeKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrConvertTimeToWin32PerformanceCounterKHRDelegate(XrInstance instance, long time, IntPtr performanceCounter);
		private static xrConvertTimeToWin32PerformanceCounterKHRDelegate xrConvertTimeToWin32PerformanceCounterKHR_ptr;
		public static XrResult xrConvertTimeToWin32PerformanceCounterKHR(XrInstance instance, long time, IntPtr performanceCounter)
        {
            xrConvertTimeToWin32PerformanceCounterKHR_ptr ??= LoadFunction<xrConvertTimeToWin32PerformanceCounterKHRDelegate>("xrConvertTimeToWin32PerformanceCounterKHR");
            XrResult _result = xrConvertTimeToWin32PerformanceCounterKHR_ptr(instance, time, performanceCounter);
            Debug.Result(_result, "xrConvertTimeToWin32PerformanceCounterKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrConvertTimespecTimeToTimeKHRDelegate(XrInstance instance, IntPtr timespecTime, long* time);
		private static xrConvertTimespecTimeToTimeKHRDelegate xrConvertTimespecTimeToTimeKHR_ptr;
		public static XrResult xrConvertTimespecTimeToTimeKHR(XrInstance instance, IntPtr timespecTime, long* time)
        {
            xrConvertTimespecTimeToTimeKHR_ptr ??= LoadFunction<xrConvertTimespecTimeToTimeKHRDelegate>("xrConvertTimespecTimeToTimeKHR");
            XrResult _result = xrConvertTimespecTimeToTimeKHR_ptr(instance, timespecTime, time);
            Debug.Result(_result, "xrConvertTimespecTimeToTimeKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrConvertTimeToTimespecTimeKHRDelegate(XrInstance instance, long time, IntPtr timespecTime);
		private static xrConvertTimeToTimespecTimeKHRDelegate xrConvertTimeToTimespecTimeKHR_ptr;
		public static XrResult xrConvertTimeToTimespecTimeKHR(XrInstance instance, long time, IntPtr timespecTime)
        {
            xrConvertTimeToTimespecTimeKHR_ptr ??= LoadFunction<xrConvertTimeToTimespecTimeKHRDelegate>("xrConvertTimeToTimespecTimeKHR");
            XrResult _result = xrConvertTimeToTimespecTimeKHR_ptr(instance, time, timespecTime);
            Debug.Result(_result, "xrConvertTimeToTimespecTimeKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorMSFTDelegate(XrSession session, XrSpatialAnchorCreateInfoMSFT* createInfo, XrSpatialAnchorMSFT* anchor);
		private static xrCreateSpatialAnchorMSFTDelegate xrCreateSpatialAnchorMSFT_ptr;
		public static XrResult xrCreateSpatialAnchorMSFT(XrSession session, XrSpatialAnchorCreateInfoMSFT* createInfo, XrSpatialAnchorMSFT* anchor)
        {
            xrCreateSpatialAnchorMSFT_ptr ??= LoadFunction<xrCreateSpatialAnchorMSFTDelegate>("xrCreateSpatialAnchorMSFT");
            XrResult _result = xrCreateSpatialAnchorMSFT_ptr(session, createInfo, anchor);
            Debug.Result(_result, "xrCreateSpatialAnchorMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorSpaceMSFTDelegate(XrSession session, XrSpatialAnchorSpaceCreateInfoMSFT* createInfo, XrSpace* space);
		private static xrCreateSpatialAnchorSpaceMSFTDelegate xrCreateSpatialAnchorSpaceMSFT_ptr;
		public static XrResult xrCreateSpatialAnchorSpaceMSFT(XrSession session, XrSpatialAnchorSpaceCreateInfoMSFT* createInfo, XrSpace* space)
        {
            xrCreateSpatialAnchorSpaceMSFT_ptr ??= LoadFunction<xrCreateSpatialAnchorSpaceMSFTDelegate>("xrCreateSpatialAnchorSpaceMSFT");
            XrResult _result = xrCreateSpatialAnchorSpaceMSFT_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateSpatialAnchorSpaceMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialAnchorMSFTDelegate(XrSpatialAnchorMSFT anchor);
		private static xrDestroySpatialAnchorMSFTDelegate xrDestroySpatialAnchorMSFT_ptr;
		public static XrResult xrDestroySpatialAnchorMSFT(XrSpatialAnchorMSFT anchor)
        {
            xrDestroySpatialAnchorMSFT_ptr ??= LoadFunction<xrDestroySpatialAnchorMSFTDelegate>("xrDestroySpatialAnchorMSFT");
            XrResult _result = xrDestroySpatialAnchorMSFT_ptr(anchor);
            Debug.Result(_result, "xrDestroySpatialAnchorMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetInputDeviceActiveEXTDelegate(XrSession session, ulong interactionProfile, ulong topLevelPath, XrBool32 isActive);
		private static xrSetInputDeviceActiveEXTDelegate xrSetInputDeviceActiveEXT_ptr;
		public static XrResult xrSetInputDeviceActiveEXT(XrSession session, ulong interactionProfile, ulong topLevelPath, XrBool32 isActive)
        {
            xrSetInputDeviceActiveEXT_ptr ??= LoadFunction<xrSetInputDeviceActiveEXTDelegate>("xrSetInputDeviceActiveEXT");
            XrResult _result = xrSetInputDeviceActiveEXT_ptr(session, interactionProfile, topLevelPath, isActive);
            Debug.Result(_result, "xrSetInputDeviceActiveEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetInputDeviceStateBoolEXTDelegate(XrSession session, ulong topLevelPath, ulong inputSourcePath, XrBool32 state);
		private static xrSetInputDeviceStateBoolEXTDelegate xrSetInputDeviceStateBoolEXT_ptr;
		public static XrResult xrSetInputDeviceStateBoolEXT(XrSession session, ulong topLevelPath, ulong inputSourcePath, XrBool32 state)
        {
            xrSetInputDeviceStateBoolEXT_ptr ??= LoadFunction<xrSetInputDeviceStateBoolEXTDelegate>("xrSetInputDeviceStateBoolEXT");
            XrResult _result = xrSetInputDeviceStateBoolEXT_ptr(session, topLevelPath, inputSourcePath, state);
            Debug.Result(_result, "xrSetInputDeviceStateBoolEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetInputDeviceStateFloatEXTDelegate(XrSession session, ulong topLevelPath, ulong inputSourcePath, float state);
		private static xrSetInputDeviceStateFloatEXTDelegate xrSetInputDeviceStateFloatEXT_ptr;
		public static XrResult xrSetInputDeviceStateFloatEXT(XrSession session, ulong topLevelPath, ulong inputSourcePath, float state)
        {
            xrSetInputDeviceStateFloatEXT_ptr ??= LoadFunction<xrSetInputDeviceStateFloatEXTDelegate>("xrSetInputDeviceStateFloatEXT");
            XrResult _result = xrSetInputDeviceStateFloatEXT_ptr(session, topLevelPath, inputSourcePath, state);
            Debug.Result(_result, "xrSetInputDeviceStateFloatEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetInputDeviceStateVector2fEXTDelegate(XrSession session, ulong topLevelPath, ulong inputSourcePath, XrVector2f state);
		private static xrSetInputDeviceStateVector2fEXTDelegate xrSetInputDeviceStateVector2fEXT_ptr;
		public static XrResult xrSetInputDeviceStateVector2fEXT(XrSession session, ulong topLevelPath, ulong inputSourcePath, XrVector2f state)
        {
            xrSetInputDeviceStateVector2fEXT_ptr ??= LoadFunction<xrSetInputDeviceStateVector2fEXTDelegate>("xrSetInputDeviceStateVector2fEXT");
            XrResult _result = xrSetInputDeviceStateVector2fEXT_ptr(session, topLevelPath, inputSourcePath, state);
            Debug.Result(_result, "xrSetInputDeviceStateVector2fEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetInputDeviceLocationEXTDelegate(XrSession session, ulong topLevelPath, ulong inputSourcePath, XrSpace space, XrPosef pose);
		private static xrSetInputDeviceLocationEXTDelegate xrSetInputDeviceLocationEXT_ptr;
		public static XrResult xrSetInputDeviceLocationEXT(XrSession session, ulong topLevelPath, ulong inputSourcePath, XrSpace space, XrPosef pose)
        {
            xrSetInputDeviceLocationEXT_ptr ??= LoadFunction<xrSetInputDeviceLocationEXTDelegate>("xrSetInputDeviceLocationEXT");
            XrResult _result = xrSetInputDeviceLocationEXT_ptr(session, topLevelPath, inputSourcePath, space, pose);
            Debug.Result(_result, "xrSetInputDeviceLocationEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialGraphNodeSpaceMSFTDelegate(XrSession session, XrSpatialGraphNodeSpaceCreateInfoMSFT* createInfo, XrSpace* space);
		private static xrCreateSpatialGraphNodeSpaceMSFTDelegate xrCreateSpatialGraphNodeSpaceMSFT_ptr;
		public static XrResult xrCreateSpatialGraphNodeSpaceMSFT(XrSession session, XrSpatialGraphNodeSpaceCreateInfoMSFT* createInfo, XrSpace* space)
        {
            xrCreateSpatialGraphNodeSpaceMSFT_ptr ??= LoadFunction<xrCreateSpatialGraphNodeSpaceMSFTDelegate>("xrCreateSpatialGraphNodeSpaceMSFT");
            XrResult _result = xrCreateSpatialGraphNodeSpaceMSFT_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateSpatialGraphNodeSpaceMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTryCreateSpatialGraphStaticNodeBindingMSFTDelegate(XrSession session, XrSpatialGraphStaticNodeBindingCreateInfoMSFT* createInfo, XrSpatialGraphNodeBindingMSFT* nodeBinding);
		private static xrTryCreateSpatialGraphStaticNodeBindingMSFTDelegate xrTryCreateSpatialGraphStaticNodeBindingMSFT_ptr;
		public static XrResult xrTryCreateSpatialGraphStaticNodeBindingMSFT(XrSession session, XrSpatialGraphStaticNodeBindingCreateInfoMSFT* createInfo, XrSpatialGraphNodeBindingMSFT* nodeBinding)
        {
            xrTryCreateSpatialGraphStaticNodeBindingMSFT_ptr ??= LoadFunction<xrTryCreateSpatialGraphStaticNodeBindingMSFTDelegate>("xrTryCreateSpatialGraphStaticNodeBindingMSFT");
            XrResult _result = xrTryCreateSpatialGraphStaticNodeBindingMSFT_ptr(session, createInfo, nodeBinding);
            Debug.Result(_result, "xrTryCreateSpatialGraphStaticNodeBindingMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialGraphNodeBindingMSFTDelegate(XrSpatialGraphNodeBindingMSFT nodeBinding);
		private static xrDestroySpatialGraphNodeBindingMSFTDelegate xrDestroySpatialGraphNodeBindingMSFT_ptr;
		public static XrResult xrDestroySpatialGraphNodeBindingMSFT(XrSpatialGraphNodeBindingMSFT nodeBinding)
        {
            xrDestroySpatialGraphNodeBindingMSFT_ptr ??= LoadFunction<xrDestroySpatialGraphNodeBindingMSFTDelegate>("xrDestroySpatialGraphNodeBindingMSFT");
            XrResult _result = xrDestroySpatialGraphNodeBindingMSFT_ptr(nodeBinding);
            Debug.Result(_result, "xrDestroySpatialGraphNodeBindingMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialGraphNodeBindingPropertiesMSFTDelegate(XrSpatialGraphNodeBindingMSFT nodeBinding, XrSpatialGraphNodeBindingPropertiesGetInfoMSFT* getInfo, XrSpatialGraphNodeBindingPropertiesMSFT* properties);
		private static xrGetSpatialGraphNodeBindingPropertiesMSFTDelegate xrGetSpatialGraphNodeBindingPropertiesMSFT_ptr;
		public static XrResult xrGetSpatialGraphNodeBindingPropertiesMSFT(XrSpatialGraphNodeBindingMSFT nodeBinding, XrSpatialGraphNodeBindingPropertiesGetInfoMSFT* getInfo, XrSpatialGraphNodeBindingPropertiesMSFT* properties)
        {
            xrGetSpatialGraphNodeBindingPropertiesMSFT_ptr ??= LoadFunction<xrGetSpatialGraphNodeBindingPropertiesMSFTDelegate>("xrGetSpatialGraphNodeBindingPropertiesMSFT");
            XrResult _result = xrGetSpatialGraphNodeBindingPropertiesMSFT_ptr(nodeBinding, getInfo, properties);
            Debug.Result(_result, "xrGetSpatialGraphNodeBindingPropertiesMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateHandTrackerEXTDelegate(XrSession session, XrHandTrackerCreateInfoEXT* createInfo, XrHandTrackerEXT* handTracker);
		private static xrCreateHandTrackerEXTDelegate xrCreateHandTrackerEXT_ptr;
		public static XrResult xrCreateHandTrackerEXT(XrSession session, XrHandTrackerCreateInfoEXT* createInfo, XrHandTrackerEXT* handTracker)
        {
            xrCreateHandTrackerEXT_ptr ??= LoadFunction<xrCreateHandTrackerEXTDelegate>("xrCreateHandTrackerEXT");
            XrResult _result = xrCreateHandTrackerEXT_ptr(session, createInfo, handTracker);
            Debug.Result(_result, "xrCreateHandTrackerEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyHandTrackerEXTDelegate(XrHandTrackerEXT handTracker);
		private static xrDestroyHandTrackerEXTDelegate xrDestroyHandTrackerEXT_ptr;
		public static XrResult xrDestroyHandTrackerEXT(XrHandTrackerEXT handTracker)
        {
            xrDestroyHandTrackerEXT_ptr ??= LoadFunction<xrDestroyHandTrackerEXTDelegate>("xrDestroyHandTrackerEXT");
            XrResult _result = xrDestroyHandTrackerEXT_ptr(handTracker);
            Debug.Result(_result, "xrDestroyHandTrackerEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateHandJointsEXTDelegate(XrHandTrackerEXT handTracker, XrHandJointsLocateInfoEXT* locateInfo, XrHandJointLocationsEXT* locations);
		private static xrLocateHandJointsEXTDelegate xrLocateHandJointsEXT_ptr;
		public static XrResult xrLocateHandJointsEXT(XrHandTrackerEXT handTracker, XrHandJointsLocateInfoEXT* locateInfo, XrHandJointLocationsEXT* locations)
        {
            xrLocateHandJointsEXT_ptr ??= LoadFunction<xrLocateHandJointsEXTDelegate>("xrLocateHandJointsEXT");
            XrResult _result = xrLocateHandJointsEXT_ptr(handTracker, locateInfo, locations);
            Debug.Result(_result, "xrLocateHandJointsEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateHandMeshSpaceMSFTDelegate(XrHandTrackerEXT handTracker, XrHandMeshSpaceCreateInfoMSFT* createInfo, XrSpace* space);
		private static xrCreateHandMeshSpaceMSFTDelegate xrCreateHandMeshSpaceMSFT_ptr;
		public static XrResult xrCreateHandMeshSpaceMSFT(XrHandTrackerEXT handTracker, XrHandMeshSpaceCreateInfoMSFT* createInfo, XrSpace* space)
        {
            xrCreateHandMeshSpaceMSFT_ptr ??= LoadFunction<xrCreateHandMeshSpaceMSFTDelegate>("xrCreateHandMeshSpaceMSFT");
            XrResult _result = xrCreateHandMeshSpaceMSFT_ptr(handTracker, createInfo, space);
            Debug.Result(_result, "xrCreateHandMeshSpaceMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUpdateHandMeshMSFTDelegate(XrHandTrackerEXT handTracker, XrHandMeshUpdateInfoMSFT* updateInfo, XrHandMeshMSFT* handMesh);
		private static xrUpdateHandMeshMSFTDelegate xrUpdateHandMeshMSFT_ptr;
		public static XrResult xrUpdateHandMeshMSFT(XrHandTrackerEXT handTracker, XrHandMeshUpdateInfoMSFT* updateInfo, XrHandMeshMSFT* handMesh)
        {
            xrUpdateHandMeshMSFT_ptr ??= LoadFunction<xrUpdateHandMeshMSFTDelegate>("xrUpdateHandMeshMSFT");
            XrResult _result = xrUpdateHandMeshMSFT_ptr(handTracker, updateInfo, handMesh);
            Debug.Result(_result, "xrUpdateHandMeshMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetControllerModelKeyMSFTDelegate(XrSession session, ulong topLevelUserPath, XrControllerModelKeyStateMSFT* controllerModelKeyState);
		private static xrGetControllerModelKeyMSFTDelegate xrGetControllerModelKeyMSFT_ptr;
		public static XrResult xrGetControllerModelKeyMSFT(XrSession session, ulong topLevelUserPath, XrControllerModelKeyStateMSFT* controllerModelKeyState)
        {
            xrGetControllerModelKeyMSFT_ptr ??= LoadFunction<xrGetControllerModelKeyMSFTDelegate>("xrGetControllerModelKeyMSFT");
            XrResult _result = xrGetControllerModelKeyMSFT_ptr(session, topLevelUserPath, controllerModelKeyState);
            Debug.Result(_result, "xrGetControllerModelKeyMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLoadControllerModelMSFTDelegate(XrSession session, ulong modelKey, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrLoadControllerModelMSFTDelegate xrLoadControllerModelMSFT_ptr;
		public static XrResult xrLoadControllerModelMSFT(XrSession session, ulong modelKey, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrLoadControllerModelMSFT_ptr ??= LoadFunction<xrLoadControllerModelMSFTDelegate>("xrLoadControllerModelMSFT");
            XrResult _result = xrLoadControllerModelMSFT_ptr(session, modelKey, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrLoadControllerModelMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetControllerModelPropertiesMSFTDelegate(XrSession session, ulong modelKey, XrControllerModelPropertiesMSFT* properties);
		private static xrGetControllerModelPropertiesMSFTDelegate xrGetControllerModelPropertiesMSFT_ptr;
		public static XrResult xrGetControllerModelPropertiesMSFT(XrSession session, ulong modelKey, XrControllerModelPropertiesMSFT* properties)
        {
            xrGetControllerModelPropertiesMSFT_ptr ??= LoadFunction<xrGetControllerModelPropertiesMSFTDelegate>("xrGetControllerModelPropertiesMSFT");
            XrResult _result = xrGetControllerModelPropertiesMSFT_ptr(session, modelKey, properties);
            Debug.Result(_result, "xrGetControllerModelPropertiesMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetControllerModelStateMSFTDelegate(XrSession session, ulong modelKey, XrControllerModelStateMSFT* state);
		private static xrGetControllerModelStateMSFTDelegate xrGetControllerModelStateMSFT_ptr;
		public static XrResult xrGetControllerModelStateMSFT(XrSession session, ulong modelKey, XrControllerModelStateMSFT* state)
        {
            xrGetControllerModelStateMSFT_ptr ??= LoadFunction<xrGetControllerModelStateMSFTDelegate>("xrGetControllerModelStateMSFT");
            XrResult _result = xrGetControllerModelStateMSFT_ptr(session, modelKey, state);
            Debug.Result(_result, "xrGetControllerModelStateMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorFromPerceptionAnchorMSFTDelegate(XrSession session, IntPtr perceptionAnchor, XrSpatialAnchorMSFT* anchor);
		private static xrCreateSpatialAnchorFromPerceptionAnchorMSFTDelegate xrCreateSpatialAnchorFromPerceptionAnchorMSFT_ptr;
		public static XrResult xrCreateSpatialAnchorFromPerceptionAnchorMSFT(XrSession session, IntPtr perceptionAnchor, XrSpatialAnchorMSFT* anchor)
        {
            xrCreateSpatialAnchorFromPerceptionAnchorMSFT_ptr ??= LoadFunction<xrCreateSpatialAnchorFromPerceptionAnchorMSFTDelegate>("xrCreateSpatialAnchorFromPerceptionAnchorMSFT");
            XrResult _result = xrCreateSpatialAnchorFromPerceptionAnchorMSFT_ptr(session, perceptionAnchor, anchor);
            Debug.Result(_result, "xrCreateSpatialAnchorFromPerceptionAnchorMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTryGetPerceptionAnchorFromSpatialAnchorMSFTDelegate(XrSession session, XrSpatialAnchorMSFT anchor, IntPtr perceptionAnchor);
		private static xrTryGetPerceptionAnchorFromSpatialAnchorMSFTDelegate xrTryGetPerceptionAnchorFromSpatialAnchorMSFT_ptr;
		public static XrResult xrTryGetPerceptionAnchorFromSpatialAnchorMSFT(XrSession session, XrSpatialAnchorMSFT anchor, IntPtr perceptionAnchor)
        {
            xrTryGetPerceptionAnchorFromSpatialAnchorMSFT_ptr ??= LoadFunction<xrTryGetPerceptionAnchorFromSpatialAnchorMSFTDelegate>("xrTryGetPerceptionAnchorFromSpatialAnchorMSFT");
            XrResult _result = xrTryGetPerceptionAnchorFromSpatialAnchorMSFT_ptr(session, anchor, perceptionAnchor);
            Debug.Result(_result, "xrTryGetPerceptionAnchorFromSpatialAnchorMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateReprojectionModesMSFTDelegate(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint modeCapacityInput, uint* modeCountOutput, XrReprojectionModeMSFT* modes);
		private static xrEnumerateReprojectionModesMSFTDelegate xrEnumerateReprojectionModesMSFT_ptr;
		public static XrResult xrEnumerateReprojectionModesMSFT(XrInstance instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint modeCapacityInput, uint* modeCountOutput, XrReprojectionModeMSFT* modes)
        {
            xrEnumerateReprojectionModesMSFT_ptr ??= LoadFunction<xrEnumerateReprojectionModesMSFTDelegate>("xrEnumerateReprojectionModesMSFT");
            XrResult _result = xrEnumerateReprojectionModesMSFT_ptr(instance, systemId, viewConfigurationType, modeCapacityInput, modeCountOutput, modes);
            Debug.Result(_result, "xrEnumerateReprojectionModesMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUpdateSwapchainFBDelegate(XrSwapchain swapchain, XrSwapchainStateBaseHeaderFB* state);
		private static xrUpdateSwapchainFBDelegate xrUpdateSwapchainFB_ptr;
		public static XrResult xrUpdateSwapchainFB(XrSwapchain swapchain, XrSwapchainStateBaseHeaderFB* state)
        {
            xrUpdateSwapchainFB_ptr ??= LoadFunction<xrUpdateSwapchainFBDelegate>("xrUpdateSwapchainFB");
            XrResult _result = xrUpdateSwapchainFB_ptr(swapchain, state);
            Debug.Result(_result, "xrUpdateSwapchainFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSwapchainStateFBDelegate(XrSwapchain swapchain, XrSwapchainStateBaseHeaderFB* state);
		private static xrGetSwapchainStateFBDelegate xrGetSwapchainStateFB_ptr;
		public static XrResult xrGetSwapchainStateFB(XrSwapchain swapchain, XrSwapchainStateBaseHeaderFB* state)
        {
            xrGetSwapchainStateFB_ptr ??= LoadFunction<xrGetSwapchainStateFBDelegate>("xrGetSwapchainStateFB");
            XrResult _result = xrGetSwapchainStateFB_ptr(swapchain, state);
            Debug.Result(_result, "xrGetSwapchainStateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateBodyTrackerFBDelegate(XrSession session, XrBodyTrackerCreateInfoFB* createInfo, XrBodyTrackerFB* bodyTracker);
		private static xrCreateBodyTrackerFBDelegate xrCreateBodyTrackerFB_ptr;
		public static XrResult xrCreateBodyTrackerFB(XrSession session, XrBodyTrackerCreateInfoFB* createInfo, XrBodyTrackerFB* bodyTracker)
        {
            xrCreateBodyTrackerFB_ptr ??= LoadFunction<xrCreateBodyTrackerFBDelegate>("xrCreateBodyTrackerFB");
            XrResult _result = xrCreateBodyTrackerFB_ptr(session, createInfo, bodyTracker);
            Debug.Result(_result, "xrCreateBodyTrackerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyBodyTrackerFBDelegate(XrBodyTrackerFB bodyTracker);
		private static xrDestroyBodyTrackerFBDelegate xrDestroyBodyTrackerFB_ptr;
		public static XrResult xrDestroyBodyTrackerFB(XrBodyTrackerFB bodyTracker)
        {
            xrDestroyBodyTrackerFB_ptr ??= LoadFunction<xrDestroyBodyTrackerFBDelegate>("xrDestroyBodyTrackerFB");
            XrResult _result = xrDestroyBodyTrackerFB_ptr(bodyTracker);
            Debug.Result(_result, "xrDestroyBodyTrackerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateBodyJointsFBDelegate(XrBodyTrackerFB bodyTracker, XrBodyJointsLocateInfoFB* locateInfo, XrBodyJointLocationsFB* locations);
		private static xrLocateBodyJointsFBDelegate xrLocateBodyJointsFB_ptr;
		public static XrResult xrLocateBodyJointsFB(XrBodyTrackerFB bodyTracker, XrBodyJointsLocateInfoFB* locateInfo, XrBodyJointLocationsFB* locations)
        {
            xrLocateBodyJointsFB_ptr ??= LoadFunction<xrLocateBodyJointsFBDelegate>("xrLocateBodyJointsFB");
            XrResult _result = xrLocateBodyJointsFB_ptr(bodyTracker, locateInfo, locations);
            Debug.Result(_result, "xrLocateBodyJointsFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetBodySkeletonFBDelegate(XrBodyTrackerFB bodyTracker, XrBodySkeletonFB* skeleton);
		private static xrGetBodySkeletonFBDelegate xrGetBodySkeletonFB_ptr;
		public static XrResult xrGetBodySkeletonFB(XrBodyTrackerFB bodyTracker, XrBodySkeletonFB* skeleton)
        {
            xrGetBodySkeletonFB_ptr ??= LoadFunction<xrGetBodySkeletonFBDelegate>("xrGetBodySkeletonFB");
            XrResult _result = xrGetBodySkeletonFB_ptr(bodyTracker, skeleton);
            Debug.Result(_result, "xrGetBodySkeletonFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrInitializeLoaderKHRDelegate(XrLoaderInitInfoBaseHeaderKHR* loaderInitInfo);
		private static xrInitializeLoaderKHRDelegate xrInitializeLoaderKHR_ptr;
		public static XrResult xrInitializeLoaderKHR(XrLoaderInitInfoBaseHeaderKHR* loaderInitInfo)
        {
            xrInitializeLoaderKHR_ptr ??= LoadFunction<xrInitializeLoaderKHRDelegate>("xrInitializeLoaderKHR");
            XrResult _result = xrInitializeLoaderKHR_ptr(loaderInitInfo);
            Debug.Result(_result, "xrInitializeLoaderKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateVulkanInstanceKHRDelegate(XrInstance instance, XrVulkanInstanceCreateInfoKHR* createInfo, IntPtr vulkanInstance, IntPtr vulkanResult);
		private static xrCreateVulkanInstanceKHRDelegate xrCreateVulkanInstanceKHR_ptr;
		public static XrResult xrCreateVulkanInstanceKHR(XrInstance instance, XrVulkanInstanceCreateInfoKHR* createInfo, IntPtr vulkanInstance, IntPtr vulkanResult)
        {
            xrCreateVulkanInstanceKHR_ptr ??= LoadFunction<xrCreateVulkanInstanceKHRDelegate>("xrCreateVulkanInstanceKHR");
            XrResult _result = xrCreateVulkanInstanceKHR_ptr(instance, createInfo, vulkanInstance, vulkanResult);
            Debug.Result(_result, "xrCreateVulkanInstanceKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateVulkanDeviceKHRDelegate(XrInstance instance, XrVulkanDeviceCreateInfoKHR* createInfo, IntPtr vulkanDevice, IntPtr vulkanResult);
		private static xrCreateVulkanDeviceKHRDelegate xrCreateVulkanDeviceKHR_ptr;
		public static XrResult xrCreateVulkanDeviceKHR(XrInstance instance, XrVulkanDeviceCreateInfoKHR* createInfo, IntPtr vulkanDevice, IntPtr vulkanResult)
        {
            xrCreateVulkanDeviceKHR_ptr ??= LoadFunction<xrCreateVulkanDeviceKHRDelegate>("xrCreateVulkanDeviceKHR");
            XrResult _result = xrCreateVulkanDeviceKHR_ptr(instance, createInfo, vulkanDevice, vulkanResult);
            Debug.Result(_result, "xrCreateVulkanDeviceKHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVulkanGraphicsDevice2KHRDelegate(XrInstance instance, XrVulkanGraphicsDeviceGetInfoKHR* getInfo, IntPtr vulkanPhysicalDevice);
		private static xrGetVulkanGraphicsDevice2KHRDelegate xrGetVulkanGraphicsDevice2KHR_ptr;
		public static XrResult xrGetVulkanGraphicsDevice2KHR(XrInstance instance, XrVulkanGraphicsDeviceGetInfoKHR* getInfo, IntPtr vulkanPhysicalDevice)
        {
            xrGetVulkanGraphicsDevice2KHR_ptr ??= LoadFunction<xrGetVulkanGraphicsDevice2KHRDelegate>("xrGetVulkanGraphicsDevice2KHR");
            XrResult _result = xrGetVulkanGraphicsDevice2KHR_ptr(instance, getInfo, vulkanPhysicalDevice);
            Debug.Result(_result, "xrGetVulkanGraphicsDevice2KHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSceneComputeFeaturesMSFTDelegate(XrInstance instance, ulong systemId, uint featureCapacityInput, uint* featureCountOutput, XrSceneComputeFeatureMSFT* features);
		private static xrEnumerateSceneComputeFeaturesMSFTDelegate xrEnumerateSceneComputeFeaturesMSFT_ptr;
		public static XrResult xrEnumerateSceneComputeFeaturesMSFT(XrInstance instance, ulong systemId, uint featureCapacityInput, uint* featureCountOutput, XrSceneComputeFeatureMSFT* features)
        {
            xrEnumerateSceneComputeFeaturesMSFT_ptr ??= LoadFunction<xrEnumerateSceneComputeFeaturesMSFTDelegate>("xrEnumerateSceneComputeFeaturesMSFT");
            XrResult _result = xrEnumerateSceneComputeFeaturesMSFT_ptr(instance, systemId, featureCapacityInput, featureCountOutput, features);
            Debug.Result(_result, "xrEnumerateSceneComputeFeaturesMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSceneObserverMSFTDelegate(XrSession session, XrSceneObserverCreateInfoMSFT* createInfo, XrSceneObserverMSFT* sceneObserver);
		private static xrCreateSceneObserverMSFTDelegate xrCreateSceneObserverMSFT_ptr;
		public static XrResult xrCreateSceneObserverMSFT(XrSession session, XrSceneObserverCreateInfoMSFT* createInfo, XrSceneObserverMSFT* sceneObserver)
        {
            xrCreateSceneObserverMSFT_ptr ??= LoadFunction<xrCreateSceneObserverMSFTDelegate>("xrCreateSceneObserverMSFT");
            XrResult _result = xrCreateSceneObserverMSFT_ptr(session, createInfo, sceneObserver);
            Debug.Result(_result, "xrCreateSceneObserverMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySceneObserverMSFTDelegate(XrSceneObserverMSFT sceneObserver);
		private static xrDestroySceneObserverMSFTDelegate xrDestroySceneObserverMSFT_ptr;
		public static XrResult xrDestroySceneObserverMSFT(XrSceneObserverMSFT sceneObserver)
        {
            xrDestroySceneObserverMSFT_ptr ??= LoadFunction<xrDestroySceneObserverMSFTDelegate>("xrDestroySceneObserverMSFT");
            XrResult _result = xrDestroySceneObserverMSFT_ptr(sceneObserver);
            Debug.Result(_result, "xrDestroySceneObserverMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSceneMSFTDelegate(XrSceneObserverMSFT sceneObserver, XrSceneCreateInfoMSFT* createInfo, XrSceneMSFT* scene);
		private static xrCreateSceneMSFTDelegate xrCreateSceneMSFT_ptr;
		public static XrResult xrCreateSceneMSFT(XrSceneObserverMSFT sceneObserver, XrSceneCreateInfoMSFT* createInfo, XrSceneMSFT* scene)
        {
            xrCreateSceneMSFT_ptr ??= LoadFunction<xrCreateSceneMSFTDelegate>("xrCreateSceneMSFT");
            XrResult _result = xrCreateSceneMSFT_ptr(sceneObserver, createInfo, scene);
            Debug.Result(_result, "xrCreateSceneMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySceneMSFTDelegate(XrSceneMSFT scene);
		private static xrDestroySceneMSFTDelegate xrDestroySceneMSFT_ptr;
		public static XrResult xrDestroySceneMSFT(XrSceneMSFT scene)
        {
            xrDestroySceneMSFT_ptr ??= LoadFunction<xrDestroySceneMSFTDelegate>("xrDestroySceneMSFT");
            XrResult _result = xrDestroySceneMSFT_ptr(scene);
            Debug.Result(_result, "xrDestroySceneMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrComputeNewSceneMSFTDelegate(XrSceneObserverMSFT sceneObserver, XrNewSceneComputeInfoMSFT* computeInfo);
		private static xrComputeNewSceneMSFTDelegate xrComputeNewSceneMSFT_ptr;
		public static XrResult xrComputeNewSceneMSFT(XrSceneObserverMSFT sceneObserver, XrNewSceneComputeInfoMSFT* computeInfo)
        {
            xrComputeNewSceneMSFT_ptr ??= LoadFunction<xrComputeNewSceneMSFTDelegate>("xrComputeNewSceneMSFT");
            XrResult _result = xrComputeNewSceneMSFT_ptr(sceneObserver, computeInfo);
            Debug.Result(_result, "xrComputeNewSceneMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSceneComputeStateMSFTDelegate(XrSceneObserverMSFT sceneObserver, XrSceneComputeStateMSFT* state);
		private static xrGetSceneComputeStateMSFTDelegate xrGetSceneComputeStateMSFT_ptr;
		public static XrResult xrGetSceneComputeStateMSFT(XrSceneObserverMSFT sceneObserver, XrSceneComputeStateMSFT* state)
        {
            xrGetSceneComputeStateMSFT_ptr ??= LoadFunction<xrGetSceneComputeStateMSFTDelegate>("xrGetSceneComputeStateMSFT");
            XrResult _result = xrGetSceneComputeStateMSFT_ptr(sceneObserver, state);
            Debug.Result(_result, "xrGetSceneComputeStateMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSceneComponentsMSFTDelegate(XrSceneMSFT scene, XrSceneComponentsGetInfoMSFT* getInfo, XrSceneComponentsMSFT* components);
		private static xrGetSceneComponentsMSFTDelegate xrGetSceneComponentsMSFT_ptr;
		public static XrResult xrGetSceneComponentsMSFT(XrSceneMSFT scene, XrSceneComponentsGetInfoMSFT* getInfo, XrSceneComponentsMSFT* components)
        {
            xrGetSceneComponentsMSFT_ptr ??= LoadFunction<xrGetSceneComponentsMSFTDelegate>("xrGetSceneComponentsMSFT");
            XrResult _result = xrGetSceneComponentsMSFT_ptr(scene, getInfo, components);
            Debug.Result(_result, "xrGetSceneComponentsMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateSceneComponentsMSFTDelegate(XrSceneMSFT scene, XrSceneComponentsLocateInfoMSFT* locateInfo, XrSceneComponentLocationsMSFT* locations);
		private static xrLocateSceneComponentsMSFTDelegate xrLocateSceneComponentsMSFT_ptr;
		public static XrResult xrLocateSceneComponentsMSFT(XrSceneMSFT scene, XrSceneComponentsLocateInfoMSFT* locateInfo, XrSceneComponentLocationsMSFT* locations)
        {
            xrLocateSceneComponentsMSFT_ptr ??= LoadFunction<xrLocateSceneComponentsMSFTDelegate>("xrLocateSceneComponentsMSFT");
            XrResult _result = xrLocateSceneComponentsMSFT_ptr(scene, locateInfo, locations);
            Debug.Result(_result, "xrLocateSceneComponentsMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSceneMeshBuffersMSFTDelegate(XrSceneMSFT scene, XrSceneMeshBuffersGetInfoMSFT* getInfo, XrSceneMeshBuffersMSFT* buffers);
		private static xrGetSceneMeshBuffersMSFTDelegate xrGetSceneMeshBuffersMSFT_ptr;
		public static XrResult xrGetSceneMeshBuffersMSFT(XrSceneMSFT scene, XrSceneMeshBuffersGetInfoMSFT* getInfo, XrSceneMeshBuffersMSFT* buffers)
        {
            xrGetSceneMeshBuffersMSFT_ptr ??= LoadFunction<xrGetSceneMeshBuffersMSFTDelegate>("xrGetSceneMeshBuffersMSFT");
            XrResult _result = xrGetSceneMeshBuffersMSFT_ptr(scene, getInfo, buffers);
            Debug.Result(_result, "xrGetSceneMeshBuffersMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDeserializeSceneMSFTDelegate(XrSceneObserverMSFT sceneObserver, XrSceneDeserializeInfoMSFT* deserializeInfo);
		private static xrDeserializeSceneMSFTDelegate xrDeserializeSceneMSFT_ptr;
		public static XrResult xrDeserializeSceneMSFT(XrSceneObserverMSFT sceneObserver, XrSceneDeserializeInfoMSFT* deserializeInfo)
        {
            xrDeserializeSceneMSFT_ptr ??= LoadFunction<xrDeserializeSceneMSFTDelegate>("xrDeserializeSceneMSFT");
            XrResult _result = xrDeserializeSceneMSFT_ptr(sceneObserver, deserializeInfo);
            Debug.Result(_result, "xrDeserializeSceneMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSerializedSceneFragmentDataMSFTDelegate(XrSceneMSFT scene, XrSerializedSceneFragmentDataGetInfoMSFT* getInfo, uint countInput, uint* readOutput, byte* buffer);
		private static xrGetSerializedSceneFragmentDataMSFTDelegate xrGetSerializedSceneFragmentDataMSFT_ptr;
		public static XrResult xrGetSerializedSceneFragmentDataMSFT(XrSceneMSFT scene, XrSerializedSceneFragmentDataGetInfoMSFT* getInfo, uint countInput, uint* readOutput, byte* buffer)
        {
            xrGetSerializedSceneFragmentDataMSFT_ptr ??= LoadFunction<xrGetSerializedSceneFragmentDataMSFTDelegate>("xrGetSerializedSceneFragmentDataMSFT");
            XrResult _result = xrGetSerializedSceneFragmentDataMSFT_ptr(scene, getInfo, countInput, readOutput, buffer);
            Debug.Result(_result, "xrGetSerializedSceneFragmentDataMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateDisplayRefreshRatesFBDelegate(XrSession session, uint displayRefreshRateCapacityInput, uint* displayRefreshRateCountOutput, float* displayRefreshRates);
		private static xrEnumerateDisplayRefreshRatesFBDelegate xrEnumerateDisplayRefreshRatesFB_ptr;
		public static XrResult xrEnumerateDisplayRefreshRatesFB(XrSession session, uint displayRefreshRateCapacityInput, uint* displayRefreshRateCountOutput, float* displayRefreshRates)
        {
            xrEnumerateDisplayRefreshRatesFB_ptr ??= LoadFunction<xrEnumerateDisplayRefreshRatesFBDelegate>("xrEnumerateDisplayRefreshRatesFB");
            XrResult _result = xrEnumerateDisplayRefreshRatesFB_ptr(session, displayRefreshRateCapacityInput, displayRefreshRateCountOutput, displayRefreshRates);
            Debug.Result(_result, "xrEnumerateDisplayRefreshRatesFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetDisplayRefreshRateFBDelegate(XrSession session, float* displayRefreshRate);
		private static xrGetDisplayRefreshRateFBDelegate xrGetDisplayRefreshRateFB_ptr;
		public static XrResult xrGetDisplayRefreshRateFB(XrSession session, float* displayRefreshRate)
        {
            xrGetDisplayRefreshRateFB_ptr ??= LoadFunction<xrGetDisplayRefreshRateFBDelegate>("xrGetDisplayRefreshRateFB");
            XrResult _result = xrGetDisplayRefreshRateFB_ptr(session, displayRefreshRate);
            Debug.Result(_result, "xrGetDisplayRefreshRateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestDisplayRefreshRateFBDelegate(XrSession session, float displayRefreshRate);
		private static xrRequestDisplayRefreshRateFBDelegate xrRequestDisplayRefreshRateFB_ptr;
		public static XrResult xrRequestDisplayRefreshRateFB(XrSession session, float displayRefreshRate)
        {
            xrRequestDisplayRefreshRateFB_ptr ??= LoadFunction<xrRequestDisplayRefreshRateFBDelegate>("xrRequestDisplayRefreshRateFB");
            XrResult _result = xrRequestDisplayRefreshRateFB_ptr(session, displayRefreshRate);
            Debug.Result(_result, "xrRequestDisplayRefreshRateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateViveTrackerPathsHTCXDelegate(XrInstance instance, uint pathCapacityInput, uint* pathCountOutput, XrViveTrackerPathsHTCX* paths);
		private static xrEnumerateViveTrackerPathsHTCXDelegate xrEnumerateViveTrackerPathsHTCX_ptr;
		public static XrResult xrEnumerateViveTrackerPathsHTCX(XrInstance instance, uint pathCapacityInput, uint* pathCountOutput, XrViveTrackerPathsHTCX* paths)
        {
            xrEnumerateViveTrackerPathsHTCX_ptr ??= LoadFunction<xrEnumerateViveTrackerPathsHTCXDelegate>("xrEnumerateViveTrackerPathsHTCX");
            XrResult _result = xrEnumerateViveTrackerPathsHTCX_ptr(instance, pathCapacityInput, pathCountOutput, paths);
            Debug.Result(_result, "xrEnumerateViveTrackerPathsHTCX");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateFacialTrackerHTCDelegate(XrSession session, XrFacialTrackerCreateInfoHTC* createInfo, XrFacialTrackerHTC* facialTracker);
		private static xrCreateFacialTrackerHTCDelegate xrCreateFacialTrackerHTC_ptr;
		public static XrResult xrCreateFacialTrackerHTC(XrSession session, XrFacialTrackerCreateInfoHTC* createInfo, XrFacialTrackerHTC* facialTracker)
        {
            xrCreateFacialTrackerHTC_ptr ??= LoadFunction<xrCreateFacialTrackerHTCDelegate>("xrCreateFacialTrackerHTC");
            XrResult _result = xrCreateFacialTrackerHTC_ptr(session, createInfo, facialTracker);
            Debug.Result(_result, "xrCreateFacialTrackerHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyFacialTrackerHTCDelegate(XrFacialTrackerHTC facialTracker);
		private static xrDestroyFacialTrackerHTCDelegate xrDestroyFacialTrackerHTC_ptr;
		public static XrResult xrDestroyFacialTrackerHTC(XrFacialTrackerHTC facialTracker)
        {
            xrDestroyFacialTrackerHTC_ptr ??= LoadFunction<xrDestroyFacialTrackerHTCDelegate>("xrDestroyFacialTrackerHTC");
            XrResult _result = xrDestroyFacialTrackerHTC_ptr(facialTracker);
            Debug.Result(_result, "xrDestroyFacialTrackerHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetFacialExpressionsHTCDelegate(XrFacialTrackerHTC facialTracker, XrFacialExpressionsHTC* facialExpressions);
		private static xrGetFacialExpressionsHTCDelegate xrGetFacialExpressionsHTC_ptr;
		public static XrResult xrGetFacialExpressionsHTC(XrFacialTrackerHTC facialTracker, XrFacialExpressionsHTC* facialExpressions)
        {
            xrGetFacialExpressionsHTC_ptr ??= LoadFunction<xrGetFacialExpressionsHTCDelegate>("xrGetFacialExpressionsHTC");
            XrResult _result = xrGetFacialExpressionsHTC_ptr(facialTracker, facialExpressions);
            Debug.Result(_result, "xrGetFacialExpressionsHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateColorSpacesFBDelegate(XrSession session, uint colorSpaceCapacityInput, uint* colorSpaceCountOutput, XrColorSpaceFB* colorSpaces);
		private static xrEnumerateColorSpacesFBDelegate xrEnumerateColorSpacesFB_ptr;
		public static XrResult xrEnumerateColorSpacesFB(XrSession session, uint colorSpaceCapacityInput, uint* colorSpaceCountOutput, XrColorSpaceFB* colorSpaces)
        {
            xrEnumerateColorSpacesFB_ptr ??= LoadFunction<xrEnumerateColorSpacesFBDelegate>("xrEnumerateColorSpacesFB");
            XrResult _result = xrEnumerateColorSpacesFB_ptr(session, colorSpaceCapacityInput, colorSpaceCountOutput, colorSpaces);
            Debug.Result(_result, "xrEnumerateColorSpacesFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetColorSpaceFBDelegate(XrSession session, XrColorSpaceFB colorSpace);
		private static xrSetColorSpaceFBDelegate xrSetColorSpaceFB_ptr;
		public static XrResult xrSetColorSpaceFB(XrSession session, XrColorSpaceFB colorSpace)
        {
            xrSetColorSpaceFB_ptr ??= LoadFunction<xrSetColorSpaceFBDelegate>("xrSetColorSpaceFB");
            XrResult _result = xrSetColorSpaceFB_ptr(session, colorSpace);
            Debug.Result(_result, "xrSetColorSpaceFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetHandMeshFBDelegate(XrHandTrackerEXT handTracker, XrHandTrackingMeshFB* mesh);
		private static xrGetHandMeshFBDelegate xrGetHandMeshFB_ptr;
		public static XrResult xrGetHandMeshFB(XrHandTrackerEXT handTracker, XrHandTrackingMeshFB* mesh)
        {
            xrGetHandMeshFB_ptr ??= LoadFunction<xrGetHandMeshFBDelegate>("xrGetHandMeshFB");
            XrResult _result = xrGetHandMeshFB_ptr(handTracker, mesh);
            Debug.Result(_result, "xrGetHandMeshFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorFBDelegate(XrSession session, XrSpatialAnchorCreateInfoFB* info, ulong* requestId);
		private static xrCreateSpatialAnchorFBDelegate xrCreateSpatialAnchorFB_ptr;
		public static XrResult xrCreateSpatialAnchorFB(XrSession session, XrSpatialAnchorCreateInfoFB* info, ulong* requestId)
        {
            xrCreateSpatialAnchorFB_ptr ??= LoadFunction<xrCreateSpatialAnchorFBDelegate>("xrCreateSpatialAnchorFB");
            XrResult _result = xrCreateSpatialAnchorFB_ptr(session, info, requestId);
            Debug.Result(_result, "xrCreateSpatialAnchorFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceUuidFBDelegate(XrSpace space, XrUuid* uuid);
		private static xrGetSpaceUuidFBDelegate xrGetSpaceUuidFB_ptr;
		public static XrResult xrGetSpaceUuidFB(XrSpace space, XrUuid* uuid)
        {
            xrGetSpaceUuidFB_ptr ??= LoadFunction<xrGetSpaceUuidFBDelegate>("xrGetSpaceUuidFB");
            XrResult _result = xrGetSpaceUuidFB_ptr(space, uuid);
            Debug.Result(_result, "xrGetSpaceUuidFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSpaceSupportedComponentsFBDelegate(XrSpace space, uint componentTypeCapacityInput, uint* componentTypeCountOutput, XrSpaceComponentTypeFB* componentTypes);
		private static xrEnumerateSpaceSupportedComponentsFBDelegate xrEnumerateSpaceSupportedComponentsFB_ptr;
		public static XrResult xrEnumerateSpaceSupportedComponentsFB(XrSpace space, uint componentTypeCapacityInput, uint* componentTypeCountOutput, XrSpaceComponentTypeFB* componentTypes)
        {
            xrEnumerateSpaceSupportedComponentsFB_ptr ??= LoadFunction<xrEnumerateSpaceSupportedComponentsFBDelegate>("xrEnumerateSpaceSupportedComponentsFB");
            XrResult _result = xrEnumerateSpaceSupportedComponentsFB_ptr(space, componentTypeCapacityInput, componentTypeCountOutput, componentTypes);
            Debug.Result(_result, "xrEnumerateSpaceSupportedComponentsFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetSpaceComponentStatusFBDelegate(XrSpace space, XrSpaceComponentStatusSetInfoFB* info, ulong* requestId);
		private static xrSetSpaceComponentStatusFBDelegate xrSetSpaceComponentStatusFB_ptr;
		public static XrResult xrSetSpaceComponentStatusFB(XrSpace space, XrSpaceComponentStatusSetInfoFB* info, ulong* requestId)
        {
            xrSetSpaceComponentStatusFB_ptr ??= LoadFunction<xrSetSpaceComponentStatusFBDelegate>("xrSetSpaceComponentStatusFB");
            XrResult _result = xrSetSpaceComponentStatusFB_ptr(space, info, requestId);
            Debug.Result(_result, "xrSetSpaceComponentStatusFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceComponentStatusFBDelegate(XrSpace space, XrSpaceComponentTypeFB componentType, XrSpaceComponentStatusFB* status);
		private static xrGetSpaceComponentStatusFBDelegate xrGetSpaceComponentStatusFB_ptr;
		public static XrResult xrGetSpaceComponentStatusFB(XrSpace space, XrSpaceComponentTypeFB componentType, XrSpaceComponentStatusFB* status)
        {
            xrGetSpaceComponentStatusFB_ptr ??= LoadFunction<xrGetSpaceComponentStatusFBDelegate>("xrGetSpaceComponentStatusFB");
            XrResult _result = xrGetSpaceComponentStatusFB_ptr(space, componentType, status);
            Debug.Result(_result, "xrGetSpaceComponentStatusFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateFoveationProfileFBDelegate(XrSession session, XrFoveationProfileCreateInfoFB* createInfo, XrFoveationProfileFB* profile);
		private static xrCreateFoveationProfileFBDelegate xrCreateFoveationProfileFB_ptr;
		public static XrResult xrCreateFoveationProfileFB(XrSession session, XrFoveationProfileCreateInfoFB* createInfo, XrFoveationProfileFB* profile)
        {
            xrCreateFoveationProfileFB_ptr ??= LoadFunction<xrCreateFoveationProfileFBDelegate>("xrCreateFoveationProfileFB");
            XrResult _result = xrCreateFoveationProfileFB_ptr(session, createInfo, profile);
            Debug.Result(_result, "xrCreateFoveationProfileFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyFoveationProfileFBDelegate(XrFoveationProfileFB profile);
		private static xrDestroyFoveationProfileFBDelegate xrDestroyFoveationProfileFB_ptr;
		public static XrResult xrDestroyFoveationProfileFB(XrFoveationProfileFB profile)
        {
            xrDestroyFoveationProfileFB_ptr ??= LoadFunction<xrDestroyFoveationProfileFBDelegate>("xrDestroyFoveationProfileFB");
            XrResult _result = xrDestroyFoveationProfileFB_ptr(profile);
            Debug.Result(_result, "xrDestroyFoveationProfileFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQuerySystemTrackedKeyboardFBDelegate(XrSession session, XrKeyboardTrackingQueryFB* queryInfo, XrKeyboardTrackingDescriptionFB* keyboard);
		private static xrQuerySystemTrackedKeyboardFBDelegate xrQuerySystemTrackedKeyboardFB_ptr;
		public static XrResult xrQuerySystemTrackedKeyboardFB(XrSession session, XrKeyboardTrackingQueryFB* queryInfo, XrKeyboardTrackingDescriptionFB* keyboard)
        {
            xrQuerySystemTrackedKeyboardFB_ptr ??= LoadFunction<xrQuerySystemTrackedKeyboardFBDelegate>("xrQuerySystemTrackedKeyboardFB");
            XrResult _result = xrQuerySystemTrackedKeyboardFB_ptr(session, queryInfo, keyboard);
            Debug.Result(_result, "xrQuerySystemTrackedKeyboardFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateKeyboardSpaceFBDelegate(XrSession session, XrKeyboardSpaceCreateInfoFB* createInfo, XrSpace* keyboardSpace);
		private static xrCreateKeyboardSpaceFBDelegate xrCreateKeyboardSpaceFB_ptr;
		public static XrResult xrCreateKeyboardSpaceFB(XrSession session, XrKeyboardSpaceCreateInfoFB* createInfo, XrSpace* keyboardSpace)
        {
            xrCreateKeyboardSpaceFB_ptr ??= LoadFunction<xrCreateKeyboardSpaceFBDelegate>("xrCreateKeyboardSpaceFB");
            XrResult _result = xrCreateKeyboardSpaceFB_ptr(session, createInfo, keyboardSpace);
            Debug.Result(_result, "xrCreateKeyboardSpaceFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateTriangleMeshFBDelegate(XrSession session, XrTriangleMeshCreateInfoFB* createInfo, XrTriangleMeshFB* outTriangleMesh);
		private static xrCreateTriangleMeshFBDelegate xrCreateTriangleMeshFB_ptr;
		public static XrResult xrCreateTriangleMeshFB(XrSession session, XrTriangleMeshCreateInfoFB* createInfo, XrTriangleMeshFB* outTriangleMesh)
        {
            xrCreateTriangleMeshFB_ptr ??= LoadFunction<xrCreateTriangleMeshFBDelegate>("xrCreateTriangleMeshFB");
            XrResult _result = xrCreateTriangleMeshFB_ptr(session, createInfo, outTriangleMesh);
            Debug.Result(_result, "xrCreateTriangleMeshFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyTriangleMeshFBDelegate(XrTriangleMeshFB mesh);
		private static xrDestroyTriangleMeshFBDelegate xrDestroyTriangleMeshFB_ptr;
		public static XrResult xrDestroyTriangleMeshFB(XrTriangleMeshFB mesh)
        {
            xrDestroyTriangleMeshFB_ptr ??= LoadFunction<xrDestroyTriangleMeshFBDelegate>("xrDestroyTriangleMeshFB");
            XrResult _result = xrDestroyTriangleMeshFB_ptr(mesh);
            Debug.Result(_result, "xrDestroyTriangleMeshFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTriangleMeshGetVertexBufferFBDelegate(XrTriangleMeshFB mesh, XrVector3f** outVertexBuffer);
		private static xrTriangleMeshGetVertexBufferFBDelegate xrTriangleMeshGetVertexBufferFB_ptr;
		public static XrResult xrTriangleMeshGetVertexBufferFB(XrTriangleMeshFB mesh, XrVector3f** outVertexBuffer)
        {
            xrTriangleMeshGetVertexBufferFB_ptr ??= LoadFunction<xrTriangleMeshGetVertexBufferFBDelegate>("xrTriangleMeshGetVertexBufferFB");
            XrResult _result = xrTriangleMeshGetVertexBufferFB_ptr(mesh, outVertexBuffer);
            Debug.Result(_result, "xrTriangleMeshGetVertexBufferFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTriangleMeshGetIndexBufferFBDelegate(XrTriangleMeshFB mesh, uint** outIndexBuffer);
		private static xrTriangleMeshGetIndexBufferFBDelegate xrTriangleMeshGetIndexBufferFB_ptr;
		public static XrResult xrTriangleMeshGetIndexBufferFB(XrTriangleMeshFB mesh, uint** outIndexBuffer)
        {
            xrTriangleMeshGetIndexBufferFB_ptr ??= LoadFunction<xrTriangleMeshGetIndexBufferFBDelegate>("xrTriangleMeshGetIndexBufferFB");
            XrResult _result = xrTriangleMeshGetIndexBufferFB_ptr(mesh, outIndexBuffer);
            Debug.Result(_result, "xrTriangleMeshGetIndexBufferFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTriangleMeshBeginUpdateFBDelegate(XrTriangleMeshFB mesh);
		private static xrTriangleMeshBeginUpdateFBDelegate xrTriangleMeshBeginUpdateFB_ptr;
		public static XrResult xrTriangleMeshBeginUpdateFB(XrTriangleMeshFB mesh)
        {
            xrTriangleMeshBeginUpdateFB_ptr ??= LoadFunction<xrTriangleMeshBeginUpdateFBDelegate>("xrTriangleMeshBeginUpdateFB");
            XrResult _result = xrTriangleMeshBeginUpdateFB_ptr(mesh);
            Debug.Result(_result, "xrTriangleMeshBeginUpdateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTriangleMeshEndUpdateFBDelegate(XrTriangleMeshFB mesh, uint vertexCount, uint triangleCount);
		private static xrTriangleMeshEndUpdateFBDelegate xrTriangleMeshEndUpdateFB_ptr;
		public static XrResult xrTriangleMeshEndUpdateFB(XrTriangleMeshFB mesh, uint vertexCount, uint triangleCount)
        {
            xrTriangleMeshEndUpdateFB_ptr ??= LoadFunction<xrTriangleMeshEndUpdateFBDelegate>("xrTriangleMeshEndUpdateFB");
            XrResult _result = xrTriangleMeshEndUpdateFB_ptr(mesh, vertexCount, triangleCount);
            Debug.Result(_result, "xrTriangleMeshEndUpdateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTriangleMeshBeginVertexBufferUpdateFBDelegate(XrTriangleMeshFB mesh, uint* outVertexCount);
		private static xrTriangleMeshBeginVertexBufferUpdateFBDelegate xrTriangleMeshBeginVertexBufferUpdateFB_ptr;
		public static XrResult xrTriangleMeshBeginVertexBufferUpdateFB(XrTriangleMeshFB mesh, uint* outVertexCount)
        {
            xrTriangleMeshBeginVertexBufferUpdateFB_ptr ??= LoadFunction<xrTriangleMeshBeginVertexBufferUpdateFBDelegate>("xrTriangleMeshBeginVertexBufferUpdateFB");
            XrResult _result = xrTriangleMeshBeginVertexBufferUpdateFB_ptr(mesh, outVertexCount);
            Debug.Result(_result, "xrTriangleMeshBeginVertexBufferUpdateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrTriangleMeshEndVertexBufferUpdateFBDelegate(XrTriangleMeshFB mesh);
		private static xrTriangleMeshEndVertexBufferUpdateFBDelegate xrTriangleMeshEndVertexBufferUpdateFB_ptr;
		public static XrResult xrTriangleMeshEndVertexBufferUpdateFB(XrTriangleMeshFB mesh)
        {
            xrTriangleMeshEndVertexBufferUpdateFB_ptr ??= LoadFunction<xrTriangleMeshEndVertexBufferUpdateFBDelegate>("xrTriangleMeshEndVertexBufferUpdateFB");
            XrResult _result = xrTriangleMeshEndVertexBufferUpdateFB_ptr(mesh);
            Debug.Result(_result, "xrTriangleMeshEndVertexBufferUpdateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreatePassthroughFBDelegate(XrSession session, XrPassthroughCreateInfoFB* createInfo, XrPassthroughFB* outPassthrough);
		private static xrCreatePassthroughFBDelegate xrCreatePassthroughFB_ptr;
		public static XrResult xrCreatePassthroughFB(XrSession session, XrPassthroughCreateInfoFB* createInfo, XrPassthroughFB* outPassthrough)
        {
            xrCreatePassthroughFB_ptr ??= LoadFunction<xrCreatePassthroughFBDelegate>("xrCreatePassthroughFB");
            XrResult _result = xrCreatePassthroughFB_ptr(session, createInfo, outPassthrough);
            Debug.Result(_result, "xrCreatePassthroughFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyPassthroughFBDelegate(XrPassthroughFB passthrough);
		private static xrDestroyPassthroughFBDelegate xrDestroyPassthroughFB_ptr;
		public static XrResult xrDestroyPassthroughFB(XrPassthroughFB passthrough)
        {
            xrDestroyPassthroughFB_ptr ??= LoadFunction<xrDestroyPassthroughFBDelegate>("xrDestroyPassthroughFB");
            XrResult _result = xrDestroyPassthroughFB_ptr(passthrough);
            Debug.Result(_result, "xrDestroyPassthroughFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPassthroughStartFBDelegate(XrPassthroughFB passthrough);
		private static xrPassthroughStartFBDelegate xrPassthroughStartFB_ptr;
		public static XrResult xrPassthroughStartFB(XrPassthroughFB passthrough)
        {
            xrPassthroughStartFB_ptr ??= LoadFunction<xrPassthroughStartFBDelegate>("xrPassthroughStartFB");
            XrResult _result = xrPassthroughStartFB_ptr(passthrough);
            Debug.Result(_result, "xrPassthroughStartFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPassthroughPauseFBDelegate(XrPassthroughFB passthrough);
		private static xrPassthroughPauseFBDelegate xrPassthroughPauseFB_ptr;
		public static XrResult xrPassthroughPauseFB(XrPassthroughFB passthrough)
        {
            xrPassthroughPauseFB_ptr ??= LoadFunction<xrPassthroughPauseFBDelegate>("xrPassthroughPauseFB");
            XrResult _result = xrPassthroughPauseFB_ptr(passthrough);
            Debug.Result(_result, "xrPassthroughPauseFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreatePassthroughLayerFBDelegate(XrSession session, XrPassthroughLayerCreateInfoFB* createInfo, XrPassthroughLayerFB* outLayer);
		private static xrCreatePassthroughLayerFBDelegate xrCreatePassthroughLayerFB_ptr;
		public static XrResult xrCreatePassthroughLayerFB(XrSession session, XrPassthroughLayerCreateInfoFB* createInfo, XrPassthroughLayerFB* outLayer)
        {
            xrCreatePassthroughLayerFB_ptr ??= LoadFunction<xrCreatePassthroughLayerFBDelegate>("xrCreatePassthroughLayerFB");
            XrResult _result = xrCreatePassthroughLayerFB_ptr(session, createInfo, outLayer);
            Debug.Result(_result, "xrCreatePassthroughLayerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyPassthroughLayerFBDelegate(XrPassthroughLayerFB layer);
		private static xrDestroyPassthroughLayerFBDelegate xrDestroyPassthroughLayerFB_ptr;
		public static XrResult xrDestroyPassthroughLayerFB(XrPassthroughLayerFB layer)
        {
            xrDestroyPassthroughLayerFB_ptr ??= LoadFunction<xrDestroyPassthroughLayerFBDelegate>("xrDestroyPassthroughLayerFB");
            XrResult _result = xrDestroyPassthroughLayerFB_ptr(layer);
            Debug.Result(_result, "xrDestroyPassthroughLayerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPassthroughLayerPauseFBDelegate(XrPassthroughLayerFB layer);
		private static xrPassthroughLayerPauseFBDelegate xrPassthroughLayerPauseFB_ptr;
		public static XrResult xrPassthroughLayerPauseFB(XrPassthroughLayerFB layer)
        {
            xrPassthroughLayerPauseFB_ptr ??= LoadFunction<xrPassthroughLayerPauseFBDelegate>("xrPassthroughLayerPauseFB");
            XrResult _result = xrPassthroughLayerPauseFB_ptr(layer);
            Debug.Result(_result, "xrPassthroughLayerPauseFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPassthroughLayerResumeFBDelegate(XrPassthroughLayerFB layer);
		private static xrPassthroughLayerResumeFBDelegate xrPassthroughLayerResumeFB_ptr;
		public static XrResult xrPassthroughLayerResumeFB(XrPassthroughLayerFB layer)
        {
            xrPassthroughLayerResumeFB_ptr ??= LoadFunction<xrPassthroughLayerResumeFBDelegate>("xrPassthroughLayerResumeFB");
            XrResult _result = xrPassthroughLayerResumeFB_ptr(layer);
            Debug.Result(_result, "xrPassthroughLayerResumeFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPassthroughLayerSetStyleFBDelegate(XrPassthroughLayerFB layer, XrPassthroughStyleFB* style);
		private static xrPassthroughLayerSetStyleFBDelegate xrPassthroughLayerSetStyleFB_ptr;
		public static XrResult xrPassthroughLayerSetStyleFB(XrPassthroughLayerFB layer, XrPassthroughStyleFB* style)
        {
            xrPassthroughLayerSetStyleFB_ptr ??= LoadFunction<xrPassthroughLayerSetStyleFBDelegate>("xrPassthroughLayerSetStyleFB");
            XrResult _result = xrPassthroughLayerSetStyleFB_ptr(layer, style);
            Debug.Result(_result, "xrPassthroughLayerSetStyleFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateGeometryInstanceFBDelegate(XrSession session, XrGeometryInstanceCreateInfoFB* createInfo, XrGeometryInstanceFB* outGeometryInstance);
		private static xrCreateGeometryInstanceFBDelegate xrCreateGeometryInstanceFB_ptr;
		public static XrResult xrCreateGeometryInstanceFB(XrSession session, XrGeometryInstanceCreateInfoFB* createInfo, XrGeometryInstanceFB* outGeometryInstance)
        {
            xrCreateGeometryInstanceFB_ptr ??= LoadFunction<xrCreateGeometryInstanceFBDelegate>("xrCreateGeometryInstanceFB");
            XrResult _result = xrCreateGeometryInstanceFB_ptr(session, createInfo, outGeometryInstance);
            Debug.Result(_result, "xrCreateGeometryInstanceFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyGeometryInstanceFBDelegate(XrGeometryInstanceFB instance);
		private static xrDestroyGeometryInstanceFBDelegate xrDestroyGeometryInstanceFB_ptr;
		public static XrResult xrDestroyGeometryInstanceFB(XrGeometryInstanceFB instance)
        {
            xrDestroyGeometryInstanceFB_ptr ??= LoadFunction<xrDestroyGeometryInstanceFBDelegate>("xrDestroyGeometryInstanceFB");
            XrResult _result = xrDestroyGeometryInstanceFB_ptr(instance);
            Debug.Result(_result, "xrDestroyGeometryInstanceFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGeometryInstanceSetTransformFBDelegate(XrGeometryInstanceFB instance, XrGeometryInstanceTransformFB* transformation);
		private static xrGeometryInstanceSetTransformFBDelegate xrGeometryInstanceSetTransformFB_ptr;
		public static XrResult xrGeometryInstanceSetTransformFB(XrGeometryInstanceFB instance, XrGeometryInstanceTransformFB* transformation)
        {
            xrGeometryInstanceSetTransformFB_ptr ??= LoadFunction<xrGeometryInstanceSetTransformFBDelegate>("xrGeometryInstanceSetTransformFB");
            XrResult _result = xrGeometryInstanceSetTransformFB_ptr(instance, transformation);
            Debug.Result(_result, "xrGeometryInstanceSetTransformFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateRenderModelPathsFBDelegate(XrSession session, uint pathCapacityInput, uint* pathCountOutput, XrRenderModelPathInfoFB* paths);
		private static xrEnumerateRenderModelPathsFBDelegate xrEnumerateRenderModelPathsFB_ptr;
		public static XrResult xrEnumerateRenderModelPathsFB(XrSession session, uint pathCapacityInput, uint* pathCountOutput, XrRenderModelPathInfoFB* paths)
        {
            xrEnumerateRenderModelPathsFB_ptr ??= LoadFunction<xrEnumerateRenderModelPathsFBDelegate>("xrEnumerateRenderModelPathsFB");
            XrResult _result = xrEnumerateRenderModelPathsFB_ptr(session, pathCapacityInput, pathCountOutput, paths);
            Debug.Result(_result, "xrEnumerateRenderModelPathsFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetRenderModelPropertiesFBDelegate(XrSession session, ulong path, XrRenderModelPropertiesFB* properties);
		private static xrGetRenderModelPropertiesFBDelegate xrGetRenderModelPropertiesFB_ptr;
		public static XrResult xrGetRenderModelPropertiesFB(XrSession session, ulong path, XrRenderModelPropertiesFB* properties)
        {
            xrGetRenderModelPropertiesFB_ptr ??= LoadFunction<xrGetRenderModelPropertiesFBDelegate>("xrGetRenderModelPropertiesFB");
            XrResult _result = xrGetRenderModelPropertiesFB_ptr(session, path, properties);
            Debug.Result(_result, "xrGetRenderModelPropertiesFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLoadRenderModelFBDelegate(XrSession session, XrRenderModelLoadInfoFB* info, XrRenderModelBufferFB* buffer);
		private static xrLoadRenderModelFBDelegate xrLoadRenderModelFB_ptr;
		public static XrResult xrLoadRenderModelFB(XrSession session, XrRenderModelLoadInfoFB* info, XrRenderModelBufferFB* buffer)
        {
            xrLoadRenderModelFB_ptr ??= LoadFunction<xrLoadRenderModelFBDelegate>("xrLoadRenderModelFB");
            XrResult _result = xrLoadRenderModelFB_ptr(session, info, buffer);
            Debug.Result(_result, "xrLoadRenderModelFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetEnvironmentDepthEstimationVARJODelegate(XrSession session, XrBool32 enabled);
		private static xrSetEnvironmentDepthEstimationVARJODelegate xrSetEnvironmentDepthEstimationVARJO_ptr;
		public static XrResult xrSetEnvironmentDepthEstimationVARJO(XrSession session, XrBool32 enabled)
        {
            xrSetEnvironmentDepthEstimationVARJO_ptr ??= LoadFunction<xrSetEnvironmentDepthEstimationVARJODelegate>("xrSetEnvironmentDepthEstimationVARJO");
            XrResult _result = xrSetEnvironmentDepthEstimationVARJO_ptr(session, enabled);
            Debug.Result(_result, "xrSetEnvironmentDepthEstimationVARJO");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetMarkerTrackingVARJODelegate(XrSession session, XrBool32 enabled);
		private static xrSetMarkerTrackingVARJODelegate xrSetMarkerTrackingVARJO_ptr;
		public static XrResult xrSetMarkerTrackingVARJO(XrSession session, XrBool32 enabled)
        {
            xrSetMarkerTrackingVARJO_ptr ??= LoadFunction<xrSetMarkerTrackingVARJODelegate>("xrSetMarkerTrackingVARJO");
            XrResult _result = xrSetMarkerTrackingVARJO_ptr(session, enabled);
            Debug.Result(_result, "xrSetMarkerTrackingVARJO");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetMarkerTrackingTimeoutVARJODelegate(XrSession session, ulong markerId, long timeout);
		private static xrSetMarkerTrackingTimeoutVARJODelegate xrSetMarkerTrackingTimeoutVARJO_ptr;
		public static XrResult xrSetMarkerTrackingTimeoutVARJO(XrSession session, ulong markerId, long timeout)
        {
            xrSetMarkerTrackingTimeoutVARJO_ptr ??= LoadFunction<xrSetMarkerTrackingTimeoutVARJODelegate>("xrSetMarkerTrackingTimeoutVARJO");
            XrResult _result = xrSetMarkerTrackingTimeoutVARJO_ptr(session, markerId, timeout);
            Debug.Result(_result, "xrSetMarkerTrackingTimeoutVARJO");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetMarkerTrackingPredictionVARJODelegate(XrSession session, ulong markerId, XrBool32 enable);
		private static xrSetMarkerTrackingPredictionVARJODelegate xrSetMarkerTrackingPredictionVARJO_ptr;
		public static XrResult xrSetMarkerTrackingPredictionVARJO(XrSession session, ulong markerId, XrBool32 enable)
        {
            xrSetMarkerTrackingPredictionVARJO_ptr ??= LoadFunction<xrSetMarkerTrackingPredictionVARJODelegate>("xrSetMarkerTrackingPredictionVARJO");
            XrResult _result = xrSetMarkerTrackingPredictionVARJO_ptr(session, markerId, enable);
            Debug.Result(_result, "xrSetMarkerTrackingPredictionVARJO");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMarkerSizeVARJODelegate(XrSession session, ulong markerId, XrExtent2Df* size);
		private static xrGetMarkerSizeVARJODelegate xrGetMarkerSizeVARJO_ptr;
		public static XrResult xrGetMarkerSizeVARJO(XrSession session, ulong markerId, XrExtent2Df* size)
        {
            xrGetMarkerSizeVARJO_ptr ??= LoadFunction<xrGetMarkerSizeVARJODelegate>("xrGetMarkerSizeVARJO");
            XrResult _result = xrGetMarkerSizeVARJO_ptr(session, markerId, size);
            Debug.Result(_result, "xrGetMarkerSizeVARJO");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateMarkerSpaceVARJODelegate(XrSession session, XrMarkerSpaceCreateInfoVARJO* createInfo, XrSpace* space);
		private static xrCreateMarkerSpaceVARJODelegate xrCreateMarkerSpaceVARJO_ptr;
		public static XrResult xrCreateMarkerSpaceVARJO(XrSession session, XrMarkerSpaceCreateInfoVARJO* createInfo, XrSpace* space)
        {
            xrCreateMarkerSpaceVARJO_ptr ??= LoadFunction<xrCreateMarkerSpaceVARJODelegate>("xrCreateMarkerSpaceVARJO");
            XrResult _result = xrCreateMarkerSpaceVARJO_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateMarkerSpaceVARJO");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetViewOffsetVARJODelegate(XrSession session, float offset);
		private static xrSetViewOffsetVARJODelegate xrSetViewOffsetVARJO_ptr;
		public static XrResult xrSetViewOffsetVARJO(XrSession session, float offset)
        {
            xrSetViewOffsetVARJO_ptr ??= LoadFunction<xrSetViewOffsetVARJODelegate>("xrSetViewOffsetVARJO");
            XrResult _result = xrSetViewOffsetVARJO_ptr(session, offset);
            Debug.Result(_result, "xrSetViewOffsetVARJO");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpaceFromCoordinateFrameUIDMLDelegate(XrSession session, XrCoordinateSpaceCreateInfoML createInfo, XrSpace* space);
		private static xrCreateSpaceFromCoordinateFrameUIDMLDelegate xrCreateSpaceFromCoordinateFrameUIDML_ptr;
		public static XrResult xrCreateSpaceFromCoordinateFrameUIDML(XrSession session, XrCoordinateSpaceCreateInfoML createInfo, XrSpace* space)
        {
            xrCreateSpaceFromCoordinateFrameUIDML_ptr ??= LoadFunction<xrCreateSpaceFromCoordinateFrameUIDMLDelegate>("xrCreateSpaceFromCoordinateFrameUIDML");
            XrResult _result = xrCreateSpaceFromCoordinateFrameUIDML_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateSpaceFromCoordinateFrameUIDML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateMarkerDetectorMLDelegate(XrSession session, XrMarkerDetectorCreateInfoML* createInfo, XrMarkerDetectorML* markerDetector);
		private static xrCreateMarkerDetectorMLDelegate xrCreateMarkerDetectorML_ptr;
		public static XrResult xrCreateMarkerDetectorML(XrSession session, XrMarkerDetectorCreateInfoML* createInfo, XrMarkerDetectorML* markerDetector)
        {
            xrCreateMarkerDetectorML_ptr ??= LoadFunction<xrCreateMarkerDetectorMLDelegate>("xrCreateMarkerDetectorML");
            XrResult _result = xrCreateMarkerDetectorML_ptr(session, createInfo, markerDetector);
            Debug.Result(_result, "xrCreateMarkerDetectorML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyMarkerDetectorMLDelegate(XrMarkerDetectorML markerDetector);
		private static xrDestroyMarkerDetectorMLDelegate xrDestroyMarkerDetectorML_ptr;
		public static XrResult xrDestroyMarkerDetectorML(XrMarkerDetectorML markerDetector)
        {
            xrDestroyMarkerDetectorML_ptr ??= LoadFunction<xrDestroyMarkerDetectorMLDelegate>("xrDestroyMarkerDetectorML");
            XrResult _result = xrDestroyMarkerDetectorML_ptr(markerDetector);
            Debug.Result(_result, "xrDestroyMarkerDetectorML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSnapshotMarkerDetectorMLDelegate(XrMarkerDetectorML markerDetector, XrMarkerDetectorSnapshotInfoML* snapshotInfo);
		private static xrSnapshotMarkerDetectorMLDelegate xrSnapshotMarkerDetectorML_ptr;
		public static XrResult xrSnapshotMarkerDetectorML(XrMarkerDetectorML markerDetector, XrMarkerDetectorSnapshotInfoML* snapshotInfo)
        {
            xrSnapshotMarkerDetectorML_ptr ??= LoadFunction<xrSnapshotMarkerDetectorMLDelegate>("xrSnapshotMarkerDetectorML");
            XrResult _result = xrSnapshotMarkerDetectorML_ptr(markerDetector, snapshotInfo);
            Debug.Result(_result, "xrSnapshotMarkerDetectorML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMarkerDetectorStateMLDelegate(XrMarkerDetectorML markerDetector, XrMarkerDetectorStateML* state);
		private static xrGetMarkerDetectorStateMLDelegate xrGetMarkerDetectorStateML_ptr;
		public static XrResult xrGetMarkerDetectorStateML(XrMarkerDetectorML markerDetector, XrMarkerDetectorStateML* state)
        {
            xrGetMarkerDetectorStateML_ptr ??= LoadFunction<xrGetMarkerDetectorStateMLDelegate>("xrGetMarkerDetectorStateML");
            XrResult _result = xrGetMarkerDetectorStateML_ptr(markerDetector, state);
            Debug.Result(_result, "xrGetMarkerDetectorStateML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMarkersMLDelegate(XrMarkerDetectorML markerDetector, uint markerCapacityInput, uint* markerCountOutput, ulong* markers);
		private static xrGetMarkersMLDelegate xrGetMarkersML_ptr;
		public static XrResult xrGetMarkersML(XrMarkerDetectorML markerDetector, uint markerCapacityInput, uint* markerCountOutput, ulong* markers)
        {
            xrGetMarkersML_ptr ??= LoadFunction<xrGetMarkersMLDelegate>("xrGetMarkersML");
            XrResult _result = xrGetMarkersML_ptr(markerDetector, markerCapacityInput, markerCountOutput, markers);
            Debug.Result(_result, "xrGetMarkersML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMarkerReprojectionErrorMLDelegate(XrMarkerDetectorML markerDetector, ulong marker, float* reprojectionErrorMeters);
		private static xrGetMarkerReprojectionErrorMLDelegate xrGetMarkerReprojectionErrorML_ptr;
		public static XrResult xrGetMarkerReprojectionErrorML(XrMarkerDetectorML markerDetector, ulong marker, float* reprojectionErrorMeters)
        {
            xrGetMarkerReprojectionErrorML_ptr ??= LoadFunction<xrGetMarkerReprojectionErrorMLDelegate>("xrGetMarkerReprojectionErrorML");
            XrResult _result = xrGetMarkerReprojectionErrorML_ptr(markerDetector, marker, reprojectionErrorMeters);
            Debug.Result(_result, "xrGetMarkerReprojectionErrorML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMarkerLengthMLDelegate(XrMarkerDetectorML markerDetector, ulong marker, float* meters);
		private static xrGetMarkerLengthMLDelegate xrGetMarkerLengthML_ptr;
		public static XrResult xrGetMarkerLengthML(XrMarkerDetectorML markerDetector, ulong marker, float* meters)
        {
            xrGetMarkerLengthML_ptr ??= LoadFunction<xrGetMarkerLengthMLDelegate>("xrGetMarkerLengthML");
            XrResult _result = xrGetMarkerLengthML_ptr(markerDetector, marker, meters);
            Debug.Result(_result, "xrGetMarkerLengthML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMarkerNumberMLDelegate(XrMarkerDetectorML markerDetector, ulong marker, ulong* number);
		private static xrGetMarkerNumberMLDelegate xrGetMarkerNumberML_ptr;
		public static XrResult xrGetMarkerNumberML(XrMarkerDetectorML markerDetector, ulong marker, ulong* number)
        {
            xrGetMarkerNumberML_ptr ??= LoadFunction<xrGetMarkerNumberMLDelegate>("xrGetMarkerNumberML");
            XrResult _result = xrGetMarkerNumberML_ptr(markerDetector, marker, number);
            Debug.Result(_result, "xrGetMarkerNumberML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetMarkerStringMLDelegate(XrMarkerDetectorML markerDetector, ulong marker, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetMarkerStringMLDelegate xrGetMarkerStringML_ptr;
		public static XrResult xrGetMarkerStringML(XrMarkerDetectorML markerDetector, ulong marker, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetMarkerStringML_ptr ??= LoadFunction<xrGetMarkerStringMLDelegate>("xrGetMarkerStringML");
            XrResult _result = xrGetMarkerStringML_ptr(markerDetector, marker, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetMarkerStringML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateMarkerSpaceMLDelegate(XrSession session, XrMarkerSpaceCreateInfoML* createInfo, XrSpace* space);
		private static xrCreateMarkerSpaceMLDelegate xrCreateMarkerSpaceML_ptr;
		public static XrResult xrCreateMarkerSpaceML(XrSession session, XrMarkerSpaceCreateInfoML* createInfo, XrSpace* space)
        {
            xrCreateMarkerSpaceML_ptr ??= LoadFunction<xrCreateMarkerSpaceMLDelegate>("xrCreateMarkerSpaceML");
            XrResult _result = xrCreateMarkerSpaceML_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateMarkerSpaceML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnableLocalizationEventsMLDelegate(XrSession session, XrLocalizationEnableEventsInfoML info);
		private static xrEnableLocalizationEventsMLDelegate xrEnableLocalizationEventsML_ptr;
		public static XrResult xrEnableLocalizationEventsML(XrSession session, XrLocalizationEnableEventsInfoML info)
        {
            xrEnableLocalizationEventsML_ptr ??= LoadFunction<xrEnableLocalizationEventsMLDelegate>("xrEnableLocalizationEventsML");
            XrResult _result = xrEnableLocalizationEventsML_ptr(session, info);
            Debug.Result(_result, "xrEnableLocalizationEventsML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQueryLocalizationMapsMLDelegate(XrSession session, XrLocalizationMapQueryInfoBaseHeaderML* queryInfo, uint mapCapacityInput, uint mapCountOutput, XrLocalizationMapML* maps);
		private static xrQueryLocalizationMapsMLDelegate xrQueryLocalizationMapsML_ptr;
		public static XrResult xrQueryLocalizationMapsML(XrSession session, XrLocalizationMapQueryInfoBaseHeaderML* queryInfo, uint mapCapacityInput, uint mapCountOutput, XrLocalizationMapML* maps)
        {
            xrQueryLocalizationMapsML_ptr ??= LoadFunction<xrQueryLocalizationMapsMLDelegate>("xrQueryLocalizationMapsML");
            XrResult _result = xrQueryLocalizationMapsML_ptr(session, queryInfo, mapCapacityInput, mapCountOutput, maps);
            Debug.Result(_result, "xrQueryLocalizationMapsML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestMapLocalizationMLDelegate(XrSession session, XrMapLocalizationRequestInfoML* requestInfo);
		private static xrRequestMapLocalizationMLDelegate xrRequestMapLocalizationML_ptr;
		public static XrResult xrRequestMapLocalizationML(XrSession session, XrMapLocalizationRequestInfoML* requestInfo)
        {
            xrRequestMapLocalizationML_ptr ??= LoadFunction<xrRequestMapLocalizationMLDelegate>("xrRequestMapLocalizationML");
            XrResult _result = xrRequestMapLocalizationML_ptr(session, requestInfo);
            Debug.Result(_result, "xrRequestMapLocalizationML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrImportLocalizationMapMLDelegate(XrSession session, XrLocalizationMapImportInfoML* importInfo, XrUuid* mapUuid);
		private static xrImportLocalizationMapMLDelegate xrImportLocalizationMapML_ptr;
		public static XrResult xrImportLocalizationMapML(XrSession session, XrLocalizationMapImportInfoML* importInfo, XrUuid* mapUuid)
        {
            xrImportLocalizationMapML_ptr ??= LoadFunction<xrImportLocalizationMapMLDelegate>("xrImportLocalizationMapML");
            XrResult _result = xrImportLocalizationMapML_ptr(session, importInfo, mapUuid);
            Debug.Result(_result, "xrImportLocalizationMapML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateExportedLocalizationMapMLDelegate(XrSession session, XrUuid* mapUuid, XrExportedLocalizationMapML* map);
		private static xrCreateExportedLocalizationMapMLDelegate xrCreateExportedLocalizationMapML_ptr;
		public static XrResult xrCreateExportedLocalizationMapML(XrSession session, XrUuid* mapUuid, XrExportedLocalizationMapML* map)
        {
            xrCreateExportedLocalizationMapML_ptr ??= LoadFunction<xrCreateExportedLocalizationMapMLDelegate>("xrCreateExportedLocalizationMapML");
            XrResult _result = xrCreateExportedLocalizationMapML_ptr(session, mapUuid, map);
            Debug.Result(_result, "xrCreateExportedLocalizationMapML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyExportedLocalizationMapMLDelegate(XrExportedLocalizationMapML map);
		private static xrDestroyExportedLocalizationMapMLDelegate xrDestroyExportedLocalizationMapML_ptr;
		public static XrResult xrDestroyExportedLocalizationMapML(XrExportedLocalizationMapML map)
        {
            xrDestroyExportedLocalizationMapML_ptr ??= LoadFunction<xrDestroyExportedLocalizationMapMLDelegate>("xrDestroyExportedLocalizationMapML");
            XrResult _result = xrDestroyExportedLocalizationMapML_ptr(map);
            Debug.Result(_result, "xrDestroyExportedLocalizationMapML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetExportedLocalizationMapDataMLDelegate(XrExportedLocalizationMapML map, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetExportedLocalizationMapDataMLDelegate xrGetExportedLocalizationMapDataML_ptr;
		public static XrResult xrGetExportedLocalizationMapDataML(XrExportedLocalizationMapML map, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetExportedLocalizationMapDataML_ptr ??= LoadFunction<xrGetExportedLocalizationMapDataMLDelegate>("xrGetExportedLocalizationMapDataML");
            XrResult _result = xrGetExportedLocalizationMapDataML_ptr(map, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetExportedLocalizationMapDataML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorsAsyncMLDelegate(XrSession session, XrSpatialAnchorsCreateInfoBaseHeaderML* createInfo, ulong* future);
		private static xrCreateSpatialAnchorsAsyncMLDelegate xrCreateSpatialAnchorsAsyncML_ptr;
		public static XrResult xrCreateSpatialAnchorsAsyncML(XrSession session, XrSpatialAnchorsCreateInfoBaseHeaderML* createInfo, ulong* future)
        {
            xrCreateSpatialAnchorsAsyncML_ptr ??= LoadFunction<xrCreateSpatialAnchorsAsyncMLDelegate>("xrCreateSpatialAnchorsAsyncML");
            XrResult _result = xrCreateSpatialAnchorsAsyncML_ptr(session, createInfo, future);
            Debug.Result(_result, "xrCreateSpatialAnchorsAsyncML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorsCompleteMLDelegate(XrSession session, ulong future, XrCreateSpatialAnchorsCompletionML* completion);
		private static xrCreateSpatialAnchorsCompleteMLDelegate xrCreateSpatialAnchorsCompleteML_ptr;
		public static XrResult xrCreateSpatialAnchorsCompleteML(XrSession session, ulong future, XrCreateSpatialAnchorsCompletionML* completion)
        {
            xrCreateSpatialAnchorsCompleteML_ptr ??= LoadFunction<xrCreateSpatialAnchorsCompleteMLDelegate>("xrCreateSpatialAnchorsCompleteML");
            XrResult _result = xrCreateSpatialAnchorsCompleteML_ptr(session, future, completion);
            Debug.Result(_result, "xrCreateSpatialAnchorsCompleteML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialAnchorStateMLDelegate(XrSpace anchor, XrSpatialAnchorStateML* state);
		private static xrGetSpatialAnchorStateMLDelegate xrGetSpatialAnchorStateML_ptr;
		public static XrResult xrGetSpatialAnchorStateML(XrSpace anchor, XrSpatialAnchorStateML* state)
        {
            xrGetSpatialAnchorStateML_ptr ??= LoadFunction<xrGetSpatialAnchorStateMLDelegate>("xrGetSpatialAnchorStateML");
            XrResult _result = xrGetSpatialAnchorStateML_ptr(anchor, state);
            Debug.Result(_result, "xrGetSpatialAnchorStateML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorsStorageMLDelegate(XrSession session, XrSpatialAnchorsCreateStorageInfoML* createInfo, XrSpatialAnchorsStorageML* storage);
		private static xrCreateSpatialAnchorsStorageMLDelegate xrCreateSpatialAnchorsStorageML_ptr;
		public static XrResult xrCreateSpatialAnchorsStorageML(XrSession session, XrSpatialAnchorsCreateStorageInfoML* createInfo, XrSpatialAnchorsStorageML* storage)
        {
            xrCreateSpatialAnchorsStorageML_ptr ??= LoadFunction<xrCreateSpatialAnchorsStorageMLDelegate>("xrCreateSpatialAnchorsStorageML");
            XrResult _result = xrCreateSpatialAnchorsStorageML_ptr(session, createInfo, storage);
            Debug.Result(_result, "xrCreateSpatialAnchorsStorageML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialAnchorsStorageMLDelegate(XrSpatialAnchorsStorageML storage);
		private static xrDestroySpatialAnchorsStorageMLDelegate xrDestroySpatialAnchorsStorageML_ptr;
		public static XrResult xrDestroySpatialAnchorsStorageML(XrSpatialAnchorsStorageML storage)
        {
            xrDestroySpatialAnchorsStorageML_ptr ??= LoadFunction<xrDestroySpatialAnchorsStorageMLDelegate>("xrDestroySpatialAnchorsStorageML");
            XrResult _result = xrDestroySpatialAnchorsStorageML_ptr(storage);
            Debug.Result(_result, "xrDestroySpatialAnchorsStorageML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQuerySpatialAnchorsAsyncMLDelegate(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsQueryInfoBaseHeaderML* queryInfo, ulong* future);
		private static xrQuerySpatialAnchorsAsyncMLDelegate xrQuerySpatialAnchorsAsyncML_ptr;
		public static XrResult xrQuerySpatialAnchorsAsyncML(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsQueryInfoBaseHeaderML* queryInfo, ulong* future)
        {
            xrQuerySpatialAnchorsAsyncML_ptr ??= LoadFunction<xrQuerySpatialAnchorsAsyncMLDelegate>("xrQuerySpatialAnchorsAsyncML");
            XrResult _result = xrQuerySpatialAnchorsAsyncML_ptr(storage, queryInfo, future);
            Debug.Result(_result, "xrQuerySpatialAnchorsAsyncML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQuerySpatialAnchorsCompleteMLDelegate(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsQueryCompletionML* completion);
		private static xrQuerySpatialAnchorsCompleteMLDelegate xrQuerySpatialAnchorsCompleteML_ptr;
		public static XrResult xrQuerySpatialAnchorsCompleteML(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsQueryCompletionML* completion)
        {
            xrQuerySpatialAnchorsCompleteML_ptr ??= LoadFunction<xrQuerySpatialAnchorsCompleteMLDelegate>("xrQuerySpatialAnchorsCompleteML");
            XrResult _result = xrQuerySpatialAnchorsCompleteML_ptr(storage, future, completion);
            Debug.Result(_result, "xrQuerySpatialAnchorsCompleteML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPublishSpatialAnchorsAsyncMLDelegate(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsPublishInfoML* publishInfo, ulong* future);
		private static xrPublishSpatialAnchorsAsyncMLDelegate xrPublishSpatialAnchorsAsyncML_ptr;
		public static XrResult xrPublishSpatialAnchorsAsyncML(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsPublishInfoML* publishInfo, ulong* future)
        {
            xrPublishSpatialAnchorsAsyncML_ptr ??= LoadFunction<xrPublishSpatialAnchorsAsyncMLDelegate>("xrPublishSpatialAnchorsAsyncML");
            XrResult _result = xrPublishSpatialAnchorsAsyncML_ptr(storage, publishInfo, future);
            Debug.Result(_result, "xrPublishSpatialAnchorsAsyncML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPublishSpatialAnchorsCompleteMLDelegate(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsPublishCompletionML* completion);
		private static xrPublishSpatialAnchorsCompleteMLDelegate xrPublishSpatialAnchorsCompleteML_ptr;
		public static XrResult xrPublishSpatialAnchorsCompleteML(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsPublishCompletionML* completion)
        {
            xrPublishSpatialAnchorsCompleteML_ptr ??= LoadFunction<xrPublishSpatialAnchorsCompleteMLDelegate>("xrPublishSpatialAnchorsCompleteML");
            XrResult _result = xrPublishSpatialAnchorsCompleteML_ptr(storage, future, completion);
            Debug.Result(_result, "xrPublishSpatialAnchorsCompleteML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDeleteSpatialAnchorsAsyncMLDelegate(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsDeleteInfoML* deleteInfo, ulong* future);
		private static xrDeleteSpatialAnchorsAsyncMLDelegate xrDeleteSpatialAnchorsAsyncML_ptr;
		public static XrResult xrDeleteSpatialAnchorsAsyncML(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsDeleteInfoML* deleteInfo, ulong* future)
        {
            xrDeleteSpatialAnchorsAsyncML_ptr ??= LoadFunction<xrDeleteSpatialAnchorsAsyncMLDelegate>("xrDeleteSpatialAnchorsAsyncML");
            XrResult _result = xrDeleteSpatialAnchorsAsyncML_ptr(storage, deleteInfo, future);
            Debug.Result(_result, "xrDeleteSpatialAnchorsAsyncML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDeleteSpatialAnchorsCompleteMLDelegate(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsDeleteCompletionML* completion);
		private static xrDeleteSpatialAnchorsCompleteMLDelegate xrDeleteSpatialAnchorsCompleteML_ptr;
		public static XrResult xrDeleteSpatialAnchorsCompleteML(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsDeleteCompletionML* completion)
        {
            xrDeleteSpatialAnchorsCompleteML_ptr ??= LoadFunction<xrDeleteSpatialAnchorsCompleteMLDelegate>("xrDeleteSpatialAnchorsCompleteML");
            XrResult _result = xrDeleteSpatialAnchorsCompleteML_ptr(storage, future, completion);
            Debug.Result(_result, "xrDeleteSpatialAnchorsCompleteML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUpdateSpatialAnchorsExpirationAsyncMLDelegate(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsUpdateExpirationInfoML* updateInfo, ulong* future);
		private static xrUpdateSpatialAnchorsExpirationAsyncMLDelegate xrUpdateSpatialAnchorsExpirationAsyncML_ptr;
		public static XrResult xrUpdateSpatialAnchorsExpirationAsyncML(XrSpatialAnchorsStorageML storage, XrSpatialAnchorsUpdateExpirationInfoML* updateInfo, ulong* future)
        {
            xrUpdateSpatialAnchorsExpirationAsyncML_ptr ??= LoadFunction<xrUpdateSpatialAnchorsExpirationAsyncMLDelegate>("xrUpdateSpatialAnchorsExpirationAsyncML");
            XrResult _result = xrUpdateSpatialAnchorsExpirationAsyncML_ptr(storage, updateInfo, future);
            Debug.Result(_result, "xrUpdateSpatialAnchorsExpirationAsyncML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUpdateSpatialAnchorsExpirationCompleteMLDelegate(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsUpdateExpirationCompletionML* completion);
		private static xrUpdateSpatialAnchorsExpirationCompleteMLDelegate xrUpdateSpatialAnchorsExpirationCompleteML_ptr;
		public static XrResult xrUpdateSpatialAnchorsExpirationCompleteML(XrSpatialAnchorsStorageML storage, ulong future, XrSpatialAnchorsUpdateExpirationCompletionML* completion)
        {
            xrUpdateSpatialAnchorsExpirationCompleteML_ptr ??= LoadFunction<xrUpdateSpatialAnchorsExpirationCompleteMLDelegate>("xrUpdateSpatialAnchorsExpirationCompleteML");
            XrResult _result = xrUpdateSpatialAnchorsExpirationCompleteML_ptr(storage, future, completion);
            Debug.Result(_result, "xrUpdateSpatialAnchorsExpirationCompleteML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnableUserCalibrationEventsMLDelegate(XrInstance instance, XrUserCalibrationEnableEventsInfoML* enableInfo);
		private static xrEnableUserCalibrationEventsMLDelegate xrEnableUserCalibrationEventsML_ptr;
		public static XrResult xrEnableUserCalibrationEventsML(XrInstance instance, XrUserCalibrationEnableEventsInfoML* enableInfo)
        {
            xrEnableUserCalibrationEventsML_ptr ??= LoadFunction<xrEnableUserCalibrationEventsMLDelegate>("xrEnableUserCalibrationEventsML");
            XrResult _result = xrEnableUserCalibrationEventsML_ptr(instance, enableInfo);
            Debug.Result(_result, "xrEnableUserCalibrationEventsML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorStoreConnectionMSFTDelegate(XrSession session, XrSpatialAnchorStoreConnectionMSFT* spatialAnchorStore);
		private static xrCreateSpatialAnchorStoreConnectionMSFTDelegate xrCreateSpatialAnchorStoreConnectionMSFT_ptr;
		public static XrResult xrCreateSpatialAnchorStoreConnectionMSFT(XrSession session, XrSpatialAnchorStoreConnectionMSFT* spatialAnchorStore)
        {
            xrCreateSpatialAnchorStoreConnectionMSFT_ptr ??= LoadFunction<xrCreateSpatialAnchorStoreConnectionMSFTDelegate>("xrCreateSpatialAnchorStoreConnectionMSFT");
            XrResult _result = xrCreateSpatialAnchorStoreConnectionMSFT_ptr(session, spatialAnchorStore);
            Debug.Result(_result, "xrCreateSpatialAnchorStoreConnectionMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialAnchorStoreConnectionMSFTDelegate(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore);
		private static xrDestroySpatialAnchorStoreConnectionMSFTDelegate xrDestroySpatialAnchorStoreConnectionMSFT_ptr;
		public static XrResult xrDestroySpatialAnchorStoreConnectionMSFT(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore)
        {
            xrDestroySpatialAnchorStoreConnectionMSFT_ptr ??= LoadFunction<xrDestroySpatialAnchorStoreConnectionMSFTDelegate>("xrDestroySpatialAnchorStoreConnectionMSFT");
            XrResult _result = xrDestroySpatialAnchorStoreConnectionMSFT_ptr(spatialAnchorStore);
            Debug.Result(_result, "xrDestroySpatialAnchorStoreConnectionMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPersistSpatialAnchorMSFTDelegate(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore, XrSpatialAnchorPersistenceInfoMSFT* spatialAnchorPersistenceInfo);
		private static xrPersistSpatialAnchorMSFTDelegate xrPersistSpatialAnchorMSFT_ptr;
		public static XrResult xrPersistSpatialAnchorMSFT(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore, XrSpatialAnchorPersistenceInfoMSFT* spatialAnchorPersistenceInfo)
        {
            xrPersistSpatialAnchorMSFT_ptr ??= LoadFunction<xrPersistSpatialAnchorMSFTDelegate>("xrPersistSpatialAnchorMSFT");
            XrResult _result = xrPersistSpatialAnchorMSFT_ptr(spatialAnchorStore, spatialAnchorPersistenceInfo);
            Debug.Result(_result, "xrPersistSpatialAnchorMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumeratePersistedSpatialAnchorNamesMSFTDelegate(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore, uint spatialAnchorNameCapacityInput, uint* spatialAnchorNameCountOutput, XrSpatialAnchorPersistenceNameMSFT* spatialAnchorNames);
		private static xrEnumeratePersistedSpatialAnchorNamesMSFTDelegate xrEnumeratePersistedSpatialAnchorNamesMSFT_ptr;
		public static XrResult xrEnumeratePersistedSpatialAnchorNamesMSFT(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore, uint spatialAnchorNameCapacityInput, uint* spatialAnchorNameCountOutput, XrSpatialAnchorPersistenceNameMSFT* spatialAnchorNames)
        {
            xrEnumeratePersistedSpatialAnchorNamesMSFT_ptr ??= LoadFunction<xrEnumeratePersistedSpatialAnchorNamesMSFTDelegate>("xrEnumeratePersistedSpatialAnchorNamesMSFT");
            XrResult _result = xrEnumeratePersistedSpatialAnchorNamesMSFT_ptr(spatialAnchorStore, spatialAnchorNameCapacityInput, spatialAnchorNameCountOutput, spatialAnchorNames);
            Debug.Result(_result, "xrEnumeratePersistedSpatialAnchorNamesMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorFromPersistedNameMSFTDelegate(XrSession session, XrSpatialAnchorFromPersistedAnchorCreateInfoMSFT* spatialAnchorCreateInfo, XrSpatialAnchorMSFT* spatialAnchor);
		private static xrCreateSpatialAnchorFromPersistedNameMSFTDelegate xrCreateSpatialAnchorFromPersistedNameMSFT_ptr;
		public static XrResult xrCreateSpatialAnchorFromPersistedNameMSFT(XrSession session, XrSpatialAnchorFromPersistedAnchorCreateInfoMSFT* spatialAnchorCreateInfo, XrSpatialAnchorMSFT* spatialAnchor)
        {
            xrCreateSpatialAnchorFromPersistedNameMSFT_ptr ??= LoadFunction<xrCreateSpatialAnchorFromPersistedNameMSFTDelegate>("xrCreateSpatialAnchorFromPersistedNameMSFT");
            XrResult _result = xrCreateSpatialAnchorFromPersistedNameMSFT_ptr(session, spatialAnchorCreateInfo, spatialAnchor);
            Debug.Result(_result, "xrCreateSpatialAnchorFromPersistedNameMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUnpersistSpatialAnchorMSFTDelegate(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore, XrSpatialAnchorPersistenceNameMSFT* spatialAnchorPersistenceName);
		private static xrUnpersistSpatialAnchorMSFTDelegate xrUnpersistSpatialAnchorMSFT_ptr;
		public static XrResult xrUnpersistSpatialAnchorMSFT(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore, XrSpatialAnchorPersistenceNameMSFT* spatialAnchorPersistenceName)
        {
            xrUnpersistSpatialAnchorMSFT_ptr ??= LoadFunction<xrUnpersistSpatialAnchorMSFTDelegate>("xrUnpersistSpatialAnchorMSFT");
            XrResult _result = xrUnpersistSpatialAnchorMSFT_ptr(spatialAnchorStore, spatialAnchorPersistenceName);
            Debug.Result(_result, "xrUnpersistSpatialAnchorMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrClearSpatialAnchorStoreMSFTDelegate(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore);
		private static xrClearSpatialAnchorStoreMSFTDelegate xrClearSpatialAnchorStoreMSFT_ptr;
		public static XrResult xrClearSpatialAnchorStoreMSFT(XrSpatialAnchorStoreConnectionMSFT spatialAnchorStore)
        {
            xrClearSpatialAnchorStoreMSFT_ptr ??= LoadFunction<xrClearSpatialAnchorStoreMSFTDelegate>("xrClearSpatialAnchorStoreMSFT");
            XrResult _result = xrClearSpatialAnchorStoreMSFT_ptr(spatialAnchorStore);
            Debug.Result(_result, "xrClearSpatialAnchorStoreMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSceneMarkerRawDataMSFTDelegate(XrSceneMSFT scene, XrUuidMSFT* markerId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetSceneMarkerRawDataMSFTDelegate xrGetSceneMarkerRawDataMSFT_ptr;
		public static XrResult xrGetSceneMarkerRawDataMSFT(XrSceneMSFT scene, XrUuidMSFT* markerId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetSceneMarkerRawDataMSFT_ptr ??= LoadFunction<xrGetSceneMarkerRawDataMSFTDelegate>("xrGetSceneMarkerRawDataMSFT");
            XrResult _result = xrGetSceneMarkerRawDataMSFT_ptr(scene, markerId, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSceneMarkerRawDataMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSceneMarkerDecodedStringMSFTDelegate(XrSceneMSFT scene, XrUuidMSFT* markerId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetSceneMarkerDecodedStringMSFTDelegate xrGetSceneMarkerDecodedStringMSFT_ptr;
		public static XrResult xrGetSceneMarkerDecodedStringMSFT(XrSceneMSFT scene, XrUuidMSFT* markerId, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetSceneMarkerDecodedStringMSFT_ptr ??= LoadFunction<xrGetSceneMarkerDecodedStringMSFTDelegate>("xrGetSceneMarkerDecodedStringMSFT");
            XrResult _result = xrGetSceneMarkerDecodedStringMSFT_ptr(scene, markerId, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSceneMarkerDecodedStringMSFT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStructureTypeToString2KHRDelegate(XrInstance instance, XrStructureType value, byte buffer);
		private static xrStructureTypeToString2KHRDelegate xrStructureTypeToString2KHR_ptr;
		public static XrResult xrStructureTypeToString2KHR(XrInstance instance, XrStructureType value, byte buffer)
        {
            xrStructureTypeToString2KHR_ptr ??= LoadFunction<xrStructureTypeToString2KHRDelegate>("xrStructureTypeToString2KHR");
            XrResult _result = xrStructureTypeToString2KHR_ptr(instance, value, buffer);
            Debug.Result(_result, "xrStructureTypeToString2KHR");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQuerySpacesFBDelegate(XrSession session, XrSpaceQueryInfoBaseHeaderFB* info, ulong* requestId);
		private static xrQuerySpacesFBDelegate xrQuerySpacesFB_ptr;
		public static XrResult xrQuerySpacesFB(XrSession session, XrSpaceQueryInfoBaseHeaderFB* info, ulong* requestId)
        {
            xrQuerySpacesFB_ptr ??= LoadFunction<xrQuerySpacesFBDelegate>("xrQuerySpacesFB");
            XrResult _result = xrQuerySpacesFB_ptr(session, info, requestId);
            Debug.Result(_result, "xrQuerySpacesFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRetrieveSpaceQueryResultsFBDelegate(XrSession session, ulong requestId, XrSpaceQueryResultsFB* results);
		private static xrRetrieveSpaceQueryResultsFBDelegate xrRetrieveSpaceQueryResultsFB_ptr;
		public static XrResult xrRetrieveSpaceQueryResultsFB(XrSession session, ulong requestId, XrSpaceQueryResultsFB* results)
        {
            xrRetrieveSpaceQueryResultsFB_ptr ??= LoadFunction<xrRetrieveSpaceQueryResultsFBDelegate>("xrRetrieveSpaceQueryResultsFB");
            XrResult _result = xrRetrieveSpaceQueryResultsFB_ptr(session, requestId, results);
            Debug.Result(_result, "xrRetrieveSpaceQueryResultsFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSaveSpaceFBDelegate(XrSession session, XrSpaceSaveInfoFB* info, ulong* requestId);
		private static xrSaveSpaceFBDelegate xrSaveSpaceFB_ptr;
		public static XrResult xrSaveSpaceFB(XrSession session, XrSpaceSaveInfoFB* info, ulong* requestId)
        {
            xrSaveSpaceFB_ptr ??= LoadFunction<xrSaveSpaceFBDelegate>("xrSaveSpaceFB");
            XrResult _result = xrSaveSpaceFB_ptr(session, info, requestId);
            Debug.Result(_result, "xrSaveSpaceFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEraseSpaceFBDelegate(XrSession session, XrSpaceEraseInfoFB* info, ulong* requestId);
		private static xrEraseSpaceFBDelegate xrEraseSpaceFB_ptr;
		public static XrResult xrEraseSpaceFB(XrSession session, XrSpaceEraseInfoFB* info, ulong* requestId)
        {
            xrEraseSpaceFB_ptr ??= LoadFunction<xrEraseSpaceFBDelegate>("xrEraseSpaceFB");
            XrResult _result = xrEraseSpaceFB_ptr(session, info, requestId);
            Debug.Result(_result, "xrEraseSpaceFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetAudioOutputDeviceGuidOculusDelegate(XrInstance instance, string buffer);
		private static xrGetAudioOutputDeviceGuidOculusDelegate xrGetAudioOutputDeviceGuidOculus_ptr;
		public static XrResult xrGetAudioOutputDeviceGuidOculus(XrInstance instance, string buffer)
        {
            xrGetAudioOutputDeviceGuidOculus_ptr ??= LoadFunction<xrGetAudioOutputDeviceGuidOculusDelegate>("xrGetAudioOutputDeviceGuidOculus");
            XrResult _result = xrGetAudioOutputDeviceGuidOculus_ptr(instance, buffer);
            Debug.Result(_result, "xrGetAudioOutputDeviceGuidOculus");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetAudioInputDeviceGuidOculusDelegate(XrInstance instance, string buffer);
		private static xrGetAudioInputDeviceGuidOculusDelegate xrGetAudioInputDeviceGuidOculus_ptr;
		public static XrResult xrGetAudioInputDeviceGuidOculus(XrInstance instance, string buffer)
        {
            xrGetAudioInputDeviceGuidOculus_ptr ??= LoadFunction<xrGetAudioInputDeviceGuidOculusDelegate>("xrGetAudioInputDeviceGuidOculus");
            XrResult _result = xrGetAudioInputDeviceGuidOculus_ptr(instance, buffer);
            Debug.Result(_result, "xrGetAudioInputDeviceGuidOculus");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrShareSpacesFBDelegate(XrSession session, XrSpaceShareInfoFB* info, ulong* requestId);
		private static xrShareSpacesFBDelegate xrShareSpacesFB_ptr;
		public static XrResult xrShareSpacesFB(XrSession session, XrSpaceShareInfoFB* info, ulong* requestId)
        {
            xrShareSpacesFB_ptr ??= LoadFunction<xrShareSpacesFBDelegate>("xrShareSpacesFB");
            XrResult _result = xrShareSpacesFB_ptr(session, info, requestId);
            Debug.Result(_result, "xrShareSpacesFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceBoundingBox2DFBDelegate(XrSession session, XrSpace space, XrRect2Df* boundingBox2DOutput);
		private static xrGetSpaceBoundingBox2DFBDelegate xrGetSpaceBoundingBox2DFB_ptr;
		public static XrResult xrGetSpaceBoundingBox2DFB(XrSession session, XrSpace space, XrRect2Df* boundingBox2DOutput)
        {
            xrGetSpaceBoundingBox2DFB_ptr ??= LoadFunction<xrGetSpaceBoundingBox2DFBDelegate>("xrGetSpaceBoundingBox2DFB");
            XrResult _result = xrGetSpaceBoundingBox2DFB_ptr(session, space, boundingBox2DOutput);
            Debug.Result(_result, "xrGetSpaceBoundingBox2DFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceBoundingBox3DFBDelegate(XrSession session, XrSpace space, XrRect3DfFB* boundingBox3DOutput);
		private static xrGetSpaceBoundingBox3DFBDelegate xrGetSpaceBoundingBox3DFB_ptr;
		public static XrResult xrGetSpaceBoundingBox3DFB(XrSession session, XrSpace space, XrRect3DfFB* boundingBox3DOutput)
        {
            xrGetSpaceBoundingBox3DFB_ptr ??= LoadFunction<xrGetSpaceBoundingBox3DFBDelegate>("xrGetSpaceBoundingBox3DFB");
            XrResult _result = xrGetSpaceBoundingBox3DFB_ptr(session, space, boundingBox3DOutput);
            Debug.Result(_result, "xrGetSpaceBoundingBox3DFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceSemanticLabelsFBDelegate(XrSession session, XrSpace space, XrSemanticLabelsFB* semanticLabelsOutput);
		private static xrGetSpaceSemanticLabelsFBDelegate xrGetSpaceSemanticLabelsFB_ptr;
		public static XrResult xrGetSpaceSemanticLabelsFB(XrSession session, XrSpace space, XrSemanticLabelsFB* semanticLabelsOutput)
        {
            xrGetSpaceSemanticLabelsFB_ptr ??= LoadFunction<xrGetSpaceSemanticLabelsFBDelegate>("xrGetSpaceSemanticLabelsFB");
            XrResult _result = xrGetSpaceSemanticLabelsFB_ptr(session, space, semanticLabelsOutput);
            Debug.Result(_result, "xrGetSpaceSemanticLabelsFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceBoundary2DFBDelegate(XrSession session, XrSpace space, XrBoundary2DFB* boundary2DOutput);
		private static xrGetSpaceBoundary2DFBDelegate xrGetSpaceBoundary2DFB_ptr;
		public static XrResult xrGetSpaceBoundary2DFB(XrSession session, XrSpace space, XrBoundary2DFB* boundary2DOutput)
        {
            xrGetSpaceBoundary2DFB_ptr ??= LoadFunction<xrGetSpaceBoundary2DFBDelegate>("xrGetSpaceBoundary2DFB");
            XrResult _result = xrGetSpaceBoundary2DFB_ptr(session, space, boundary2DOutput);
            Debug.Result(_result, "xrGetSpaceBoundary2DFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceRoomLayoutFBDelegate(XrSession session, XrSpace space, XrRoomLayoutFB* roomLayoutOutput);
		private static xrGetSpaceRoomLayoutFBDelegate xrGetSpaceRoomLayoutFB_ptr;
		public static XrResult xrGetSpaceRoomLayoutFB(XrSession session, XrSpace space, XrRoomLayoutFB* roomLayoutOutput)
        {
            xrGetSpaceRoomLayoutFB_ptr ??= LoadFunction<xrGetSpaceRoomLayoutFBDelegate>("xrGetSpaceRoomLayoutFB");
            XrResult _result = xrGetSpaceRoomLayoutFB_ptr(session, space, roomLayoutOutput);
            Debug.Result(_result, "xrGetSpaceRoomLayoutFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetDigitalLensControlALMALENCEDelegate(XrSession session, XrDigitalLensControlALMALENCE* digitalLensControl);
		private static xrSetDigitalLensControlALMALENCEDelegate xrSetDigitalLensControlALMALENCE_ptr;
		public static XrResult xrSetDigitalLensControlALMALENCE(XrSession session, XrDigitalLensControlALMALENCE* digitalLensControl)
        {
            xrSetDigitalLensControlALMALENCE_ptr ??= LoadFunction<xrSetDigitalLensControlALMALENCEDelegate>("xrSetDigitalLensControlALMALENCE");
            XrResult _result = xrSetDigitalLensControlALMALENCE_ptr(session, digitalLensControl);
            Debug.Result(_result, "xrSetDigitalLensControlALMALENCE");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestSceneCaptureFBDelegate(XrSession session, XrSceneCaptureRequestInfoFB* info, ulong* requestId);
		private static xrRequestSceneCaptureFBDelegate xrRequestSceneCaptureFB_ptr;
		public static XrResult xrRequestSceneCaptureFB(XrSession session, XrSceneCaptureRequestInfoFB* info, ulong* requestId)
        {
            xrRequestSceneCaptureFB_ptr ??= LoadFunction<xrRequestSceneCaptureFBDelegate>("xrRequestSceneCaptureFB");
            XrResult _result = xrRequestSceneCaptureFB_ptr(session, info, requestId);
            Debug.Result(_result, "xrRequestSceneCaptureFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceContainerFBDelegate(XrSession session, XrSpace space, XrSpaceContainerFB* spaceContainerOutput);
		private static xrGetSpaceContainerFBDelegate xrGetSpaceContainerFB_ptr;
		public static XrResult xrGetSpaceContainerFB(XrSession session, XrSpace space, XrSpaceContainerFB* spaceContainerOutput)
        {
            xrGetSpaceContainerFB_ptr ??= LoadFunction<xrGetSpaceContainerFBDelegate>("xrGetSpaceContainerFB");
            XrResult _result = xrGetSpaceContainerFB_ptr(session, space, spaceContainerOutput);
            Debug.Result(_result, "xrGetSpaceContainerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetFoveationEyeTrackedStateMETADelegate(XrSession session, XrFoveationEyeTrackedStateMETA* foveationState);
		private static xrGetFoveationEyeTrackedStateMETADelegate xrGetFoveationEyeTrackedStateMETA_ptr;
		public static XrResult xrGetFoveationEyeTrackedStateMETA(XrSession session, XrFoveationEyeTrackedStateMETA* foveationState)
        {
            xrGetFoveationEyeTrackedStateMETA_ptr ??= LoadFunction<xrGetFoveationEyeTrackedStateMETADelegate>("xrGetFoveationEyeTrackedStateMETA");
            XrResult _result = xrGetFoveationEyeTrackedStateMETA_ptr(session, foveationState);
            Debug.Result(_result, "xrGetFoveationEyeTrackedStateMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateFaceTrackerFBDelegate(XrSession session, XrFaceTrackerCreateInfoFB* createInfo, XrFaceTrackerFB* faceTracker);
		private static xrCreateFaceTrackerFBDelegate xrCreateFaceTrackerFB_ptr;
		public static XrResult xrCreateFaceTrackerFB(XrSession session, XrFaceTrackerCreateInfoFB* createInfo, XrFaceTrackerFB* faceTracker)
        {
            xrCreateFaceTrackerFB_ptr ??= LoadFunction<xrCreateFaceTrackerFBDelegate>("xrCreateFaceTrackerFB");
            XrResult _result = xrCreateFaceTrackerFB_ptr(session, createInfo, faceTracker);
            Debug.Result(_result, "xrCreateFaceTrackerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyFaceTrackerFBDelegate(XrFaceTrackerFB faceTracker);
		private static xrDestroyFaceTrackerFBDelegate xrDestroyFaceTrackerFB_ptr;
		public static XrResult xrDestroyFaceTrackerFB(XrFaceTrackerFB faceTracker)
        {
            xrDestroyFaceTrackerFB_ptr ??= LoadFunction<xrDestroyFaceTrackerFBDelegate>("xrDestroyFaceTrackerFB");
            XrResult _result = xrDestroyFaceTrackerFB_ptr(faceTracker);
            Debug.Result(_result, "xrDestroyFaceTrackerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetFaceExpressionWeightsFBDelegate(XrFaceTrackerFB faceTracker, XrFaceExpressionInfoFB* expressionInfo, XrFaceExpressionWeightsFB* expressionWeights);
		private static xrGetFaceExpressionWeightsFBDelegate xrGetFaceExpressionWeightsFB_ptr;
		public static XrResult xrGetFaceExpressionWeightsFB(XrFaceTrackerFB faceTracker, XrFaceExpressionInfoFB* expressionInfo, XrFaceExpressionWeightsFB* expressionWeights)
        {
            xrGetFaceExpressionWeightsFB_ptr ??= LoadFunction<xrGetFaceExpressionWeightsFBDelegate>("xrGetFaceExpressionWeightsFB");
            XrResult _result = xrGetFaceExpressionWeightsFB_ptr(faceTracker, expressionInfo, expressionWeights);
            Debug.Result(_result, "xrGetFaceExpressionWeightsFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateEyeTrackerFBDelegate(XrSession session, XrEyeTrackerCreateInfoFB* createInfo, XrEyeTrackerFB* eyeTracker);
		private static xrCreateEyeTrackerFBDelegate xrCreateEyeTrackerFB_ptr;
		public static XrResult xrCreateEyeTrackerFB(XrSession session, XrEyeTrackerCreateInfoFB* createInfo, XrEyeTrackerFB* eyeTracker)
        {
            xrCreateEyeTrackerFB_ptr ??= LoadFunction<xrCreateEyeTrackerFBDelegate>("xrCreateEyeTrackerFB");
            XrResult _result = xrCreateEyeTrackerFB_ptr(session, createInfo, eyeTracker);
            Debug.Result(_result, "xrCreateEyeTrackerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyEyeTrackerFBDelegate(XrEyeTrackerFB eyeTracker);
		private static xrDestroyEyeTrackerFBDelegate xrDestroyEyeTrackerFB_ptr;
		public static XrResult xrDestroyEyeTrackerFB(XrEyeTrackerFB eyeTracker)
        {
            xrDestroyEyeTrackerFB_ptr ??= LoadFunction<xrDestroyEyeTrackerFBDelegate>("xrDestroyEyeTrackerFB");
            XrResult _result = xrDestroyEyeTrackerFB_ptr(eyeTracker);
            Debug.Result(_result, "xrDestroyEyeTrackerFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetEyeGazesFBDelegate(XrEyeTrackerFB eyeTracker, XrEyeGazesInfoFB* gazeInfo, XrEyeGazesFB* eyeGazes);
		private static xrGetEyeGazesFBDelegate xrGetEyeGazesFB_ptr;
		public static XrResult xrGetEyeGazesFB(XrEyeTrackerFB eyeTracker, XrEyeGazesInfoFB* gazeInfo, XrEyeGazesFB* eyeGazes)
        {
            xrGetEyeGazesFB_ptr ??= LoadFunction<xrGetEyeGazesFBDelegate>("xrGetEyeGazesFB");
            XrResult _result = xrGetEyeGazesFB_ptr(eyeTracker, gazeInfo, eyeGazes);
            Debug.Result(_result, "xrGetEyeGazesFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPassthroughLayerSetKeyboardHandsIntensityFBDelegate(XrPassthroughLayerFB layer, XrPassthroughKeyboardHandsIntensityFB* intensity);
		private static xrPassthroughLayerSetKeyboardHandsIntensityFBDelegate xrPassthroughLayerSetKeyboardHandsIntensityFB_ptr;
		public static XrResult xrPassthroughLayerSetKeyboardHandsIntensityFB(XrPassthroughLayerFB layer, XrPassthroughKeyboardHandsIntensityFB* intensity)
        {
            xrPassthroughLayerSetKeyboardHandsIntensityFB_ptr ??= LoadFunction<xrPassthroughLayerSetKeyboardHandsIntensityFBDelegate>("xrPassthroughLayerSetKeyboardHandsIntensityFB");
            XrResult _result = xrPassthroughLayerSetKeyboardHandsIntensityFB_ptr(layer, intensity);
            Debug.Result(_result, "xrPassthroughLayerSetKeyboardHandsIntensityFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetDeviceSampleRateFBDelegate(XrSession session, XrHapticActionInfo* hapticActionInfo, XrDevicePcmSampleRateStateFB* deviceSampleRate);
		private static xrGetDeviceSampleRateFBDelegate xrGetDeviceSampleRateFB_ptr;
		public static XrResult xrGetDeviceSampleRateFB(XrSession session, XrHapticActionInfo* hapticActionInfo, XrDevicePcmSampleRateStateFB* deviceSampleRate)
        {
            xrGetDeviceSampleRateFB_ptr ??= LoadFunction<xrGetDeviceSampleRateFBDelegate>("xrGetDeviceSampleRateFB");
            XrResult _result = xrGetDeviceSampleRateFB_ptr(session, hapticActionInfo, deviceSampleRate);
            Debug.Result(_result, "xrGetDeviceSampleRateFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetPassthroughPreferencesMETADelegate(XrSession session, XrPassthroughPreferencesMETA* preferences);
		private static xrGetPassthroughPreferencesMETADelegate xrGetPassthroughPreferencesMETA_ptr;
		public static XrResult xrGetPassthroughPreferencesMETA(XrSession session, XrPassthroughPreferencesMETA* preferences)
        {
            xrGetPassthroughPreferencesMETA_ptr ??= LoadFunction<xrGetPassthroughPreferencesMETADelegate>("xrGetPassthroughPreferencesMETA");
            XrResult _result = xrGetPassthroughPreferencesMETA_ptr(session, preferences);
            Debug.Result(_result, "xrGetPassthroughPreferencesMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateVirtualKeyboardMETADelegate(XrSession session, XrVirtualKeyboardCreateInfoMETA* createInfo, XrVirtualKeyboardMETA* keyboard);
		private static xrCreateVirtualKeyboardMETADelegate xrCreateVirtualKeyboardMETA_ptr;
		public static XrResult xrCreateVirtualKeyboardMETA(XrSession session, XrVirtualKeyboardCreateInfoMETA* createInfo, XrVirtualKeyboardMETA* keyboard)
        {
            xrCreateVirtualKeyboardMETA_ptr ??= LoadFunction<xrCreateVirtualKeyboardMETADelegate>("xrCreateVirtualKeyboardMETA");
            XrResult _result = xrCreateVirtualKeyboardMETA_ptr(session, createInfo, keyboard);
            Debug.Result(_result, "xrCreateVirtualKeyboardMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyVirtualKeyboardMETADelegate(XrVirtualKeyboardMETA keyboard);
		private static xrDestroyVirtualKeyboardMETADelegate xrDestroyVirtualKeyboardMETA_ptr;
		public static XrResult xrDestroyVirtualKeyboardMETA(XrVirtualKeyboardMETA keyboard)
        {
            xrDestroyVirtualKeyboardMETA_ptr ??= LoadFunction<xrDestroyVirtualKeyboardMETADelegate>("xrDestroyVirtualKeyboardMETA");
            XrResult _result = xrDestroyVirtualKeyboardMETA_ptr(keyboard);
            Debug.Result(_result, "xrDestroyVirtualKeyboardMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateVirtualKeyboardSpaceMETADelegate(XrSession session, XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardSpaceCreateInfoMETA* createInfo, XrSpace* keyboardSpace);
		private static xrCreateVirtualKeyboardSpaceMETADelegate xrCreateVirtualKeyboardSpaceMETA_ptr;
		public static XrResult xrCreateVirtualKeyboardSpaceMETA(XrSession session, XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardSpaceCreateInfoMETA* createInfo, XrSpace* keyboardSpace)
        {
            xrCreateVirtualKeyboardSpaceMETA_ptr ??= LoadFunction<xrCreateVirtualKeyboardSpaceMETADelegate>("xrCreateVirtualKeyboardSpaceMETA");
            XrResult _result = xrCreateVirtualKeyboardSpaceMETA_ptr(session, keyboard, createInfo, keyboardSpace);
            Debug.Result(_result, "xrCreateVirtualKeyboardSpaceMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSuggestVirtualKeyboardLocationMETADelegate(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardLocationInfoMETA* locationInfo);
		private static xrSuggestVirtualKeyboardLocationMETADelegate xrSuggestVirtualKeyboardLocationMETA_ptr;
		public static XrResult xrSuggestVirtualKeyboardLocationMETA(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardLocationInfoMETA* locationInfo)
        {
            xrSuggestVirtualKeyboardLocationMETA_ptr ??= LoadFunction<xrSuggestVirtualKeyboardLocationMETADelegate>("xrSuggestVirtualKeyboardLocationMETA");
            XrResult _result = xrSuggestVirtualKeyboardLocationMETA_ptr(keyboard, locationInfo);
            Debug.Result(_result, "xrSuggestVirtualKeyboardLocationMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVirtualKeyboardScaleMETADelegate(XrVirtualKeyboardMETA keyboard, float* scale);
		private static xrGetVirtualKeyboardScaleMETADelegate xrGetVirtualKeyboardScaleMETA_ptr;
		public static XrResult xrGetVirtualKeyboardScaleMETA(XrVirtualKeyboardMETA keyboard, float* scale)
        {
            xrGetVirtualKeyboardScaleMETA_ptr ??= LoadFunction<xrGetVirtualKeyboardScaleMETADelegate>("xrGetVirtualKeyboardScaleMETA");
            XrResult _result = xrGetVirtualKeyboardScaleMETA_ptr(keyboard, scale);
            Debug.Result(_result, "xrGetVirtualKeyboardScaleMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetVirtualKeyboardModelVisibilityMETADelegate(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardModelVisibilitySetInfoMETA* modelVisibility);
		private static xrSetVirtualKeyboardModelVisibilityMETADelegate xrSetVirtualKeyboardModelVisibilityMETA_ptr;
		public static XrResult xrSetVirtualKeyboardModelVisibilityMETA(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardModelVisibilitySetInfoMETA* modelVisibility)
        {
            xrSetVirtualKeyboardModelVisibilityMETA_ptr ??= LoadFunction<xrSetVirtualKeyboardModelVisibilityMETADelegate>("xrSetVirtualKeyboardModelVisibilityMETA");
            XrResult _result = xrSetVirtualKeyboardModelVisibilityMETA_ptr(keyboard, modelVisibility);
            Debug.Result(_result, "xrSetVirtualKeyboardModelVisibilityMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVirtualKeyboardModelAnimationStatesMETADelegate(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardModelAnimationStatesMETA* animationStates);
		private static xrGetVirtualKeyboardModelAnimationStatesMETADelegate xrGetVirtualKeyboardModelAnimationStatesMETA_ptr;
		public static XrResult xrGetVirtualKeyboardModelAnimationStatesMETA(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardModelAnimationStatesMETA* animationStates)
        {
            xrGetVirtualKeyboardModelAnimationStatesMETA_ptr ??= LoadFunction<xrGetVirtualKeyboardModelAnimationStatesMETADelegate>("xrGetVirtualKeyboardModelAnimationStatesMETA");
            XrResult _result = xrGetVirtualKeyboardModelAnimationStatesMETA_ptr(keyboard, animationStates);
            Debug.Result(_result, "xrGetVirtualKeyboardModelAnimationStatesMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVirtualKeyboardDirtyTexturesMETADelegate(XrVirtualKeyboardMETA keyboard, uint textureIdCapacityInput, uint* textureIdCountOutput, ulong* textureIds);
		private static xrGetVirtualKeyboardDirtyTexturesMETADelegate xrGetVirtualKeyboardDirtyTexturesMETA_ptr;
		public static XrResult xrGetVirtualKeyboardDirtyTexturesMETA(XrVirtualKeyboardMETA keyboard, uint textureIdCapacityInput, uint* textureIdCountOutput, ulong* textureIds)
        {
            xrGetVirtualKeyboardDirtyTexturesMETA_ptr ??= LoadFunction<xrGetVirtualKeyboardDirtyTexturesMETADelegate>("xrGetVirtualKeyboardDirtyTexturesMETA");
            XrResult _result = xrGetVirtualKeyboardDirtyTexturesMETA_ptr(keyboard, textureIdCapacityInput, textureIdCountOutput, textureIds);
            Debug.Result(_result, "xrGetVirtualKeyboardDirtyTexturesMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetVirtualKeyboardTextureDataMETADelegate(XrVirtualKeyboardMETA keyboard, ulong textureId, XrVirtualKeyboardTextureDataMETA* textureData);
		private static xrGetVirtualKeyboardTextureDataMETADelegate xrGetVirtualKeyboardTextureDataMETA_ptr;
		public static XrResult xrGetVirtualKeyboardTextureDataMETA(XrVirtualKeyboardMETA keyboard, ulong textureId, XrVirtualKeyboardTextureDataMETA* textureData)
        {
            xrGetVirtualKeyboardTextureDataMETA_ptr ??= LoadFunction<xrGetVirtualKeyboardTextureDataMETADelegate>("xrGetVirtualKeyboardTextureDataMETA");
            XrResult _result = xrGetVirtualKeyboardTextureDataMETA_ptr(keyboard, textureId, textureData);
            Debug.Result(_result, "xrGetVirtualKeyboardTextureDataMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSendVirtualKeyboardInputMETADelegate(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardInputInfoMETA* info, XrPosef* interactorRootPose);
		private static xrSendVirtualKeyboardInputMETADelegate xrSendVirtualKeyboardInputMETA_ptr;
		public static XrResult xrSendVirtualKeyboardInputMETA(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardInputInfoMETA* info, XrPosef* interactorRootPose)
        {
            xrSendVirtualKeyboardInputMETA_ptr ??= LoadFunction<xrSendVirtualKeyboardInputMETADelegate>("xrSendVirtualKeyboardInputMETA");
            XrResult _result = xrSendVirtualKeyboardInputMETA_ptr(keyboard, info, interactorRootPose);
            Debug.Result(_result, "xrSendVirtualKeyboardInputMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrChangeVirtualKeyboardTextContextMETADelegate(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardTextContextChangeInfoMETA* changeInfo);
		private static xrChangeVirtualKeyboardTextContextMETADelegate xrChangeVirtualKeyboardTextContextMETA_ptr;
		public static XrResult xrChangeVirtualKeyboardTextContextMETA(XrVirtualKeyboardMETA keyboard, XrVirtualKeyboardTextContextChangeInfoMETA* changeInfo)
        {
            xrChangeVirtualKeyboardTextContextMETA_ptr ??= LoadFunction<xrChangeVirtualKeyboardTextContextMETADelegate>("xrChangeVirtualKeyboardTextContextMETA");
            XrResult _result = xrChangeVirtualKeyboardTextContextMETA_ptr(keyboard, changeInfo);
            Debug.Result(_result, "xrChangeVirtualKeyboardTextContextMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateExternalCamerasOCULUSDelegate(XrSession session, uint cameraCapacityInput, uint* cameraCountOutput, XrExternalCameraOCULUS* cameras);
		private static xrEnumerateExternalCamerasOCULUSDelegate xrEnumerateExternalCamerasOCULUS_ptr;
		public static XrResult xrEnumerateExternalCamerasOCULUS(XrSession session, uint cameraCapacityInput, uint* cameraCountOutput, XrExternalCameraOCULUS* cameras)
        {
            xrEnumerateExternalCamerasOCULUS_ptr ??= LoadFunction<xrEnumerateExternalCamerasOCULUSDelegate>("xrEnumerateExternalCamerasOCULUS");
            XrResult _result = xrEnumerateExternalCamerasOCULUS_ptr(session, cameraCapacityInput, cameraCountOutput, cameras);
            Debug.Result(_result, "xrEnumerateExternalCamerasOCULUS");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumeratePerformanceMetricsCounterPathsMETADelegate(XrInstance instance, uint counterPathCapacityInput, uint* counterPathCountOutput, ulong* counterPaths);
		private static xrEnumeratePerformanceMetricsCounterPathsMETADelegate xrEnumeratePerformanceMetricsCounterPathsMETA_ptr;
		public static XrResult xrEnumeratePerformanceMetricsCounterPathsMETA(XrInstance instance, uint counterPathCapacityInput, uint* counterPathCountOutput, ulong* counterPaths)
        {
            xrEnumeratePerformanceMetricsCounterPathsMETA_ptr ??= LoadFunction<xrEnumeratePerformanceMetricsCounterPathsMETADelegate>("xrEnumeratePerformanceMetricsCounterPathsMETA");
            XrResult _result = xrEnumeratePerformanceMetricsCounterPathsMETA_ptr(instance, counterPathCapacityInput, counterPathCountOutput, counterPaths);
            Debug.Result(_result, "xrEnumeratePerformanceMetricsCounterPathsMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetPerformanceMetricsStateMETADelegate(XrSession session, XrPerformanceMetricsStateMETA* state);
		private static xrSetPerformanceMetricsStateMETADelegate xrSetPerformanceMetricsStateMETA_ptr;
		public static XrResult xrSetPerformanceMetricsStateMETA(XrSession session, XrPerformanceMetricsStateMETA* state)
        {
            xrSetPerformanceMetricsStateMETA_ptr ??= LoadFunction<xrSetPerformanceMetricsStateMETADelegate>("xrSetPerformanceMetricsStateMETA");
            XrResult _result = xrSetPerformanceMetricsStateMETA_ptr(session, state);
            Debug.Result(_result, "xrSetPerformanceMetricsStateMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetPerformanceMetricsStateMETADelegate(XrSession session, XrPerformanceMetricsStateMETA* state);
		private static xrGetPerformanceMetricsStateMETADelegate xrGetPerformanceMetricsStateMETA_ptr;
		public static XrResult xrGetPerformanceMetricsStateMETA(XrSession session, XrPerformanceMetricsStateMETA* state)
        {
            xrGetPerformanceMetricsStateMETA_ptr ??= LoadFunction<xrGetPerformanceMetricsStateMETADelegate>("xrGetPerformanceMetricsStateMETA");
            XrResult _result = xrGetPerformanceMetricsStateMETA_ptr(session, state);
            Debug.Result(_result, "xrGetPerformanceMetricsStateMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQueryPerformanceMetricsCounterMETADelegate(XrSession session, ulong counterPath, XrPerformanceMetricsCounterMETA* counter);
		private static xrQueryPerformanceMetricsCounterMETADelegate xrQueryPerformanceMetricsCounterMETA_ptr;
		public static XrResult xrQueryPerformanceMetricsCounterMETA(XrSession session, ulong counterPath, XrPerformanceMetricsCounterMETA* counter)
        {
            xrQueryPerformanceMetricsCounterMETA_ptr ??= LoadFunction<xrQueryPerformanceMetricsCounterMETADelegate>("xrQueryPerformanceMetricsCounterMETA");
            XrResult _result = xrQueryPerformanceMetricsCounterMETA_ptr(session, counterPath, counter);
            Debug.Result(_result, "xrQueryPerformanceMetricsCounterMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSaveSpaceListFBDelegate(XrSession session, XrSpaceListSaveInfoFB* info, ulong* requestId);
		private static xrSaveSpaceListFBDelegate xrSaveSpaceListFB_ptr;
		public static XrResult xrSaveSpaceListFB(XrSession session, XrSpaceListSaveInfoFB* info, ulong* requestId)
        {
            xrSaveSpaceListFB_ptr ??= LoadFunction<xrSaveSpaceListFBDelegate>("xrSaveSpaceListFB");
            XrResult _result = xrSaveSpaceListFB_ptr(session, info, requestId);
            Debug.Result(_result, "xrSaveSpaceListFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpaceUserFBDelegate(XrSession session, XrSpaceUserCreateInfoFB* info, XrSpaceUserFB* user);
		private static xrCreateSpaceUserFBDelegate xrCreateSpaceUserFB_ptr;
		public static XrResult xrCreateSpaceUserFB(XrSession session, XrSpaceUserCreateInfoFB* info, XrSpaceUserFB* user)
        {
            xrCreateSpaceUserFB_ptr ??= LoadFunction<xrCreateSpaceUserFBDelegate>("xrCreateSpaceUserFB");
            XrResult _result = xrCreateSpaceUserFB_ptr(session, info, user);
            Debug.Result(_result, "xrCreateSpaceUserFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceUserIdFBDelegate(XrSpaceUserFB user, ulong* userId);
		private static xrGetSpaceUserIdFBDelegate xrGetSpaceUserIdFB_ptr;
		public static XrResult xrGetSpaceUserIdFB(XrSpaceUserFB user, ulong* userId)
        {
            xrGetSpaceUserIdFB_ptr ??= LoadFunction<xrGetSpaceUserIdFBDelegate>("xrGetSpaceUserIdFB");
            XrResult _result = xrGetSpaceUserIdFB_ptr(user, userId);
            Debug.Result(_result, "xrGetSpaceUserIdFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpaceUserFBDelegate(XrSpaceUserFB user);
		private static xrDestroySpaceUserFBDelegate xrDestroySpaceUserFB_ptr;
		public static XrResult xrDestroySpaceUserFB(XrSpaceUserFB user)
        {
            xrDestroySpaceUserFB_ptr ??= LoadFunction<xrDestroySpaceUserFBDelegate>("xrDestroySpaceUserFB");
            XrResult _result = xrDestroySpaceUserFB_ptr(user);
            Debug.Result(_result, "xrDestroySpaceUserFB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetRecommendedLayerResolutionMETADelegate(XrSession session, XrRecommendedLayerResolutionGetInfoMETA* info, XrRecommendedLayerResolutionMETA* resolution);
		private static xrGetRecommendedLayerResolutionMETADelegate xrGetRecommendedLayerResolutionMETA_ptr;
		public static XrResult xrGetRecommendedLayerResolutionMETA(XrSession session, XrRecommendedLayerResolutionGetInfoMETA* info, XrRecommendedLayerResolutionMETA* resolution)
        {
            xrGetRecommendedLayerResolutionMETA_ptr ??= LoadFunction<xrGetRecommendedLayerResolutionMETADelegate>("xrGetRecommendedLayerResolutionMETA");
            XrResult _result = xrGetRecommendedLayerResolutionMETA_ptr(session, info, resolution);
            Debug.Result(_result, "xrGetRecommendedLayerResolutionMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSaveSpacesMETADelegate(XrSession session, XrSpacesSaveInfoMETA* info, ulong* requestId);
		private static xrSaveSpacesMETADelegate xrSaveSpacesMETA_ptr;
		public static XrResult xrSaveSpacesMETA(XrSession session, XrSpacesSaveInfoMETA* info, ulong* requestId)
        {
            xrSaveSpacesMETA_ptr ??= LoadFunction<xrSaveSpacesMETADelegate>("xrSaveSpacesMETA");
            XrResult _result = xrSaveSpacesMETA_ptr(session, info, requestId);
            Debug.Result(_result, "xrSaveSpacesMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEraseSpacesMETADelegate(XrSession session, XrSpacesEraseInfoMETA* info, ulong* requestId);
		private static xrEraseSpacesMETADelegate xrEraseSpacesMETA_ptr;
		public static XrResult xrEraseSpacesMETA(XrSession session, XrSpacesEraseInfoMETA* info, ulong* requestId)
        {
            xrEraseSpacesMETA_ptr ??= LoadFunction<xrEraseSpacesMETADelegate>("xrEraseSpacesMETA");
            XrResult _result = xrEraseSpacesMETA_ptr(session, info, requestId);
            Debug.Result(_result, "xrEraseSpacesMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreatePassthroughColorLutMETADelegate(XrPassthroughFB passthrough, XrPassthroughColorLutCreateInfoMETA* createInfo, XrPassthroughColorLutMETA* colorLut);
		private static xrCreatePassthroughColorLutMETADelegate xrCreatePassthroughColorLutMETA_ptr;
		public static XrResult xrCreatePassthroughColorLutMETA(XrPassthroughFB passthrough, XrPassthroughColorLutCreateInfoMETA* createInfo, XrPassthroughColorLutMETA* colorLut)
        {
            xrCreatePassthroughColorLutMETA_ptr ??= LoadFunction<xrCreatePassthroughColorLutMETADelegate>("xrCreatePassthroughColorLutMETA");
            XrResult _result = xrCreatePassthroughColorLutMETA_ptr(passthrough, createInfo, colorLut);
            Debug.Result(_result, "xrCreatePassthroughColorLutMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyPassthroughColorLutMETADelegate(XrPassthroughColorLutMETA colorLut);
		private static xrDestroyPassthroughColorLutMETADelegate xrDestroyPassthroughColorLutMETA_ptr;
		public static XrResult xrDestroyPassthroughColorLutMETA(XrPassthroughColorLutMETA colorLut)
        {
            xrDestroyPassthroughColorLutMETA_ptr ??= LoadFunction<xrDestroyPassthroughColorLutMETADelegate>("xrDestroyPassthroughColorLutMETA");
            XrResult _result = xrDestroyPassthroughColorLutMETA_ptr(colorLut);
            Debug.Result(_result, "xrDestroyPassthroughColorLutMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUpdatePassthroughColorLutMETADelegate(XrPassthroughColorLutMETA colorLut, XrPassthroughColorLutUpdateInfoMETA* updateInfo);
		private static xrUpdatePassthroughColorLutMETADelegate xrUpdatePassthroughColorLutMETA_ptr;
		public static XrResult xrUpdatePassthroughColorLutMETA(XrPassthroughColorLutMETA colorLut, XrPassthroughColorLutUpdateInfoMETA* updateInfo)
        {
            xrUpdatePassthroughColorLutMETA_ptr ??= LoadFunction<xrUpdatePassthroughColorLutMETADelegate>("xrUpdatePassthroughColorLutMETA");
            XrResult _result = xrUpdatePassthroughColorLutMETA_ptr(colorLut, updateInfo);
            Debug.Result(_result, "xrUpdatePassthroughColorLutMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpaceTriangleMeshMETADelegate(XrSpace space, XrSpaceTriangleMeshGetInfoMETA* getInfo, XrSpaceTriangleMeshMETA* triangleMeshOutput);
		private static xrGetSpaceTriangleMeshMETADelegate xrGetSpaceTriangleMeshMETA_ptr;
		public static XrResult xrGetSpaceTriangleMeshMETA(XrSpace space, XrSpaceTriangleMeshGetInfoMETA* getInfo, XrSpaceTriangleMeshMETA* triangleMeshOutput)
        {
            xrGetSpaceTriangleMeshMETA_ptr ??= LoadFunction<xrGetSpaceTriangleMeshMETADelegate>("xrGetSpaceTriangleMeshMETA");
            XrResult _result = xrGetSpaceTriangleMeshMETA_ptr(space, getInfo, triangleMeshOutput);
            Debug.Result(_result, "xrGetSpaceTriangleMeshMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSuggestBodyTrackingCalibrationOverrideMETADelegate(XrBodyTrackerFB bodyTracker, XrBodyTrackingCalibrationInfoMETA* calibrationInfo);
		private static xrSuggestBodyTrackingCalibrationOverrideMETADelegate xrSuggestBodyTrackingCalibrationOverrideMETA_ptr;
		public static XrResult xrSuggestBodyTrackingCalibrationOverrideMETA(XrBodyTrackerFB bodyTracker, XrBodyTrackingCalibrationInfoMETA* calibrationInfo)
        {
            xrSuggestBodyTrackingCalibrationOverrideMETA_ptr ??= LoadFunction<xrSuggestBodyTrackingCalibrationOverrideMETADelegate>("xrSuggestBodyTrackingCalibrationOverrideMETA");
            XrResult _result = xrSuggestBodyTrackingCalibrationOverrideMETA_ptr(bodyTracker, calibrationInfo);
            Debug.Result(_result, "xrSuggestBodyTrackingCalibrationOverrideMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrResetBodyTrackingCalibrationMETADelegate(XrBodyTrackerFB bodyTracker);
		private static xrResetBodyTrackingCalibrationMETADelegate xrResetBodyTrackingCalibrationMETA_ptr;
		public static XrResult xrResetBodyTrackingCalibrationMETA(XrBodyTrackerFB bodyTracker)
        {
            xrResetBodyTrackingCalibrationMETA_ptr ??= LoadFunction<xrResetBodyTrackingCalibrationMETADelegate>("xrResetBodyTrackingCalibrationMETA");
            XrResult _result = xrResetBodyTrackingCalibrationMETA_ptr(bodyTracker);
            Debug.Result(_result, "xrResetBodyTrackingCalibrationMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateFaceTracker2FBDelegate(XrSession session, XrFaceTrackerCreateInfo2FB* createInfo, XrFaceTracker2FB* faceTracker);
		private static xrCreateFaceTracker2FBDelegate xrCreateFaceTracker2FB_ptr;
		public static XrResult xrCreateFaceTracker2FB(XrSession session, XrFaceTrackerCreateInfo2FB* createInfo, XrFaceTracker2FB* faceTracker)
        {
            xrCreateFaceTracker2FB_ptr ??= LoadFunction<xrCreateFaceTracker2FBDelegate>("xrCreateFaceTracker2FB");
            XrResult _result = xrCreateFaceTracker2FB_ptr(session, createInfo, faceTracker);
            Debug.Result(_result, "xrCreateFaceTracker2FB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyFaceTracker2FBDelegate(XrFaceTracker2FB faceTracker);
		private static xrDestroyFaceTracker2FBDelegate xrDestroyFaceTracker2FB_ptr;
		public static XrResult xrDestroyFaceTracker2FB(XrFaceTracker2FB faceTracker)
        {
            xrDestroyFaceTracker2FB_ptr ??= LoadFunction<xrDestroyFaceTracker2FBDelegate>("xrDestroyFaceTracker2FB");
            XrResult _result = xrDestroyFaceTracker2FB_ptr(faceTracker);
            Debug.Result(_result, "xrDestroyFaceTracker2FB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetFaceExpressionWeights2FBDelegate(XrFaceTracker2FB faceTracker, XrFaceExpressionInfo2FB* expressionInfo, XrFaceExpressionWeights2FB* expressionWeights);
		private static xrGetFaceExpressionWeights2FBDelegate xrGetFaceExpressionWeights2FB_ptr;
		public static XrResult xrGetFaceExpressionWeights2FB(XrFaceTracker2FB faceTracker, XrFaceExpressionInfo2FB* expressionInfo, XrFaceExpressionWeights2FB* expressionWeights)
        {
            xrGetFaceExpressionWeights2FB_ptr ??= LoadFunction<xrGetFaceExpressionWeights2FBDelegate>("xrGetFaceExpressionWeights2FB");
            XrResult _result = xrGetFaceExpressionWeights2FB_ptr(faceTracker, expressionInfo, expressionWeights);
            Debug.Result(_result, "xrGetFaceExpressionWeights2FB");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrShareSpacesMETADelegate(XrSession session, XrShareSpacesInfoMETA* info, ulong* requestId);
		private static xrShareSpacesMETADelegate xrShareSpacesMETA_ptr;
		public static XrResult xrShareSpacesMETA(XrSession session, XrShareSpacesInfoMETA* info, ulong* requestId)
        {
            xrShareSpacesMETA_ptr ??= LoadFunction<xrShareSpacesMETADelegate>("xrShareSpacesMETA");
            XrResult _result = xrShareSpacesMETA_ptr(session, info, requestId);
            Debug.Result(_result, "xrShareSpacesMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateEnvironmentDepthProviderMETADelegate(XrSession session, XrEnvironmentDepthProviderCreateInfoMETA* createInfo, XrEnvironmentDepthProviderMETA* environmentDepthProvider);
		private static xrCreateEnvironmentDepthProviderMETADelegate xrCreateEnvironmentDepthProviderMETA_ptr;
		public static XrResult xrCreateEnvironmentDepthProviderMETA(XrSession session, XrEnvironmentDepthProviderCreateInfoMETA* createInfo, XrEnvironmentDepthProviderMETA* environmentDepthProvider)
        {
            xrCreateEnvironmentDepthProviderMETA_ptr ??= LoadFunction<xrCreateEnvironmentDepthProviderMETADelegate>("xrCreateEnvironmentDepthProviderMETA");
            XrResult _result = xrCreateEnvironmentDepthProviderMETA_ptr(session, createInfo, environmentDepthProvider);
            Debug.Result(_result, "xrCreateEnvironmentDepthProviderMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyEnvironmentDepthProviderMETADelegate(XrEnvironmentDepthProviderMETA environmentDepthProvider);
		private static xrDestroyEnvironmentDepthProviderMETADelegate xrDestroyEnvironmentDepthProviderMETA_ptr;
		public static XrResult xrDestroyEnvironmentDepthProviderMETA(XrEnvironmentDepthProviderMETA environmentDepthProvider)
        {
            xrDestroyEnvironmentDepthProviderMETA_ptr ??= LoadFunction<xrDestroyEnvironmentDepthProviderMETADelegate>("xrDestroyEnvironmentDepthProviderMETA");
            XrResult _result = xrDestroyEnvironmentDepthProviderMETA_ptr(environmentDepthProvider);
            Debug.Result(_result, "xrDestroyEnvironmentDepthProviderMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStartEnvironmentDepthProviderMETADelegate(XrEnvironmentDepthProviderMETA environmentDepthProvider);
		private static xrStartEnvironmentDepthProviderMETADelegate xrStartEnvironmentDepthProviderMETA_ptr;
		public static XrResult xrStartEnvironmentDepthProviderMETA(XrEnvironmentDepthProviderMETA environmentDepthProvider)
        {
            xrStartEnvironmentDepthProviderMETA_ptr ??= LoadFunction<xrStartEnvironmentDepthProviderMETADelegate>("xrStartEnvironmentDepthProviderMETA");
            XrResult _result = xrStartEnvironmentDepthProviderMETA_ptr(environmentDepthProvider);
            Debug.Result(_result, "xrStartEnvironmentDepthProviderMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStopEnvironmentDepthProviderMETADelegate(XrEnvironmentDepthProviderMETA environmentDepthProvider);
		private static xrStopEnvironmentDepthProviderMETADelegate xrStopEnvironmentDepthProviderMETA_ptr;
		public static XrResult xrStopEnvironmentDepthProviderMETA(XrEnvironmentDepthProviderMETA environmentDepthProvider)
        {
            xrStopEnvironmentDepthProviderMETA_ptr ??= LoadFunction<xrStopEnvironmentDepthProviderMETADelegate>("xrStopEnvironmentDepthProviderMETA");
            XrResult _result = xrStopEnvironmentDepthProviderMETA_ptr(environmentDepthProvider);
            Debug.Result(_result, "xrStopEnvironmentDepthProviderMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateEnvironmentDepthSwapchainMETADelegate(XrEnvironmentDepthProviderMETA environmentDepthProvider, XrEnvironmentDepthSwapchainCreateInfoMETA* createInfo, XrEnvironmentDepthSwapchainMETA* swapchain);
		private static xrCreateEnvironmentDepthSwapchainMETADelegate xrCreateEnvironmentDepthSwapchainMETA_ptr;
		public static XrResult xrCreateEnvironmentDepthSwapchainMETA(XrEnvironmentDepthProviderMETA environmentDepthProvider, XrEnvironmentDepthSwapchainCreateInfoMETA* createInfo, XrEnvironmentDepthSwapchainMETA* swapchain)
        {
            xrCreateEnvironmentDepthSwapchainMETA_ptr ??= LoadFunction<xrCreateEnvironmentDepthSwapchainMETADelegate>("xrCreateEnvironmentDepthSwapchainMETA");
            XrResult _result = xrCreateEnvironmentDepthSwapchainMETA_ptr(environmentDepthProvider, createInfo, swapchain);
            Debug.Result(_result, "xrCreateEnvironmentDepthSwapchainMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyEnvironmentDepthSwapchainMETADelegate(XrEnvironmentDepthSwapchainMETA swapchain);
		private static xrDestroyEnvironmentDepthSwapchainMETADelegate xrDestroyEnvironmentDepthSwapchainMETA_ptr;
		public static XrResult xrDestroyEnvironmentDepthSwapchainMETA(XrEnvironmentDepthSwapchainMETA swapchain)
        {
            xrDestroyEnvironmentDepthSwapchainMETA_ptr ??= LoadFunction<xrDestroyEnvironmentDepthSwapchainMETADelegate>("xrDestroyEnvironmentDepthSwapchainMETA");
            XrResult _result = xrDestroyEnvironmentDepthSwapchainMETA_ptr(swapchain);
            Debug.Result(_result, "xrDestroyEnvironmentDepthSwapchainMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateEnvironmentDepthSwapchainImagesMETADelegate(XrEnvironmentDepthSwapchainMETA swapchain, uint imageCapacityInput, uint* imageCountOutput, XrSwapchainImageBaseHeader* images);
		private static xrEnumerateEnvironmentDepthSwapchainImagesMETADelegate xrEnumerateEnvironmentDepthSwapchainImagesMETA_ptr;
		public static XrResult xrEnumerateEnvironmentDepthSwapchainImagesMETA(XrEnvironmentDepthSwapchainMETA swapchain, uint imageCapacityInput, uint* imageCountOutput, XrSwapchainImageBaseHeader* images)
        {
            xrEnumerateEnvironmentDepthSwapchainImagesMETA_ptr ??= LoadFunction<xrEnumerateEnvironmentDepthSwapchainImagesMETADelegate>("xrEnumerateEnvironmentDepthSwapchainImagesMETA");
            XrResult _result = xrEnumerateEnvironmentDepthSwapchainImagesMETA_ptr(swapchain, imageCapacityInput, imageCountOutput, images);
            Debug.Result(_result, "xrEnumerateEnvironmentDepthSwapchainImagesMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetEnvironmentDepthSwapchainStateMETADelegate(XrEnvironmentDepthSwapchainMETA swapchain, XrEnvironmentDepthSwapchainStateMETA* state);
		private static xrGetEnvironmentDepthSwapchainStateMETADelegate xrGetEnvironmentDepthSwapchainStateMETA_ptr;
		public static XrResult xrGetEnvironmentDepthSwapchainStateMETA(XrEnvironmentDepthSwapchainMETA swapchain, XrEnvironmentDepthSwapchainStateMETA* state)
        {
            xrGetEnvironmentDepthSwapchainStateMETA_ptr ??= LoadFunction<xrGetEnvironmentDepthSwapchainStateMETADelegate>("xrGetEnvironmentDepthSwapchainStateMETA");
            XrResult _result = xrGetEnvironmentDepthSwapchainStateMETA_ptr(swapchain, state);
            Debug.Result(_result, "xrGetEnvironmentDepthSwapchainStateMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrAcquireEnvironmentDepthImageMETADelegate(XrEnvironmentDepthProviderMETA environmentDepthProvider, XrEnvironmentDepthImageAcquireInfoMETA* acquireInfo, XrEnvironmentDepthImageMETA* environmentDepthImage);
		private static xrAcquireEnvironmentDepthImageMETADelegate xrAcquireEnvironmentDepthImageMETA_ptr;
		public static XrResult xrAcquireEnvironmentDepthImageMETA(XrEnvironmentDepthProviderMETA environmentDepthProvider, XrEnvironmentDepthImageAcquireInfoMETA* acquireInfo, XrEnvironmentDepthImageMETA* environmentDepthImage)
        {
            xrAcquireEnvironmentDepthImageMETA_ptr ??= LoadFunction<xrAcquireEnvironmentDepthImageMETADelegate>("xrAcquireEnvironmentDepthImageMETA");
            XrResult _result = xrAcquireEnvironmentDepthImageMETA_ptr(environmentDepthProvider, acquireInfo, environmentDepthImage);
            Debug.Result(_result, "xrAcquireEnvironmentDepthImageMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetEnvironmentDepthHandRemovalMETADelegate(XrEnvironmentDepthProviderMETA environmentDepthProvider, XrEnvironmentDepthHandRemovalSetInfoMETA* setInfo);
		private static xrSetEnvironmentDepthHandRemovalMETADelegate xrSetEnvironmentDepthHandRemovalMETA_ptr;
		public static XrResult xrSetEnvironmentDepthHandRemovalMETA(XrEnvironmentDepthProviderMETA environmentDepthProvider, XrEnvironmentDepthHandRemovalSetInfoMETA* setInfo)
        {
            xrSetEnvironmentDepthHandRemovalMETA_ptr ??= LoadFunction<xrSetEnvironmentDepthHandRemovalMETADelegate>("xrSetEnvironmentDepthHandRemovalMETA");
            XrResult _result = xrSetEnvironmentDepthHandRemovalMETA_ptr(environmentDepthProvider, setInfo);
            Debug.Result(_result, "xrSetEnvironmentDepthHandRemovalMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateRenderModelEXTDelegate(XrSession session, XrRenderModelCreateInfoEXT* createInfo, XrRenderModelEXT* renderModel);
		private static xrCreateRenderModelEXTDelegate xrCreateRenderModelEXT_ptr;
		public static XrResult xrCreateRenderModelEXT(XrSession session, XrRenderModelCreateInfoEXT* createInfo, XrRenderModelEXT* renderModel)
        {
            xrCreateRenderModelEXT_ptr ??= LoadFunction<xrCreateRenderModelEXTDelegate>("xrCreateRenderModelEXT");
            XrResult _result = xrCreateRenderModelEXT_ptr(session, createInfo, renderModel);
            Debug.Result(_result, "xrCreateRenderModelEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyRenderModelEXTDelegate(XrRenderModelEXT renderModel);
		private static xrDestroyRenderModelEXTDelegate xrDestroyRenderModelEXT_ptr;
		public static XrResult xrDestroyRenderModelEXT(XrRenderModelEXT renderModel)
        {
            xrDestroyRenderModelEXT_ptr ??= LoadFunction<xrDestroyRenderModelEXTDelegate>("xrDestroyRenderModelEXT");
            XrResult _result = xrDestroyRenderModelEXT_ptr(renderModel);
            Debug.Result(_result, "xrDestroyRenderModelEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetRenderModelPropertiesEXTDelegate(XrRenderModelEXT renderModel, XrRenderModelPropertiesGetInfoEXT* getInfo, XrRenderModelPropertiesEXT* properties);
		private static xrGetRenderModelPropertiesEXTDelegate xrGetRenderModelPropertiesEXT_ptr;
		public static XrResult xrGetRenderModelPropertiesEXT(XrRenderModelEXT renderModel, XrRenderModelPropertiesGetInfoEXT* getInfo, XrRenderModelPropertiesEXT* properties)
        {
            xrGetRenderModelPropertiesEXT_ptr ??= LoadFunction<xrGetRenderModelPropertiesEXTDelegate>("xrGetRenderModelPropertiesEXT");
            XrResult _result = xrGetRenderModelPropertiesEXT_ptr(renderModel, getInfo, properties);
            Debug.Result(_result, "xrGetRenderModelPropertiesEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateRenderModelSpaceEXTDelegate(XrSession session, XrRenderModelSpaceCreateInfoEXT* createInfo, XrSpace* space);
		private static xrCreateRenderModelSpaceEXTDelegate xrCreateRenderModelSpaceEXT_ptr;
		public static XrResult xrCreateRenderModelSpaceEXT(XrSession session, XrRenderModelSpaceCreateInfoEXT* createInfo, XrSpace* space)
        {
            xrCreateRenderModelSpaceEXT_ptr ??= LoadFunction<xrCreateRenderModelSpaceEXTDelegate>("xrCreateRenderModelSpaceEXT");
            XrResult _result = xrCreateRenderModelSpaceEXT_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateRenderModelSpaceEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateRenderModelAssetEXTDelegate(XrSession session, XrRenderModelAssetCreateInfoEXT* createInfo, XrRenderModelAssetEXT* asset);
		private static xrCreateRenderModelAssetEXTDelegate xrCreateRenderModelAssetEXT_ptr;
		public static XrResult xrCreateRenderModelAssetEXT(XrSession session, XrRenderModelAssetCreateInfoEXT* createInfo, XrRenderModelAssetEXT* asset)
        {
            xrCreateRenderModelAssetEXT_ptr ??= LoadFunction<xrCreateRenderModelAssetEXTDelegate>("xrCreateRenderModelAssetEXT");
            XrResult _result = xrCreateRenderModelAssetEXT_ptr(session, createInfo, asset);
            Debug.Result(_result, "xrCreateRenderModelAssetEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyRenderModelAssetEXTDelegate(XrRenderModelAssetEXT asset);
		private static xrDestroyRenderModelAssetEXTDelegate xrDestroyRenderModelAssetEXT_ptr;
		public static XrResult xrDestroyRenderModelAssetEXT(XrRenderModelAssetEXT asset)
        {
            xrDestroyRenderModelAssetEXT_ptr ??= LoadFunction<xrDestroyRenderModelAssetEXTDelegate>("xrDestroyRenderModelAssetEXT");
            XrResult _result = xrDestroyRenderModelAssetEXT_ptr(asset);
            Debug.Result(_result, "xrDestroyRenderModelAssetEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetRenderModelAssetDataEXTDelegate(XrRenderModelAssetEXT asset, XrRenderModelAssetDataGetInfoEXT* getInfo, XrRenderModelAssetDataEXT* buffer);
		private static xrGetRenderModelAssetDataEXTDelegate xrGetRenderModelAssetDataEXT_ptr;
		public static XrResult xrGetRenderModelAssetDataEXT(XrRenderModelAssetEXT asset, XrRenderModelAssetDataGetInfoEXT* getInfo, XrRenderModelAssetDataEXT* buffer)
        {
            xrGetRenderModelAssetDataEXT_ptr ??= LoadFunction<xrGetRenderModelAssetDataEXTDelegate>("xrGetRenderModelAssetDataEXT");
            XrResult _result = xrGetRenderModelAssetDataEXT_ptr(asset, getInfo, buffer);
            Debug.Result(_result, "xrGetRenderModelAssetDataEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetRenderModelAssetPropertiesEXTDelegate(XrRenderModelAssetEXT asset, XrRenderModelAssetPropertiesGetInfoEXT* getInfo, XrRenderModelAssetPropertiesEXT* properties);
		private static xrGetRenderModelAssetPropertiesEXTDelegate xrGetRenderModelAssetPropertiesEXT_ptr;
		public static XrResult xrGetRenderModelAssetPropertiesEXT(XrRenderModelAssetEXT asset, XrRenderModelAssetPropertiesGetInfoEXT* getInfo, XrRenderModelAssetPropertiesEXT* properties)
        {
            xrGetRenderModelAssetPropertiesEXT_ptr ??= LoadFunction<xrGetRenderModelAssetPropertiesEXTDelegate>("xrGetRenderModelAssetPropertiesEXT");
            XrResult _result = xrGetRenderModelAssetPropertiesEXT_ptr(asset, getInfo, properties);
            Debug.Result(_result, "xrGetRenderModelAssetPropertiesEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetRenderModelStateEXTDelegate(XrRenderModelEXT renderModel, XrRenderModelStateGetInfoEXT* getInfo, XrRenderModelStateEXT* state);
		private static xrGetRenderModelStateEXTDelegate xrGetRenderModelStateEXT_ptr;
		public static XrResult xrGetRenderModelStateEXT(XrRenderModelEXT renderModel, XrRenderModelStateGetInfoEXT* getInfo, XrRenderModelStateEXT* state)
        {
            xrGetRenderModelStateEXT_ptr ??= LoadFunction<xrGetRenderModelStateEXTDelegate>("xrGetRenderModelStateEXT");
            XrResult _result = xrGetRenderModelStateEXT_ptr(renderModel, getInfo, state);
            Debug.Result(_result, "xrGetRenderModelStateEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateInteractionRenderModelIdsEXTDelegate(XrSession session, XrInteractionRenderModelIdsEnumerateInfoEXT* getInfo, uint renderModelIdCapacityInput, uint* renderModelIdCountOutput, ulong* renderModelIds);
		private static xrEnumerateInteractionRenderModelIdsEXTDelegate xrEnumerateInteractionRenderModelIdsEXT_ptr;
		public static XrResult xrEnumerateInteractionRenderModelIdsEXT(XrSession session, XrInteractionRenderModelIdsEnumerateInfoEXT* getInfo, uint renderModelIdCapacityInput, uint* renderModelIdCountOutput, ulong* renderModelIds)
        {
            xrEnumerateInteractionRenderModelIdsEXT_ptr ??= LoadFunction<xrEnumerateInteractionRenderModelIdsEXTDelegate>("xrEnumerateInteractionRenderModelIdsEXT");
            XrResult _result = xrEnumerateInteractionRenderModelIdsEXT_ptr(session, getInfo, renderModelIdCapacityInput, renderModelIdCountOutput, renderModelIds);
            Debug.Result(_result, "xrEnumerateInteractionRenderModelIdsEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateRenderModelSubactionPathsEXTDelegate(XrRenderModelEXT renderModel, XrInteractionRenderModelSubactionPathInfoEXT* info, uint pathCapacityInput, uint* pathCountOutput, ulong* paths);
		private static xrEnumerateRenderModelSubactionPathsEXTDelegate xrEnumerateRenderModelSubactionPathsEXT_ptr;
		public static XrResult xrEnumerateRenderModelSubactionPathsEXT(XrRenderModelEXT renderModel, XrInteractionRenderModelSubactionPathInfoEXT* info, uint pathCapacityInput, uint* pathCountOutput, ulong* paths)
        {
            xrEnumerateRenderModelSubactionPathsEXT_ptr ??= LoadFunction<xrEnumerateRenderModelSubactionPathsEXTDelegate>("xrEnumerateRenderModelSubactionPathsEXT");
            XrResult _result = xrEnumerateRenderModelSubactionPathsEXT_ptr(renderModel, info, pathCapacityInput, pathCountOutput, paths);
            Debug.Result(_result, "xrEnumerateRenderModelSubactionPathsEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetRenderModelPoseTopLevelUserPathEXTDelegate(XrRenderModelEXT renderModel, XrInteractionRenderModelTopLevelUserPathGetInfoEXT* info, ulong* topLevelUserPath);
		private static xrGetRenderModelPoseTopLevelUserPathEXTDelegate xrGetRenderModelPoseTopLevelUserPathEXT_ptr;
		public static XrResult xrGetRenderModelPoseTopLevelUserPathEXT(XrRenderModelEXT renderModel, XrInteractionRenderModelTopLevelUserPathGetInfoEXT* info, ulong* topLevelUserPath)
        {
            xrGetRenderModelPoseTopLevelUserPathEXT_ptr ??= LoadFunction<xrGetRenderModelPoseTopLevelUserPathEXTDelegate>("xrGetRenderModelPoseTopLevelUserPathEXT");
            XrResult _result = xrGetRenderModelPoseTopLevelUserPathEXT_ptr(renderModel, info, topLevelUserPath);
            Debug.Result(_result, "xrGetRenderModelPoseTopLevelUserPathEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetTrackingOptimizationSettingsHintQCOMDelegate(XrSession session, XrTrackingOptimizationSettingsDomainQCOM domain, XrTrackingOptimizationSettingsHintQCOM hint);
		private static xrSetTrackingOptimizationSettingsHintQCOMDelegate xrSetTrackingOptimizationSettingsHintQCOM_ptr;
		public static XrResult xrSetTrackingOptimizationSettingsHintQCOM(XrSession session, XrTrackingOptimizationSettingsDomainQCOM domain, XrTrackingOptimizationSettingsHintQCOM hint)
        {
            xrSetTrackingOptimizationSettingsHintQCOM_ptr ??= LoadFunction<xrSetTrackingOptimizationSettingsHintQCOMDelegate>("xrSetTrackingOptimizationSettingsHintQCOM");
            XrResult _result = xrSetTrackingOptimizationSettingsHintQCOM_ptr(session, domain, hint);
            Debug.Result(_result, "xrSetTrackingOptimizationSettingsHintQCOM");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreatePassthroughHTCDelegate(XrSession session, XrPassthroughCreateInfoHTC* createInfo, XrPassthroughHTC* passthrough);
		private static xrCreatePassthroughHTCDelegate xrCreatePassthroughHTC_ptr;
		public static XrResult xrCreatePassthroughHTC(XrSession session, XrPassthroughCreateInfoHTC* createInfo, XrPassthroughHTC* passthrough)
        {
            xrCreatePassthroughHTC_ptr ??= LoadFunction<xrCreatePassthroughHTCDelegate>("xrCreatePassthroughHTC");
            XrResult _result = xrCreatePassthroughHTC_ptr(session, createInfo, passthrough);
            Debug.Result(_result, "xrCreatePassthroughHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyPassthroughHTCDelegate(XrPassthroughHTC passthrough);
		private static xrDestroyPassthroughHTCDelegate xrDestroyPassthroughHTC_ptr;
		public static XrResult xrDestroyPassthroughHTC(XrPassthroughHTC passthrough)
        {
            xrDestroyPassthroughHTC_ptr ??= LoadFunction<xrDestroyPassthroughHTCDelegate>("xrDestroyPassthroughHTC");
            XrResult _result = xrDestroyPassthroughHTC_ptr(passthrough);
            Debug.Result(_result, "xrDestroyPassthroughHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrApplyFoveationHTCDelegate(XrSession session, XrFoveationApplyInfoHTC* applyInfo);
		private static xrApplyFoveationHTCDelegate xrApplyFoveationHTC_ptr;
		public static XrResult xrApplyFoveationHTC(XrSession session, XrFoveationApplyInfoHTC* applyInfo)
        {
            xrApplyFoveationHTC_ptr ??= LoadFunction<xrApplyFoveationHTCDelegate>("xrApplyFoveationHTC");
            XrResult _result = xrApplyFoveationHTC_ptr(session, applyInfo);
            Debug.Result(_result, "xrApplyFoveationHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorHTCDelegate(XrSession session, XrSpatialAnchorCreateInfoHTC* createInfo, XrSpace* anchor);
		private static xrCreateSpatialAnchorHTCDelegate xrCreateSpatialAnchorHTC_ptr;
		public static XrResult xrCreateSpatialAnchorHTC(XrSession session, XrSpatialAnchorCreateInfoHTC* createInfo, XrSpace* anchor)
        {
            xrCreateSpatialAnchorHTC_ptr ??= LoadFunction<xrCreateSpatialAnchorHTCDelegate>("xrCreateSpatialAnchorHTC");
            XrResult _result = xrCreateSpatialAnchorHTC_ptr(session, createInfo, anchor);
            Debug.Result(_result, "xrCreateSpatialAnchorHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialAnchorNameHTCDelegate(XrSpace anchor, XrSpatialAnchorNameHTC* name);
		private static xrGetSpatialAnchorNameHTCDelegate xrGetSpatialAnchorNameHTC_ptr;
		public static XrResult xrGetSpatialAnchorNameHTC(XrSpace anchor, XrSpatialAnchorNameHTC* name)
        {
            xrGetSpatialAnchorNameHTC_ptr ??= LoadFunction<xrGetSpatialAnchorNameHTCDelegate>("xrGetSpatialAnchorNameHTC");
            XrResult _result = xrGetSpatialAnchorNameHTC_ptr(anchor, name);
            Debug.Result(_result, "xrGetSpatialAnchorNameHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateBodyTrackerHTCDelegate(XrSession session, XrBodyTrackerCreateInfoHTC* createInfo, XrBodyTrackerHTC* bodyTracker);
		private static xrCreateBodyTrackerHTCDelegate xrCreateBodyTrackerHTC_ptr;
		public static XrResult xrCreateBodyTrackerHTC(XrSession session, XrBodyTrackerCreateInfoHTC* createInfo, XrBodyTrackerHTC* bodyTracker)
        {
            xrCreateBodyTrackerHTC_ptr ??= LoadFunction<xrCreateBodyTrackerHTCDelegate>("xrCreateBodyTrackerHTC");
            XrResult _result = xrCreateBodyTrackerHTC_ptr(session, createInfo, bodyTracker);
            Debug.Result(_result, "xrCreateBodyTrackerHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyBodyTrackerHTCDelegate(XrBodyTrackerHTC bodyTracker);
		private static xrDestroyBodyTrackerHTCDelegate xrDestroyBodyTrackerHTC_ptr;
		public static XrResult xrDestroyBodyTrackerHTC(XrBodyTrackerHTC bodyTracker)
        {
            xrDestroyBodyTrackerHTC_ptr ??= LoadFunction<xrDestroyBodyTrackerHTCDelegate>("xrDestroyBodyTrackerHTC");
            XrResult _result = xrDestroyBodyTrackerHTC_ptr(bodyTracker);
            Debug.Result(_result, "xrDestroyBodyTrackerHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateBodyJointsHTCDelegate(XrBodyTrackerHTC bodyTracker, XrBodyJointsLocateInfoHTC* locateInfo, XrBodyJointLocationsHTC* locations);
		private static xrLocateBodyJointsHTCDelegate xrLocateBodyJointsHTC_ptr;
		public static XrResult xrLocateBodyJointsHTC(XrBodyTrackerHTC bodyTracker, XrBodyJointsLocateInfoHTC* locateInfo, XrBodyJointLocationsHTC* locations)
        {
            xrLocateBodyJointsHTC_ptr ??= LoadFunction<xrLocateBodyJointsHTCDelegate>("xrLocateBodyJointsHTC");
            XrResult _result = xrLocateBodyJointsHTC_ptr(bodyTracker, locateInfo, locations);
            Debug.Result(_result, "xrLocateBodyJointsHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetBodySkeletonHTCDelegate(XrBodyTrackerHTC bodyTracker, XrSpace baseSpace, uint skeletonGenerationId, XrBodySkeletonHTC* skeleton);
		private static xrGetBodySkeletonHTCDelegate xrGetBodySkeletonHTC_ptr;
		public static XrResult xrGetBodySkeletonHTC(XrBodyTrackerHTC bodyTracker, XrSpace baseSpace, uint skeletonGenerationId, XrBodySkeletonHTC* skeleton)
        {
            xrGetBodySkeletonHTC_ptr ??= LoadFunction<xrGetBodySkeletonHTCDelegate>("xrGetBodySkeletonHTC");
            XrResult _result = xrGetBodySkeletonHTC_ptr(bodyTracker, baseSpace, skeletonGenerationId, skeleton);
            Debug.Result(_result, "xrGetBodySkeletonHTC");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrApplyForceFeedbackCurlMNDXDelegate(XrHandTrackerEXT handTracker, XrForceFeedbackCurlApplyLocationsMNDX* locations);
		private static xrApplyForceFeedbackCurlMNDXDelegate xrApplyForceFeedbackCurlMNDX_ptr;
		public static XrResult xrApplyForceFeedbackCurlMNDX(XrHandTrackerEXT handTracker, XrForceFeedbackCurlApplyLocationsMNDX* locations)
        {
            xrApplyForceFeedbackCurlMNDX_ptr ??= LoadFunction<xrApplyForceFeedbackCurlMNDXDelegate>("xrApplyForceFeedbackCurlMNDX");
            XrResult _result = xrApplyForceFeedbackCurlMNDX_ptr(handTracker, locations);
            Debug.Result(_result, "xrApplyForceFeedbackCurlMNDX");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateBodyTrackerBDDelegate(XrSession session, XrBodyTrackerCreateInfoBD* createInfo, XrBodyTrackerBD* bodyTracker);
		private static xrCreateBodyTrackerBDDelegate xrCreateBodyTrackerBD_ptr;
		public static XrResult xrCreateBodyTrackerBD(XrSession session, XrBodyTrackerCreateInfoBD* createInfo, XrBodyTrackerBD* bodyTracker)
        {
            xrCreateBodyTrackerBD_ptr ??= LoadFunction<xrCreateBodyTrackerBDDelegate>("xrCreateBodyTrackerBD");
            XrResult _result = xrCreateBodyTrackerBD_ptr(session, createInfo, bodyTracker);
            Debug.Result(_result, "xrCreateBodyTrackerBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyBodyTrackerBDDelegate(XrBodyTrackerBD bodyTracker);
		private static xrDestroyBodyTrackerBDDelegate xrDestroyBodyTrackerBD_ptr;
		public static XrResult xrDestroyBodyTrackerBD(XrBodyTrackerBD bodyTracker)
        {
            xrDestroyBodyTrackerBD_ptr ??= LoadFunction<xrDestroyBodyTrackerBDDelegate>("xrDestroyBodyTrackerBD");
            XrResult _result = xrDestroyBodyTrackerBD_ptr(bodyTracker);
            Debug.Result(_result, "xrDestroyBodyTrackerBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrLocateBodyJointsBDDelegate(XrBodyTrackerBD bodyTracker, XrBodyJointsLocateInfoBD* locateInfo, XrBodyJointLocationsBD* locations);
		private static xrLocateBodyJointsBDDelegate xrLocateBodyJointsBD_ptr;
		public static XrResult xrLocateBodyJointsBD(XrBodyTrackerBD bodyTracker, XrBodyJointsLocateInfoBD* locateInfo, XrBodyJointLocationsBD* locations)
        {
            xrLocateBodyJointsBD_ptr ??= LoadFunction<xrLocateBodyJointsBDDelegate>("xrLocateBodyJointsBD");
            XrResult _result = xrLocateBodyJointsBD_ptr(bodyTracker, locateInfo, locations);
            Debug.Result(_result, "xrLocateBodyJointsBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSpatialEntityComponentTypesBDDelegate(XrSenseDataSnapshotBD snapshot, ulong entityId, uint componentTypeCapacityInput, uint* componentTypeCountOutput, XrSpatialEntityComponentTypeBD* componentTypes);
		private static xrEnumerateSpatialEntityComponentTypesBDDelegate xrEnumerateSpatialEntityComponentTypesBD_ptr;
		public static XrResult xrEnumerateSpatialEntityComponentTypesBD(XrSenseDataSnapshotBD snapshot, ulong entityId, uint componentTypeCapacityInput, uint* componentTypeCountOutput, XrSpatialEntityComponentTypeBD* componentTypes)
        {
            xrEnumerateSpatialEntityComponentTypesBD_ptr ??= LoadFunction<xrEnumerateSpatialEntityComponentTypesBDDelegate>("xrEnumerateSpatialEntityComponentTypesBD");
            XrResult _result = xrEnumerateSpatialEntityComponentTypesBD_ptr(snapshot, entityId, componentTypeCapacityInput, componentTypeCountOutput, componentTypes);
            Debug.Result(_result, "xrEnumerateSpatialEntityComponentTypesBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialEntityUuidBDDelegate(XrSenseDataSnapshotBD snapshot, ulong entityId, XrUuid* uuid);
		private static xrGetSpatialEntityUuidBDDelegate xrGetSpatialEntityUuidBD_ptr;
		public static XrResult xrGetSpatialEntityUuidBD(XrSenseDataSnapshotBD snapshot, ulong entityId, XrUuid* uuid)
        {
            xrGetSpatialEntityUuidBD_ptr ??= LoadFunction<xrGetSpatialEntityUuidBDDelegate>("xrGetSpatialEntityUuidBD");
            XrResult _result = xrGetSpatialEntityUuidBD_ptr(snapshot, entityId, uuid);
            Debug.Result(_result, "xrGetSpatialEntityUuidBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialEntityComponentDataBDDelegate(XrSenseDataSnapshotBD snapshot, XrSpatialEntityComponentGetInfoBD* getInfo, XrSpatialEntityComponentDataBaseHeaderBD* componentData);
		private static xrGetSpatialEntityComponentDataBDDelegate xrGetSpatialEntityComponentDataBD_ptr;
		public static XrResult xrGetSpatialEntityComponentDataBD(XrSenseDataSnapshotBD snapshot, XrSpatialEntityComponentGetInfoBD* getInfo, XrSpatialEntityComponentDataBaseHeaderBD* componentData)
        {
            xrGetSpatialEntityComponentDataBD_ptr ??= LoadFunction<xrGetSpatialEntityComponentDataBDDelegate>("xrGetSpatialEntityComponentDataBD");
            XrResult _result = xrGetSpatialEntityComponentDataBD_ptr(snapshot, getInfo, componentData);
            Debug.Result(_result, "xrGetSpatialEntityComponentDataBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSenseDataProviderBDDelegate(XrSession session, XrSenseDataProviderCreateInfoBD* createInfo, XrSenseDataProviderBD* provider);
		private static xrCreateSenseDataProviderBDDelegate xrCreateSenseDataProviderBD_ptr;
		public static XrResult xrCreateSenseDataProviderBD(XrSession session, XrSenseDataProviderCreateInfoBD* createInfo, XrSenseDataProviderBD* provider)
        {
            xrCreateSenseDataProviderBD_ptr ??= LoadFunction<xrCreateSenseDataProviderBDDelegate>("xrCreateSenseDataProviderBD");
            XrResult _result = xrCreateSenseDataProviderBD_ptr(session, createInfo, provider);
            Debug.Result(_result, "xrCreateSenseDataProviderBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStartSenseDataProviderAsyncBDDelegate(XrSenseDataProviderBD provider, XrSenseDataProviderStartInfoBD* startInfo, ulong* future);
		private static xrStartSenseDataProviderAsyncBDDelegate xrStartSenseDataProviderAsyncBD_ptr;
		public static XrResult xrStartSenseDataProviderAsyncBD(XrSenseDataProviderBD provider, XrSenseDataProviderStartInfoBD* startInfo, ulong* future)
        {
            xrStartSenseDataProviderAsyncBD_ptr ??= LoadFunction<xrStartSenseDataProviderAsyncBDDelegate>("xrStartSenseDataProviderAsyncBD");
            XrResult _result = xrStartSenseDataProviderAsyncBD_ptr(provider, startInfo, future);
            Debug.Result(_result, "xrStartSenseDataProviderAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStartSenseDataProviderCompleteBDDelegate(XrSession session, ulong future, XrFutureCompletionEXT* completion);
		private static xrStartSenseDataProviderCompleteBDDelegate xrStartSenseDataProviderCompleteBD_ptr;
		public static XrResult xrStartSenseDataProviderCompleteBD(XrSession session, ulong future, XrFutureCompletionEXT* completion)
        {
            xrStartSenseDataProviderCompleteBD_ptr ??= LoadFunction<xrStartSenseDataProviderCompleteBDDelegate>("xrStartSenseDataProviderCompleteBD");
            XrResult _result = xrStartSenseDataProviderCompleteBD_ptr(session, future, completion);
            Debug.Result(_result, "xrStartSenseDataProviderCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSenseDataProviderStateBDDelegate(XrSenseDataProviderBD provider, XrSenseDataProviderStateBD* state);
		private static xrGetSenseDataProviderStateBDDelegate xrGetSenseDataProviderStateBD_ptr;
		public static XrResult xrGetSenseDataProviderStateBD(XrSenseDataProviderBD provider, XrSenseDataProviderStateBD* state)
        {
            xrGetSenseDataProviderStateBD_ptr ??= LoadFunction<xrGetSenseDataProviderStateBDDelegate>("xrGetSenseDataProviderStateBD");
            XrResult _result = xrGetSenseDataProviderStateBD_ptr(provider, state);
            Debug.Result(_result, "xrGetSenseDataProviderStateBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQuerySenseDataAsyncBDDelegate(XrSenseDataProviderBD provider, XrSenseDataQueryInfoBD* queryInfo, ulong* future);
		private static xrQuerySenseDataAsyncBDDelegate xrQuerySenseDataAsyncBD_ptr;
		public static XrResult xrQuerySenseDataAsyncBD(XrSenseDataProviderBD provider, XrSenseDataQueryInfoBD* queryInfo, ulong* future)
        {
            xrQuerySenseDataAsyncBD_ptr ??= LoadFunction<xrQuerySenseDataAsyncBDDelegate>("xrQuerySenseDataAsyncBD");
            XrResult _result = xrQuerySenseDataAsyncBD_ptr(provider, queryInfo, future);
            Debug.Result(_result, "xrQuerySenseDataAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQuerySenseDataCompleteBDDelegate(XrSenseDataProviderBD provider, ulong future, XrSenseDataQueryCompletionBD* completion);
		private static xrQuerySenseDataCompleteBDDelegate xrQuerySenseDataCompleteBD_ptr;
		public static XrResult xrQuerySenseDataCompleteBD(XrSenseDataProviderBD provider, ulong future, XrSenseDataQueryCompletionBD* completion)
        {
            xrQuerySenseDataCompleteBD_ptr ??= LoadFunction<xrQuerySenseDataCompleteBDDelegate>("xrQuerySenseDataCompleteBD");
            XrResult _result = xrQuerySenseDataCompleteBD_ptr(provider, future, completion);
            Debug.Result(_result, "xrQuerySenseDataCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySenseDataSnapshotBDDelegate(XrSenseDataSnapshotBD snapshot);
		private static xrDestroySenseDataSnapshotBDDelegate xrDestroySenseDataSnapshotBD_ptr;
		public static XrResult xrDestroySenseDataSnapshotBD(XrSenseDataSnapshotBD snapshot)
        {
            xrDestroySenseDataSnapshotBD_ptr ??= LoadFunction<xrDestroySenseDataSnapshotBDDelegate>("xrDestroySenseDataSnapshotBD");
            XrResult _result = xrDestroySenseDataSnapshotBD_ptr(snapshot);
            Debug.Result(_result, "xrDestroySenseDataSnapshotBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetQueriedSenseDataBDDelegate(XrSenseDataSnapshotBD snapshot, XrQueriedSenseDataGetInfoBD* getInfo, XrQueriedSenseDataBD* queriedSenseData);
		private static xrGetQueriedSenseDataBDDelegate xrGetQueriedSenseDataBD_ptr;
		public static XrResult xrGetQueriedSenseDataBD(XrSenseDataSnapshotBD snapshot, XrQueriedSenseDataGetInfoBD* getInfo, XrQueriedSenseDataBD* queriedSenseData)
        {
            xrGetQueriedSenseDataBD_ptr ??= LoadFunction<xrGetQueriedSenseDataBDDelegate>("xrGetQueriedSenseDataBD");
            XrResult _result = xrGetQueriedSenseDataBD_ptr(snapshot, getInfo, queriedSenseData);
            Debug.Result(_result, "xrGetQueriedSenseDataBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStopSenseDataProviderBDDelegate(XrSenseDataProviderBD provider);
		private static xrStopSenseDataProviderBDDelegate xrStopSenseDataProviderBD_ptr;
		public static XrResult xrStopSenseDataProviderBD(XrSenseDataProviderBD provider)
        {
            xrStopSenseDataProviderBD_ptr ??= LoadFunction<xrStopSenseDataProviderBDDelegate>("xrStopSenseDataProviderBD");
            XrResult _result = xrStopSenseDataProviderBD_ptr(provider);
            Debug.Result(_result, "xrStopSenseDataProviderBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySenseDataProviderBDDelegate(XrSenseDataProviderBD provider);
		private static xrDestroySenseDataProviderBDDelegate xrDestroySenseDataProviderBD_ptr;
		public static XrResult xrDestroySenseDataProviderBD(XrSenseDataProviderBD provider)
        {
            xrDestroySenseDataProviderBD_ptr ??= LoadFunction<xrDestroySenseDataProviderBDDelegate>("xrDestroySenseDataProviderBD");
            XrResult _result = xrDestroySenseDataProviderBD_ptr(provider);
            Debug.Result(_result, "xrDestroySenseDataProviderBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialEntityAnchorBDDelegate(XrSenseDataProviderBD provider, XrSpatialEntityAnchorCreateInfoBD* createInfo, XrAnchorBD* anchor);
		private static xrCreateSpatialEntityAnchorBDDelegate xrCreateSpatialEntityAnchorBD_ptr;
		public static XrResult xrCreateSpatialEntityAnchorBD(XrSenseDataProviderBD provider, XrSpatialEntityAnchorCreateInfoBD* createInfo, XrAnchorBD* anchor)
        {
            xrCreateSpatialEntityAnchorBD_ptr ??= LoadFunction<xrCreateSpatialEntityAnchorBDDelegate>("xrCreateSpatialEntityAnchorBD");
            XrResult _result = xrCreateSpatialEntityAnchorBD_ptr(provider, createInfo, anchor);
            Debug.Result(_result, "xrCreateSpatialEntityAnchorBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyAnchorBDDelegate(XrAnchorBD anchor);
		private static xrDestroyAnchorBDDelegate xrDestroyAnchorBD_ptr;
		public static XrResult xrDestroyAnchorBD(XrAnchorBD anchor)
        {
            xrDestroyAnchorBD_ptr ??= LoadFunction<xrDestroyAnchorBDDelegate>("xrDestroyAnchorBD");
            XrResult _result = xrDestroyAnchorBD_ptr(anchor);
            Debug.Result(_result, "xrDestroyAnchorBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetAnchorUuidBDDelegate(XrAnchorBD anchor, XrUuid* uuid);
		private static xrGetAnchorUuidBDDelegate xrGetAnchorUuidBD_ptr;
		public static XrResult xrGetAnchorUuidBD(XrAnchorBD anchor, XrUuid* uuid)
        {
            xrGetAnchorUuidBD_ptr ??= LoadFunction<xrGetAnchorUuidBDDelegate>("xrGetAnchorUuidBD");
            XrResult _result = xrGetAnchorUuidBD_ptr(anchor, uuid);
            Debug.Result(_result, "xrGetAnchorUuidBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateAnchorSpaceBDDelegate(XrSession session, XrAnchorSpaceCreateInfoBD* createInfo, XrSpace* space);
		private static xrCreateAnchorSpaceBDDelegate xrCreateAnchorSpaceBD_ptr;
		public static XrResult xrCreateAnchorSpaceBD(XrSession session, XrAnchorSpaceCreateInfoBD* createInfo, XrSpace* space)
        {
            xrCreateAnchorSpaceBD_ptr ??= LoadFunction<xrCreateAnchorSpaceBDDelegate>("xrCreateAnchorSpaceBD");
            XrResult _result = xrCreateAnchorSpaceBD_ptr(session, createInfo, space);
            Debug.Result(_result, "xrCreateAnchorSpaceBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorAsyncBDDelegate(XrSenseDataProviderBD provider, XrSpatialAnchorCreateInfoBD* info, ulong* future);
		private static xrCreateSpatialAnchorAsyncBDDelegate xrCreateSpatialAnchorAsyncBD_ptr;
		public static XrResult xrCreateSpatialAnchorAsyncBD(XrSenseDataProviderBD provider, XrSpatialAnchorCreateInfoBD* info, ulong* future)
        {
            xrCreateSpatialAnchorAsyncBD_ptr ??= LoadFunction<xrCreateSpatialAnchorAsyncBDDelegate>("xrCreateSpatialAnchorAsyncBD");
            XrResult _result = xrCreateSpatialAnchorAsyncBD_ptr(provider, info, future);
            Debug.Result(_result, "xrCreateSpatialAnchorAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorCompleteBDDelegate(XrSenseDataProviderBD provider, ulong future, XrSpatialAnchorCreateCompletionBD* completion);
		private static xrCreateSpatialAnchorCompleteBDDelegate xrCreateSpatialAnchorCompleteBD_ptr;
		public static XrResult xrCreateSpatialAnchorCompleteBD(XrSenseDataProviderBD provider, ulong future, XrSpatialAnchorCreateCompletionBD* completion)
        {
            xrCreateSpatialAnchorCompleteBD_ptr ??= LoadFunction<xrCreateSpatialAnchorCompleteBDDelegate>("xrCreateSpatialAnchorCompleteBD");
            XrResult _result = xrCreateSpatialAnchorCompleteBD_ptr(provider, future, completion);
            Debug.Result(_result, "xrCreateSpatialAnchorCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPersistSpatialAnchorAsyncBDDelegate(XrSenseDataProviderBD provider, XrSpatialAnchorPersistInfoBD* info, ulong* future);
		private static xrPersistSpatialAnchorAsyncBDDelegate xrPersistSpatialAnchorAsyncBD_ptr;
		public static XrResult xrPersistSpatialAnchorAsyncBD(XrSenseDataProviderBD provider, XrSpatialAnchorPersistInfoBD* info, ulong* future)
        {
            xrPersistSpatialAnchorAsyncBD_ptr ??= LoadFunction<xrPersistSpatialAnchorAsyncBDDelegate>("xrPersistSpatialAnchorAsyncBD");
            XrResult _result = xrPersistSpatialAnchorAsyncBD_ptr(provider, info, future);
            Debug.Result(_result, "xrPersistSpatialAnchorAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPersistSpatialAnchorCompleteBDDelegate(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion);
		private static xrPersistSpatialAnchorCompleteBDDelegate xrPersistSpatialAnchorCompleteBD_ptr;
		public static XrResult xrPersistSpatialAnchorCompleteBD(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion)
        {
            xrPersistSpatialAnchorCompleteBD_ptr ??= LoadFunction<xrPersistSpatialAnchorCompleteBDDelegate>("xrPersistSpatialAnchorCompleteBD");
            XrResult _result = xrPersistSpatialAnchorCompleteBD_ptr(provider, future, completion);
            Debug.Result(_result, "xrPersistSpatialAnchorCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUnpersistSpatialAnchorAsyncBDDelegate(XrSenseDataProviderBD provider, XrSpatialAnchorUnpersistInfoBD* info, ulong* future);
		private static xrUnpersistSpatialAnchorAsyncBDDelegate xrUnpersistSpatialAnchorAsyncBD_ptr;
		public static XrResult xrUnpersistSpatialAnchorAsyncBD(XrSenseDataProviderBD provider, XrSpatialAnchorUnpersistInfoBD* info, ulong* future)
        {
            xrUnpersistSpatialAnchorAsyncBD_ptr ??= LoadFunction<xrUnpersistSpatialAnchorAsyncBDDelegate>("xrUnpersistSpatialAnchorAsyncBD");
            XrResult _result = xrUnpersistSpatialAnchorAsyncBD_ptr(provider, info, future);
            Debug.Result(_result, "xrUnpersistSpatialAnchorAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUnpersistSpatialAnchorCompleteBDDelegate(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion);
		private static xrUnpersistSpatialAnchorCompleteBDDelegate xrUnpersistSpatialAnchorCompleteBD_ptr;
		public static XrResult xrUnpersistSpatialAnchorCompleteBD(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion)
        {
            xrUnpersistSpatialAnchorCompleteBD_ptr ??= LoadFunction<xrUnpersistSpatialAnchorCompleteBDDelegate>("xrUnpersistSpatialAnchorCompleteBD");
            XrResult _result = xrUnpersistSpatialAnchorCompleteBD_ptr(provider, future, completion);
            Debug.Result(_result, "xrUnpersistSpatialAnchorCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrShareSpatialAnchorAsyncBDDelegate(XrSenseDataProviderBD provider, XrSpatialAnchorShareInfoBD* info, ulong* future);
		private static xrShareSpatialAnchorAsyncBDDelegate xrShareSpatialAnchorAsyncBD_ptr;
		public static XrResult xrShareSpatialAnchorAsyncBD(XrSenseDataProviderBD provider, XrSpatialAnchorShareInfoBD* info, ulong* future)
        {
            xrShareSpatialAnchorAsyncBD_ptr ??= LoadFunction<xrShareSpatialAnchorAsyncBDDelegate>("xrShareSpatialAnchorAsyncBD");
            XrResult _result = xrShareSpatialAnchorAsyncBD_ptr(provider, info, future);
            Debug.Result(_result, "xrShareSpatialAnchorAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrShareSpatialAnchorCompleteBDDelegate(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion);
		private static xrShareSpatialAnchorCompleteBDDelegate xrShareSpatialAnchorCompleteBD_ptr;
		public static XrResult xrShareSpatialAnchorCompleteBD(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion)
        {
            xrShareSpatialAnchorCompleteBD_ptr ??= LoadFunction<xrShareSpatialAnchorCompleteBDDelegate>("xrShareSpatialAnchorCompleteBD");
            XrResult _result = xrShareSpatialAnchorCompleteBD_ptr(provider, future, completion);
            Debug.Result(_result, "xrShareSpatialAnchorCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDownloadSharedSpatialAnchorAsyncBDDelegate(XrSenseDataProviderBD provider, XrSharedSpatialAnchorDownloadInfoBD* info, ulong* future);
		private static xrDownloadSharedSpatialAnchorAsyncBDDelegate xrDownloadSharedSpatialAnchorAsyncBD_ptr;
		public static XrResult xrDownloadSharedSpatialAnchorAsyncBD(XrSenseDataProviderBD provider, XrSharedSpatialAnchorDownloadInfoBD* info, ulong* future)
        {
            xrDownloadSharedSpatialAnchorAsyncBD_ptr ??= LoadFunction<xrDownloadSharedSpatialAnchorAsyncBDDelegate>("xrDownloadSharedSpatialAnchorAsyncBD");
            XrResult _result = xrDownloadSharedSpatialAnchorAsyncBD_ptr(provider, info, future);
            Debug.Result(_result, "xrDownloadSharedSpatialAnchorAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDownloadSharedSpatialAnchorCompleteBDDelegate(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion);
		private static xrDownloadSharedSpatialAnchorCompleteBDDelegate xrDownloadSharedSpatialAnchorCompleteBD_ptr;
		public static XrResult xrDownloadSharedSpatialAnchorCompleteBD(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion)
        {
            xrDownloadSharedSpatialAnchorCompleteBD_ptr ??= LoadFunction<xrDownloadSharedSpatialAnchorCompleteBDDelegate>("xrDownloadSharedSpatialAnchorCompleteBD");
            XrResult _result = xrDownloadSharedSpatialAnchorCompleteBD_ptr(provider, future, completion);
            Debug.Result(_result, "xrDownloadSharedSpatialAnchorCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCaptureSceneAsyncBDDelegate(XrSenseDataProviderBD provider, XrSceneCaptureInfoBD* info, ulong* future);
		private static xrCaptureSceneAsyncBDDelegate xrCaptureSceneAsyncBD_ptr;
		public static XrResult xrCaptureSceneAsyncBD(XrSenseDataProviderBD provider, XrSceneCaptureInfoBD* info, ulong* future)
        {
            xrCaptureSceneAsyncBD_ptr ??= LoadFunction<xrCaptureSceneAsyncBDDelegate>("xrCaptureSceneAsyncBD");
            XrResult _result = xrCaptureSceneAsyncBD_ptr(provider, info, future);
            Debug.Result(_result, "xrCaptureSceneAsyncBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCaptureSceneCompleteBDDelegate(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion);
		private static xrCaptureSceneCompleteBDDelegate xrCaptureSceneCompleteBD_ptr;
		public static XrResult xrCaptureSceneCompleteBD(XrSenseDataProviderBD provider, ulong future, XrFutureCompletionEXT* completion)
        {
            xrCaptureSceneCompleteBD_ptr ??= LoadFunction<xrCaptureSceneCompleteBDDelegate>("xrCaptureSceneCompleteBD");
            XrResult _result = xrCaptureSceneCompleteBD_ptr(provider, future, completion);
            Debug.Result(_result, "xrCaptureSceneCompleteBD");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreatePlaneDetectorEXTDelegate(XrSession session, XrPlaneDetectorCreateInfoEXT* createInfo, XrPlaneDetectorEXT* planeDetector);
		private static xrCreatePlaneDetectorEXTDelegate xrCreatePlaneDetectorEXT_ptr;
		public static XrResult xrCreatePlaneDetectorEXT(XrSession session, XrPlaneDetectorCreateInfoEXT* createInfo, XrPlaneDetectorEXT* planeDetector)
        {
            xrCreatePlaneDetectorEXT_ptr ??= LoadFunction<xrCreatePlaneDetectorEXTDelegate>("xrCreatePlaneDetectorEXT");
            XrResult _result = xrCreatePlaneDetectorEXT_ptr(session, createInfo, planeDetector);
            Debug.Result(_result, "xrCreatePlaneDetectorEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyPlaneDetectorEXTDelegate(XrPlaneDetectorEXT planeDetector);
		private static xrDestroyPlaneDetectorEXTDelegate xrDestroyPlaneDetectorEXT_ptr;
		public static XrResult xrDestroyPlaneDetectorEXT(XrPlaneDetectorEXT planeDetector)
        {
            xrDestroyPlaneDetectorEXT_ptr ??= LoadFunction<xrDestroyPlaneDetectorEXTDelegate>("xrDestroyPlaneDetectorEXT");
            XrResult _result = xrDestroyPlaneDetectorEXT_ptr(planeDetector);
            Debug.Result(_result, "xrDestroyPlaneDetectorEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrBeginPlaneDetectionEXTDelegate(XrPlaneDetectorEXT planeDetector, XrPlaneDetectorBeginInfoEXT* beginInfo);
		private static xrBeginPlaneDetectionEXTDelegate xrBeginPlaneDetectionEXT_ptr;
		public static XrResult xrBeginPlaneDetectionEXT(XrPlaneDetectorEXT planeDetector, XrPlaneDetectorBeginInfoEXT* beginInfo)
        {
            xrBeginPlaneDetectionEXT_ptr ??= LoadFunction<xrBeginPlaneDetectionEXTDelegate>("xrBeginPlaneDetectionEXT");
            XrResult _result = xrBeginPlaneDetectionEXT_ptr(planeDetector, beginInfo);
            Debug.Result(_result, "xrBeginPlaneDetectionEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetPlaneDetectionStateEXTDelegate(XrPlaneDetectorEXT planeDetector, XrPlaneDetectionStateEXT* state);
		private static xrGetPlaneDetectionStateEXTDelegate xrGetPlaneDetectionStateEXT_ptr;
		public static XrResult xrGetPlaneDetectionStateEXT(XrPlaneDetectorEXT planeDetector, XrPlaneDetectionStateEXT* state)
        {
            xrGetPlaneDetectionStateEXT_ptr ??= LoadFunction<xrGetPlaneDetectionStateEXTDelegate>("xrGetPlaneDetectionStateEXT");
            XrResult _result = xrGetPlaneDetectionStateEXT_ptr(planeDetector, state);
            Debug.Result(_result, "xrGetPlaneDetectionStateEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetPlaneDetectionsEXTDelegate(XrPlaneDetectorEXT planeDetector, XrPlaneDetectorGetInfoEXT* info, XrPlaneDetectorLocationsEXT* locations);
		private static xrGetPlaneDetectionsEXTDelegate xrGetPlaneDetectionsEXT_ptr;
		public static XrResult xrGetPlaneDetectionsEXT(XrPlaneDetectorEXT planeDetector, XrPlaneDetectorGetInfoEXT* info, XrPlaneDetectorLocationsEXT* locations)
        {
            xrGetPlaneDetectionsEXT_ptr ??= LoadFunction<xrGetPlaneDetectionsEXTDelegate>("xrGetPlaneDetectionsEXT");
            XrResult _result = xrGetPlaneDetectionsEXT_ptr(planeDetector, info, locations);
            Debug.Result(_result, "xrGetPlaneDetectionsEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetPlanePolygonBufferEXTDelegate(XrPlaneDetectorEXT planeDetector, ulong planeId, uint polygonBufferIndex, XrPlaneDetectorPolygonBufferEXT* polygonBuffer);
		private static xrGetPlanePolygonBufferEXTDelegate xrGetPlanePolygonBufferEXT_ptr;
		public static XrResult xrGetPlanePolygonBufferEXT(XrPlaneDetectorEXT planeDetector, ulong planeId, uint polygonBufferIndex, XrPlaneDetectorPolygonBufferEXT* polygonBuffer)
        {
            xrGetPlanePolygonBufferEXT_ptr ??= LoadFunction<xrGetPlanePolygonBufferEXTDelegate>("xrGetPlanePolygonBufferEXT");
            XrResult _result = xrGetPlanePolygonBufferEXT_ptr(planeDetector, planeId, polygonBufferIndex, polygonBuffer);
            Debug.Result(_result, "xrGetPlanePolygonBufferEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSupportedTrackableTypesANDROIDDelegate(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes);
		private static xrEnumerateSupportedTrackableTypesANDROIDDelegate xrEnumerateSupportedTrackableTypesANDROID_ptr;
		public static XrResult xrEnumerateSupportedTrackableTypesANDROID(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes)
        {
            xrEnumerateSupportedTrackableTypesANDROID_ptr ??= LoadFunction<xrEnumerateSupportedTrackableTypesANDROIDDelegate>("xrEnumerateSupportedTrackableTypesANDROID");
            XrResult _result = xrEnumerateSupportedTrackableTypesANDROID_ptr(instance, systemId, trackableTypeCapacityInput, trackableTypeCountOutput, trackableTypes);
            Debug.Result(_result, "xrEnumerateSupportedTrackableTypesANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSupportedAnchorTrackableTypesANDROIDDelegate(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes);
		private static xrEnumerateSupportedAnchorTrackableTypesANDROIDDelegate xrEnumerateSupportedAnchorTrackableTypesANDROID_ptr;
		public static XrResult xrEnumerateSupportedAnchorTrackableTypesANDROID(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes)
        {
            xrEnumerateSupportedAnchorTrackableTypesANDROID_ptr ??= LoadFunction<xrEnumerateSupportedAnchorTrackableTypesANDROIDDelegate>("xrEnumerateSupportedAnchorTrackableTypesANDROID");
            XrResult _result = xrEnumerateSupportedAnchorTrackableTypesANDROID_ptr(instance, systemId, trackableTypeCapacityInput, trackableTypeCountOutput, trackableTypes);
            Debug.Result(_result, "xrEnumerateSupportedAnchorTrackableTypesANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateTrackableTrackerANDROIDDelegate(XrSession session, XrTrackableTrackerCreateInfoANDROID* createInfo, XrTrackableTrackerANDROID* trackableTracker);
		private static xrCreateTrackableTrackerANDROIDDelegate xrCreateTrackableTrackerANDROID_ptr;
		public static XrResult xrCreateTrackableTrackerANDROID(XrSession session, XrTrackableTrackerCreateInfoANDROID* createInfo, XrTrackableTrackerANDROID* trackableTracker)
        {
            xrCreateTrackableTrackerANDROID_ptr ??= LoadFunction<xrCreateTrackableTrackerANDROIDDelegate>("xrCreateTrackableTrackerANDROID");
            XrResult _result = xrCreateTrackableTrackerANDROID_ptr(session, createInfo, trackableTracker);
            Debug.Result(_result, "xrCreateTrackableTrackerANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyTrackableTrackerANDROIDDelegate(XrTrackableTrackerANDROID trackableTracker);
		private static xrDestroyTrackableTrackerANDROIDDelegate xrDestroyTrackableTrackerANDROID_ptr;
		public static XrResult xrDestroyTrackableTrackerANDROID(XrTrackableTrackerANDROID trackableTracker)
        {
            xrDestroyTrackableTrackerANDROID_ptr ??= LoadFunction<xrDestroyTrackableTrackerANDROIDDelegate>("xrDestroyTrackableTrackerANDROID");
            XrResult _result = xrDestroyTrackableTrackerANDROID_ptr(trackableTracker);
            Debug.Result(_result, "xrDestroyTrackableTrackerANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetAllTrackablesANDROIDDelegate(XrTrackableTrackerANDROID trackableTracker, uint trackableCapacityInput, uint* trackableCountOutput, ulong* trackables);
		private static xrGetAllTrackablesANDROIDDelegate xrGetAllTrackablesANDROID_ptr;
		public static XrResult xrGetAllTrackablesANDROID(XrTrackableTrackerANDROID trackableTracker, uint trackableCapacityInput, uint* trackableCountOutput, ulong* trackables)
        {
            xrGetAllTrackablesANDROID_ptr ??= LoadFunction<xrGetAllTrackablesANDROIDDelegate>("xrGetAllTrackablesANDROID");
            XrResult _result = xrGetAllTrackablesANDROID_ptr(trackableTracker, trackableCapacityInput, trackableCountOutput, trackables);
            Debug.Result(_result, "xrGetAllTrackablesANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetTrackablePlaneANDROIDDelegate(XrTrackableTrackerANDROID trackableTracker, XrTrackableGetInfoANDROID* getInfo, XrTrackablePlaneANDROID* planeOutput);
		private static xrGetTrackablePlaneANDROIDDelegate xrGetTrackablePlaneANDROID_ptr;
		public static XrResult xrGetTrackablePlaneANDROID(XrTrackableTrackerANDROID trackableTracker, XrTrackableGetInfoANDROID* getInfo, XrTrackablePlaneANDROID* planeOutput)
        {
            xrGetTrackablePlaneANDROID_ptr ??= LoadFunction<xrGetTrackablePlaneANDROIDDelegate>("xrGetTrackablePlaneANDROID");
            XrResult _result = xrGetTrackablePlaneANDROID_ptr(trackableTracker, getInfo, planeOutput);
            Debug.Result(_result, "xrGetTrackablePlaneANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateAnchorSpaceANDROIDDelegate(XrSession session, XrAnchorSpaceCreateInfoANDROID* createInfo, XrSpace* anchorOutput);
		private static xrCreateAnchorSpaceANDROIDDelegate xrCreateAnchorSpaceANDROID_ptr;
		public static XrResult xrCreateAnchorSpaceANDROID(XrSession session, XrAnchorSpaceCreateInfoANDROID* createInfo, XrSpace* anchorOutput)
        {
            xrCreateAnchorSpaceANDROID_ptr ??= LoadFunction<xrCreateAnchorSpaceANDROIDDelegate>("xrCreateAnchorSpaceANDROID");
            XrResult _result = xrCreateAnchorSpaceANDROID_ptr(session, createInfo, anchorOutput);
            Debug.Result(_result, "xrCreateAnchorSpaceANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSupportedPersistenceAnchorTypesANDROIDDelegate(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes);
		private static xrEnumerateSupportedPersistenceAnchorTypesANDROIDDelegate xrEnumerateSupportedPersistenceAnchorTypesANDROID_ptr;
		public static XrResult xrEnumerateSupportedPersistenceAnchorTypesANDROID(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes)
        {
            xrEnumerateSupportedPersistenceAnchorTypesANDROID_ptr ??= LoadFunction<xrEnumerateSupportedPersistenceAnchorTypesANDROIDDelegate>("xrEnumerateSupportedPersistenceAnchorTypesANDROID");
            XrResult _result = xrEnumerateSupportedPersistenceAnchorTypesANDROID_ptr(instance, systemId, trackableTypeCapacityInput, trackableTypeCountOutput, trackableTypes);
            Debug.Result(_result, "xrEnumerateSupportedPersistenceAnchorTypesANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateDeviceAnchorPersistenceANDROIDDelegate(XrSession session, XrDeviceAnchorPersistenceCreateInfoANDROID* createInfo, XrDeviceAnchorPersistenceANDROID* outHandle);
		private static xrCreateDeviceAnchorPersistenceANDROIDDelegate xrCreateDeviceAnchorPersistenceANDROID_ptr;
		public static XrResult xrCreateDeviceAnchorPersistenceANDROID(XrSession session, XrDeviceAnchorPersistenceCreateInfoANDROID* createInfo, XrDeviceAnchorPersistenceANDROID* outHandle)
        {
            xrCreateDeviceAnchorPersistenceANDROID_ptr ??= LoadFunction<xrCreateDeviceAnchorPersistenceANDROIDDelegate>("xrCreateDeviceAnchorPersistenceANDROID");
            XrResult _result = xrCreateDeviceAnchorPersistenceANDROID_ptr(session, createInfo, outHandle);
            Debug.Result(_result, "xrCreateDeviceAnchorPersistenceANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyDeviceAnchorPersistenceANDROIDDelegate(XrDeviceAnchorPersistenceANDROID handle);
		private static xrDestroyDeviceAnchorPersistenceANDROIDDelegate xrDestroyDeviceAnchorPersistenceANDROID_ptr;
		public static XrResult xrDestroyDeviceAnchorPersistenceANDROID(XrDeviceAnchorPersistenceANDROID handle)
        {
            xrDestroyDeviceAnchorPersistenceANDROID_ptr ??= LoadFunction<xrDestroyDeviceAnchorPersistenceANDROIDDelegate>("xrDestroyDeviceAnchorPersistenceANDROID");
            XrResult _result = xrDestroyDeviceAnchorPersistenceANDROID_ptr(handle);
            Debug.Result(_result, "xrDestroyDeviceAnchorPersistenceANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPersistAnchorANDROIDDelegate(XrDeviceAnchorPersistenceANDROID handle, XrPersistedAnchorSpaceInfoANDROID* persistedInfo, XrUuid* anchorIdOutput);
		private static xrPersistAnchorANDROIDDelegate xrPersistAnchorANDROID_ptr;
		public static XrResult xrPersistAnchorANDROID(XrDeviceAnchorPersistenceANDROID handle, XrPersistedAnchorSpaceInfoANDROID* persistedInfo, XrUuid* anchorIdOutput)
        {
            xrPersistAnchorANDROID_ptr ??= LoadFunction<xrPersistAnchorANDROIDDelegate>("xrPersistAnchorANDROID");
            XrResult _result = xrPersistAnchorANDROID_ptr(handle, persistedInfo, anchorIdOutput);
            Debug.Result(_result, "xrPersistAnchorANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetAnchorPersistStateANDROIDDelegate(XrDeviceAnchorPersistenceANDROID handle, XrUuid* anchorId, XrAnchorPersistStateANDROID* persistState);
		private static xrGetAnchorPersistStateANDROIDDelegate xrGetAnchorPersistStateANDROID_ptr;
		public static XrResult xrGetAnchorPersistStateANDROID(XrDeviceAnchorPersistenceANDROID handle, XrUuid* anchorId, XrAnchorPersistStateANDROID* persistState)
        {
            xrGetAnchorPersistStateANDROID_ptr ??= LoadFunction<xrGetAnchorPersistStateANDROIDDelegate>("xrGetAnchorPersistStateANDROID");
            XrResult _result = xrGetAnchorPersistStateANDROID_ptr(handle, anchorId, persistState);
            Debug.Result(_result, "xrGetAnchorPersistStateANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreatePersistedAnchorSpaceANDROIDDelegate(XrDeviceAnchorPersistenceANDROID handle, XrPersistedAnchorSpaceCreateInfoANDROID* createInfo, XrSpace* anchorOutput);
		private static xrCreatePersistedAnchorSpaceANDROIDDelegate xrCreatePersistedAnchorSpaceANDROID_ptr;
		public static XrResult xrCreatePersistedAnchorSpaceANDROID(XrDeviceAnchorPersistenceANDROID handle, XrPersistedAnchorSpaceCreateInfoANDROID* createInfo, XrSpace* anchorOutput)
        {
            xrCreatePersistedAnchorSpaceANDROID_ptr ??= LoadFunction<xrCreatePersistedAnchorSpaceANDROIDDelegate>("xrCreatePersistedAnchorSpaceANDROID");
            XrResult _result = xrCreatePersistedAnchorSpaceANDROID_ptr(handle, createInfo, anchorOutput);
            Debug.Result(_result, "xrCreatePersistedAnchorSpaceANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumeratePersistedAnchorsANDROIDDelegate(XrDeviceAnchorPersistenceANDROID handle, uint anchorIdCapacityInput, uint* anchorIdCountOutput, XrUuid* anchorIds);
		private static xrEnumeratePersistedAnchorsANDROIDDelegate xrEnumeratePersistedAnchorsANDROID_ptr;
		public static XrResult xrEnumeratePersistedAnchorsANDROID(XrDeviceAnchorPersistenceANDROID handle, uint anchorIdCapacityInput, uint* anchorIdCountOutput, XrUuid* anchorIds)
        {
            xrEnumeratePersistedAnchorsANDROID_ptr ??= LoadFunction<xrEnumeratePersistedAnchorsANDROIDDelegate>("xrEnumeratePersistedAnchorsANDROID");
            XrResult _result = xrEnumeratePersistedAnchorsANDROID_ptr(handle, anchorIdCapacityInput, anchorIdCountOutput, anchorIds);
            Debug.Result(_result, "xrEnumeratePersistedAnchorsANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUnpersistAnchorANDROIDDelegate(XrDeviceAnchorPersistenceANDROID handle, XrUuid* anchorId);
		private static xrUnpersistAnchorANDROIDDelegate xrUnpersistAnchorANDROID_ptr;
		public static XrResult xrUnpersistAnchorANDROID(XrDeviceAnchorPersistenceANDROID handle, XrUuid* anchorId)
        {
            xrUnpersistAnchorANDROID_ptr ??= LoadFunction<xrUnpersistAnchorANDROIDDelegate>("xrUnpersistAnchorANDROID");
            XrResult _result = xrUnpersistAnchorANDROID_ptr(handle, anchorId);
            Debug.Result(_result, "xrUnpersistAnchorANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetPassthroughCameraStateANDROIDDelegate(XrSession session, XrPassthroughCameraStateGetInfoANDROID* getInfo, XrPassthroughCameraStateANDROID* cameraStateOutput);
		private static xrGetPassthroughCameraStateANDROIDDelegate xrGetPassthroughCameraStateANDROID_ptr;
		public static XrResult xrGetPassthroughCameraStateANDROID(XrSession session, XrPassthroughCameraStateGetInfoANDROID* getInfo, XrPassthroughCameraStateANDROID* cameraStateOutput)
        {
            xrGetPassthroughCameraStateANDROID_ptr ??= LoadFunction<xrGetPassthroughCameraStateANDROIDDelegate>("xrGetPassthroughCameraStateANDROID");
            XrResult _result = xrGetPassthroughCameraStateANDROID_ptr(session, getInfo, cameraStateOutput);
            Debug.Result(_result, "xrGetPassthroughCameraStateANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateRaycastSupportedTrackableTypesANDROIDDelegate(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes);
		private static xrEnumerateRaycastSupportedTrackableTypesANDROIDDelegate xrEnumerateRaycastSupportedTrackableTypesANDROID_ptr;
		public static XrResult xrEnumerateRaycastSupportedTrackableTypesANDROID(XrInstance instance, ulong systemId, uint trackableTypeCapacityInput, uint* trackableTypeCountOutput, XrTrackableTypeANDROID* trackableTypes)
        {
            xrEnumerateRaycastSupportedTrackableTypesANDROID_ptr ??= LoadFunction<xrEnumerateRaycastSupportedTrackableTypesANDROIDDelegate>("xrEnumerateRaycastSupportedTrackableTypesANDROID");
            XrResult _result = xrEnumerateRaycastSupportedTrackableTypesANDROID_ptr(instance, systemId, trackableTypeCapacityInput, trackableTypeCountOutput, trackableTypes);
            Debug.Result(_result, "xrEnumerateRaycastSupportedTrackableTypesANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRaycastANDROIDDelegate(XrSession session, XrRaycastInfoANDROID* rayInfo, XrRaycastHitResultsANDROID* results);
		private static xrRaycastANDROIDDelegate xrRaycastANDROID_ptr;
		public static XrResult xrRaycastANDROID(XrSession session, XrRaycastInfoANDROID* rayInfo, XrRaycastHitResultsANDROID* results)
        {
            xrRaycastANDROID_ptr ??= LoadFunction<xrRaycastANDROIDDelegate>("xrRaycastANDROID");
            XrResult _result = xrRaycastANDROID_ptr(session, rayInfo, results);
            Debug.Result(_result, "xrRaycastANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetTrackableObjectANDROIDDelegate(XrTrackableTrackerANDROID tracker, XrTrackableGetInfoANDROID* getInfo, XrTrackableObjectANDROID* objectOutput);
		private static xrGetTrackableObjectANDROIDDelegate xrGetTrackableObjectANDROID_ptr;
		public static XrResult xrGetTrackableObjectANDROID(XrTrackableTrackerANDROID tracker, XrTrackableGetInfoANDROID* getInfo, XrTrackableObjectANDROID* objectOutput)
        {
            xrGetTrackableObjectANDROID_ptr ??= LoadFunction<xrGetTrackableObjectANDROIDDelegate>("xrGetTrackableObjectANDROID");
            XrResult _result = xrGetTrackableObjectANDROID_ptr(tracker, getInfo, objectOutput);
            Debug.Result(_result, "xrGetTrackableObjectANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPollFutureEXTDelegate(XrInstance instance, XrFuturePollInfoEXT* pollInfo, XrFuturePollResultEXT* pollResult);
		private static xrPollFutureEXTDelegate xrPollFutureEXT_ptr;
		public static XrResult xrPollFutureEXT(XrInstance instance, XrFuturePollInfoEXT* pollInfo, XrFuturePollResultEXT* pollResult)
        {
            xrPollFutureEXT_ptr ??= LoadFunction<xrPollFutureEXTDelegate>("xrPollFutureEXT");
            XrResult _result = xrPollFutureEXT_ptr(instance, pollInfo, pollResult);
            Debug.Result(_result, "xrPollFutureEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCancelFutureEXTDelegate(XrInstance instance, XrFutureCancelInfoEXT* cancelInfo);
		private static xrCancelFutureEXTDelegate xrCancelFutureEXT_ptr;
		public static XrResult xrCancelFutureEXT(XrInstance instance, XrFutureCancelInfoEXT* cancelInfo)
        {
            xrCancelFutureEXT_ptr ??= LoadFunction<xrCancelFutureEXTDelegate>("xrCancelFutureEXT");
            XrResult _result = xrCancelFutureEXT_ptr(instance, cancelInfo);
            Debug.Result(_result, "xrCancelFutureEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrSetSystemNotificationsMLDelegate(XrInstance instance, XrSystemNotificationsSetInfoML* info);
		private static xrSetSystemNotificationsMLDelegate xrSetSystemNotificationsML_ptr;
		public static XrResult xrSetSystemNotificationsML(XrInstance instance, XrSystemNotificationsSetInfoML* info)
        {
            xrSetSystemNotificationsML_ptr ??= LoadFunction<xrSetSystemNotificationsMLDelegate>("xrSetSystemNotificationsML");
            XrResult _result = xrSetSystemNotificationsML_ptr(instance, info);
            Debug.Result(_result, "xrSetSystemNotificationsML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateWorldMeshDetectorMLDelegate(XrSession session, XrWorldMeshDetectorCreateInfoML* createInfo, XrWorldMeshDetectorML* detector);
		private static xrCreateWorldMeshDetectorMLDelegate xrCreateWorldMeshDetectorML_ptr;
		public static XrResult xrCreateWorldMeshDetectorML(XrSession session, XrWorldMeshDetectorCreateInfoML* createInfo, XrWorldMeshDetectorML* detector)
        {
            xrCreateWorldMeshDetectorML_ptr ??= LoadFunction<xrCreateWorldMeshDetectorMLDelegate>("xrCreateWorldMeshDetectorML");
            XrResult _result = xrCreateWorldMeshDetectorML_ptr(session, createInfo, detector);
            Debug.Result(_result, "xrCreateWorldMeshDetectorML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyWorldMeshDetectorMLDelegate(XrWorldMeshDetectorML detector);
		private static xrDestroyWorldMeshDetectorMLDelegate xrDestroyWorldMeshDetectorML_ptr;
		public static XrResult xrDestroyWorldMeshDetectorML(XrWorldMeshDetectorML detector)
        {
            xrDestroyWorldMeshDetectorML_ptr ??= LoadFunction<xrDestroyWorldMeshDetectorMLDelegate>("xrDestroyWorldMeshDetectorML");
            XrResult _result = xrDestroyWorldMeshDetectorML_ptr(detector);
            Debug.Result(_result, "xrDestroyWorldMeshDetectorML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestWorldMeshStateAsyncMLDelegate(XrWorldMeshDetectorML detector, XrWorldMeshStateRequestInfoML* stateRequest, ulong* future);
		private static xrRequestWorldMeshStateAsyncMLDelegate xrRequestWorldMeshStateAsyncML_ptr;
		public static XrResult xrRequestWorldMeshStateAsyncML(XrWorldMeshDetectorML detector, XrWorldMeshStateRequestInfoML* stateRequest, ulong* future)
        {
            xrRequestWorldMeshStateAsyncML_ptr ??= LoadFunction<xrRequestWorldMeshStateAsyncMLDelegate>("xrRequestWorldMeshStateAsyncML");
            XrResult _result = xrRequestWorldMeshStateAsyncML_ptr(detector, stateRequest, future);
            Debug.Result(_result, "xrRequestWorldMeshStateAsyncML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestWorldMeshStateCompleteMLDelegate(XrWorldMeshDetectorML detector, ulong future, XrWorldMeshStateRequestCompletionML* completion);
		private static xrRequestWorldMeshStateCompleteMLDelegate xrRequestWorldMeshStateCompleteML_ptr;
		public static XrResult xrRequestWorldMeshStateCompleteML(XrWorldMeshDetectorML detector, ulong future, XrWorldMeshStateRequestCompletionML* completion)
        {
            xrRequestWorldMeshStateCompleteML_ptr ??= LoadFunction<xrRequestWorldMeshStateCompleteMLDelegate>("xrRequestWorldMeshStateCompleteML");
            XrResult _result = xrRequestWorldMeshStateCompleteML_ptr(detector, future, completion);
            Debug.Result(_result, "xrRequestWorldMeshStateCompleteML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetWorldMeshBufferRecommendSizeMLDelegate(XrWorldMeshDetectorML detector, XrWorldMeshBufferRecommendedSizeInfoML* sizeInfo, XrWorldMeshBufferSizeML* size);
		private static xrGetWorldMeshBufferRecommendSizeMLDelegate xrGetWorldMeshBufferRecommendSizeML_ptr;
		public static XrResult xrGetWorldMeshBufferRecommendSizeML(XrWorldMeshDetectorML detector, XrWorldMeshBufferRecommendedSizeInfoML* sizeInfo, XrWorldMeshBufferSizeML* size)
        {
            xrGetWorldMeshBufferRecommendSizeML_ptr ??= LoadFunction<xrGetWorldMeshBufferRecommendSizeMLDelegate>("xrGetWorldMeshBufferRecommendSizeML");
            XrResult _result = xrGetWorldMeshBufferRecommendSizeML_ptr(detector, sizeInfo, size);
            Debug.Result(_result, "xrGetWorldMeshBufferRecommendSizeML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrAllocateWorldMeshBufferMLDelegate(XrWorldMeshDetectorML detector, XrWorldMeshBufferSizeML* size, XrWorldMeshBufferML* buffer);
		private static xrAllocateWorldMeshBufferMLDelegate xrAllocateWorldMeshBufferML_ptr;
		public static XrResult xrAllocateWorldMeshBufferML(XrWorldMeshDetectorML detector, XrWorldMeshBufferSizeML* size, XrWorldMeshBufferML* buffer)
        {
            xrAllocateWorldMeshBufferML_ptr ??= LoadFunction<xrAllocateWorldMeshBufferMLDelegate>("xrAllocateWorldMeshBufferML");
            XrResult _result = xrAllocateWorldMeshBufferML_ptr(detector, size, buffer);
            Debug.Result(_result, "xrAllocateWorldMeshBufferML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrFreeWorldMeshBufferMLDelegate(XrWorldMeshDetectorML detector, XrWorldMeshBufferML* buffer);
		private static xrFreeWorldMeshBufferMLDelegate xrFreeWorldMeshBufferML_ptr;
		public static XrResult xrFreeWorldMeshBufferML(XrWorldMeshDetectorML detector, XrWorldMeshBufferML* buffer)
        {
            xrFreeWorldMeshBufferML_ptr ??= LoadFunction<xrFreeWorldMeshBufferMLDelegate>("xrFreeWorldMeshBufferML");
            XrResult _result = xrFreeWorldMeshBufferML_ptr(detector, buffer);
            Debug.Result(_result, "xrFreeWorldMeshBufferML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestWorldMeshAsyncMLDelegate(XrWorldMeshDetectorML detector, XrWorldMeshGetInfoML* getInfo, XrWorldMeshBufferML* buffer, ulong* future);
		private static xrRequestWorldMeshAsyncMLDelegate xrRequestWorldMeshAsyncML_ptr;
		public static XrResult xrRequestWorldMeshAsyncML(XrWorldMeshDetectorML detector, XrWorldMeshGetInfoML* getInfo, XrWorldMeshBufferML* buffer, ulong* future)
        {
            xrRequestWorldMeshAsyncML_ptr ??= LoadFunction<xrRequestWorldMeshAsyncMLDelegate>("xrRequestWorldMeshAsyncML");
            XrResult _result = xrRequestWorldMeshAsyncML_ptr(detector, getInfo, buffer, future);
            Debug.Result(_result, "xrRequestWorldMeshAsyncML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrRequestWorldMeshCompleteMLDelegate(XrWorldMeshDetectorML detector, XrWorldMeshRequestCompletionInfoML* completionInfo, ulong future, XrWorldMeshRequestCompletionML* completion);
		private static xrRequestWorldMeshCompleteMLDelegate xrRequestWorldMeshCompleteML_ptr;
		public static XrResult xrRequestWorldMeshCompleteML(XrWorldMeshDetectorML detector, XrWorldMeshRequestCompletionInfoML* completionInfo, ulong future, XrWorldMeshRequestCompletionML* completion)
        {
            xrRequestWorldMeshCompleteML_ptr ??= LoadFunction<xrRequestWorldMeshCompleteMLDelegate>("xrRequestWorldMeshCompleteML");
            XrResult _result = xrRequestWorldMeshCompleteML_ptr(detector, completionInfo, future, completion);
            Debug.Result(_result, "xrRequestWorldMeshCompleteML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateFacialExpressionClientMLDelegate(XrSession session, XrFacialExpressionClientCreateInfoML* createInfo, XrFacialExpressionClientML* facialExpressionClient);
		private static xrCreateFacialExpressionClientMLDelegate xrCreateFacialExpressionClientML_ptr;
		public static XrResult xrCreateFacialExpressionClientML(XrSession session, XrFacialExpressionClientCreateInfoML* createInfo, XrFacialExpressionClientML* facialExpressionClient)
        {
            xrCreateFacialExpressionClientML_ptr ??= LoadFunction<xrCreateFacialExpressionClientMLDelegate>("xrCreateFacialExpressionClientML");
            XrResult _result = xrCreateFacialExpressionClientML_ptr(session, createInfo, facialExpressionClient);
            Debug.Result(_result, "xrCreateFacialExpressionClientML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroyFacialExpressionClientMLDelegate(XrFacialExpressionClientML facialExpressionClient);
		private static xrDestroyFacialExpressionClientMLDelegate xrDestroyFacialExpressionClientML_ptr;
		public static XrResult xrDestroyFacialExpressionClientML(XrFacialExpressionClientML facialExpressionClient)
        {
            xrDestroyFacialExpressionClientML_ptr ??= LoadFunction<xrDestroyFacialExpressionClientMLDelegate>("xrDestroyFacialExpressionClientML");
            XrResult _result = xrDestroyFacialExpressionClientML_ptr(facialExpressionClient);
            Debug.Result(_result, "xrDestroyFacialExpressionClientML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetFacialExpressionBlendShapePropertiesMLDelegate(XrFacialExpressionClientML facialExpressionClient, XrFacialExpressionBlendShapeGetInfoML* blendShapeGetInfo, uint blendShapeCount, XrFacialExpressionBlendShapePropertiesML* blendShapes);
		private static xrGetFacialExpressionBlendShapePropertiesMLDelegate xrGetFacialExpressionBlendShapePropertiesML_ptr;
		public static XrResult xrGetFacialExpressionBlendShapePropertiesML(XrFacialExpressionClientML facialExpressionClient, XrFacialExpressionBlendShapeGetInfoML* blendShapeGetInfo, uint blendShapeCount, XrFacialExpressionBlendShapePropertiesML* blendShapes)
        {
            xrGetFacialExpressionBlendShapePropertiesML_ptr ??= LoadFunction<xrGetFacialExpressionBlendShapePropertiesMLDelegate>("xrGetFacialExpressionBlendShapePropertiesML");
            XrResult _result = xrGetFacialExpressionBlendShapePropertiesML_ptr(facialExpressionClient, blendShapeGetInfo, blendShapeCount, blendShapes);
            Debug.Result(_result, "xrGetFacialExpressionBlendShapePropertiesML");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrResumeSimultaneousHandsAndControllersTrackingMETADelegate(XrSession session, XrSimultaneousHandsAndControllersTrackingResumeInfoMETA* resumeInfo);
		private static xrResumeSimultaneousHandsAndControllersTrackingMETADelegate xrResumeSimultaneousHandsAndControllersTrackingMETA_ptr;
		public static XrResult xrResumeSimultaneousHandsAndControllersTrackingMETA(XrSession session, XrSimultaneousHandsAndControllersTrackingResumeInfoMETA* resumeInfo)
        {
            xrResumeSimultaneousHandsAndControllersTrackingMETA_ptr ??= LoadFunction<xrResumeSimultaneousHandsAndControllersTrackingMETADelegate>("xrResumeSimultaneousHandsAndControllersTrackingMETA");
            XrResult _result = xrResumeSimultaneousHandsAndControllersTrackingMETA_ptr(session, resumeInfo);
            Debug.Result(_result, "xrResumeSimultaneousHandsAndControllersTrackingMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPauseSimultaneousHandsAndControllersTrackingMETADelegate(XrSession session, XrSimultaneousHandsAndControllersTrackingPauseInfoMETA* pauseInfo);
		private static xrPauseSimultaneousHandsAndControllersTrackingMETADelegate xrPauseSimultaneousHandsAndControllersTrackingMETA_ptr;
		public static XrResult xrPauseSimultaneousHandsAndControllersTrackingMETA(XrSession session, XrSimultaneousHandsAndControllersTrackingPauseInfoMETA* pauseInfo)
        {
            xrPauseSimultaneousHandsAndControllersTrackingMETA_ptr ??= LoadFunction<xrPauseSimultaneousHandsAndControllersTrackingMETADelegate>("xrPauseSimultaneousHandsAndControllersTrackingMETA");
            XrResult _result = xrPauseSimultaneousHandsAndControllersTrackingMETA_ptr(session, pauseInfo);
            Debug.Result(_result, "xrPauseSimultaneousHandsAndControllersTrackingMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStartColocationDiscoveryMETADelegate(XrSession session, XrColocationDiscoveryStartInfoMETA* info, ulong* discoveryRequestId);
		private static xrStartColocationDiscoveryMETADelegate xrStartColocationDiscoveryMETA_ptr;
		public static XrResult xrStartColocationDiscoveryMETA(XrSession session, XrColocationDiscoveryStartInfoMETA* info, ulong* discoveryRequestId)
        {
            xrStartColocationDiscoveryMETA_ptr ??= LoadFunction<xrStartColocationDiscoveryMETADelegate>("xrStartColocationDiscoveryMETA");
            XrResult _result = xrStartColocationDiscoveryMETA_ptr(session, info, discoveryRequestId);
            Debug.Result(_result, "xrStartColocationDiscoveryMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStopColocationDiscoveryMETADelegate(XrSession session, XrColocationDiscoveryStopInfoMETA* info, ulong* requestId);
		private static xrStopColocationDiscoveryMETADelegate xrStopColocationDiscoveryMETA_ptr;
		public static XrResult xrStopColocationDiscoveryMETA(XrSession session, XrColocationDiscoveryStopInfoMETA* info, ulong* requestId)
        {
            xrStopColocationDiscoveryMETA_ptr ??= LoadFunction<xrStopColocationDiscoveryMETADelegate>("xrStopColocationDiscoveryMETA");
            XrResult _result = xrStopColocationDiscoveryMETA_ptr(session, info, requestId);
            Debug.Result(_result, "xrStopColocationDiscoveryMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStartColocationAdvertisementMETADelegate(XrSession session, XrColocationAdvertisementStartInfoMETA* info, ulong* advertisementRequestId);
		private static xrStartColocationAdvertisementMETADelegate xrStartColocationAdvertisementMETA_ptr;
		public static XrResult xrStartColocationAdvertisementMETA(XrSession session, XrColocationAdvertisementStartInfoMETA* info, ulong* advertisementRequestId)
        {
            xrStartColocationAdvertisementMETA_ptr ??= LoadFunction<xrStartColocationAdvertisementMETADelegate>("xrStartColocationAdvertisementMETA");
            XrResult _result = xrStartColocationAdvertisementMETA_ptr(session, info, advertisementRequestId);
            Debug.Result(_result, "xrStartColocationAdvertisementMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrStopColocationAdvertisementMETADelegate(XrSession session, XrColocationAdvertisementStopInfoMETA* info, ulong* requestId);
		private static xrStopColocationAdvertisementMETADelegate xrStopColocationAdvertisementMETA_ptr;
		public static XrResult xrStopColocationAdvertisementMETA(XrSession session, XrColocationAdvertisementStopInfoMETA* info, ulong* requestId)
        {
            xrStopColocationAdvertisementMETA_ptr ??= LoadFunction<xrStopColocationAdvertisementMETADelegate>("xrStopColocationAdvertisementMETA");
            XrResult _result = xrStopColocationAdvertisementMETA_ptr(session, info, requestId);
            Debug.Result(_result, "xrStopColocationAdvertisementMETA");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrShareAnchorANDROIDDelegate(XrSession session, XrAnchorSharingInfoANDROID* sharingInfo, XrAnchorSharingTokenANDROID* anchorToken);
		private static xrShareAnchorANDROIDDelegate xrShareAnchorANDROID_ptr;
		public static XrResult xrShareAnchorANDROID(XrSession session, XrAnchorSharingInfoANDROID* sharingInfo, XrAnchorSharingTokenANDROID* anchorToken)
        {
            xrShareAnchorANDROID_ptr ??= LoadFunction<xrShareAnchorANDROIDDelegate>("xrShareAnchorANDROID");
            XrResult _result = xrShareAnchorANDROID_ptr(session, sharingInfo, anchorToken);
            Debug.Result(_result, "xrShareAnchorANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUnshareAnchorANDROIDDelegate(XrSession session, XrSpace anchor);
		private static xrUnshareAnchorANDROIDDelegate xrUnshareAnchorANDROID_ptr;
		public static XrResult xrUnshareAnchorANDROID(XrSession session, XrSpace anchor)
        {
            xrUnshareAnchorANDROID_ptr ??= LoadFunction<xrUnshareAnchorANDROIDDelegate>("xrUnshareAnchorANDROID");
            XrResult _result = xrUnshareAnchorANDROID_ptr(session, anchor);
            Debug.Result(_result, "xrUnshareAnchorANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetTrackableMarkerANDROIDDelegate(XrTrackableTrackerANDROID tracker, XrTrackableGetInfoANDROID* getInfo, XrTrackableMarkerANDROID* markerOutput);
		private static xrGetTrackableMarkerANDROIDDelegate xrGetTrackableMarkerANDROID_ptr;
		public static XrResult xrGetTrackableMarkerANDROID(XrTrackableTrackerANDROID tracker, XrTrackableGetInfoANDROID* getInfo, XrTrackableMarkerANDROID* markerOutput)
        {
            xrGetTrackableMarkerANDROID_ptr ??= LoadFunction<xrGetTrackableMarkerANDROIDDelegate>("xrGetTrackableMarkerANDROID");
            XrResult _result = xrGetTrackableMarkerANDROID_ptr(tracker, getInfo, markerOutput);
            Debug.Result(_result, "xrGetTrackableMarkerANDROID");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSpatialCapabilitiesEXTDelegate(XrInstance instance, ulong systemId, uint capabilityCapacityInput, uint* capabilityCountOutput, XrSpatialCapabilityEXT* capabilities);
		private static xrEnumerateSpatialCapabilitiesEXTDelegate xrEnumerateSpatialCapabilitiesEXT_ptr;
		public static XrResult xrEnumerateSpatialCapabilitiesEXT(XrInstance instance, ulong systemId, uint capabilityCapacityInput, uint* capabilityCountOutput, XrSpatialCapabilityEXT* capabilities)
        {
            xrEnumerateSpatialCapabilitiesEXT_ptr ??= LoadFunction<xrEnumerateSpatialCapabilitiesEXTDelegate>("xrEnumerateSpatialCapabilitiesEXT");
            XrResult _result = xrEnumerateSpatialCapabilitiesEXT_ptr(instance, systemId, capabilityCapacityInput, capabilityCountOutput, capabilities);
            Debug.Result(_result, "xrEnumerateSpatialCapabilitiesEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSpatialCapabilityComponentTypesEXTDelegate(XrInstance instance, ulong systemId, XrSpatialCapabilityEXT capability, XrSpatialCapabilityComponentTypesEXT* capabilityComponents);
		private static xrEnumerateSpatialCapabilityComponentTypesEXTDelegate xrEnumerateSpatialCapabilityComponentTypesEXT_ptr;
		public static XrResult xrEnumerateSpatialCapabilityComponentTypesEXT(XrInstance instance, ulong systemId, XrSpatialCapabilityEXT capability, XrSpatialCapabilityComponentTypesEXT* capabilityComponents)
        {
            xrEnumerateSpatialCapabilityComponentTypesEXT_ptr ??= LoadFunction<xrEnumerateSpatialCapabilityComponentTypesEXTDelegate>("xrEnumerateSpatialCapabilityComponentTypesEXT");
            XrResult _result = xrEnumerateSpatialCapabilityComponentTypesEXT_ptr(instance, systemId, capability, capabilityComponents);
            Debug.Result(_result, "xrEnumerateSpatialCapabilityComponentTypesEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSpatialCapabilityFeaturesEXTDelegate(XrInstance instance, ulong systemId, XrSpatialCapabilityEXT capability, uint capabilityFeatureCapacityInput, uint* capabilityFeatureCountOutput, XrSpatialCapabilityFeatureEXT* capabilityFeatures);
		private static xrEnumerateSpatialCapabilityFeaturesEXTDelegate xrEnumerateSpatialCapabilityFeaturesEXT_ptr;
		public static XrResult xrEnumerateSpatialCapabilityFeaturesEXT(XrInstance instance, ulong systemId, XrSpatialCapabilityEXT capability, uint capabilityFeatureCapacityInput, uint* capabilityFeatureCountOutput, XrSpatialCapabilityFeatureEXT* capabilityFeatures)
        {
            xrEnumerateSpatialCapabilityFeaturesEXT_ptr ??= LoadFunction<xrEnumerateSpatialCapabilityFeaturesEXTDelegate>("xrEnumerateSpatialCapabilityFeaturesEXT");
            XrResult _result = xrEnumerateSpatialCapabilityFeaturesEXT_ptr(instance, systemId, capability, capabilityFeatureCapacityInput, capabilityFeatureCountOutput, capabilityFeatures);
            Debug.Result(_result, "xrEnumerateSpatialCapabilityFeaturesEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialContextAsyncEXTDelegate(XrSession session, XrSpatialContextCreateInfoEXT* createInfo, ulong* future);
		private static xrCreateSpatialContextAsyncEXTDelegate xrCreateSpatialContextAsyncEXT_ptr;
		public static XrResult xrCreateSpatialContextAsyncEXT(XrSession session, XrSpatialContextCreateInfoEXT* createInfo, ulong* future)
        {
            xrCreateSpatialContextAsyncEXT_ptr ??= LoadFunction<xrCreateSpatialContextAsyncEXTDelegate>("xrCreateSpatialContextAsyncEXT");
            XrResult _result = xrCreateSpatialContextAsyncEXT_ptr(session, createInfo, future);
            Debug.Result(_result, "xrCreateSpatialContextAsyncEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialContextCompleteEXTDelegate(XrSession session, ulong future, XrCreateSpatialContextCompletionEXT* completion);
		private static xrCreateSpatialContextCompleteEXTDelegate xrCreateSpatialContextCompleteEXT_ptr;
		public static XrResult xrCreateSpatialContextCompleteEXT(XrSession session, ulong future, XrCreateSpatialContextCompletionEXT* completion)
        {
            xrCreateSpatialContextCompleteEXT_ptr ??= LoadFunction<xrCreateSpatialContextCompleteEXTDelegate>("xrCreateSpatialContextCompleteEXT");
            XrResult _result = xrCreateSpatialContextCompleteEXT_ptr(session, future, completion);
            Debug.Result(_result, "xrCreateSpatialContextCompleteEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialContextEXTDelegate(XrSpatialContextEXT spatialContext);
		private static xrDestroySpatialContextEXTDelegate xrDestroySpatialContextEXT_ptr;
		public static XrResult xrDestroySpatialContextEXT(XrSpatialContextEXT spatialContext)
        {
            xrDestroySpatialContextEXT_ptr ??= LoadFunction<xrDestroySpatialContextEXTDelegate>("xrDestroySpatialContextEXT");
            XrResult _result = xrDestroySpatialContextEXT_ptr(spatialContext);
            Debug.Result(_result, "xrDestroySpatialContextEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialDiscoverySnapshotAsyncEXTDelegate(XrSpatialContextEXT spatialContext, XrSpatialDiscoverySnapshotCreateInfoEXT* createInfo, ulong* future);
		private static xrCreateSpatialDiscoverySnapshotAsyncEXTDelegate xrCreateSpatialDiscoverySnapshotAsyncEXT_ptr;
		public static XrResult xrCreateSpatialDiscoverySnapshotAsyncEXT(XrSpatialContextEXT spatialContext, XrSpatialDiscoverySnapshotCreateInfoEXT* createInfo, ulong* future)
        {
            xrCreateSpatialDiscoverySnapshotAsyncEXT_ptr ??= LoadFunction<xrCreateSpatialDiscoverySnapshotAsyncEXTDelegate>("xrCreateSpatialDiscoverySnapshotAsyncEXT");
            XrResult _result = xrCreateSpatialDiscoverySnapshotAsyncEXT_ptr(spatialContext, createInfo, future);
            Debug.Result(_result, "xrCreateSpatialDiscoverySnapshotAsyncEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialDiscoverySnapshotCompleteEXTDelegate(XrSpatialContextEXT spatialContext, XrCreateSpatialDiscoverySnapshotCompletionInfoEXT* createSnapshotCompletionInfo, XrCreateSpatialDiscoverySnapshotCompletionEXT* completion);
		private static xrCreateSpatialDiscoverySnapshotCompleteEXTDelegate xrCreateSpatialDiscoverySnapshotCompleteEXT_ptr;
		public static XrResult xrCreateSpatialDiscoverySnapshotCompleteEXT(XrSpatialContextEXT spatialContext, XrCreateSpatialDiscoverySnapshotCompletionInfoEXT* createSnapshotCompletionInfo, XrCreateSpatialDiscoverySnapshotCompletionEXT* completion)
        {
            xrCreateSpatialDiscoverySnapshotCompleteEXT_ptr ??= LoadFunction<xrCreateSpatialDiscoverySnapshotCompleteEXTDelegate>("xrCreateSpatialDiscoverySnapshotCompleteEXT");
            XrResult _result = xrCreateSpatialDiscoverySnapshotCompleteEXT_ptr(spatialContext, createSnapshotCompletionInfo, completion);
            Debug.Result(_result, "xrCreateSpatialDiscoverySnapshotCompleteEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrQuerySpatialComponentDataEXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialComponentDataQueryConditionEXT* queryCondition, XrSpatialComponentDataQueryResultEXT* queryResult);
		private static xrQuerySpatialComponentDataEXTDelegate xrQuerySpatialComponentDataEXT_ptr;
		public static XrResult xrQuerySpatialComponentDataEXT(XrSpatialSnapshotEXT snapshot, XrSpatialComponentDataQueryConditionEXT* queryCondition, XrSpatialComponentDataQueryResultEXT* queryResult)
        {
            xrQuerySpatialComponentDataEXT_ptr ??= LoadFunction<xrQuerySpatialComponentDataEXTDelegate>("xrQuerySpatialComponentDataEXT");
            XrResult _result = xrQuerySpatialComponentDataEXT_ptr(snapshot, queryCondition, queryResult);
            Debug.Result(_result, "xrQuerySpatialComponentDataEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialSnapshotEXTDelegate(XrSpatialSnapshotEXT snapshot);
		private static xrDestroySpatialSnapshotEXTDelegate xrDestroySpatialSnapshotEXT_ptr;
		public static XrResult xrDestroySpatialSnapshotEXT(XrSpatialSnapshotEXT snapshot)
        {
            xrDestroySpatialSnapshotEXT_ptr ??= LoadFunction<xrDestroySpatialSnapshotEXTDelegate>("xrDestroySpatialSnapshotEXT");
            XrResult _result = xrDestroySpatialSnapshotEXT_ptr(snapshot);
            Debug.Result(_result, "xrDestroySpatialSnapshotEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialEntityFromIdEXTDelegate(XrSpatialContextEXT spatialContext, XrSpatialEntityFromIdCreateInfoEXT* createInfo, XrSpatialEntityEXT* spatialEntity);
		private static xrCreateSpatialEntityFromIdEXTDelegate xrCreateSpatialEntityFromIdEXT_ptr;
		public static XrResult xrCreateSpatialEntityFromIdEXT(XrSpatialContextEXT spatialContext, XrSpatialEntityFromIdCreateInfoEXT* createInfo, XrSpatialEntityEXT* spatialEntity)
        {
            xrCreateSpatialEntityFromIdEXT_ptr ??= LoadFunction<xrCreateSpatialEntityFromIdEXTDelegate>("xrCreateSpatialEntityFromIdEXT");
            XrResult _result = xrCreateSpatialEntityFromIdEXT_ptr(spatialContext, createInfo, spatialEntity);
            Debug.Result(_result, "xrCreateSpatialEntityFromIdEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialEntityEXTDelegate(XrSpatialEntityEXT spatialEntity);
		private static xrDestroySpatialEntityEXTDelegate xrDestroySpatialEntityEXT_ptr;
		public static XrResult xrDestroySpatialEntityEXT(XrSpatialEntityEXT spatialEntity)
        {
            xrDestroySpatialEntityEXT_ptr ??= LoadFunction<xrDestroySpatialEntityEXTDelegate>("xrDestroySpatialEntityEXT");
            XrResult _result = xrDestroySpatialEntityEXT_ptr(spatialEntity);
            Debug.Result(_result, "xrDestroySpatialEntityEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialUpdateSnapshotEXTDelegate(XrSpatialContextEXT spatialContext, XrSpatialUpdateSnapshotCreateInfoEXT* createInfo, XrSpatialSnapshotEXT* snapshot);
		private static xrCreateSpatialUpdateSnapshotEXTDelegate xrCreateSpatialUpdateSnapshotEXT_ptr;
		public static XrResult xrCreateSpatialUpdateSnapshotEXT(XrSpatialContextEXT spatialContext, XrSpatialUpdateSnapshotCreateInfoEXT* createInfo, XrSpatialSnapshotEXT* snapshot)
        {
            xrCreateSpatialUpdateSnapshotEXT_ptr ??= LoadFunction<xrCreateSpatialUpdateSnapshotEXTDelegate>("xrCreateSpatialUpdateSnapshotEXT");
            XrResult _result = xrCreateSpatialUpdateSnapshotEXT_ptr(spatialContext, createInfo, snapshot);
            Debug.Result(_result, "xrCreateSpatialUpdateSnapshotEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialBufferStringEXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetSpatialBufferStringEXTDelegate xrGetSpatialBufferStringEXT_ptr;
		public static XrResult xrGetSpatialBufferStringEXT(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetSpatialBufferStringEXT_ptr ??= LoadFunction<xrGetSpatialBufferStringEXTDelegate>("xrGetSpatialBufferStringEXT");
            XrResult _result = xrGetSpatialBufferStringEXT_ptr(snapshot, info, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSpatialBufferStringEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialBufferUint8EXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);
		private static xrGetSpatialBufferUint8EXTDelegate xrGetSpatialBufferUint8EXT_ptr;
		public static XrResult xrGetSpatialBufferUint8EXT(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer)
        {
            xrGetSpatialBufferUint8EXT_ptr ??= LoadFunction<xrGetSpatialBufferUint8EXTDelegate>("xrGetSpatialBufferUint8EXT");
            XrResult _result = xrGetSpatialBufferUint8EXT_ptr(snapshot, info, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSpatialBufferUint8EXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialBufferUint16EXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, ushort* buffer);
		private static xrGetSpatialBufferUint16EXTDelegate xrGetSpatialBufferUint16EXT_ptr;
		public static XrResult xrGetSpatialBufferUint16EXT(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, ushort* buffer)
        {
            xrGetSpatialBufferUint16EXT_ptr ??= LoadFunction<xrGetSpatialBufferUint16EXTDelegate>("xrGetSpatialBufferUint16EXT");
            XrResult _result = xrGetSpatialBufferUint16EXT_ptr(snapshot, info, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSpatialBufferUint16EXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialBufferUint32EXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, uint* buffer);
		private static xrGetSpatialBufferUint32EXTDelegate xrGetSpatialBufferUint32EXT_ptr;
		public static XrResult xrGetSpatialBufferUint32EXT(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, uint* buffer)
        {
            xrGetSpatialBufferUint32EXT_ptr ??= LoadFunction<xrGetSpatialBufferUint32EXTDelegate>("xrGetSpatialBufferUint32EXT");
            XrResult _result = xrGetSpatialBufferUint32EXT_ptr(snapshot, info, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSpatialBufferUint32EXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialBufferFloatEXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, float* buffer);
		private static xrGetSpatialBufferFloatEXTDelegate xrGetSpatialBufferFloatEXT_ptr;
		public static XrResult xrGetSpatialBufferFloatEXT(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, float* buffer)
        {
            xrGetSpatialBufferFloatEXT_ptr ??= LoadFunction<xrGetSpatialBufferFloatEXTDelegate>("xrGetSpatialBufferFloatEXT");
            XrResult _result = xrGetSpatialBufferFloatEXT_ptr(snapshot, info, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSpatialBufferFloatEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialBufferVector2fEXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, XrVector2f* buffer);
		private static xrGetSpatialBufferVector2fEXTDelegate xrGetSpatialBufferVector2fEXT_ptr;
		public static XrResult xrGetSpatialBufferVector2fEXT(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, XrVector2f* buffer)
        {
            xrGetSpatialBufferVector2fEXT_ptr ??= LoadFunction<xrGetSpatialBufferVector2fEXTDelegate>("xrGetSpatialBufferVector2fEXT");
            XrResult _result = xrGetSpatialBufferVector2fEXT_ptr(snapshot, info, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSpatialBufferVector2fEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrGetSpatialBufferVector3fEXTDelegate(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, XrVector3f* buffer);
		private static xrGetSpatialBufferVector3fEXTDelegate xrGetSpatialBufferVector3fEXT_ptr;
		public static XrResult xrGetSpatialBufferVector3fEXT(XrSpatialSnapshotEXT snapshot, XrSpatialBufferGetInfoEXT* info, uint bufferCapacityInput, uint* bufferCountOutput, XrVector3f* buffer)
        {
            xrGetSpatialBufferVector3fEXT_ptr ??= LoadFunction<xrGetSpatialBufferVector3fEXTDelegate>("xrGetSpatialBufferVector3fEXT");
            XrResult _result = xrGetSpatialBufferVector3fEXT_ptr(snapshot, info, bufferCapacityInput, bufferCountOutput, buffer);
            Debug.Result(_result, "xrGetSpatialBufferVector3fEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialAnchorEXTDelegate(XrSpatialContextEXT spatialContext, XrSpatialAnchorCreateInfoEXT* createInfo, ulong* anchorEntityId, XrSpatialEntityEXT* anchorEntity);
		private static xrCreateSpatialAnchorEXTDelegate xrCreateSpatialAnchorEXT_ptr;
		public static XrResult xrCreateSpatialAnchorEXT(XrSpatialContextEXT spatialContext, XrSpatialAnchorCreateInfoEXT* createInfo, ulong* anchorEntityId, XrSpatialEntityEXT* anchorEntity)
        {
            xrCreateSpatialAnchorEXT_ptr ??= LoadFunction<xrCreateSpatialAnchorEXTDelegate>("xrCreateSpatialAnchorEXT");
            XrResult _result = xrCreateSpatialAnchorEXT_ptr(spatialContext, createInfo, anchorEntityId, anchorEntity);
            Debug.Result(_result, "xrCreateSpatialAnchorEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrEnumerateSpatialPersistenceScopesEXTDelegate(XrInstance instance, ulong systemId, uint persistenceScopeCapacityInput, uint* persistenceScopeCountOutput, XrSpatialPersistenceScopeEXT* persistenceScopes);
		private static xrEnumerateSpatialPersistenceScopesEXTDelegate xrEnumerateSpatialPersistenceScopesEXT_ptr;
		public static XrResult xrEnumerateSpatialPersistenceScopesEXT(XrInstance instance, ulong systemId, uint persistenceScopeCapacityInput, uint* persistenceScopeCountOutput, XrSpatialPersistenceScopeEXT* persistenceScopes)
        {
            xrEnumerateSpatialPersistenceScopesEXT_ptr ??= LoadFunction<xrEnumerateSpatialPersistenceScopesEXTDelegate>("xrEnumerateSpatialPersistenceScopesEXT");
            XrResult _result = xrEnumerateSpatialPersistenceScopesEXT_ptr(instance, systemId, persistenceScopeCapacityInput, persistenceScopeCountOutput, persistenceScopes);
            Debug.Result(_result, "xrEnumerateSpatialPersistenceScopesEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialPersistenceContextAsyncEXTDelegate(XrSession session, XrSpatialPersistenceContextCreateInfoEXT* createInfo, ulong* future);
		private static xrCreateSpatialPersistenceContextAsyncEXTDelegate xrCreateSpatialPersistenceContextAsyncEXT_ptr;
		public static XrResult xrCreateSpatialPersistenceContextAsyncEXT(XrSession session, XrSpatialPersistenceContextCreateInfoEXT* createInfo, ulong* future)
        {
            xrCreateSpatialPersistenceContextAsyncEXT_ptr ??= LoadFunction<xrCreateSpatialPersistenceContextAsyncEXTDelegate>("xrCreateSpatialPersistenceContextAsyncEXT");
            XrResult _result = xrCreateSpatialPersistenceContextAsyncEXT_ptr(session, createInfo, future);
            Debug.Result(_result, "xrCreateSpatialPersistenceContextAsyncEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrCreateSpatialPersistenceContextCompleteEXTDelegate(XrSession session, ulong future, XrCreateSpatialPersistenceContextCompletionEXT* completion);
		private static xrCreateSpatialPersistenceContextCompleteEXTDelegate xrCreateSpatialPersistenceContextCompleteEXT_ptr;
		public static XrResult xrCreateSpatialPersistenceContextCompleteEXT(XrSession session, ulong future, XrCreateSpatialPersistenceContextCompletionEXT* completion)
        {
            xrCreateSpatialPersistenceContextCompleteEXT_ptr ??= LoadFunction<xrCreateSpatialPersistenceContextCompleteEXTDelegate>("xrCreateSpatialPersistenceContextCompleteEXT");
            XrResult _result = xrCreateSpatialPersistenceContextCompleteEXT_ptr(session, future, completion);
            Debug.Result(_result, "xrCreateSpatialPersistenceContextCompleteEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrDestroySpatialPersistenceContextEXTDelegate(XrSpatialPersistenceContextEXT persistenceContext);
		private static xrDestroySpatialPersistenceContextEXTDelegate xrDestroySpatialPersistenceContextEXT_ptr;
		public static XrResult xrDestroySpatialPersistenceContextEXT(XrSpatialPersistenceContextEXT persistenceContext)
        {
            xrDestroySpatialPersistenceContextEXT_ptr ??= LoadFunction<xrDestroySpatialPersistenceContextEXTDelegate>("xrDestroySpatialPersistenceContextEXT");
            XrResult _result = xrDestroySpatialPersistenceContextEXT_ptr(persistenceContext);
            Debug.Result(_result, "xrDestroySpatialPersistenceContextEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPersistSpatialEntityAsyncEXTDelegate(XrSpatialPersistenceContextEXT persistenceContext, XrSpatialEntityPersistInfoEXT* persistInfo, ulong* future);
		private static xrPersistSpatialEntityAsyncEXTDelegate xrPersistSpatialEntityAsyncEXT_ptr;
		public static XrResult xrPersistSpatialEntityAsyncEXT(XrSpatialPersistenceContextEXT persistenceContext, XrSpatialEntityPersistInfoEXT* persistInfo, ulong* future)
        {
            xrPersistSpatialEntityAsyncEXT_ptr ??= LoadFunction<xrPersistSpatialEntityAsyncEXTDelegate>("xrPersistSpatialEntityAsyncEXT");
            XrResult _result = xrPersistSpatialEntityAsyncEXT_ptr(persistenceContext, persistInfo, future);
            Debug.Result(_result, "xrPersistSpatialEntityAsyncEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrPersistSpatialEntityCompleteEXTDelegate(XrSpatialPersistenceContextEXT persistenceContext, ulong future, XrPersistSpatialEntityCompletionEXT* completion);
		private static xrPersistSpatialEntityCompleteEXTDelegate xrPersistSpatialEntityCompleteEXT_ptr;
		public static XrResult xrPersistSpatialEntityCompleteEXT(XrSpatialPersistenceContextEXT persistenceContext, ulong future, XrPersistSpatialEntityCompletionEXT* completion)
        {
            xrPersistSpatialEntityCompleteEXT_ptr ??= LoadFunction<xrPersistSpatialEntityCompleteEXTDelegate>("xrPersistSpatialEntityCompleteEXT");
            XrResult _result = xrPersistSpatialEntityCompleteEXT_ptr(persistenceContext, future, completion);
            Debug.Result(_result, "xrPersistSpatialEntityCompleteEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUnpersistSpatialEntityAsyncEXTDelegate(XrSpatialPersistenceContextEXT persistenceContext, XrSpatialEntityUnpersistInfoEXT* unpersistInfo, ulong* future);
		private static xrUnpersistSpatialEntityAsyncEXTDelegate xrUnpersistSpatialEntityAsyncEXT_ptr;
		public static XrResult xrUnpersistSpatialEntityAsyncEXT(XrSpatialPersistenceContextEXT persistenceContext, XrSpatialEntityUnpersistInfoEXT* unpersistInfo, ulong* future)
        {
            xrUnpersistSpatialEntityAsyncEXT_ptr ??= LoadFunction<xrUnpersistSpatialEntityAsyncEXTDelegate>("xrUnpersistSpatialEntityAsyncEXT");
            XrResult _result = xrUnpersistSpatialEntityAsyncEXT_ptr(persistenceContext, unpersistInfo, future);
            Debug.Result(_result, "xrUnpersistSpatialEntityAsyncEXT");
            return _result;
        }
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate XrResult xrUnpersistSpatialEntityCompleteEXTDelegate(XrSpatialPersistenceContextEXT persistenceContext, ulong future, XrUnpersistSpatialEntityCompletionEXT* completion);
		private static xrUnpersistSpatialEntityCompleteEXTDelegate xrUnpersistSpatialEntityCompleteEXT_ptr;
		public static XrResult xrUnpersistSpatialEntityCompleteEXT(XrSpatialPersistenceContextEXT persistenceContext, ulong future, XrUnpersistSpatialEntityCompletionEXT* completion)
        {
            xrUnpersistSpatialEntityCompleteEXT_ptr ??= LoadFunction<xrUnpersistSpatialEntityCompleteEXTDelegate>("xrUnpersistSpatialEntityCompleteEXT");
            XrResult _result = xrUnpersistSpatialEntityCompleteEXT_ptr(persistenceContext, future, completion);
            Debug.Result(_result, "xrUnpersistSpatialEntityCompleteEXT");
            return _result;
        }
}
