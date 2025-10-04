using System.Text;


namespace Engine;


public unsafe class XRPath
{
    public readonly string pathName;
    public readonly ulong  path    ;



    public XRPath(XRInstance _xrInstance, string _pathName)
    {
        pathName = _pathName;

        path = StringToPath(_xrInstance, pathName);
    }


    public static string PathToString(XRInstance _xrInstance, ulong _path)
    {
        if (_path == 0)
        {
            return string.Empty;
        }

        byte[] _buffer         = new byte[256]       ;
        uint   _bufferCount    = 0                   ;

        fixed (byte* bufferPtr = _buffer)
        {
            TimmyXR.xrPathToString(_xrInstance.instance, _path, (uint)_buffer.Length, &_bufferCount, bufferPtr);
        }

        return Encoding.UTF8.GetString(_buffer, 0, (int)_bufferCount - 1);
    }

    public static ulong StringToPath(XRInstance _xrInstance, string _string)
    {
        byte[] _buffer = Encoding.UTF8.GetBytes(_string + '\0');
        
        ulong _path;

        fixed (byte* strPtr = _buffer)
        {
            TimmyXR.xrStringToPath(_xrInstance.instance, strPtr, &_path);
        }

        return _path;
    }
}