


namespace Engine;


public unsafe class XRSwapchainImage
{
    public readonly TextureArray     texture;
    public readonly FramebufferArray framebuffer;


    public XRSwapchainImage(TextureArray _texture)
    {
        texture = _texture;
        framebuffer = new FramebufferArray(_texture);
    }


    public void Begin()
    {
        framebuffer.Bind();
    }
}