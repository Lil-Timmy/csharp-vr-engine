


namespace Engine;


public readonly struct Vertex
{
    public readonly vec3 position;
    public readonly vec3 normal;
    public readonly vec2 uv;
    
    
    public Vertex(vec3 _position, vec3 _normal, vec2 _uv)
    {
        position = _position;
        normal   = _normal;
        uv       = _uv;
    }
}