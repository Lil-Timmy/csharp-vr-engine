


namespace Engine;


public unsafe class XRInput
{
    public readonly string     name ;
    public readonly string     path ;
    public readonly XrActionType type ;
    public readonly int        index;


    public XRInput(string _name, XrActionType _type, string _path, int _index)
    {
        name  = _name ;
        type  = _type ;
        path  = _path ;
        index = _index;
    }
}