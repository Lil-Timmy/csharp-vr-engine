using static Engine.GL;


namespace Engine;


public unsafe class Texture : Disposable
{
    public readonly uint    handle;

    public          ivec2   size { get; private set; }
    
    
    public Texture(uint _handle, ivec2 _size)
    {
        handle = _handle;
        size   = _size;
        
        Bind();
    }
    public Texture(ivec2 _size)
    {
        handle = glGenTexture();
        
        Set(_size);
        SetParameters();
    }
    public Texture(Image _image)
    {
        handle = glGenTexture();

        Set(_image);
        SetParameters();
    }
    protected override void OnDispose()
    {
        glDeleteTextures(handle);
    }
    ///<summary>Binds the texture to the active texture unit.</summary>///
    public void Bind()
    {
        glBindTexture(GL_TEXTURE_2D, handle);
    }
    
    public void Set(ivec2 _size)
    {
        size = _size;
        
        Bind();
        glTexImage2D<byte>(GL_TEXTURE_2D, 0, GL_RGBA, size.x, size.y, 0, GL_RGBA8, GL_UNSIGNED_BYTE, null);
    }
    public void Set(Image _image)
    {
        size = _image.size;
        
        Bind();
        glTexImage2D<byte>(GL_TEXTURE_2D, 0, GL_RGBA, size.x, size.y, 0, GL_RGBA8, GL_UNSIGNED_BYTE, _image.pixels);
    }
    
    public byte[] Read()
    {
        byte[] _pixels = new byte[size.x * size.y];
        
        Bind();
        glGetTexImage<byte>(GL_TEXTURE_2D, 0, GL_RGBA, GL_UNSIGNED_BYTE, ref _pixels);
        
        return _pixels;
    }
    
    private static void SetParameters()
    {
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR       );
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST      );
        
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S    , GL_CLAMP_TO_EDGE);
        glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T    , GL_CLAMP_TO_EDGE);
    }
}