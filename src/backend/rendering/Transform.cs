using System.Collections.Generic;


namespace Engine;


public class Transform
{
    public vec3 position { get { return parent.position + localPosition_; } set { localPosition_ = value - parent.position; } }
    public quat rotation { get { return parent.rotation * localRotation_; } set { localRotation_ = value / parent.rotation; } }
    public vec3 scale    { get { return parent.scale    * localScale_   ; } set { localScale_    = value / parent.scale   ; } }
    
    public vec3 localPosition { get { return localPosition_; } set { localPosition_ = value; } }
    public quat localRotation { get { return localRotation_; } set { localRotation_ = value; } }
    public vec3 localScale    { get { return localScale_   ; } set { localScale_    = value; } }
    
    private vec3 localPosition_;
    private quat localRotation_;
    private vec3 localScale_;
    
    public readonly Mesh mesh;
    
    private readonly Transform      parent;
    private readonly List<Transform> children;
    
    
    public Transform(Transform _parentTransform, Mesh _mesh, vec3 _position, quat _rotation, vec3 _scale)
    {
        parent   = _parentTransform;
        children = new List<Transform>();
        
        mesh     = _mesh;
        
        position = _position;
        rotation = _rotation;
        scale    = _scale;
    }
    public Transform(Mesh _mesh, vec3 _position, quat _rotation, vec3 _scale)
    {
        parent   = globalTransform;
        children = new List<Transform>();
        
        mesh = _mesh;
        
        position = _position;
        rotation = _rotation;
        scale    = _scale;
    }
    
    private Transform()
    {
        parent = null;
        children = new List<Transform>();
        
        position = vec3.ZERO;
        rotation = quat.IDENTITY;
        scale    = vec3.ONE;
    }
    
    
    
    private static readonly Transform globalTransform = new Transform();
    
    
    // private static void OnRender()
    // {
    //     RenderChildren(globalTransform);
    // }
    
    private static void RenderChildren(Transform _parent)
    {
        foreach(Transform _transform in _parent.children)
        {
            if (_transform.mesh != null)
            {
                Debug.Log("Render");
            }
            
            RenderChildren(_transform);
        }
    }
}