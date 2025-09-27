using static Engine.GL;


namespace Engine;


public unsafe class VertexArray : Disposable
{
    public  readonly uint handle;


    public VertexArray()
    {
        handle = glGenVertexArray();
        
        Bind();
    }
    protected override void OnDispose()
    {
        glDeleteVertexArrays(handle);
    }
    public void Bind()
    {
        glBindVertexArray(handle);
    }
    
    public void Attribute<T>(Buffer<T> _buffer, string _name, int _elementSize, int _stride, uint _offset, bool _perInstance) where T : unmanaged
    {
        Bind();
        _buffer.Bind(GL_ARRAY_BUFFER);
        
        uint _location = (uint)glGetAttribLocation(handle, _name);
        glEnableVertexAttribArray(_location);
        glVertexAttribPointer    (_location, _elementSize, GL_FLOAT, false, sizeof(float) * _stride, sizeof(float) * _offset);
        glVertexAttribDivisor    (_location, _perInstance ? 1u : 0u);
    }
}