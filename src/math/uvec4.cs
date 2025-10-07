using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct uvec4
{
    public static readonly uvec4 ZERO  = new uvec4( 0,  0,  0,  0);
    public static readonly uvec4 ONE   = new uvec4( 1,  1,  1,  1);
    
    public static readonly uvec4 RIGHT = new uvec4( 1,  0,  0,  0);
    public static readonly uvec4 UP    = new uvec4( 0,  1,  0,  0);
    public static readonly uvec4 FOR   = new uvec4( 0,  0,  1,  0);
    public static readonly uvec4 IN    = new uvec4( 0,  0,  0,  1);
    
    
    public uint x;
    public uint y;
    public uint z;
    public uint w;

    public readonly uvec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(x, y); }
    public readonly uvec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(y, x); }
    public readonly uvec2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(x, z); }
    public readonly uvec2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(z, x); }
    public readonly uvec2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(y, z); }
    public readonly uvec2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(z, y); }
    public readonly uvec2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(x, w); }
    public readonly uvec2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(w, x); }
    public readonly uvec2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(y, w); }
    public readonly uvec2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(w, y); }
    public readonly uvec2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(z, w); }
    public readonly uvec2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(w, z); }

    public readonly uvec3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, y, z); }
    public readonly uvec3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, z, y); }
    public readonly uvec3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, x, z); }
    public readonly uvec3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, z, x); }
    public readonly uvec3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, x, y); }
    public readonly uvec3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, y, x); }
    public readonly uvec3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, y, w); }
    public readonly uvec3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, w, y); }
    public readonly uvec3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, x, w); }
    public readonly uvec3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, w, x); }
    public readonly uvec3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(w, x, y); }
    public readonly uvec3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(w, y, x); }
    public readonly uvec3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, z, w); }
    public readonly uvec3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(x, w, z); }
    public readonly uvec3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, x, w); }
    public readonly uvec3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, w, x); }
    public readonly uvec3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(w, x, z); }
    public readonly uvec3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(w, z, x); }
    public readonly uvec3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, z, w); }
    public readonly uvec3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(y, w, z); }
    public readonly uvec3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, y, w); }
    public readonly uvec3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(z, w, y); }
    public readonly uvec3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(w, y, z); }
    public readonly uvec3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec3(w, z, y); }

    public readonly uvec4 xyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, y, z, w); }
    public readonly uvec4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, y, w, z); }
    public readonly uvec4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, z, y, w); }
    public readonly uvec4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, z, w, y); }
    public readonly uvec4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, w, y, z); }
    public readonly uvec4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, w, z, y); }
    public readonly uvec4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(y, x, z, w); }
    public readonly uvec4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(y, x, w, z); }
    public readonly uvec4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(y, z, x, w); }
    public readonly uvec4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(y, z, w, x); }
    public readonly uvec4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(y, w, x, z); }
    public readonly uvec4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(y, w, z, x); }
    public readonly uvec4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(z, x, y, w); }
    public readonly uvec4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(z, x, w, y); }
    public readonly uvec4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(z, y, x, w); }
    public readonly uvec4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(z, y, w, x); }
    public readonly uvec4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(z, w, x, y); }
    public readonly uvec4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(z, w, y, x); }
    public readonly uvec4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(w, x, y, z); }
    public readonly uvec4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(w, x, z, y); }
    public readonly uvec4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(w, y, x, z); }
    public readonly uvec4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(w, y, z, x); }
    public readonly uvec4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(w, z, x, y); }
    public readonly uvec4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(w, z, y, x); }
    
    public readonly uvec4 _yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(0, y, z, w); }
    public readonly uvec4 x_zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, 0, z, w); }
    public readonly uvec4 xy_w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, y, 0, w); }
    public readonly uvec4 xyz_ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, y, z, 0); }
    
    public readonly uvec4 x___ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(x, 0, 0, 0); }
    public readonly uvec4 _y__ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(0, y, 0, 0); }
    public readonly uvec4 __z_ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(0, 0, z, 0); }
    public readonly uvec4 ___w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec4(0, 0, 0, w); }



    #region CONSTRUCTOR
    public uvec4(uint _x, uint _y, uint _z, uint _w)
    {
        (x, y, z, w) = (_x, _y, _z, _w);
    }
    public uvec4(uvec2 _xy, uint _z, uint _w)
    {
        (x, y, z, w) = (_xy.x, _xy.y, _z, _w);
    }
    public uvec4(uint _x, uvec2 _xy, uint _w)
    {
        (x, y, z, w) = (_x, _xy.x, _xy.y, _w);
    }
    public uvec4(uint _x, uint _y, uvec2 _zw)
    {
        (x, y, z, w) = (_x, _y, _zw.x, _zw.y);
    }
    public uvec4(uvec2 _xy, uvec2 _zw)
    {
        (x, y, z, w) = (_xy.x, _xy.y, _zw.x, _zw.y);
    }
    public uvec4(uvec3 _xyz, uint _w)
    {
        (x, y, z, w) = (_xyz.x, _xyz.y, _xyz.z, _w);
    }
    public uvec4(uint _x, uvec3 _yzw)
    {
        (x, y, z, w) = (_x, _yzw.x, _yzw.y, _yzw.z);
    }
    public uvec4(uint _xyzw)
    {
        (x, y, z, w) = (_xyzw, _xyzw, _xyzw, _xyzw);
    }
    #endregion
    


    #region ADD
    public static uvec4 operator +(uvec4 _leftVec, uvec4 _rightVec)
    {
        return new uvec4(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y,
            _leftVec.z + _rightVec.z,
            _leftVec.w + _rightVec.w
        );
    }
    public static uvec4 operator +(uvec4 _leftVec, uint _rightScalar)
    {
        return new uvec4(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar,
            _leftVec.z + _rightScalar,
            _leftVec.w + _rightScalar
        );
    }
    public static uvec4 operator +(uint _leftScalar, uvec4 _rightVec)
    {
        return new uvec4(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y,
            _leftScalar + _rightVec.z,
            _leftScalar + _rightVec.w
        );
    }
    #endregion
    
    #region SUBTRACT
    public static uvec4 operator -(uvec4 _leftVec, uvec4 _rightVec)
    {
        return new uvec4(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y,
            _leftVec.z - _rightVec.z,
            _leftVec.w - _rightVec.w
        );
    }
    public static uvec4 operator -(uvec4 _leftVec, uint _rightScalar)
    {
        return new uvec4(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar,
            _leftVec.z - _rightScalar,
            _leftVec.w - _rightScalar
        );
    }
    public static uvec4 operator -(uint _leftScalar, uvec4 _rightVec)
    {
        return new uvec4(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y,
            _leftScalar - _rightVec.z,
            _leftScalar - _rightVec.w
        );
    }
    #endregion

    #region MULTIPLY
    public static uvec4 operator *(uvec4 _leftVec, uvec4 _rightVec)
    {
        return new uvec4(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y,
            _leftVec.z * _rightVec.z,
            _leftVec.w * _rightVec.w
        );
    }
    public static uvec4 operator *(uvec4 _leftVec, uint _rightScalar)
    {
        return new uvec4(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar,
            _leftVec.z * _rightScalar,
            _leftVec.w * _rightScalar
        );
    }
    public static uvec4 operator *(uint _leftScalar, uvec4 _rightVec)
    {
        return new uvec4(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y,
            _leftScalar * _rightVec.z,
            _leftScalar * _rightVec.w
        );
    }
    #endregion

    #region DIVIDE
    public static uvec4 operator /(uvec4 _leftVec, uvec4 _rightVec)
    {
        return new uvec4(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y,
            _leftVec.z / _rightVec.z,
            _leftVec.w / _rightVec.w
        );
    }
    public static uvec4 operator /(uvec4 _leftVec, uint _rightScalar)
    {
        return new uvec4(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar,
            _leftVec.z / _rightScalar,
            _leftVec.w / _rightScalar
        );
    }
    public static uvec4 operator /(uint _leftScalar, uvec4 _rightVec)
    {
        return new uvec4(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y,
            _leftScalar / _rightVec.z,
            _leftScalar / _rightVec.w
        );
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y, z, w);
    #endregion



    #region EQUAL
    public readonly          bool Equals(uvec4  _vec) => x == _vec.x && y == _vec.y && z == _vec.z && w == _vec.w;
    public readonly override bool Equals(object _obj) => (_obj is uvec4 _vec) && Equals(_vec     );
    
    public static bool operator ==(uvec4 _leftVec, uvec4 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(uvec4 _leftVec, uvec4 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector4     (uvec4                        _vec) => new System.Numerics.Vector4     (     _vec.x,      _vec.y,      _vec.z,      _vec.w);
    public static implicit operator uvec4                       (System.Numerics.Vector4      _vec) => new uvec4                       ((uint)_vec.X, (uint)_vec.Y, (uint)_vec.Z, (uint)_vec.W);
    
    public static implicit operator uvec4                       (vec4                         _vec) => new uvec4                       ((uint)_vec.x, (uint)_vec.y, (uint)_vec.z, (uint)_vec.w);
    #endregion
    
    
    
    #region OUTPUT
    public override readonly string ToString() => $"({x}, {y}, {z}, {w})";
    #endregion
}