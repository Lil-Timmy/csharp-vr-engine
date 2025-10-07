using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;



namespace Engine;



public unsafe class XRSession : Disposable
{
    public readonly XrSession session;
    
    public bool isActive      { get; private set; }
    public bool isRendering   { get; private set; }
    public bool isInteracting { get; private set; }


    private XrSessionState sessionState;

    private XrGraphicsBindingOpenGLWin32KHR graphicsBinding;
    private XrSessionCreateInfo        sessionCreateInfo    ;
    private XrEventDataBuffer          eventDataBuffer      ;
    private XrSessionBeginInfo         sessionBeginInfo     ;
    

    [DllImport("opengl32.dll", EntryPoint = "wglGetCurrentDC", ExactSpelling = true)]
    private static extern nint wglGetCurrentDC();
    [DllImport("opengl32.dll", EntryPoint = "wglGetCurrentContext", ExactSpelling = true)]
    private static extern nint wglGetCurrentContext();

    public XRSession(XRInstance _instance, XRSystemID _systemID)
    {
        graphicsBinding = new XrGraphicsBindingOpenGLWin32KHR()
        {
            type  = XrStructureType.XR_TYPE_GRAPHICS_BINDING_OPENGL_WIN32_KHR,
            next  = null                                                     ,
            hDC   = wglGetCurrentDC()                                        ,
            hGLRC = wglGetCurrentContext()                                   ,
        };

        fixed (XrGraphicsBindingOpenGLWin32KHR* _graphicsBindingPtr = &graphicsBinding)
        {
            sessionCreateInfo = new XrSessionCreateInfo()
            {
                type        = XrStructureType.XR_TYPE_SESSION_CREATE_INFO,
                next        = _graphicsBindingPtr                        ,
                createFlags = (ulong)XrSessionCreateFlags.None           ,
                systemId    = _systemID.id                               ,
            };
        }


        fixed (XrSession*           _sessionPtr           = &session          )
        fixed (XrSessionCreateInfo* _sessionCreateInfoPtr = &sessionCreateInfo)
        {
            TimmyXR.xrCreateSession(_instance.instance, _sessionCreateInfoPtr, _sessionPtr);
        }


        sessionBeginInfo = new XrSessionBeginInfo()
        {
            type = XrStructureType.XR_TYPE_SESSION_BEGIN_INFO,
            next = null                                      ,
            
            primaryViewConfigurationType = XrViewConfigurationType.XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO,
        };

        eventDataBuffer = new XrEventDataBuffer()
        {
            type = XrStructureType.XR_TYPE_EVENT_DATA_BUFFER,
            next = null                                     ,
        };


        sessionState = XrSessionState.XR_SESSION_STATE_UNKNOWN;
    }

    protected override void OnDispose()
    {
        TimmyXR.xrDestroySession(session);
    }


    public void UpdateEvents(XRInstance _instance)
    {
        fixed (XrEventDataBuffer* _eventDataBufferPtr = &eventDataBuffer)
        {
            while(TimmyXR.xrPollEvent(_instance.instance, _eventDataBufferPtr) == XrResult.XR_SUCCESS)
            {
                if (eventDataBuffer.type == XrStructureType.XR_TYPE_EVENT_DATA_SESSION_STATE_CHANGED)
                {
                    UpdateSessionState(Unsafe.As<XrEventDataBuffer, XrEventDataSessionStateChanged>(ref eventDataBuffer).state);
                }
                else if (eventDataBuffer.type == XrStructureType.XR_TYPE_EVENT_DATA_REFERENCE_SPACE_CHANGE_PENDING)
                {
                    
                }
                
                eventDataBuffer.type = XrStructureType.XR_TYPE_EVENT_DATA_BUFFER;
            }
        }
    }

    private void UpdateSessionState(XrSessionState _sessionState)
    {
        sessionState = _sessionState;

        switch (sessionState)
        {
            case XrSessionState.XR_SESSION_STATE_IDLE: // Next state(s): Ready, Loss Pending.
                // The session has been created, but cannot yet be begun.
                // Alternatively, this could mark the end of the session and go to state loss pending.
                isActive      = false;
                isInteracting = false;
                isRendering   = false;
                break;

            case XrSessionState.XR_SESSION_STATE_READY: // Next state(s): Synchronized
                // The session is ready to begin.
                Begin();
                isActive      = true;
                isInteracting = false;
                isRendering   = false;
                break;
            
            case XrSessionState.XR_SESSION_STATE_SYNCHRONIZED: // Next state(s): Visible.
                // Info state, means the session is running, but cannot yet be used.
                isActive      = true;
                isInteracting = false;
                isRendering   = false;
                break;
            
            case XrSessionState.XR_SESSION_STATE_VISIBLE: // Next state(s): Focused, Stopping.
                // Highly recommended you render in this stage along with focused, but potentially with lower quality.
                // If your app is fast, this should essentially act like state focused.
                // Note: Resizing the swapchain is possible, but not recommended since it's very imperformant to do so at runtime any time you go to states visible or focused.
                isActive      = true;
                isInteracting = false;
                isRendering   = true;
                break;
            
            case XrSessionState.XR_SESSION_STATE_FOCUSED: // Next state(s): Visible, Stopping.
                // The session is fully ready to render to the screen at regular quality. This can transition back to
                // visible if it begins to perform poorly or when clicking into a menu like on Meta Quest headsets.
                isActive      = true;
                isInteracting = true;
                isRendering   = true;
                break;

            case XrSessionState.XR_SESSION_STATE_STOPPING: // Next state(s): Idle.
                // The session is ending and returning to idle due to some need to recreate swapchain or begin session again.
                End();
                isActive      = false;
                isInteracting = false;
                isRendering   = false;
                break;
            
            case XrSessionState.XR_SESSION_STATE_LOSS_PENDING: // Next states(s): Exiting.
                // Marks the end of the session, save any persistant resources.
                isActive      = false;
                isInteracting = false;
                isRendering   = false;
                break;
            
            case XrSessionState.XR_SESSION_STATE_EXITING: // Next state(s): N/A.
                // Self-explanatory, the program is shutting down completely, clean up session resources.
                Program.isActive = false;
                isActive      = false;
                isInteracting = false;
                isRendering   = false;
                break;
            
            
            default: // Namely: SessionState.Unknown, Next states(s): N/A.
                // This should never happen unless an error ocurrs.
                Debug.Error($"OpenXR session state is unkown [{sessionState}].");
                break;
        }

        Debug.Log($"Session state: {sessionState}", System.ConsoleColor.White);
    }


    private void Begin()
    {
        fixed(XrSessionBeginInfo* _sessionBeginInfoPtr = &sessionBeginInfo)
        {
            TimmyXR.xrBeginSession(session, _sessionBeginInfoPtr);
        }
    }

    public void End() 
    {
        TimmyXR.xrEndSession(session);
    }
}