using System.IO;


namespace Engine;


public static class Testing
{
    private static Renderable renderable;
    
    
    
    private static void OnBegin()
    {
        renderable = new Renderable
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
        
        renderable.Dispose();
    }
    
    
    // private static bool _prevDown;
    // private static void OnUpdate()
    // {
    //     renderable.localPosition = Input.rightControllerPosition;
    //     renderable.localRotation = Input.rightControllerRotation;
    //     renderable.localScale    = new vec3(Input.rightControllerTrigger * 0.1f + 0.1f);
        
    //     if (Input.rightControllerSecondary && !_prevDown)
    //     {
    //         OpenXR.Recenter();
    //     }
    //     if (Input.rightControllerSecondary != _prevDown)
    //     {
    //         _prevDown = Input.rightControllerSecondary;
    //     }
    // }
}