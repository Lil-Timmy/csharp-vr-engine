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
    protected override void OnDispose()
    {
        glDeleteTextures(handle);
    }
    ///<summary>Binds the texture to the active texture unit.</summary>///
    public void Bind()
    {
        glBindTexture(GL_TEXTURE_2D_ARRAY, handle);
    }
}