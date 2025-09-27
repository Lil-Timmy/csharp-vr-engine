using static Engine.GL;


namespace Engine;


public unsafe class Framebuffer : Disposable
{
    public readonly uint    handle;
    
    public readonly Texture texture;
    public          ivec2   size;
    
    
    public Framebuffer(Texture _texture)
    {
        handle = glGenFramebuffer();
        texture = _texture;
        Attach();
    }
    protected override void OnDispose()
    {
        glDeleteFramebuffers(handle);
    }
    public void Bind()
    {
        glBindFramebuffer(GL_FRAMEBUFFER, handle);
        glViewport(0, 0, size.x, size.y);
    }
    
    public void Set(ivec2 _size)
    {
        Bind();
        texture.Set(_size);
        Attach();
    }
    
    private void Attach()
    {
        Bind();
        glFramebufferTexture2D(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, GL_TEXTURE_2D, texture.handle, 0);
    }
}