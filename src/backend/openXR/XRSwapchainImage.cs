


namespace Engine;


public unsafe class XRSwapchainImage
{
    public readonly uint handle;


    public XRSwapchainImage(uint _image)
    {
        handle = _image;
    }
}