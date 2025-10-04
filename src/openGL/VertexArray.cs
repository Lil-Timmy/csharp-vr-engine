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
}