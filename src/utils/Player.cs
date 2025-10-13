


using System.IO;

namespace Engine;


public static class Player
{
    private static Transform pivot;
    
    private static vec3 previousHeadsetPosition         = vec3.ZERO;
    private static vec3 previousLeftControllerPosition  = vec3.ZERO;
    private static vec3 previousRightControllerPosition = vec3.ZERO;
    
    public static quat direction = quat.IDENTITY;
    
    public static Renderable head;
    public static Renderable neck;
    public static Renderable chest;
    public static Renderable torso;
    
    public static Renderable rightElbow;
    public static Renderable rightForearm;
    public static Renderable rightPalm;
    
    public static Renderable leftElbow;
    public static Renderable leftForearm;
    public static Renderable leftPalm;
    
    
    private static void OnBegin()
    {
        pivot = new Transform(null, vec3.ZERO, quat.IDENTITY, vec3.ONE);
        
        Mesh   _mesh   = new Mesh  (File.ReadAllLines("assets/models/debug/Cube.obj")                                              );
        Shader _shader = new Shader(File.ReadAllText ("assets/shaders/Test.vert"    ), File.ReadAllText("assets/shaders/Test.frag"));
        
        head = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            // new vec3(0.14f, 0.22f, 0.18f),
            vec3.ZERO,
            _mesh,
            _shader,
            () => { }
        );
        neck = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.07f, 0.08f, 0.07f),
            // vec3.ZERO,
            _mesh,
            _shader,
            () => { }
        );
        chest = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.36f, 0.30f, 0.15f),
            // vec3.ZERO,
            _mesh,
            _shader,
            () => { }
        );
        torso = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.28f, 0.28f, 0.20f),
            _mesh,
            _shader,
            () => { }
        );
        
        leftElbow = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.05f, 0.05f, 0.25f),
            _mesh,
            _shader,
            () => { }
        );
        leftForearm = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.05f, 0.05f, 0.35f),
            _mesh,
            _shader,
            () => { }
        );
        leftPalm = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.07f, 0.03f, 0.09f),
            _mesh,
            _shader,
            () => { }
        );
        
        rightElbow = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.05f, 0.05f, 0.25f),
            _mesh,
            _shader,
            () => { }
        );
        rightForearm = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.05f, 0.05f, 0.35f),
            _mesh,
            _shader,
            () => { }
        );
        rightPalm = new Renderable
        (
            pivot,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.07f, 0.03f, 0.09f),
            _mesh,
            _shader,
            () => { }
        );
    }
    
    private static void OnBeginUpdate()
    {
        vec3 _headsetPosDelta           = Input.headsetPosition         - previousHeadsetPosition;
        vec3 _leftControllerPosDelta    = Input.leftControllerPosition  - previousLeftControllerPosition;
        vec3 _rightControllerPosDelta   = Input.rightControllerPosition - previousRightControllerPosition;

        previousHeadsetPosition         = Input.headsetPosition;
        previousLeftControllerPosition  = Input.leftControllerPosition;
        previousRightControllerPosition = Input.rightControllerPosition;
        
        
        float _speed    = 2f * Time.delta;
        vec3  _movement = new vec3(Input.rightControllerJoystick.x *  _speed, 0f, Input.rightControllerJoystick.y * -_speed);
        
        pivot.localPosition += quat.Rotate((quat)((vec3)head.rotation)._y_, _movement);
        
        
        float _sensitivity = 3f * Time.delta;
        quat  _rotation    = (quat)new vec3(0f, (Input.leftControllerTrigger - Input.rightControllerTrigger) * _sensitivity, 0f);
        direction          = _rotation + direction;
        
        leftPalm .localPosition += quat.Rotate(_rotation, leftPalm .localPosition - head.localPosition) - (leftPalm .localPosition - head.localPosition);
        rightPalm.localPosition += quat.Rotate(_rotation, rightPalm.localPosition - head.localPosition) - (rightPalm.localPosition - head.localPosition);
        
        
        head     .localPosition += quat.Rotate(direction, _headsetPosDelta        );
        leftPalm .localPosition += quat.Rotate(direction, _leftControllerPosDelta );
        rightPalm.localPosition += quat.Rotate(direction, _rightControllerPosDelta);
        
        head     .localRotation  = direction + Input.headsetRotation        ;
        leftPalm .localRotation  = direction + Input.leftControllerRotation ;
        rightPalm.localRotation  = direction + Input.rightControllerRotation;
        
        
        axisAngle _axis = (axisAngle)head.localRotation;
        _axis.axis.x   *= 0.5f;
        _axis.axis.z   *= 0.5f;
        _axis.axis      = vec3.Normalize(_axis.axis);
        quat _rot       = (quat)_axis;
        
        neck.localPosition = head.localPosition + quat.Rotate(head.localRotation, vec3.DOWN * 0.11f);
        neck.localRotation = _rot;
        
        chest.localPosition = neck .localPosition + vec3.DOWN * 0.17f;
        chest.localRotation = (quat)((vec3)neck.localRotation)._y_;
        
        torso.localPosition = chest.localPosition + vec3.DOWN * 0.30f;
        torso.localRotation = chest.localRotation;
        
        
        (
            rightElbow  .localPosition, 
            rightForearm.localPosition, 
            rightElbow  .localRotation,
            rightForearm.localRotation 
        )
            = IK.BendPoint
        (
            chest    .localPosition + vec3.UP * 0.10f + quat.Rotate(chest    .localRotation, vec3.RIGHT * 0.18f),
            rightPalm.localPosition +                   quat.Rotate(rightPalm.localRotation, vec3.BACK  * 0.07f),
            0.25f,
            0.35f,
            vec3.Slerp(quat.Rotate(rightPalm.localRotation, vec3.BACK), quat.Rotate(chest.localRotation, new vec3(0.707f, -0.707f, 0f)), 0.3f)
        );
        
        (
            leftElbow  .localPosition,
            leftForearm.localPosition,
            leftElbow  .localRotation,
            leftForearm.localRotation
        )
            = IK.BendPoint
        (
            chest   .localPosition + vec3.UP * 0.10f + quat.Rotate(chest   .localRotation, vec3.LEFT * 0.18f),
            leftPalm.localPosition +                   quat.Rotate(leftPalm.localRotation, vec3.BACK * 0.07f),
            0.25f,
            0.35f,
            vec3.Slerp(quat.Rotate(leftPalm.localRotation, vec3.BACK), quat.Rotate(chest.localRotation, new vec3(-0.707f, -0.707f, 0f)), 0.3f)
        );


        Camera.position = head.position;
        Camera.rotation = head.rotation;
    }
}