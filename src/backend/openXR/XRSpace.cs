


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
    
    public void Recreate(XRSession _xrSession)
    {
        TimmyXR.xrDestroySpace(space);
        
        XRPose _pose        = new XRPose(OpenXR.views[0].pose);
        
        quat   _orientation = new quat(_pose.rotation.x, _pose.rotation.y, _pose.rotation.z, _pose.rotation.w) * new quat(referenceSpaceCreateInfo.poseInReferenceSpace.orientation.x, referenceSpaceCreateInfo.poseInReferenceSpace.orientation.y, referenceSpaceCreateInfo.poseInReferenceSpace.orientation.z, referenceSpaceCreateInfo.poseInReferenceSpace.orientation.w);
        
        referenceSpaceCreateInfo.poseInReferenceSpace = new XrPosef
        {
            position = new XrVector3f()
            {
                x = referenceSpaceCreateInfo.poseInReferenceSpace.position.x + _pose.position.x,
                y = 0f,
                z = referenceSpaceCreateInfo.poseInReferenceSpace.position.z + _pose.position.z,
            },
            orientation = new XrQuaternionf()
            {
                x = _orientation.x,
                y = _orientation.y,
                z = _orientation.z,
                w = _orientation.w,
            },
        };
        
        fixed (XrSpace* _spacePtr = &space)
        fixed (XrReferenceSpaceCreateInfo* _referenceSpaceCreateInfoPtr = &referenceSpaceCreateInfo)
        {
            TimmyXR.xrCreateReferenceSpace(_xrSession.session, _referenceSpaceCreateInfoPtr, _spacePtr);
        }
    }
}