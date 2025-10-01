using System.IO;
using static Engine.GL;


namespace Engine;


public class DebugSphere : Transform
{
    public vec3  color;
    
    
    public DebugSphere(vec3 _position, quat _rotation, vec3 _scale, vec3 _color) : base(null, _position, _rotation, _scale)
    {
        color = _color;
    }

    protected override void Render()
    {
        shader     .Bind();
        vertexArray.Bind();
        
        shader.Uniform("uWorldMat", scaleMatrix * rotationMatrix * positionMatrix);
        shader.Uniform("uColor"      , color   );
        
        OpenXR.Draw(shader, () =>
        {
            glDrawArraysInstanced(GL_LINE_STRIP, 0, 25, 3);
        });
    }
    
    
    
    private static Shader      shader;
    private static VertexArray vertexArray;
    
    
    private static void OnBegin()
    {
        shader      = new Shader(File.ReadAllText("src/shaders/debug/Sphere.vert"), File.ReadAllText("src/shaders/debug/Sphere.frag"));
        vertexArray = new VertexArray();
    }
}