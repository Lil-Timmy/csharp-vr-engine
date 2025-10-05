using System;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct axisAngle
{
    public vec3  axis;
    public float angle;
    
    
    
    #region CONSTRUCTOR
    public axisAngle(vec3 _axis, float _angle)
    {
        axis  = _axis;
        angle = _angle;
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(axis.x, axis.y, axis.z, angle);
    #endregion



    #region EQUAL
    public readonly          bool Equals(axisAngle  _axisAngle) => axis == _axisAngle.axis && angle == _axisAngle.angle;
    public readonly override bool Equals(object _obj) => (_obj is axisAngle _axisAngle) && Equals(_axisAngle     );
    
    public static bool operator ==(axisAngle _leftAxisAngle, axisAngle _rightAxisAngle) =>  _leftAxisAngle.Equals(_rightAxisAngle);
    public static bool operator !=(axisAngle _leftAxisAngle, axisAngle _rightAxisAngle) => !_leftAxisAngle.Equals(_rightAxisAngle);
    #endregion



    #region CONVERSION
    public static explicit operator axisAngle(quat _quat)
    {
        float _angle = 2f * Maths.Acos(_quat.w);
        float _halfAngle = Maths.Sin(_angle * 0.5f);
        
        return new axisAngle(_halfAngle < 0.001f ? vec3.UP : new vec3(_quat.x, _quat.y, _quat.z) / Maths.Sin(_halfAngle * 0.5f), _angle);
    }
    #endregion
    
    
    
    #region OUTPUT
    public override readonly string ToString() => $"{axis} [{angle:F2}]";
    #endregion
}