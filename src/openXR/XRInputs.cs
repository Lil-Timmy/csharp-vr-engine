using System.Collections.Generic;
using System.Linq;


namespace Engine;


public unsafe class XRInputs
{
    public vec3  headsetPosition           => inputPoses  [Input.HEADPOSE      ].position;
    public quat  headsetRotation           => inputPoses  [Input.HEADPOSE      ].rotation;

    public bool  rightControllerActive     { get; private set; }
    public bool  leftControllerActive      { get; private set; }
    
    public vec3  rightControllerPosition   => inputPoses [Input.RIGHTPOSE     ].position;
    public quat  rightControllerRotation   => inputPoses [Input.RIGHTPOSE     ].rotation;
    public bool  rightControllerMenu       => inputBools [Input.RIGHTMENU     ];
    public bool  rightControllerPrimary    => inputBools [Input.RIGHTPRIMARY  ];
    public bool  rightControllerSecondary  => inputBools [Input.RIGHTSECONDARY];
    public float rightControllerGrip       => inputFloats[Input.RIGHTGRIP     ];
    public float rightControllerTrigger    => inputFloats[Input.RIGHTTRIGGER  ];
    public vec2  rightControllerJoystick   => inputVecs  [Input.RIGHTJOYSTICK ];

    public vec3  leftControllerPosition    => inputPoses [Input.LEFTPOSE      ].position;
    public quat  leftControllerRotation    => inputPoses [Input.LEFTPOSE      ].rotation;
    public bool  leftControllerMenu        => inputBools [Input.LEFTMENU      ];
    public bool  leftControllerPrimary     => inputBools [Input.LEFTPRIMARY   ];
    public bool  leftControllerSecondary   => inputBools [Input.LEFTSECONDARY ];
    public float leftControllerGrip        => inputFloats[Input.LEFTGRIP      ];
    public float leftControllerTrigger     => inputFloats[Input.LEFTTRIGGER   ];
    public vec2  leftControllerJoystick    => inputVecs  [Input.LEFTJOYSTICK  ];
    
    
    private vec3 previousHeadsetRoomPosition = vec3.ZERO;
    private quat previousHeadsetRoomRotation = quat.IDENTITY;


    private struct Input
    {
        public const int HEADPOSE       = 0;
        public const int RIGHTPOSE      = 1;
        public const int LEFTPOSE       = 2;

        public const int RIGHTMENU      = 0;
        public const int RIGHTPRIMARY   = 1;
        public const int RIGHTSECONDARY = 2;
        public const int LEFTMENU       = 3;
        public const int LEFTPRIMARY    = 4;
        public const int LEFTSECONDARY  = 5;
        
        public const int RIGHTGRIP      = 0;
        public const int RIGHTTRIGGER   = 1;
        public const int LEFTGRIP       = 2;
        public const int LEFTTRIGGER    = 3;
        
        public const int RIGHTJOYSTICK  = 0;
        public const int LEFTJOYSTICK   = 1;


        public const int POSECOUNT      = 3;
        public const int BOOLCOUNT      = 6;
        public const int FLOATCOUNT     = 4;
        public const int VECCOUNT       = 2;
    }


    private readonly static XRProfile[] profiles =
    [
        // https://registry.khronos.org/OpenXR/specs/1.0/html/xrspec.html#semantic-path-interaction-profiles

        new XRProfile
        (
            "/interaction_profiles/oculus/touch_controller",
            
            new XRInput("right_pose", XrActionType.XR_ACTION_TYPE_POSE_INPUT, "/user/hand/right/input/grip/pose", Input.RIGHTPOSE),
            [
                new XRInput("right_menu"        , XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT , "/user/hand/right/input/system/click" , Input.RIGHTMENU     ),
                new XRInput("right_primary"     , XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT , "/user/hand/right/input/a/click"      , Input.RIGHTPRIMARY  ),
                new XRInput("right_secondary"   , XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT , "/user/hand/right/input/b/click"      , Input.RIGHTSECONDARY),
                new XRInput("right_grip"        , XrActionType.XR_ACTION_TYPE_FLOAT_INPUT   , "/user/hand/right/input/squeeze/value", Input.RIGHTGRIP     ),
                new XRInput("right_trigger"     , XrActionType.XR_ACTION_TYPE_FLOAT_INPUT   , "/user/hand/right/input/trigger/value", Input.RIGHTTRIGGER  ),
                new XRInput("right_joystick"    , XrActionType.XR_ACTION_TYPE_VECTOR2F_INPUT, "/user/hand/right/input/thumbstick"   , Input.RIGHTJOYSTICK ),
            ],

            new XRInput("left_pose",  XrActionType.XR_ACTION_TYPE_POSE_INPUT, "/user/hand/left/input/grip/pose",  Input.LEFTPOSE),
            [
                new XRInput("left_menu"         , XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT , "/user/hand/left/input/menu/click"    , Input.LEFTMENU      ),
                new XRInput("left_primary"      , XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT , "/user/hand/left/input/x/click"       , Input.LEFTPRIMARY   ),
                new XRInput("left_secondary"    , XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT , "/user/hand/left/input/y/click"       , Input.LEFTSECONDARY ),
                new XRInput("left_grip"         , XrActionType.XR_ACTION_TYPE_FLOAT_INPUT   , "/user/hand/left/input/squeeze/value" , Input.LEFTGRIP      ),
                new XRInput("left_trigger"      , XrActionType.XR_ACTION_TYPE_FLOAT_INPUT   , "/user/hand/left/input/trigger/value" , Input.LEFTTRIGGER   ),
                new XRInput("left_joystick"     , XrActionType.XR_ACTION_TYPE_VECTOR2F_INPUT, "/user/hand/left/input/thumbstick"    , Input.LEFTJOYSTICK  ),
            ]
        ),
    ];


    private readonly List<ulong> profileHash;
    private readonly ulong       rightPath;
    private readonly ulong       leftPath ;

    private readonly XRPose  [] inputPoses   = new XRPose  [Input.POSECOUNT ];
    private readonly bool    [] inputBools   = new bool    [Input.BOOLCOUNT ];
    private readonly float   [] inputFloats  = new float   [Input.FLOATCOUNT];
    private readonly vec2    [] inputVecs    = new vec2    [Input.VECCOUNT  ];


    private readonly (
        XRAction   rightPose  ,
        XRAction[] rightBools ,
        XRAction[] rightFloats,
        XRAction[] rightVecs  ,
        
        XRAction   leftPose   ,
        XRAction[] leftBools  ,
        XRAction[] leftFloats ,
        XRAction[] leftVecs
    )[] profileActions;


    private readonly XRActionSet                          actionSet                           ;
    private readonly XrActionSuggestedBinding[][]         actionSuggestedBindings             ;
    private readonly XrSessionActionSetsAttachInfo        sessionActionSetsAttachInfo         ;

    private readonly XrInteractionProfileSuggestedBinding interactionProfileSuggestedBinding  ;

    private readonly XrInteractionProfileState            rightInteractionProfileState;
    private readonly XrInteractionProfileState            leftInteractionProfileState;
    

    private readonly XrActiveActionSet activeActionSet;
    private          XrActionsSyncInfo actionsSyncInfo;



    public XRInputs(XRInstance _xrInstance, XRSession _xrSession)
    {
        for (int _i = 0; _i < inputPoses.Length; _i++) inputPoses[_i] = new XRPose(vec3.ZERO, quat.IDENTITY);
        
        actionSet               = new XRActionSet           (_xrInstance, "action_set", "Bindings");
        actionSuggestedBindings = new XrActionSuggestedBinding[profiles.Length][]                    ;
        
        profileActions          = new (XRAction, XRAction[], XRAction[], XRAction[], XRAction, XRAction[], XRAction[], XRAction[])[profiles.Length];

        profileHash             = new List<ulong>();
        rightPath               = XRPath.StringToPath(_xrInstance, "/user/hand/right");
        leftPath                = XRPath.StringToPath(_xrInstance, "/user/hand/left" );


        interactionProfileSuggestedBinding = new XrInteractionProfileSuggestedBinding()
        {
            type                   = XrStructureType.XR_TYPE_INTERACTION_PROFILE_SUGGESTED_BINDING,
            next                   = null                                            ,
        };


        for (int _i = 0; _i < profiles.Length; _i++)
        {
            XRProfile _profile  = profiles[_i]                                   ;
            ulong     _pathName = XRPath.StringToPath(_xrInstance, _profile.name);

            profileHash.Add(_pathName);

            profileActions[_i] = (
                new XRAction(_xrInstance, _xrSession, actionSet, _profile.rightPose),
                _profile.rightInputs.Where(_input => _input.type == XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT ).Select(_input => new XRAction(_xrInstance, _xrSession, actionSet, _input)).ToArray(),
                _profile.rightInputs.Where(_input => _input.type == XrActionType.XR_ACTION_TYPE_FLOAT_INPUT   ).Select(_input => new XRAction(_xrInstance, _xrSession, actionSet, _input)).ToArray(),
                _profile.rightInputs.Where(_input => _input.type == XrActionType.XR_ACTION_TYPE_VECTOR2F_INPUT).Select(_input => new XRAction(_xrInstance, _xrSession, actionSet, _input)).ToArray(),

                new XRAction(_xrInstance, _xrSession, actionSet, _profile.leftPose),
                _profile.leftInputs.Where(_input => _input.type == XrActionType.XR_ACTION_TYPE_BOOLEAN_INPUT ).Select(_input => new XRAction(_xrInstance, _xrSession, actionSet, _input)).ToArray(),
                _profile.leftInputs.Where(_input => _input.type == XrActionType.XR_ACTION_TYPE_FLOAT_INPUT   ).Select(_input => new XRAction(_xrInstance, _xrSession, actionSet, _input)).ToArray(),
                _profile.leftInputs.Where(_input => _input.type == XrActionType.XR_ACTION_TYPE_VECTOR2F_INPUT).Select(_input => new XRAction(_xrInstance, _xrSession, actionSet, _input)).ToArray()
            );
            

            List<XrActionSuggestedBinding> _actionSuggestedBindings = new List<XrActionSuggestedBinding>();

            _actionSuggestedBindings.Add     (profileActions[_i].rightPose.suggestedBinding);
            _actionSuggestedBindings.AddRange(profileActions[_i].rightBools .Select(_action => _action.suggestedBinding));
            _actionSuggestedBindings.AddRange(profileActions[_i].rightFloats.Select(_action => _action.suggestedBinding));
            _actionSuggestedBindings.AddRange(profileActions[_i].rightVecs  .Select(_action => _action.suggestedBinding));

            _actionSuggestedBindings.Add     (profileActions[_i].leftPose.suggestedBinding);
            _actionSuggestedBindings.AddRange(profileActions[_i].leftBools  .Select(_action => _action.suggestedBinding));
            _actionSuggestedBindings.AddRange(profileActions[_i].leftFloats .Select(_action => _action.suggestedBinding));
            _actionSuggestedBindings.AddRange(profileActions[_i].leftVecs   .Select(_action => _action.suggestedBinding));

            
            actionSuggestedBindings[_i] = _actionSuggestedBindings.ToArray();


            fixed (XrActionSuggestedBinding* _suggestedBindingsPtr = &actionSuggestedBindings[_i][0])
            { 
                interactionProfileSuggestedBinding.interactionProfile     = _pathName                               ;
                
                interactionProfileSuggestedBinding.countSuggestedBindings = (uint)actionSuggestedBindings[_i].Length;
                interactionProfileSuggestedBinding.suggestedBindings      = _suggestedBindingsPtr                   ;
                
                fixed (XrInteractionProfileSuggestedBinding* _interactionProfileSuggestedBindingPtr = &interactionProfileSuggestedBinding)
                {
                    TimmyXR.xrSuggestInteractionProfileBindings(_xrInstance.instance, _interactionProfileSuggestedBindingPtr);
                }
            }
        }


        fixed (XrActionSet* _actionSetPtr = &actionSet.actionSet)
        {
            sessionActionSetsAttachInfo = new XrSessionActionSetsAttachInfo()
            {
                type            = XrStructureType.XR_TYPE_SESSION_ACTION_SETS_ATTACH_INFO,
                next            = null                                     ,
                
                countActionSets = 1                                        ,
                actionSets      = _actionSetPtr                            ,
            };
        }

        fixed (XrSessionActionSetsAttachInfo* _sessionActionSetsAttachInfoPtr = &sessionActionSetsAttachInfo)
        {
            TimmyXR.xrAttachSessionActionSets(_xrSession.session, _sessionActionSetsAttachInfoPtr);
        }


        activeActionSet = new XrActiveActionSet()
        {
            actionSet     = actionSet.actionSet,
            subactionPath = 0                  ,
        };

        fixed (XrActiveActionSet* _activeActionSetPtr = &activeActionSet)
        {
            actionsSyncInfo = new XrActionsSyncInfo()
            {
                type                  = XrStructureType.XR_TYPE_ACTIONS_SYNC_INFO,
                next                  = null                         ,

                countActiveActionSets = 1                            ,
                activeActionSets      = _activeActionSetPtr          ,
            };
        }

        rightInteractionProfileState = new XrInteractionProfileState()
        {
            type = XrStructureType.XR_TYPE_INTERACTION_PROFILE_STATE,
            next = null                                             ,
        };
        leftInteractionProfileState = new XrInteractionProfileState()
        {
            type = XrStructureType.XR_TYPE_INTERACTION_PROFILE_STATE,
            next = null                                             ,
        };
    }
    

    public void UpdateActions(XRInstance _xrInstance, XRSession _xrSession, XRSpace _xrSpace, XRView[] _views, long _predictedDisplayTime)
    {
        fixed (XrActiveActionSet* _activeActionSetPtr = &activeActionSet)
        fixed (XrActionsSyncInfo* _actionsSyncInfoPtr = &actionsSyncInfo)
        {
            actionsSyncInfo.activeActionSets = _activeActionSetPtr;
            if (TimmyXR.xrSyncActions(_xrSession.session, _actionsSyncInfoPtr) != XrResult.XR_SUCCESS) return;
        }

        fixed (XrInteractionProfileState* _rightInteractionProfileStatePtr = &rightInteractionProfileState)
        fixed (XrInteractionProfileState* _leftInteractionProfileStatePtr  = &leftInteractionProfileState )
        {
            TimmyXR.xrGetCurrentInteractionProfile(_xrSession.session, rightPath, _rightInteractionProfileStatePtr);
            TimmyXR.xrGetCurrentInteractionProfile(_xrSession.session, leftPath , _leftInteractionProfileStatePtr);
        }

        int _rightIndex = profileHash.IndexOf(rightInteractionProfileState.interactionProfile);
        int _leftIndex  = profileHash.IndexOf(leftInteractionProfileState .interactionProfile);

        if (_rightIndex != -1)
        {
            var _profile = profileActions[_rightIndex];

            rightControllerActive = _profile.rightPose.GetPose(_xrSession, _xrSpace, _predictedDisplayTime, out XRPose _pose);

            if (rightControllerActive)
            {
                inputPoses[Input.RIGHTPOSE] = _pose;

                foreach (XRAction _action in _profile.rightBools ) inputBools [_action.input.index] = _action.GetBool (_xrSession);
                foreach (XRAction _action in _profile.rightFloats) inputFloats[_action.input.index] = _action.GetFloat(_xrSession);
                foreach (XRAction _action in _profile.rightVecs  ) inputVecs  [_action.input.index] = _action.GetVec2 (_xrSession);
            }
        }

        if (_leftIndex != -1)
        {
            var _profile = profileActions[_leftIndex];

            leftControllerActive  = _profile.leftPose.GetPose(_xrSession, _xrSpace, _predictedDisplayTime, out XRPose _pose);

            if (leftControllerActive)
            {
                inputPoses[Input.LEFTPOSE ] = _pose;
                
                foreach (XRAction _action in _profile.leftBools ) inputBools [_action.input.index] = _action.GetBool (_xrSession);
                foreach (XRAction _action in _profile.leftFloats) inputFloats[_action.input.index] = _action.GetFloat(_xrSession);
                foreach (XRAction _action in _profile.leftVecs  ) inputVecs  [_action.input.index] = _action.GetVec2 (_xrSession);
            }
        }
        
        
        XRView _leftEye  = _views[0];
        XRView _rightEye = _views[1];
        
        inputPoses[Input.HEADPOSE] = new XRPose
        (
                      (_leftEye.position + _rightEye.position) * 0.5f,
            quat.Slerp(_leftEye.rotation,  _rightEye.rotation,   0.5f)
        );
    }
}