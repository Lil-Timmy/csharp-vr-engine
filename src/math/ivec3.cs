using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct ivec3
{
    public static readonly ivec3 ZERO  = new ivec3( 0,  0,  0);
    public static readonly ivec3 ONE   = new ivec3( 1,  1,  1);
    
    public static readonly ivec3 RIGHT = new ivec3( 1,  0,  0);
    public static readonly ivec3 LEFT  = new ivec3(-1,  0,  0);
    public static readonly ivec3 UP    = new ivec3( 0,  1,  0);
    public static readonly ivec3 DOWN  = new ivec3( 0, -1,  0);
    public static readonly ivec3 FOR   = new ivec3( 0,  0,  1);
    public static readonly ivec3 BACK  = new ivec3( 0,  0, -1);
    
    
    public int x;
    public int y;
    public int z;
    
    public readonly ivec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(x, y); }
    public readonly ivec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(y, x); }
    public readonly ivec2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(x, z); }
    public readonly ivec2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(z, x); }
    public readonly ivec2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(y, z); }
    public readonly ivec2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(z, y); }

    public readonly ivec3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, y, z); }
    public readonly ivec3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, z, y); }
    public readonly ivec3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, x, z); }
    public readonly ivec3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, z, x); }
    public readonly ivec3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, x, y); }
    public readonly ivec3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, y, x); }
    
    public readonly ivec3 _yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(0, y, z); }
    public readonly ivec3 x_z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, 0, z); }
    public readonly ivec3 xy_ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, y, 0); }
    
    public readonly ivec3 x__ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, 0, 0); }
    public readonly ivec3 _y_ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(0, y, 0); }
    public readonly ivec3 __z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(0, 0, z); }



    #region CONSTRUCTOR
    public ivec3(int _x, int _y, int _z)
    {
        (x, y, z) = (_x, _y, _z);
    }
    public ivec3(ivec2 _xy, int _z)
    {
        (x, y, z) = (_xy.x, _xy.y, _z);
    }
    public ivec3(int _x, ivec2 _yz)
    {
        (x, y, z) = (_x, _yz.x, _yz.y);
    }
    public ivec3(int _xyz)
    {
        (x, y, z) = (_xyz, _xyz, _xyz);
    }
    #endregion
    


    #region ADD
    public static ivec3 operator +(ivec3 _leftVec, ivec3 _rightVec)
    {
        return new ivec3(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y,
            _leftVec.z + _rightVec.z
        );
    }
    public static ivec3 operator +(ivec3 _leftVec, int _rightScalar)
    {
        return new ivec3(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar,
            _leftVec.z + _rightScalar
        );
    }
    public static ivec3 operator +(int _leftScalar, ivec3 _rightVec)
    {
        return new ivec3(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y,
            _leftScalar + _rightVec.z
        );
    }
    #endregion
    
    #region SUBTRACT
    public static ivec3 operator -(ivec3 _leftVec, ivec3 _rightVec)
    {
        return new ivec3(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y,
            _leftVec.z - _rightVec.z
        );
    }
    public static ivec3 operator -(ivec3 _leftVec, int _rightScalar)
    {
        return new ivec3(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar,
            _leftVec.z - _rightScalar
        );
    }
    public static ivec3 operator -(int _leftScalar, ivec3 _rightVec)
    {
        return new ivec3(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y,
            _leftScalar - _rightVec.z
        );
    }
    #endregion

    #region MULTIPLY
    public static ivec3 operator *(ivec3 _leftVec, ivec3 _rightVec)
    {
        return new ivec3(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y,
            _leftVec.z * _rightVec.z
        );
    }
    public static ivec3 operator *(ivec3 _leftVec, int _rightScalar)
    {
        return new ivec3(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar,
            _leftVec.z * _rightScalar
        );
    }
    public static ivec3 operator *(int _leftScalar, ivec3 _rightVec)
    {
        return new ivec3(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y,
            _leftScalar * _rightVec.z
        );
    }
    #endregion

    #region DIVIDE
    public static ivec3 operator /(ivec3 _leftVec, ivec3 _rightVec)
    {
        return new ivec3(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y,
            _leftVec.z / _rightVec.z
        );
    }
    public static ivec3 operator /(ivec3 _leftVec, int _rightScalar)
    {
        return new ivec3(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar,
            _leftVec.z / _rightScalar
        );
    }
    public static ivec3 operator /(int _leftScalar, ivec3 _rightVec)
    {
        return new ivec3(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y,
            _leftScalar / _rightVec.z
        );
    }
    #endregion

    #region NEGATE
    public static ivec3 operator -(ivec3 _vec)
    {
        return new ivec3(
            -_vec.x,
            -_vec.y,
            -_vec.z
        );
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y, z);
    #endregion



    #region EQUAL
    public readonly          bool Equals(ivec3  _vec) => x == _vec.x && y == _vec.y && z == _vec.z;
    public readonly override bool Equals(object _obj) => (_obj is ivec3 _vec) && Equals(_vec     );
    
    public static bool operator ==(ivec3 _leftVec, ivec3 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(ivec3 _leftVec, ivec3 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector3     (ivec3                        _vec) => new System.Numerics.Vector3     (     _vec.x,      _vec.y,      _vec.z);
    public static implicit operator ivec3                       (System.Numerics.Vector3      _vec) => new ivec3                       ((int)_vec.X, (int)_vec.Y, (int)_vec.Z);
    
    public static implicit operator ivec3                       (vec3                         _vec) => new ivec3                       ((int)_vec.x, (int)_vec.y, (int)_vec.z);
    #endregion
    
    
    
    #region OUTPUT
    public override readonly string ToString() => $"({x}, {y}, {z})";
    #endregion
}