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
        
        XRView _eyeA = OpenXR.views[0];
        XRView _eyeB = OpenXR.views[1];
        
        shader.Uniform("uPositionMat", positionMatrix);
        shader.Uniform("uRotationMat", rotationMatrix);
        shader.Uniform("uScaleMat"   , scaleMatrix   );
        
        
        // Headset.
        glViewport(0, 0, (int)OpenXR.swapchain.width, (int)OpenXR.swapchain.height);
        
        // Eye A.
        glBindFramebuffer(GL_FRAMEBUFFER, OpenXR.framebuffers[0]);
        shader.Uniform("uScreenMat", mat4.Position(-_eyeA.position) * mat4.Rotation(quat.Inverse(_eyeA.rotation)) * mat4.Projection(_eyeA, 0.01f, 100f));
        callback();
        glDrawArrays(GL_TRIANGLES, 0, mesh.vertexCount);
        
        // Eye B.
        glBindFramebuffer(GL_FRAMEBUFFER, OpenXR.framebuffers[1]);
        shader.Uniform("uScreenMat", mat4.Position(-_eyeB.position) * mat4.Rotation(quat.Inverse(_eyeB.rotation)) * mat4.Projection(_eyeB, 0.01f, 100f));
        callback();
        glDrawArrays(GL_TRIANGLES, 0, mesh.vertexCount);
        
        
        // Desktop.
        glViewport(0, 0, Window.size.x, Window.size.y);
        
        // Window.
        glBindFramebuffer(GL_FRAMEBUFFER, OpenXR.framebuffers[2]);
        shader.Uniform("uScreenMat", mat4.Position(-_eyeA.position) * mat4.Rotation(quat.Inverse(_eyeA.rotation)) * mat4.Projection(Maths.pi / 2f, 1.0f, 0.01f, 100f));
        callback();
        glDrawArrays(GL_TRIANGLES, 0, mesh.vertexCount);
    }
}