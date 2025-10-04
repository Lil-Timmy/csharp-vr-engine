using System;
using static Engine.GL;


namespace Engine;


public class Renderable : Transform
{
    public readonly Mesh          mesh;
    public readonly Shader        shader;
    public readonly VertexArray   vertexArray;
    public readonly Buffer<float> vertexBuffer;
    public readonly Action        callback;
    
    
    public Renderable(Transform _parent, vec3 _localPosition, quat _localRotation, vec3 _localScale, Mesh _mesh, Shader _shader, Action _callback) : base(_parent, _localPosition, _localRotation, _localScale)
    {
        mesh     = _mesh;
        shader   = _shader;
        callback = _callback;
        
        vertexArray  = new VertexArray();
        vertexBuffer = new Buffer<float>(Buffer.Target.VERTEXARRAY, Buffer.Usage.STATIC, mesh.vertices);
        
        shader.Attribute(vertexArray, vertexBuffer, "vPosition", 3, 8, 0, false);
        shader.Attribute(vertexArray, vertexBuffer, "vUV"      , 2, 8, 3, false);
        shader.Attribute(vertexArray, vertexBuffer, "vNormal"  , 3, 8, 5, false);
    }

    protected override void Render()
    {
        shader     .Bind();
        vertexArray.Bind();
        
        callback();
        
        shader.Uniform("uPositionMat", positionMatrix);
        shader.Uniform("uRotationMat", rotationMatrix);
        shader.Uniform("uScaleMat"   , scaleMatrix   );
        
        OpenXR.Draw(shader, () => { glDrawArrays(GL_TRIANGLES, 0, mesh.vertexCount); });
    }
}