


using System.IO;

namespace Engine;


public static class Player
{
    private static Transform pivot;
    
    private static vec3 previousHeadsetPosition         = vec3.ZERO;
    private static quat previousHeadsetRotation         = quat.IDENTITY;
    
    private static vec3 previousLeftControllerPosition  = vec3.ZERO;
    private static quat previousLeftControllerRotation  = quat.IDENTITY;
    private static vec3 previousRightControllerPosition = vec3.ZERO;
    private static quat previousRightControllerRotation = quat.IDENTITY;
    
    private static Renderable head;
    private static Renderable rightPalm;
    private static Renderable leftPalm;
    
    private static Renderable neck;
    private static Renderable chest;
    
    
    private static void OnBegin()
    {
        pivot = new Transform(null, vec3.ZERO, quat.IDENTITY, vec3.ONE);
        
        Mesh   _mesh   = new Mesh  (File.ReadAllLines("assets/models/debug/Cube.obj")                                           );
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
        // neck = new Renderable
        // (
        //     pivot,
        //     vec3.ZERO,
        //     quat.IDENTITY,
        //     // new vec3(0.07f, 0.08f, 0.07f),
        //     vec3.ZERO,
        //     _mesh,
        //     _shader,
        //     () => { }
        // );
        // chest = new Renderable
        // (
        //     pivot,
        //     vec3.ZERO,
        //     quat.IDENTITY,
        //     new vec3(0.36f, 0.30f, 0.20f),
        //     _mesh,
        //     _shader,
        //     () => { }
        // );
    }
    
    private static void OnBeginUpdate()
    {
        vec3 _headsetPosDelta           = Input.headsetPosition         -              previousHeadsetPosition;
        quat _headsetRotDelta           = Input.headsetRotation         + quat.Inverse(previousHeadsetRotation);
        vec3 _leftControllerPosDelta    = Input.leftControllerPosition  -              previousLeftControllerPosition;
        quat _leftControllerRotDelta    = Input.leftControllerRotation  + quat.Inverse(previousLeftControllerRotation);
        vec3 _rightControllerPosDelta   = Input.rightControllerPosition -              previousRightControllerPosition;
        quat _rightControllerRotDelta   = Input.rightControllerRotation + quat.Inverse(previousRightControllerRotation);
        
        previousHeadsetPosition         = Input.headsetPosition;
        previousHeadsetRotation         = Input.headsetRotation;
        previousLeftControllerPosition  = Input.leftControllerPosition;
        previousLeftControllerRotation  = Input.leftControllerRotation;
        previousRightControllerPosition = Input.rightControllerPosition;
        previousRightControllerRotation = Input.rightControllerRotation;


        pivot .localPosition = _headsetPosDelta.x_z + pivot.localPosition;
        
        head  .localPosition = _headsetPosDelta._y_ + head.localPosition;
        head  .localRotation = _headsetRotDelta     + head.localRotation;
        
        leftPalm .localPosition  = _leftControllerPosDelta  - _headsetPosDelta.x_z    + leftPalm .localPosition;
        leftPalm .localRotation  = _leftControllerRotDelta                            + leftPalm .localRotation;
        rightPalm.localPosition  = _rightControllerPosDelta - _headsetPosDelta.x_z    + rightPalm.localPosition;
        rightPalm.localRotation  = _rightControllerRotDelta                           + rightPalm.localRotation;
        
        
        float _speed   = 2f * Time.delta;
        vec3 _movement = new vec3(Input.rightControllerJoystick.x *  _speed, 0f, Input.rightControllerJoystick.y * -_speed);
        pivot.localPosition += quat.Rotate((quat)((vec3)head.rotation)._y_, _movement);
        
        Camera.position = head.position;
        Camera.rotation = head.rotation;
    }
}