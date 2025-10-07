


namespace Engine;


public static class TestCamera
{
    public static vec3 position = vec3.ZERO;
    public static vec3 euler    = vec3.ZERO;
    
    public static quat rotation => (quat)euler;
    
    
    private static ivec2 previousMousePosition;
    
    
    private const float SENSITIVITY = 0.005f;
    private const float SPEED       = 1.5f;
    
    
    private static void OnUpdate()
    {
        if (Input.mousePosition != previousMousePosition)
        {
            if (Input.Held(Input.Key.ButtonMiddle))
            {
                euler.x += (Input.mousePosition.y - previousMousePosition.y) * SENSITIVITY;
                euler.y -= (Input.mousePosition.x - previousMousePosition.x) * SENSITIVITY;
            }
            
            previousMousePosition = Input.mousePosition;
        }
        
        
        vec3 _direction = vec3.ZERO;
        
        _direction.z -= Input.Held(Input.Key.W        ) ? 1f : 0f;
        _direction.z += Input.Held(Input.Key.S        ) ? 1f : 0f;
        
        _direction.x += Input.Held(Input.Key.D        ) ? 1f : 0f;
        _direction.x -= Input.Held(Input.Key.A        ) ? 1f : 0f;
        
        _direction.y += Input.Held(Input.Key.Space    ) ? 1f : 0f;
        _direction.y -= Input.Held(Input.Key.LeftShift) ? 1f : 0f;
        
        position += quat.Rotate(rotation, _direction * SPEED * Time.delta);
    }
}