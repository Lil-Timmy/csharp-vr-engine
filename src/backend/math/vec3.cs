using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct vec3
{
    public static readonly vec3 ZERO  = new vec3( 0,  0,  0);
    public static readonly vec3 ONE   = new vec3( 1,  1,  1);
    
    public static readonly vec3 RIGHT = new vec3( 1,  0,  0);
    public static readonly vec3 LEFT  = new vec3(-1,  0,  0);
    public static readonly vec3 UP    = new vec3( 0,  1,  0);
    public static readonly vec3 DOWN  = new vec3( 0, -1,  0);
    public static readonly vec3 FOR   = new vec3( 0,  0,  1);
    public static readonly vec3 BACK  = new vec3( 0,  0, -1);
    
    
    public float x;
    public float y;
    public float z;
    
    public readonly vec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(x, y); }
    public readonly vec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(y, x); }
    public readonly vec2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(x, z); }
    public readonly vec2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(z, x); }
    public readonly vec2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(y, z); }
    public readonly vec2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(z, y); }

    public readonly vec3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, y, z); }
    public readonly vec3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, z, y); }
    public readonly vec3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, x, z); }
    public readonly vec3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, z, x); }
    public readonly vec3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, x, y); }
    public readonly vec3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, y, x); }



    #region CONSTRUCTOR
    public vec3(float _x, float _y, float _z)
    {
        (x, y, z) = (_x, _y, _z);
    }
    public vec3(vec2 _xy, float _z)
    {
        (x, y, z) = (_xy.x, _xy.y, _z);
    }
    public vec3(float _x, vec2 _yz)
    {
        (x, y, z) = (_x, _yz.x, _yz.y);
    }
    public vec3(float _xyz)
    {
        (x, y, z) = (_xyz, _xyz, _xyz);
    }
    #endregion
    


    #region ADD
    public static vec3 operator +(vec3 _leftVec, vec3 _rightVec)
    {
        return new vec3(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y,
            _leftVec.z + _rightVec.z
        );
    }
    public static vec3 operator +(vec3 _leftVec, float _rightScalar)
    {
        return new vec3(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar,
            _leftVec.z + _rightScalar
        );
    }
    public static vec3 operator +(float _leftScalar, vec3 _rightVec)
    {
        return new vec3(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y,
            _leftScalar + _rightVec.z
        );
    }
    #endregion
    
    #region SUBTRACT
    public static vec3 operator -(vec3 _leftVec, vec3 _rightVec)
    {
        return new vec3(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y,
            _leftVec.z - _rightVec.z
        );
    }
    public static vec3 operator -(vec3 _leftVec, float _rightScalar)
    {
        return new vec3(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar,
            _leftVec.z - _rightScalar
        );
    }
    public static vec3 operator -(float _leftScalar, vec3 _rightVec)
    {
        return new vec3(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y,
            _leftScalar - _rightVec.z
        );
    }
    #endregion

    #region MULTIPLY
    public static vec3 operator *(vec3 _leftVec, vec3 _rightVec)
    {
        return new vec3(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y,
            _leftVec.z * _rightVec.z
        );
    }
    public static vec3 operator *(vec3 _leftVec, float _rightScalar)
    {
        return new vec3(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar,
            _leftVec.z * _rightScalar
        );
    }
    public static vec3 operator *(float _leftScalar, vec3 _rightVec)
    {
        return new vec3(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y,
            _leftScalar * _rightVec.z
        );
    }
    #endregion

    #region DIVIDE
    public static vec3 operator /(vec3 _leftVec, vec3 _rightVec)
    {
        return new vec3(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y,
            _leftVec.z / _rightVec.z
        );
    }
    public static vec3 operator /(vec3 _leftVec, float _rightScalar)
    {
        return new vec3(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar,
            _leftVec.z / _rightScalar
        );
    }
    public static vec3 operator /(float _leftScalar, vec3 _rightVec)
    {
        return new vec3(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y,
            _leftScalar / _rightVec.z
        );
    }
    #endregion

    #region NEGATE
    public static vec3 operator -(vec3 _vec)
    {
        return new vec3(
            -_vec.x,
            -_vec.y,
            -_vec.z
        );
    }
    #endregion
    
    #region MATH

    public static vec3 Normalize(vec3 _vec)
    {
        return 1f / Maths.Sqrt
        (
            _vec.x * _vec.x +
            _vec.y * _vec.y +
            _vec.z * _vec.z
        ) * _vec;
    }

    public static float Dot(vec3 _leftVec, vec3 _rightVec)
    {
        return _leftVec.x * _rightVec.x + _leftVec.y * _rightVec.y + _leftVec.z * _rightVec.z;
    }
    
    public static vec3 Cross(vec3 _leftVec, vec3 _rightVec)
    {
        return new vec3(
            _leftVec.y * _rightVec.z - _leftVec.z * _rightVec.y,
            _leftVec.z * _rightVec.x - _leftVec.x * _rightVec.z,
            _leftVec.x * _rightVec.y - _leftVec.y * _rightVec.x
        );
    }
    
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y, z);
    #endregion



    #region EQUAL
    public readonly          bool Equals(vec3  _vec) => x == _vec.x && y == _vec.y && z == _vec.z;
    public readonly override bool Equals(object _obj) => (_obj is vec3 _vec) && Equals(_vec     );
    
    public static bool operator ==(vec3 _leftVec, vec3 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(vec3 _leftVec, vec3 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector3       (vec3                    _vec ) => new System.Numerics.Vector3       (_vec.x, _vec.y, _vec.z);
    public static implicit operator vec3                          (System.Numerics.Vector3 _vec ) => new vec3                          (_vec.X, _vec.Y, _vec.Z);
    
    public static implicit operator XrVector3f                    (vec3                    _vec ) => new XrVector3f       { x = _vec.x, y = _vec.y, z = _vec.z };
    public static implicit operator vec3                          (XrVector3f              _vec ) => new vec3             (     _vec.x,     _vec.y,     _vec.z );
    
    public static implicit operator vec3                          (ivec3                   _vec ) => new vec3                          (_vec.x, _vec.y, _vec.z);
    
    public static implicit operator vec3                          (quat                    _quat) => new vec3
    (
        MathF.Atan2(2.0f * (_quat.w * _quat.x + _quat.y * _quat.z), 1.0f - 2.0f * (_quat.x * _quat.x + _quat.y * _quat.y)), // Pitch - X
        MathF.Atan2(2.0f * (_quat.w * _quat.y - _quat.x * _quat.z), 1.0f - 2.0f * (_quat.y * _quat.y + _quat.z * _quat.z)), // Yaw   - Y
        MathF.Atan2(2.0f * (_quat.w * _quat.z + _quat.x * _quat.y), 1.0f - 2.0f * (_quat.z * _quat.z + _quat.y * _quat.y))  // Roll  - Z
    );
    #endregion
    
    
    
    #region OUTPUT
    public override readonly string ToString() => $"({Maths.Round(x * 100f) * 0.01f}, {Maths.Round(y * 100f) * 0.01f}, {Maths.Round(z * 100f) * 0.01f})";
    #endregion
}