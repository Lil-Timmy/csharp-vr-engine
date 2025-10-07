using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct uvec3
{
    public static readonly uvec3 ZERO  = new uvec3( 0,  0,  0);
    public static readonly uvec3 ONE   = new uvec3( 1,  1,  1);
    
    public static readonly uvec3 RIGHT = new uvec3( 1,  0,  0);
    public static readonly uvec3 UP    = new uvec3( 0,  1,  0);
    public static readonly uvec3 FOR   = new uvec3( 0,  0,  1);
    
    
    public uint x;
    public uint y;
    public uint z;
    
    public readonly uvec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(x, y); }
    public readonly uvec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(y, x); }
    public readonly uvec2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(x, z); }
    public readonly uvec2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(z, x); }
    public readonly uvec2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(y, z); }
    public readonly uvec2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(z, y); }

    public readonly uvec3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, y, z); }
    public readonly uvec3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, z, y); }
    public readonly uvec3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, x, z); }
    public readonly uvec3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, z, x); }
    public readonly uvec3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, x, y); }
    public readonly uvec3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, y, x); }
    
    public readonly uvec3 _yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(0, y, z); }
    public readonly uvec3 x_z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, 0, z); }
    public readonly uvec3 xy_ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, y, 0); }
    
    public readonly uvec3 x__ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, 0, 0); }
    public readonly uvec3 _y_ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(0, y, 0); }
    public readonly uvec3 __z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(0, 0, z); }



    #region CONSTRUCTOR
    public uvec3(uint _x, uint _y, uint _z)
    {
        (x, y, z) = (_x, _y, _z);
    }
    public uvec3(uvec2 _xy, uint _z)
    {
        (x, y, z) = (_xy.x, _xy.y, _z);
    }
    public uvec3(uint _x, uvec2 _yz)
    {
        (x, y, z) = (_x, _yz.x, _yz.y);
    }
    public uvec3(uint _xyz)
    {
        (x, y, z) = (_xyz, _xyz, _xyz);
    }
    #endregion
    


    #region ADD
    public static uvec3 operator +(uvec3 _leftVec, uvec3 _rightVec)
    {
        return new uvec3(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y,
            _leftVec.z + _rightVec.z
        );
    }
    public static uvec3 operator +(uvec3 _leftVec, uint _rightScalar)
    {
        return new uvec3(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar,
            _leftVec.z + _rightScalar
        );
    }
    public static uvec3 operator +(uint _leftScalar, uvec3 _rightVec)
    {
        return new uvec3(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y,
            _leftScalar + _rightVec.z
        );
    }
    #endregion
    
    #region SUBTRACT
    public static uvec3 operator -(uvec3 _leftVec, uvec3 _rightVec)
    {
        return new uvec3(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y,
            _leftVec.z - _rightVec.z
        );
    }
    public static uvec3 operator -(uvec3 _leftVec, uint _rightScalar)
    {
        return new uvec3(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar,
            _leftVec.z - _rightScalar
        );
    }
    public static uvec3 operator -(uint _leftScalar, uvec3 _rightVec)
    {
        return new uvec3(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y,
            _leftScalar - _rightVec.z
        );
    }
    #endregion

    #region MULTIPLY
    public static uvec3 operator *(uvec3 _leftVec, uvec3 _rightVec)
    {
        return new uvec3(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y,
            _leftVec.z * _rightVec.z
        );
    }
    public static uvec3 operator *(uvec3 _leftVec, uint _rightScalar)
    {
        return new uvec3(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar,
            _leftVec.z * _rightScalar
        );
    }
    public static uvec3 operator *(uint _leftScalar, uvec3 _rightVec)
    {
        return new uvec3(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y,
            _leftScalar * _rightVec.z
        );
    }
    #endregion

    #region DIVIDE
    public static uvec3 operator /(uvec3 _leftVec, uvec3 _rightVec)
    {
        return new uvec3(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y,
            _leftVec.z / _rightVec.z
        );
    }
    public static uvec3 operator /(uvec3 _leftVec, uint _rightScalar)
    {
        return new uvec3(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar,
            _leftVec.z / _rightScalar
        );
    }
    public static uvec3 operator /(uint _leftScalar, uvec3 _rightVec)
    {
        return new uvec3(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y,
            _leftScalar / _rightVec.z
        );
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y, z);
    #endregion



    #region EQUAL
    public readonly          bool Equals(uvec3  _vec) => x == _vec.x && y == _vec.y && z == _vec.z;
    public readonly override bool Equals(object _obj) => (_obj is uvec3 _vec) && Equals(_vec     );
    
    public static bool operator ==(uvec3 _leftVec, uvec3 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(uvec3 _leftVec, uvec3 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector3     (uvec3                        _vec) => new System.Numerics.Vector3     (     _vec.x,      _vec.y,      _vec.z);
    public static implicit operator uvec3                       (System.Numerics.Vector3      _vec) => new uvec3                       ((uint)_vec.X, (uint)_vec.Y, (uint)_vec.Z);
    
    public static implicit operator uvec3                       (vec3                         _vec) => new uvec3                       ((uint)_vec.x, (uint)_vec.y, (uint)_vec.z);
    #endregion
    
    
    
    #region OUTPUT
    public override readonly string ToString() => $"({x}, {y}, {z})";
    #endregion
}