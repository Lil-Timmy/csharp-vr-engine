using System.IO;
using static Engine.GL;


namespace Engine;


public class DebugCube : Transform
{
    public vec3  color;
    
    
    public DebugCube(vec3 _position, quat _rotation, vec3 _scale, vec3 _color) : base(null, _position, _rotation, _scale)
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
            glDrawArrays(GL_LINES, 0, 25);
        });
    }
    
    
    
    private static Shader      shader;
    private static VertexArray vertexArray;
    
    
    private static void OnBegin()
    {
        shader      = new Shader(File.ReadAllText("assets/shaders/debug/Cube.vert"), File.ReadAllText("assets/shaders/debug/Cube.frag"));
        vertexArray = new VertexArray();
    }
}