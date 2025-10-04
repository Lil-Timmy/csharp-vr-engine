using System.Collections.Generic;


namespace Engine;


public class Transform : Entity
{
    public Transform parent
    { 
        get
        {
            return parent_;
        }
        set
        {
            parent_?.children.Remove(this);
            parent_ = value ?? sceneTransform;
            parent_.children.Add(this);
        }
    }
    public readonly List<Transform> children = new List<Transform>();
    
    public vec3 position { get { return parent_ == null ? localPosition : parent.position + localPosition; } set { localPosition = value - parent.position; } }
    public quat rotation { get { return parent_ == null ? localRotation : parent.rotation * localRotation; } set { localRotation = value / parent.rotation; } }
    public vec3 scale    { get { return parent_ == null ? localScale    : parent.scale    * localScale   ; } set { localScale    = value / parent.scale   ; } }
    
    public vec3 localPosition;
    public quat localRotation;
    public vec3 localScale;
    
    public mat4 positionMatrix => mat4.Position(position);
    public mat4 rotationMatrix => mat4.Rotation(rotation);
    public mat4 scaleMatrix    => mat4.Scale   (scale   );
    
    private Transform parent_;
    
    private static readonly Transform sceneTransform = new Transform();
    
    
    public Transform(Transform _parent, vec3 _localPosition, quat _localRotation, vec3 _localScale)
    {
        parent   = _parent;
        
        localPosition = _localPosition;
        localRotation = _localRotation;
        localScale    = _localScale;
    }
    
    private Transform()
    {
        parent_ = null;
        
        localPosition = vec3.ZERO;
        localRotation = quat.IDENTITY;
        localScale    = vec3.ONE;
    }
}