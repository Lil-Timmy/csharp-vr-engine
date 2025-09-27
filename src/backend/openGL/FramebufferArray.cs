using static Engine.GL;


namespace Engine;


public unsafe class FramebufferArray : Disposable
{
    public readonly uint         handle;
    
    public readonly TextureArray texture;
    public          ivec3        size => texture.size;
    
    
    public FramebufferArray(TextureArray _texture)
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
    
    private void Attach()
    {
        Bind();
        texture.Bind();
        glFramebufferTextureLayer(GL_FRAMEBUFFER, GL_COLOR_ATTACHMENT0, texture.handle, 0, 0);
    }
}