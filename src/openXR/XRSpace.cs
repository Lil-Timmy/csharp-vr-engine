


namespace Engine;


public unsafe class XRSpace : Disposable
{
    public readonly XrSpace space;
    

    private XrReferenceSpaceCreateInfo referenceSpaceCreateInfo;


    
    public XRSpace(XRSession _xrSession)
    {
        referenceSpaceCreateInfo = new XrReferenceSpaceCreateInfo()
        {
            type = XrStructureType.XR_TYPE_REFERENCE_SPACE_CREATE_INFO,
            next = null,
            referenceSpaceType = XrReferenceSpaceType.XR_REFERENCE_SPACE_TYPE_STAGE,
            poseInReferenceSpace = new XrPosef()
            {
                position = new XrVector3f()
                {
                    x = 0.0f,
                    y = 0.0f,
                    z = 0.0f
                },
                orientation = new XrQuaternionf()
                {
                    x = 0.0f,
                    y = 0.0f,
                    z = 0.0f,
                    w = 1.0f
                },
            },
        };


        fixed (XrSpace* _spacePtr = &space)
        fixed (XrReferenceSpaceCreateInfo* _referenceSpaceCreateInfoPtr = &referenceSpaceCreateInfo)
        {
            TimmyXR.xrCreateReferenceSpace(_xrSession.session, _referenceSpaceCreateInfoPtr, _spacePtr);
        }
    }
    
    protected override void OnDispose()
    {
        TimmyXR.xrDestroySpace(space);
    }
}