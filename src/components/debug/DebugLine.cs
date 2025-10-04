using System.IO;
using static Engine.GL;


namespace Engine;


public class DebugLine : Entity
{
    public vec3  start;
    public vec3  end;
    public vec3  color;
    
    
    public DebugLine(vec3 _start, vec3 _end, vec3 _color)
    {
        start = _start;
        end   = _end;
        color = _color;
    }

    protected override void Render()
    {
        shader     .Bind();
        vertexArray.Bind();
        
        shader.Uniform("uStart", start);
        shader.Uniform("uEnd"  , end  );
        shader.Uniform("uColor", color);
        
        OpenXR.Draw(shader, () =>
        {
            glDrawArrays(GL_LINES, 0, 2);
        });
    }
    
    
    
    private static Shader      shader;
    private static VertexArray vertexArray;
    
    
    private static void OnBegin()
    {
        shader      = new Shader(File.ReadAllText("assets/shaders/debug/Line.vert"), File.ReadAllText("assets/shaders/debug/Line.frag"));
        vertexArray = new VertexArray();
    }
}