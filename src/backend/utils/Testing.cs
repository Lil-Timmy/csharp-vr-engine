using System;
using System.IO;
using static Engine.GL;


namespace Engine;


public static class Testing
{
    private static Shader shader;
    private static VertexArray vao;
    private static Buffer<float> vbo;
    
    private static Mesh mesh;
    
    
    
    private static void OnBegin()
    {
        mesh = new Mesh("src/models/Test.obj");
        
        shader = new Shader(File.ReadAllText("src\\shaders\\Test.vert"), File.ReadAllText("src\\shaders\\Test.frag"));
        vao    = new VertexArray();
        vbo    = mesh.vertexBuffer;
        
        vao.Attribute(vbo, "vPosition", 3, 8, 0, false);
        vao.Attribute(vbo, "vUV"      , 2, 8, 3, false);
        vao.Attribute(vbo, "vNormal"  , 3, 8, 5, false);
    }
    
    
    private static bool _prevDown;
    private static void OnUpdate()
    {
        shader.Bind();
        vao   .Bind();
        
        Render(() =>
        {
            glDrawArrays(GL_TRIANGLES, 0, 60);
        });
        
        if (Input.rightControllerSecondary && !_prevDown)
        {
            OpenXR.Recenter();
        }
        if (Input.rightControllerSecondary != _prevDown)
        {
            _prevDown = Input.rightControllerSecondary;
        }
    }
    
    private static void Render(Action _callback)
    {
        XrView _viewA = OpenXR.views[0];
        XrView _viewB = OpenXR.views[1];
        
        XRPose _eyeA = new XRPose(_viewA.pose);
        XRPose _eyeB = new XRPose(_viewB.pose);
        
        mat4 _positionMat = mat4.Position(Input.rightControllerPosition);
        mat4 _rotationMat = mat4.Rotation(Input.rightControllerRotation);
        mat4 _scaleMat    = mat4.Scale(new vec3(Input.rightControllerTrigger * 0.1f + 0.1f));
        
        shader.Uniform("uPositionMat", _positionMat);
        shader.Uniform("uRotationMat", _rotationMat);
        shader.Uniform("uScaleMat"   , _scaleMat   );
        
        
        glBindFramebuffer(GL_FRAMEBUFFER, 0);
        glViewport(0, 0, Window.size.x, Window.size.y);
        // Draw:
        shader.Uniform("uScreenMat", mat4.Position(-_eyeA.position) * mat4.Rotation(quat.Inverse(_eyeA.rotation)) * mat4.ProjectionFromFov(_viewA.fov, 0.01f, 100f));
        _callback();
        
        
        glBindFramebuffer(GL_FRAMEBUFFER, OpenXR.framebuffer);
        glViewport(0, 0, (int)OpenXR.swapchain.width, (int)OpenXR.swapchain.height);
        
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 0);
        // Draw:
        _callback();
        
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 1);
        // Draw:
        shader.Uniform("uScreenMat", mat4.Position(-_eyeB.position) * mat4.Rotation(quat.Inverse(_eyeB.rotation)) * mat4.ProjectionFromFov(_viewB.fov, 0.01f, 100f));
        _callback();
    }
}