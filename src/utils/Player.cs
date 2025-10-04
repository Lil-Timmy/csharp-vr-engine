


using System.IO;

namespace Engine;


public static class Player
{
    private static Transform parent;
    
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
        parent = new Transform(null, vec3.ZERO, quat.IDENTITY, vec3.ONE);
        
        Mesh   _mesh   = new Mesh  (File.ReadAllLines("assets/models/debug/Cube.obj")                                           );
        Shader _shader = new Shader(File.ReadAllText ("assets/shaders/Test.vert"    ), File.ReadAllText("assets/shaders/Test.frag"));
        
        head = new Renderable
        (
            parent,
            vec3.ZERO,
            quat.IDENTITY,
            // new vec3(0.14f, 0.22f, 0.18f),
            vec3.ZERO,
            _mesh,
            _shader,
            () =>
            {
                head.localPosition = Input.headsetPosition;
                head.localRotation = Input.headsetRotation;
            }
        );
        leftPalm = new Renderable
        (
            parent,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.07f, 0.03f, 0.09f),
            _mesh,
            _shader,
            () =>
            {
                leftPalm.localPosition = Input.leftControllerPosition;
                leftPalm.localRotation = Input.leftControllerRotation;
            }
        );
        rightPalm = new Renderable
        (
            parent,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.07f, 0.03f, 0.09f),
            _mesh,
            _shader,
            () =>
            {
                rightPalm.localPosition = Input.rightControllerPosition;
                rightPalm.localRotation = Input.rightControllerRotation;
            }
        );
        
        neck = new Renderable
        (
            parent,
            vec3.ZERO,
            quat.IDENTITY,
            // new vec3(0.07f, 0.08f, 0.07f),
            vec3.ZERO,
            _mesh,
            _shader,
            () =>
            {
                neck.localPosition = head.localPosition + head.localRotation * vec3.DOWN * 0.13f;
                neck.localRotation = head.localRotation;
                Debug.Log((vec3)head.rotation);
            }
        );
        chest = new Renderable
        (
            parent,
            vec3.ZERO,
            quat.IDENTITY,
            new vec3(0.36f, 0.30f, 0.20f),
            _mesh,
            _shader,
            () =>
            {
                chest.localPosition = neck.localPosition + vec3.DOWN * 0.17f;
                chest.localRotation = quat.IDENTITY;
            }
        );
    }
    
    
    private static void OnUpdate()
    {
        // parent.position = new vec3(-Input.headsetPosition.x - 1.5f, 0f, -Input.headsetPosition.z + 0.5f);
    }
}