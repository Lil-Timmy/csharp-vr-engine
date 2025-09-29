using System.IO;


namespace Engine;


public static class Testing
{
    private static Renderable right;
    private static Renderable left;
    
    
    
    private static void OnBegin()
    {
        right = new Renderable
        (
            null,
            
            vec3.ZERO,
            quat.IDENTITY,
            vec3.ONE,
            
            new Mesh("src/models/Test.obj"),
            new Shader
            (
                File.ReadAllText("src/shaders/Test.vert"),
                File.ReadAllText("src/shaders/Test.frag")
            ),
            () =>
            {
                // renderable.shader.Uniform("uTest", 0f);
            }
        );
        left = new Renderable
        (
            null,
            
            vec3.ZERO,
            quat.IDENTITY,
            vec3.ONE,
            
            new Mesh("src/models/Test.obj"),
            new Shader
            (
                File.ReadAllText("src/shaders/Test.vert"),
                File.ReadAllText("src/shaders/Test.frag")
            ),
            () =>
            {
                // renderable.shader.Uniform("uTest", 0f);
            }
        );
    }
    
    
    private static bool _prevDown;
    private static void OnUpdate()
    {
        right.localPosition = Input.rightControllerPosition;
        right.localRotation = Input.rightControllerRotation;
        right.localScale    = new vec3(Input.rightControllerTrigger * 1.0f + 0.1f);
        
        left.localPosition  = Input.leftControllerPosition;
        left.localRotation  = Input.leftControllerRotation;
        left.localScale     = new vec3(Input.leftControllerTrigger  * 1.0f + 0.1f);
        
        if (Input.rightControllerSecondary && !_prevDown)
        {
            OpenXR.Recenter();
        }
        if (Input.rightControllerSecondary != _prevDown)
        {
            _prevDown = Input.rightControllerSecondary;
        }
    }
}