


namespace Engine;


public unsafe class XRActionSet : Disposable
{
    public readonly XrActionSet actionSet;

    public readonly string internalName;
    public readonly string localName   ;

    private readonly XrActionSetCreateInfo actionSetCreateInfo;


    public XRActionSet(XRInstance _xrInstance, string _internalName, string _localName)
    {
        internalName = _internalName;
        localName    = _localName   ;


        actionSetCreateInfo = new XrActionSetCreateInfo()
        {
            type     = XrStructureType.XR_TYPE_ACTION_SET_CREATE_INFO,
            next     = null                                          ,
            priority = 0                                             ,
        };
        
        fixed (byte* _actionSetNamePtr          = actionSetCreateInfo.actionSetName         )
        fixed (byte* _localizedActionSetNamePtr = actionSetCreateInfo.localizedActionSetName)
        {
            OpenXR.StringToBuffer(internalName, _actionSetNamePtr         , 64 );
            OpenXR.StringToBuffer(localName   , _localizedActionSetNamePtr, 128);
        }


        fixed (XrActionSet          * _actionSetPtr           = &actionSet          )
        fixed (XrActionSetCreateInfo* _actionSetCreateInfoPtr = &actionSetCreateInfo)
        {
            TimmyXR.xrCreateActionSet(_xrInstance.instance, _actionSetCreateInfoPtr, _actionSetPtr);
        }
    }

    protected override void OnDispose()
    {
        TimmyXR.xrDestroyActionSet(actionSet);
    }
}