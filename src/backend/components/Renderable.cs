using System;
using static Engine.GL;


namespace Engine;


public class Renderable : Transform
{
    public readonly Mesh        mesh;
    public readonly Shader      shader;
    public readonly VertexArray vertexArray;
    public readonly Action      callback;
    
    
    public Renderable(Transform _parent, vec3 _position, quat _rotation, vec3 _scale, Mesh _mesh, Shader _shader, Action _callback) : base(_parent, _position, _rotation, _scale)
    {
        mesh     = _mesh;
        shader   = _shader;
        callback = _callback;
        
        shader.Bind();
        vertexArray = new VertexArray();
        
        vertexArray.Attribute(mesh.vertexBuffer, "vPosition", 3, 8, 0, false);
        vertexArray.Attribute(mesh.vertexBuffer, "vUV"      , 2, 8, 3, false);
        vertexArray.Attribute(mesh.vertexBuffer, "vNormal"  , 3, 8, 5, false);
    }

    protected override void Render()
    {
        shader.Bind();
        vertexArray.Bind();
        
        shader.Uniform("uPositionMat", positionMatrix);
        shader.Uniform("uRotationMat", rotationMatrix);
        shader.Uniform("uScaleMat"   , scaleMatrix   );
        
        OpenXR.Draw(shader, () =>
        {
            callback();
            glDrawArrays(GL_TRIANGLES, 0, mesh.vertexCount);
        });
    }
}