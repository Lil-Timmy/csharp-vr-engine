


namespace Engine;


public readonly struct XRView
{
    public readonly vec3 position;
    public readonly quat rotation;
    
    public readonly float angleLeft;
    public readonly float angleRight;
    public readonly float angleUp;
    public readonly float angleDown;
    

    public XRView(XrView _view)
    {
        angleLeft  = _view.fov.angleLeft;
        angleRight = _view.fov.angleRight;
    
        angleUp    = _view.fov.angleUp;
        angleDown  = _view.fov.angleDown;
        
        position   = _view.pose.position;
        rotation   = _view.pose.orientation;
    }
}