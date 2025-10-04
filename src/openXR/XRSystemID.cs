


namespace Engine;


public unsafe class XRSystemID
{
    public readonly ulong id;


    private readonly XrSystemGetInfo systemGetInfo;



    public XRSystemID(XRInstance _xrInstance)
    {
        systemGetInfo = new XrSystemGetInfo()
        {
            type       = XrStructureType.XR_TYPE_SYSTEM_GET_INFO,
            next       = null                                   ,
            
            formFactor = XrFormFactor.XR_FORM_FACTOR_HEAD_MOUNTED_DISPLAY,
        };
        
        fixed (ulong*           _systemIDPtr      = &id           )
        fixed (XrSystemGetInfo* _systemGetInfoPtr = &systemGetInfo)
        {
            TimmyXR.xrGetSystem(_xrInstance.instance, _systemGetInfoPtr, _systemIDPtr);
        }
    }
}