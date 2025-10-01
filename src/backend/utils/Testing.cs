using System.IO;


namespace Engine;


public static class Testing
{
    private static DebugSphere right;
    private static DebugCube   left;
    
    
    private static void OnBegin()
    {
        right = new DebugSphere(vec3.ZERO, quat.IDENTITY, new vec3(0.5f), vec3.ONE);
        left  = new DebugCube  (vec3.ZERO, quat.IDENTITY, new vec3(0.5f), vec3.ONE);
        
        Renderable _room = new Renderable
        (
            null,
            vec3.ZERO,
            quat.IDENTITY,
            vec3.ONE,
            new Mesh  ("src/models/Room.obj"),
            new Shader(File.ReadAllText("src/shaders/Test.vert"), File.ReadAllText("src/shaders/Test.frag")),
            () =>
            {
                
            }
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
        
        if (Input.rightControllerSecondary)
        {
            TestCamera.position =       Input.headsetPosition;
            TestCamera.rotation = (vec3)Input.headsetRotation;
        }
    }
}