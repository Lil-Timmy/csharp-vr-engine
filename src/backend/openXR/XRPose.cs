


namespace Engine;


public readonly struct XRPose
{
    public readonly vec3 position;
    public readonly quat rotation;


    public XRPose(vec3 _position, quat _rotation)
    {
        position = _position;
        rotation = _rotation;
    }

    public XRPose(XrVector3f _position, XrQuaternionf _rotation)
    {
        position = new vec3(_position.x, _position.y, _position.z             );
        rotation = new quat(_rotation.x, _rotation.y, _rotation.z, _rotation.w);
    }

    public XRPose(XrPosef _pose)
    {
        position = new vec3(_pose.position   .x, _pose.position   .y, _pose.position   .z                     );
        rotation = new quat(_pose.orientation.x, _pose.orientation.y, _pose.orientation.z, _pose.orientation.w);
    }
}