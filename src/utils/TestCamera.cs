using System.IO;


namespace Engine;


public static class TestCamera
{
    public static vec3 position = vec3.ZERO;
    public static quat rotation = quat.IDENTITY;
    
    
    private static ivec2 previousMousePosition;
    
    
    private const float SENSITIVITY = 0.005f;
    private const float SPEED       = 1.5f;
    
    
    private static void OnUpdate()
    {
        if (Input.mousePosition != previousMousePosition)
        {
            vec3 _rotation = new vec3
            (
                (Input.mousePosition.y - previousMousePosition.y) *  SENSITIVITY,
                (Input.mousePosition.x - previousMousePosition.x) * -SENSITIVITY,
                0f
            );
            
            rotation *= new quat(_rotation);
            previousMousePosition = Input.mousePosition;
        }
        
        
        vec3 _direction = vec3.ZERO;
        
        _direction.z -= Input.Held(Input.Key.W        ) ? 1f : 0f;
        _direction.z += Input.Held(Input.Key.S        ) ? 1f : 0f;
        
        _direction.x += Input.Held(Input.Key.D        ) ? 1f : 0f;
        _direction.x -= Input.Held(Input.Key.A        ) ? 1f : 0f;
        
        _direction.y += Input.Held(Input.Key.Space    ) ? 1f : 0f;
        _direction.y -= Input.Held(Input.Key.LeftShift) ? 1f : 0f;
        
        position += rotation * _direction * SPEED * Time.delta;
    }
}