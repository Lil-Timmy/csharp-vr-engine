using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct ivec4
{
    public static readonly ivec4 ZERO  = new ivec4( 0,  0,  0,  0);
    public static readonly ivec4 ONE   = new ivec4( 1,  1,  1,  1);
    
    public static readonly ivec4 RIGHT = new ivec4( 1,  0,  0,  0);
    public static readonly ivec4 LEFT  = new ivec4(-1,  0,  0,  0);
    public static readonly ivec4 UP    = new ivec4( 0,  1,  0,  0);
    public static readonly ivec4 DOWN  = new ivec4( 0, -1,  0,  0);
    public static readonly ivec4 FOR   = new ivec4( 0,  0,  1,  0);
    public static readonly ivec4 BACK  = new ivec4( 0,  0, -1,  0);
    public static readonly ivec4 IN    = new ivec4( 0,  0,  0,  1);
    public static readonly ivec4 OUT   = new ivec4( 0,  0,  0, -1);
    
    
    public int x;
    public int y;
    public int z;
    public int w;

    public readonly ivec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(x, y); }
    public readonly ivec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(y, x); }
    public readonly ivec2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(x, z); }
    public readonly ivec2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(z, x); }
    public readonly ivec2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(y, z); }
    public readonly ivec2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(z, y); }
    public readonly ivec2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(x, w); }
    public readonly ivec2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(w, x); }
    public readonly ivec2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(y, w); }
    public readonly ivec2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(w, y); }
    public readonly ivec2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(z, w); }
    public readonly ivec2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(w, z); }

    public readonly ivec3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, y, z); }
    public readonly ivec3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, z, y); }
    public readonly ivec3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, x, z); }
    public readonly ivec3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, z, x); }
    public readonly ivec3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, x, y); }
    public readonly ivec3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, y, x); }
    public readonly ivec3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, y, w); }
    public readonly ivec3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, w, y); }
    public readonly ivec3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, x, w); }
    public readonly ivec3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, w, x); }
    public readonly ivec3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(w, x, y); }
    public readonly ivec3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(w, y, x); }
    public readonly ivec3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, z, w); }
    public readonly ivec3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(x, w, z); }
    public readonly ivec3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, x, w); }
    public readonly ivec3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, w, x); }
    public readonly ivec3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(w, x, z); }
    public readonly ivec3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(w, z, x); }
    public readonly ivec3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, z, w); }
    public readonly ivec3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(y, w, z); }
    public readonly ivec3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, y, w); }
    public readonly ivec3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(z, w, y); }
    public readonly ivec3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(w, y, z); }
    public readonly ivec3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec3(w, z, y); }

    public readonly ivec4 xyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(x, y, z, w); }
    public readonly ivec4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(x, y, w, z); }
    public readonly ivec4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(x, z, y, w); }
    public readonly ivec4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(x, z, w, y); }
    public readonly ivec4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(x, w, y, z); }
    public readonly ivec4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(x, w, z, y); }
    public readonly ivec4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(y, x, z, w); }
    public readonly ivec4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(y, x, w, z); }
    public readonly ivec4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(y, z, x, w); }
    public readonly ivec4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(y, z, w, x); }
    public readonly ivec4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(y, w, x, z); }
    public readonly ivec4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(y, w, z, x); }
    public readonly ivec4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(z, x, y, w); }
    public readonly ivec4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(z, x, w, y); }
    public readonly ivec4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(z, y, x, w); }
    public readonly ivec4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(z, y, w, x); }
    public readonly ivec4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(z, w, x, y); }
    public readonly ivec4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(z, w, y, x); }
    public readonly ivec4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(w, x, y, z); }
    public readonly ivec4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(w, x, z, y); }
    public readonly ivec4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(w, y, x, z); }
    public readonly ivec4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(w, y, z, x); }
    public readonly ivec4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(w, z, x, y); }
    public readonly ivec4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec4(w, z, y, x); }



    #region CONSTRUCTOR
    public ivec4(int _x, int _y, int _z, int _w)
    {
        (x, y, z, w) = (_x, _y, _z, _w);
    }
    public ivec4(ivec2 _xy, int _z, int _w)
    {
        (x, y, z, w) = (_xy.x, _xy.y, _z, _w);
    }
    public ivec4(int _x, ivec2 _xy, int _w)
    {
        (x, y, z, w) = (_x, _xy.x, _xy.y, _w);
    }
    public ivec4(int _x, int _y, ivec2 _zw)
    {
        (x, y, z, w) = (_x, _y, _zw.x, _zw.y);
    }
    public ivec4(ivec2 _xy, ivec2 _zw)
    {
        (x, y, z, w) = (_xy.x, _xy.y, _zw.x, _zw.y);
    }
    public ivec4(ivec3 _xyz, int _w)
    {
        (x, y, z, w) = (_xyz.x, _xyz.y, _xyz.z, _w);
    }
    public ivec4(int _x, ivec3 _yzw)
    {
        (x, y, z, w) = (_x, _yzw.x, _yzw.y, _yzw.z);
    }
    public ivec4(int _xyzw)
    {
        (x, y, z, w) = (_xyzw, _xyzw, _xyzw, _xyzw);
    }
    #endregion
    


    #region ADD
    public static ivec4 operator +(ivec4 _leftVec, ivec4 _rightVec)
    {
        return new ivec4(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y,
            _leftVec.z + _rightVec.z,
            _leftVec.w + _rightVec.w
        );
    }
    public static ivec4 operator +(ivec4 _leftVec, int _rightScalar)
    {
        return new ivec4(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar,
            _leftVec.z + _rightScalar,
            _leftVec.w + _rightScalar
        );
    }
    public static ivec4 operator +(int _leftScalar, ivec4 _rightVec)
    {
        return new ivec4(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y,
            _leftScalar + _rightVec.z,
            _leftScalar + _rightVec.w
        );
    }
    #endregion
    
    #region SUBTRACT
    public static ivec4 operator -(ivec4 _leftVec, ivec4 _rightVec)
    {
        return new ivec4(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y,
            _leftVec.z - _rightVec.z,
            _leftVec.w - _rightVec.w
        );
    }
    public static ivec4 operator -(ivec4 _leftVec, int _rightScalar)
    {
        return new ivec4(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar,
            _leftVec.z - _rightScalar,
            _leftVec.w - _rightScalar
        );
    }
    public static ivec4 operator -(int _leftScalar, ivec4 _rightVec)
    {
        return new ivec4(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y,
            _leftScalar - _rightVec.z,
            _leftScalar - _rightVec.w
        );
    }
    #endregion

    #region MULTIPLY
    public static ivec4 operator *(ivec4 _leftVec, ivec4 _rightVec)
    {
        return new ivec4(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y,
            _leftVec.z * _rightVec.z,
            _leftVec.w * _rightVec.w
        );
    }
    public static ivec4 operator *(ivec4 _leftVec, int _rightScalar)
    {
        return new ivec4(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar,
            _leftVec.z * _rightScalar,
            _leftVec.w * _rightScalar
        );
    }
    public static ivec4 operator *(int _leftScalar, ivec4 _rightVec)
    {
        return new ivec4(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y,
            _leftScalar * _rightVec.z,
            _leftScalar * _rightVec.w
        );
    }
    #endregion

    #region DIVIDE
    public static ivec4 operator /(ivec4 _leftVec, ivec4 _rightVec)
    {
        return new ivec4(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y,
            _leftVec.z / _rightVec.z,
            _leftVec.w / _rightVec.w
        );
    }
    public static ivec4 operator /(ivec4 _leftVec, int _rightScalar)
    {
        return new ivec4(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar,
            _leftVec.z / _rightScalar,
            _leftVec.w / _rightScalar
        );
    }
    public static ivec4 operator /(int _leftScalar, ivec4 _rightVec)
    {
        return new ivec4(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y,
            _leftScalar / _rightVec.z,
            _leftScalar / _rightVec.w
        );
    }
    #endregion

    #region NEGATE
    public static ivec4 operator -(ivec4 _vec)
    {
        return new ivec4(
            -_vec.x,
            -_vec.y,
            -_vec.z,
            -_vec.w
        );
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y, z, w);
    #endregion



    #region EQUAL
    public readonly          bool Equals(ivec4  _vec) => x == _vec.x && y == _vec.y && z == _vec.z && w == _vec.w;
    public readonly override bool Equals(object _obj) => (_obj is ivec4 _vec) && Equals(_vec     );
    
    public static bool operator ==(ivec4 _leftVec, ivec4 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(ivec4 _leftVec, ivec4 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector4     (ivec4                        _vec) => new System.Numerics.Vector4     (     _vec.x,      _vec.y,      _vec.z,      _vec.w);
    public static implicit operator ivec4                       (System.Numerics.Vector4      _vec) => new ivec4                       ((int)_vec.X, (int)_vec.Y, (int)_vec.Z, (int)_vec.W);
    
    public static implicit operator ivec4                       (vec4                         _vec) => new ivec4                       ((int)_vec.x, (int)_vec.y, (int)_vec.z, (int)_vec.w);
    #endregion
    
    
    
    #region OUTPUT
    public override readonly string ToString() => $"({x}, {y}, {z}, {w})";
    #endregion
    
    
    private const MethodImplOptions INL = MethodImplOptions.AggressiveInlining;
}