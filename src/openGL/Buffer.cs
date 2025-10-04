using static Engine.GL;


namespace Engine;


public unsafe class Buffer<TYPE> : Disposable where TYPE : unmanaged
{
    ///<summary>The pointer location to the GPU-side buffer.</summary>///
    public readonly uint handle;
    
    ///<summary>The specified type of buffer that the buffer is used for.</summary>///
    public readonly Buffer.Target target;
    ///<summary>The frequency of reading/writing the buffer, used for optimizations.</summary>///
    public readonly Buffer.Usage  usage;
    
    ///<summary>Constructs an OpenGL buffer object for GPU-side storage.</summary>///
    public Buffer(Buffer.Target _target, Buffer.Usage _usage, TYPE[] _data)
    {
        handle = glGenBuffer();
        target = _target;
        usage  = _usage;
        
        Bind();
        Set(_data);
    }
    ///<summary>Constructs an OpenGL buffer object for GPU-side storage.</summary>///
    public Buffer(Buffer.Target _target, Buffer.Usage _usage, int _length)
    {
        handle = glGenBuffer();
        target = _target;
        usage  = _usage;
        
        Bind();
        Set(_length);
    }
    ///<summary>Disposes of the GPU-buffer.</summary>///
    protected override void OnDispose()
    {
        glDeleteBuffers(handle);
    }
    ///<summary>Binds the buffer as the currently active buffer.</summary>///
    public void Bind()
    {
        glBindBuffer((int)target, handle);
    }
    ///<summary>Binds the buffer as the currently active buffer.</summary>///
    public void Bind(uint _index)
    {
        glBindBufferBase((int)target, _index, handle);
    }
    
    ///<summary>Sets the data for this buffer.</summary>///
    public void Set(TYPE[] _data)
    {
        Bind();
        glBufferData<TYPE>((int)target, _data , (int)usage);
    }
    ///<summary>Sets an uninitialized buffer with a specified length.</summary>///
    public void Set(int _length)
    {
        Bind();
        glBufferData<TYPE>((int)target, _length, (int)usage);
    }
}

public static class Buffer
{
    ///<summary>The possible buffer "types."</summary>///
    public enum Target : int
    {
        VERTEXARRAY   = 0x8892,
        INDEXARRAY    = 0x8893,
        PIXELOUT      = 0x88EB,
        PIXELIN       = 0x88EC,
        UNIFORMBLOCK  = 0x8A11,
        TEXTURE       = 0x8C2A,
        COPYOUT       = 0x8F36,
        COPYIN        = 0x8F37,
        INDIRECT      = 0x8F3F,
        SHADERSTORAGE = 0x90D2,
    }
    ///<summary>The possible buffer read/write usage frequencies.</summary>///
    public enum Usage : int
    {
        STREAM        = 0x88E0,
        DYNAMIC       = 0x88E8,
        STATIC        = 0x88E4,
    }
}