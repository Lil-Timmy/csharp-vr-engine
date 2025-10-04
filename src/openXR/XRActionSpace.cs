


namespace Engine;


public unsafe class XRActionSpace : Disposable
{
    public readonly XrSpace space;

    private readonly XrActionSpaceCreateInfo actionSpaceCreateInfo;


    public XRActionSpace(XRSession _xrSession, XRAction _xrAction)
    {
        actionSpaceCreateInfo = new XrActionSpaceCreateInfo()
        {
            type              = XrStructureType.XR_TYPE_ACTION_SPACE_CREATE_INFO,
            next              = null                                            ,
            
            action            = _xrAction.action                                ,
            subactionPath     = 0                                               ,

            poseInActionSpace = new XrPosef()
            {
                orientation = new XrQuaternionf()
                {
                    x = 0.0f,
                    y = 0.0f,
                    z = 0.0f,
                    w = 1.0f
                },
                position = new XrVector3f()
                {
                    x = 0.0f,
                    y = 0.0f,
                    z = 0.0f
                },
            },
        };


        fixed(XrActionSpaceCreateInfo* _actionSpaceCreateInfoPtr = &actionSpaceCreateInfo)
        fixed(XrSpace*                 _spacePtr                 = &space)
        {
            TimmyXR.xrCreateActionSpace(_xrSession.session, _actionSpaceCreateInfoPtr, _spacePtr);
        }
    }

    protected override void OnDispose()
    {
        TimmyXR.xrDestroySpace(space);
    }
}