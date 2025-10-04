


namespace Engine;


public unsafe class XRProfile
{
    public readonly string     name  ;


    public readonly XRInput   rightPose  ;
    public readonly XRInput[] rightInputs;

    public readonly XRInput   leftPose   ;
    public readonly XRInput[] leftInputs ;
    

    public XRProfile(string _name, XRInput _rightPose, XRInput[] _rightInputs, XRInput _leftPose, XRInput[] _leftInputs)
    {
        name        = _name       ;

        rightPose   = _rightPose  ;
        rightInputs = _rightInputs;

        leftPose    = _leftPose   ;
        leftInputs  = _leftInputs ;
    }
}