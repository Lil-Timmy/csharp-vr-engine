using System.IO;


namespace Engine;


public static class Testing
{
    private static DebugCube right;
    private static DebugCube left;
    
    private static DebugLine[] lines;
    private static Renderable  sphere;
    
    
    private static void OnBegin()
    {
        right = new DebugCube(vec3.ZERO, quat.IDENTITY, new vec3(0.5f), vec3.ONE);
        left  = new DebugCube(vec3.ZERO, quat.IDENTITY, new vec3(0.5f), vec3.ONE);
        
        lines = new DebugLine[3];
        lines[0] = new DebugLine(vec3.ZERO, vec3.ZERO, new vec3(1, 0, 0));
        lines[1] = new DebugLine(vec3.ZERO, vec3.ZERO, new vec3(0, 1, 0));
        lines[2] = new DebugLine(vec3.ZERO, vec3.ZERO, new vec3(0, 0, 1));
        
        Renderable _room = new Renderable
        (
            null,
            vec3.ZERO,
            quat.IDENTITY,
            vec3.ONE,
            new Mesh  (File.ReadAllLines("assets/models/Room.obj"  )                                            ),
            new Shader(File.ReadAllText ("assets/shaders/Test.vert") , File.ReadAllText("assets/shaders/Test.frag")),
            () =>
            {
                
            }
        );
        
        sphere = new Renderable
        (
            null,
            vec3.UP,
            quat.IDENTITY,
            new vec3(0.05f),
            new Mesh(File.ReadAllLines("assets/models/debug/Sphere.obj")),
            new Shader(File.ReadAllText ("assets/shaders/Test.vert"    ), File.ReadAllText("assets/shaders/Test.frag")),
            () => { }
        );
    }
    
    
    private static void OnUpdate()
    {
        right.position = Input.rightControllerPosition;
        right.rotation = Input.rightControllerRotation;
        right.scale    = new vec3(Input.rightControllerTrigger * 0.2f + 0.01f);
        
        left.position = Input.leftControllerPosition;
        left.rotation = Input.leftControllerRotation;
        left.scale    = new vec3(Input.leftControllerTrigger * 0.2f + 0.01f);


        // sphere.position = _rightTargetPos;
        // lines[0].start = _rightStart    ; lines[0].end = _rightTargetPos;
        // lines[1].start = _rightEnd      ; lines[1].end = _rightTargetPos;
        // lines[2].start = _rightTargetPos; lines[2].end = _rightTargetPos + quat.Rotate(Player.rightPalm.localRotation, vec3.UP * 0.2f);
    }
}