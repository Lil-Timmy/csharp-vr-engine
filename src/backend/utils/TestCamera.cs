using System.IO;


namespace Engine;


public static class TestCamera
{
    public static vec3 position = new vec3(0f, 1f, -3f);
    public static vec3 rotation = new vec3(0f,  0,  0f);
    
    
    private static ivec2 previousMousePosition;
    
    
    private const float SENSITIVITY = 0.005f;
    private const float SPEED       = 1.5f;
    
    
    private static void OnUpdate()
    {
        if (Input.mousePosition != previousMousePosition)
        {
            rotation.x += (Input.mousePosition.y - previousMousePosition.y) * SENSITIVITY;
            rotation.y -= (Input.mousePosition.x - previousMousePosition.x) * SENSITIVITY;
            
            rotation.x = Maths.Clamp(rotation.x, -Maths.pi / 2f, Maths.pi / 2f);
            
            previousMousePosition = Input.mousePosition;
        }
        
        
        vec3 _direction = vec3.ZERO;
        
        _direction.z -= Input.Held(Input.Key.W        ) ? 1f : 0f;
        _direction.z += Input.Held(Input.Key.S        ) ? 1f : 0f;
        
        _direction.x += Input.Held(Input.Key.D        ) ? 1f : 0f;
        _direction.x -= Input.Held(Input.Key.A        ) ? 1f : 0f;
        
        _direction.y += Input.Held(Input.Key.Space    ) ? 1f : 0f;
        _direction.y -= Input.Held(Input.Key.LeftShift) ? 1f : 0f;
        
        position += new quat(rotation) * _direction * SPEED * Time.delta;
    }
}