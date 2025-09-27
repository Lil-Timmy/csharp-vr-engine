using System.IO;
using static Engine.GL;


namespace Engine;


public static class Testing
{
    private static Shader shader;
    private static VertexArray vao;
    private static Buffer<float> vbo;
    
    
    
    private static void OnBegin()
    {
        shader = new Shader(File.ReadAllText("src\\shaders\\Test.vert"), File.ReadAllText("src\\shaders\\Test.frag"));
        vao    = new VertexArray();
        vbo    = new Buffer<float>(Buffer.Target.VERTEXARRAY, Buffer.Usage.STATIC, [-1, -1,  1, 0, 0,    0, 1,  0, 1, 0,    1, -1,  0, 0, 1,]);
        
        vao.Attribute(vbo, "vPosition", 2, 5, 0, false);
        vao.Attribute(vbo, "vColor"   , 3, 5, 2, false);
    }
    
    
    private static void OnUpdate()
    {
        shader.Bind();
        vao   .Bind();
        
        shader.Uniform("uPosition", new vec2(Input.headsetPosition.x - Input.rightControllerPosition.x, Input.headsetPosition.y - Input.rightControllerPosition.y));
        
        glBindFramebuffer(GL_FRAMEBUFFER, 0);
        glViewport(0, 0, Window.size.x, Window.size.y);
        glDrawArrays(GL_TRIANGLES, 0, 3);
        
        glBindFramebuffer(GL_FRAMEBUFFER, OpenXR.framebuffer);
        glViewport(0, 0, (int)OpenXR.swapchain.width, (int)OpenXR.swapchain.height);
        
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 0);
        glDrawArrays(GL_TRIANGLES, 0, 3);
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, OpenXR.swapchain.activeSwapchainImage.handle, 0, 1);
        glDrawArrays(GL_TRIANGLES, 0, 3);
    }
}