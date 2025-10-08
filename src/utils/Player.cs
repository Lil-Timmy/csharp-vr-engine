


using System.IO;

namespace Engine;


public static class Player
{
    private static Transform pivot;
    
    private static vec3 previousHeadsetPosition         = vec3.ZERO;
    private static vec3 previousLeftControllerPosition  = vec3.ZERO;
    private static vec3 previousRightControllerPosition = vec3.ZERO;
    
    private static quat direction = quat.IDENTITY;
    
    private static Renderable head;
    private static Renderable neck;
    private static Renderable chest;
    private static Renderable torso;
    
    private static Renderable rightShoulder;
    private static Renderable rightElbow;
    private static Renderable rightWrist;
    private static Renderable rightPalm;
    
    private static Renderable leftShoulder;
    private static Renderable leftElbow;
    private static Renderable leftWrist;
    private static Renderable leftPalm;
    
    
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
        vec3 _headsetPosDelta           = Input.headsetPosition         - previousHeadsetPosition;
        vec3 _leftControllerPosDelta    = Input.leftControllerPosition  - previousLeftControllerPosition;
        vec3 _rightControllerPosDelta   = Input.rightControllerPosition - previousRightControllerPosition;

        previousHeadsetPosition         = Input.headsetPosition;
        previousLeftControllerPosition  = Input.leftControllerPosition;
        previousRightControllerPosition = Input.rightControllerPosition;
        
        
        float _speed    = 2f * Time.delta;
        vec3  _movement = new vec3(Input.rightControllerJoystick.x *  _speed, 0f, Input.rightControllerJoystick.y * -_speed);
        
        pivot.localPosition += quat.Rotate((quat)((vec3)head.rotation)._y_, _movement);
        
        
        float _sensitivity = 1f * Time.delta;
        quat  _rotation    = (quat)new vec3(0f, (Input.leftControllerTrigger - Input.rightControllerTrigger) * _sensitivity, 0f);
        direction          = _rotation + direction;
        
        leftPalm .localPosition += quat.Rotate(_rotation, leftPalm .localPosition - head.localPosition) - (leftPalm .localPosition - head.localPosition);
        rightPalm.localPosition += quat.Rotate(_rotation, rightPalm.localPosition - head.localPosition) - (rightPalm.localPosition - head.localPosition);
        
        
        head     .localPosition  = quat.Rotate(direction, _headsetPosDelta        ) + head     .localPosition;
        leftPalm .localPosition  = quat.Rotate(direction, _leftControllerPosDelta ) + leftPalm .localPosition;
        rightPalm.localPosition  = quat.Rotate(direction, _rightControllerPosDelta) + rightPalm.localPosition;
        
        head     .localRotation  = direction + Input.headsetRotation        ;
        leftPalm .localRotation  = direction + Input.leftControllerRotation ;
        rightPalm.localRotation  = direction + Input.rightControllerRotation;
        
        
        Camera.position = head.position;
        Camera.rotation = head.rotation;
    }
}