


namespace Engine;


public struct pose
{
    public vec3 position;
    public quat rotation;
    
    
    public pose(vec3 _position, quat _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}