using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct vec4
{
    public static readonly vec4 ZERO  = new vec4( 0,  0,  0,  0);
    public static readonly vec4 ONE   = new vec4( 1,  1,  1,  1);
    
    public static readonly vec4 RIGHT = new vec4( 1,  0,  0,  0);
    public static readonly vec4 LEFT  = new vec4(-1,  0,  0,  0);
    public static readonly vec4 UP    = new vec4( 0,  1,  0,  0);
    public static readonly vec4 DOWN  = new vec4( 0, -1,  0,  0);
    public static readonly vec4 FOR   = new vec4( 0,  0,  1,  0);
    public static readonly vec4 BACK  = new vec4( 0,  0, -1,  0);
    public static readonly vec4 IN    = new vec4( 0,  0,  0,  1);
    public static readonly vec4 OUT   = new vec4( 0,  0,  0, -1);
    
    
    public float x;
    public float y;
    public float z;
    public float w;

    public readonly vec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(x, y); }
    public readonly vec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(y, x); }
    public readonly vec2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(x, z); }
    public readonly vec2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(z, x); }
    public readonly vec2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(y, z); }
    public readonly vec2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(z, y); }
    public readonly vec2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(x, w); }
    public readonly vec2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(w, x); }
    public readonly vec2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(y, w); }
    public readonly vec2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(w, y); }
    public readonly vec2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(z, w); }
    public readonly vec2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(w, z); }

    public readonly vec3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, y, z); }
    public readonly vec3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, z, y); }
    public readonly vec3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, x, z); }
    public readonly vec3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, z, x); }
    public readonly vec3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, x, y); }
    public readonly vec3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, y, x); }
    public readonly vec3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, y, w); }
    public readonly vec3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, w, y); }
    public readonly vec3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, x, w); }
    public readonly vec3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, w, x); }
    public readonly vec3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(w, x, y); }
    public readonly vec3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(w, y, x); }
    public readonly vec3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, z, w); }
    public readonly vec3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(x, w, z); }
    public readonly vec3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, x, w); }
    public readonly vec3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, w, x); }
    public readonly vec3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(w, x, z); }
    public readonly vec3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(w, z, x); }
    public readonly vec3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, z, w); }
    public readonly vec3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(y, w, z); }
    public readonly vec3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, y, w); }
    public readonly vec3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(z, w, y); }
    public readonly vec3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(w, y, z); }
    public readonly vec3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec3(w, z, y); }

    public readonly vec4 xyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(x, y, z, w); }
    public readonly vec4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(x, y, w, z); }
    public readonly vec4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(x, z, y, w); }
    public readonly vec4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(x, z, w, y); }
    public readonly vec4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(x, w, y, z); }
    public readonly vec4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(x, w, z, y); }
    public readonly vec4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(y, x, z, w); }
    public readonly vec4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(y, x, w, z); }
    public readonly vec4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(y, z, x, w); }
    public readonly vec4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(y, z, w, x); }
    public readonly vec4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(y, w, x, z); }
    public readonly vec4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(y, w, z, x); }
    public readonly vec4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(z, x, y, w); }
    public readonly vec4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(z, x, w, y); }
    public readonly vec4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(z, y, x, w); }
    public readonly vec4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(z, y, w, x); }
    public readonly vec4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(z, w, x, y); }
    public readonly vec4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(z, w, y, x); }
    public readonly vec4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(w, x, y, z); }
    public readonly vec4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(w, x, z, y); }
    public readonly vec4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(w, y, x, z); }
    public readonly vec4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(w, y, z, x); }
    public readonly vec4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(w, z, x, y); }
    public readonly vec4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec4(w, z, y, x); }



    #region CONSTRUCTOR
    public vec4(float _x, float _y, float _z, float _w)
    {
        (x, y, z, w) = (_x, _y, _z, _w);
    }
    public vec4(vec2 _xy, float _z, float _w)
    {
        (x, y, z, w) = (_xy.x, _xy.y, _z, _w);
    }
    public vec4(float _x, vec2 _xy, float _w)
    {
        (x, y, z, w) = (_x, _xy.x, _xy.y, _w);
    }
    public vec4(float _x, float _y, vec2 _zw)
    {
        (x, y, z, w) = (_x, _y, _zw.x, _zw.y);
    }
    public vec4(vec2 _xy, vec2 _zw)
    {
        (x, y, z, w) = (_xy.x, _xy.y, _zw.x, _zw.y);
    }
    public vec4(vec3 _xyz, float _w)
    {
        (x, y, z, w) = (_xyz.x, _xyz.y, _xyz.z, _w);
    }
    public vec4(float _x, vec3 _yzw)
    {
        (x, y, z, w) = (_x, _yzw.x, _yzw.y, _yzw.z);
    }
    public vec4(float _xyzw)
    {
        (x, y, z, w) = (_xyzw, _xyzw, _xyzw, _xyzw);
    }
    #endregion
    


    #region ADD
    public static vec4 operator +(vec4 _leftVec, vec4 _rightVec)
    {
        return new vec4(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y,
            _leftVec.z + _rightVec.z,
            _leftVec.w + _rightVec.w
        );
    }
    public static vec4 operator +(vec4 _leftVec, float _rightScalar)
    {
        return new vec4(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar,
            _leftVec.z + _rightScalar,
            _leftVec.w + _rightScalar
        );
    }
    public static vec4 operator +(float _leftScalar, vec4 _rightVec)
    {
        return new vec4(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y,
            _leftScalar + _rightVec.z,
            _leftScalar + _rightVec.w
        );
    }
    #endregion
    
    #region SUBTRACT
    public static vec4 operator -(vec4 _leftVec, vec4 _rightVec)
    {
        return new vec4(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y,
            _leftVec.z - _rightVec.z,
            _leftVec.w - _rightVec.w
        );
    }
    public static vec4 operator -(vec4 _leftVec, float _rightScalar)
    {
        return new vec4(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar,
            _leftVec.z - _rightScalar,
            _leftVec.w - _rightScalar
        );
    }
    public static vec4 operator -(float _leftScalar, vec4 _rightVec)
    {
        return new vec4(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y,
            _leftScalar - _rightVec.z,
            _leftScalar - _rightVec.w
        );
    }
    #endregion

    #region MULTIPLY
    public static vec4 operator *(vec4 _leftVec, vec4 _rightVec)
    {
        return new vec4(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y,
            _leftVec.z * _rightVec.z,
            _leftVec.w * _rightVec.w
        );
    }
    public static vec4 operator *(vec4 _leftVec, float _rightScalar)
    {
        return new vec4(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar,
            _leftVec.z * _rightScalar,
            _leftVec.w * _rightScalar
        );
    }
    public static vec4 operator *(float _leftScalar, vec4 _rightVec)
    {
        return new vec4(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y,
            _leftScalar * _rightVec.z,
            _leftScalar * _rightVec.w
        );
    }
    #endregion

    #region DIVIDE
    public static vec4 operator /(vec4 _leftVec, vec4 _rightVec)
    {
        return new vec4(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y,
            _leftVec.z / _rightVec.z,
            _leftVec.w / _rightVec.w
        );
    }
    public static vec4 operator /(vec4 _leftVec, float _rightScalar)
    {
        return new vec4(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar,
            _leftVec.z / _rightScalar,
            _leftVec.w / _rightScalar
        );
    }
    public static vec4 operator /(float _leftScalar, vec4 _rightVec)
    {
        return new vec4(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y,
            _leftScalar / _rightVec.z,
            _leftScalar / _rightVec.w
        );
    }
    #endregion

    #region NEGATE
    public static vec4 operator -(vec4 _vec)
    {
        return new vec4(
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
    public readonly          bool Equals(vec4  _vec) => x == _vec.x && y == _vec.y && z == _vec.z && w == _vec.w;
    public readonly override bool Equals(object _obj) => (_obj is vec4 _vec) && Equals(_vec     );
    
    public static bool operator ==(vec4 _leftVec, vec4 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(vec4 _leftVec, vec4 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector4       (vec4                           _vec ) => new System.Numerics.Vector4       (_vec .x, _vec .y, _vec .z, _vec .w);
    public static implicit operator vec4                          (System.Numerics.Vector4        _vec ) => new vec4                          (_vec .X, _vec .Y, _vec .Z, _vec .W);
    
    public static implicit operator vec4                          (ivec4                          _vec ) => new vec4                          (_vec .x, _vec .y, _vec .z, _vec .w);
    
    public static implicit operator vec4                          (quat                           _quat) => new vec4                          (_quat.x, _quat.y, _quat.z, _quat.w);
    #endregion
    
    
    
    #region OUTPUT
    public override readonly string ToString() => $"({x:F2}, {y:F2}, {z:F2}, {w:F2})";
    #endregion
}