


namespace Engine;


public unsafe class XRAction : Disposable
{
    public readonly XrAction  action;
    public readonly XRInput input;

    public readonly XrActionSuggestedBinding suggestedBinding;

    private readonly XrSpaceLocation spaceLocation;
    private readonly XRActionSpace xrActionSpace;

    private readonly XrActionCreateInfo   actionCreateInfo  ;
    private readonly XrActionStateGetInfo actionStateGetInfo;

    private XrActionStateBoolean  actionStateBoolean ;
    private XrActionStateFloat    actionStateFloat   ;
    private XrActionStateVector2f actionStateVector2f;
    private XrActionStatePose     actionStatePose    ;


    public XRAction(XRInstance _xrInstance, XRSession _xrSession, XRActionSet _xrActionSet, XRInput _xrInput)
    {
        input = _xrInput;


        actionCreateInfo = new XrActionCreateInfo()
        {
            type                = XrStructureType.XR_TYPE_ACTION_CREATE_INFO,
            next                = null                          ,
            
            actionType          = input.type                    ,

            countSubactionPaths = 0                             ,
            subactionPaths      = null                          ,
        };

        fixed (byte* _actionNamePtr          = actionCreateInfo.actionName         )
        fixed (byte* _localizedActionNamePtr = actionCreateInfo.localizedActionName)
        {
            Program.StringToBuffer(input.name, _actionNamePtr         , 64 );
            Program.StringToBuffer(input.name, _localizedActionNamePtr, 128);
        }


        fixed (XrAction*           _actionPtr           = &action          )
        fixed (XrActionCreateInfo* _actionCreateInfoPtr = &actionCreateInfo)
        {
            TimmyXR.xrCreateAction(_xrActionSet.actionSet, _actionCreateInfoPtr, _actionPtr);
        }


        if (input.type == XrActionType.XR_ACTION_TYPE_POSE_INPUT)
        {
            xrActionSpace = new XRActionSpace(_xrSession, this);
        }

        actionStateGetInfo = new XrActionStateGetInfo()
        {
            type          = XrStructureType.XR_TYPE_ACTION_STATE_GET_INFO,
            next          = null                            ,
            
            action        = action                          ,
            subactionPath = 0                               ,
        };


        spaceLocation       = new XrSpaceLocation       { type = XrStructureType.XR_TYPE_SPACE_LOCATION        };

        actionStateBoolean  = new XrActionStateBoolean  { type = XrStructureType.XR_TYPE_ACTION_STATE_BOOLEAN  };
        actionStateFloat    = new XrActionStateFloat    { type = XrStructureType.XR_TYPE_ACTION_STATE_FLOAT    };
        actionStateVector2f = new XrActionStateVector2f { type = XrStructureType.XR_TYPE_ACTION_STATE_VECTOR2F };
        actionStatePose     = new XrActionStatePose     { type = XrStructureType.XR_TYPE_ACTION_STATE_POSE     };


        suggestedBinding    = new XrActionSuggestedBinding()
        {
            action  = action                                      ,
            binding = XRPath.StringToPath(_xrInstance, input.path),
        };
    }

    protected override void OnDispose()
    {
        TimmyXR.xrDestroyAction(action);
    }


    public bool GetBool(XRSession _xrSession)
    {
        fixed (XrActionStateBoolean*  _actionStateBooleanPtr  = &actionStateBoolean)
        fixed (XrActionStateGetInfo*  _actionStateGetInfoPtr  = &actionStateGetInfo)
        {
            TimmyXR.xrGetActionStateBoolean(_xrSession.session, _actionStateGetInfoPtr, _actionStateBooleanPtr);
        }

        return actionStateBoolean.currentState == 1;
    }

    public float GetFloat(XRSession _xrSession)
    {
        fixed (XrActionStateFloat*   _actionStateFloatPtr     = &actionStateFloat)
        fixed (XrActionStateGetInfo* _actionStateGetInfoPtr   = &actionStateGetInfo)
        {
            TimmyXR.xrGetActionStateFloat(_xrSession.session, _actionStateGetInfoPtr, _actionStateFloatPtr);
        }

        return actionStateFloat.currentState;
    }

    public vec2 GetVec2(XRSession _xrSession)
    {
        fixed (XrActionStateVector2f* _actionStateVector2fPtr = &actionStateVector2f)
        fixed (XrActionStateGetInfo*  _actionStateGetInfoPtr  = &actionStateGetInfo)
        {
            TimmyXR.xrGetActionStateVector2f(_xrSession.session, _actionStateGetInfoPtr, _actionStateVector2fPtr);
        }

        return new vec2(actionStateVector2f.currentState.x, actionStateVector2f.currentState.y);
    }

    public bool GetPose(XRSession _xrSession, XRSpace _baseXRSpace, long _predictedDisplayTime, out XRPose _xrPose)
    {
        fixed (XrActionStatePose*     _actionStatePosePtr     = &actionStatePose)
        fixed (XrActionStateGetInfo*  _actionStateGetInfoPtr  = &actionStateGetInfo)
        {
            TimmyXR.xrGetActionStatePose(_xrSession.session, _actionStateGetInfoPtr, _actionStatePosePtr);
        }

        if (actionStatePose.isActive == 0)
        {
            _xrPose = new XRPose();
            return false;
        }


        fixed (XrSpaceLocation* _spaceLocationPtr = &spaceLocation)
        {
            TimmyXR.xrLocateSpace(xrActionSpace.space, _baseXRSpace.space, _predictedDisplayTime, _spaceLocationPtr);
        }

        if ((spaceLocation.locationFlags & (ulong)XrSpaceLocationFlags.XR_SPACE_LOCATION_POSITION_VALID_BIT   ) == 0
            ||
            (spaceLocation.locationFlags & (ulong)XrSpaceLocationFlags.XR_SPACE_LOCATION_ORIENTATION_VALID_BIT) == 0
            )
        {
            _xrPose = new XRPose();
            return false;
        }

        _xrPose = new XRPose(spaceLocation.pose);
        return true;
    }
}