


namespace Engine;


public struct XRVersion
{
    public readonly uint value => major << 22 | minor << 12 | patch;
    
    public readonly uint major;
    public readonly uint minor;
    public readonly uint patch;
    
    
    public XRVersion(uint _major, uint _minor, uint _patch)
    {
        (major, minor, patch) = (_major, _minor, _patch);
    }
}