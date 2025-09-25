using static Engine.GL;


namespace Engine;


public unsafe class TextureArray : Disposable
{
    public readonly uint    handle;

    public          ivec3   size { get; private set; }
    
    
    public TextureArray(uint _handle, ivec3 _size)
    {
        handle = _handle;
        size   = _size;
        
        Bind();
    }
    public TextureArray(ivec3 _size)
    {
        handle = glGenTexture();
        
        Set(_size);
        SetParameters();
    }
    protected override void OnDispose()
    {
        glDeleteTextures(handle);
    }
    ///<summary>Binds the texture to the active texture unit.</summary>///
    public void Bind()
    {
        glBindTexture(GL_TEXTURE_2D_ARRAY, handle);
    }
    
    public void Set(ivec3 _size)
    {
        size = _size;
        
        Bind();
        glTexImage3D<byte>(GL_TEXTURE_2D_ARRAY, 0, GL_RGBA8, size.x, size.y, size.z, 0, GL_RGBA, GL_UNSIGNED_BYTE, null);
    }
    
    public byte[] Read()
    {
        byte[] _pixels = new byte[size.x * size.y * size.z];
        
        Bind();
        glGetTexImage<byte>(GL_TEXTURE_2D_ARRAY, 0, GL_RGBA, GL_UNSIGNED_BYTE, ref _pixels);
        
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