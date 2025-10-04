using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct vec2
{
    public static readonly vec2 ZERO  = new vec2( 0,  0);
    public static readonly vec2 ONE   = new vec2( 1,  1);
    
    public static readonly vec2 RIGHT = new vec2( 1,  0);
    public static readonly vec2 LEFT  = new vec2(-1,  0);
    public static readonly vec2 UP    = new vec2( 0,  1);
    public static readonly vec2 DOWN  = new vec2( 0, -1);
    
    
    public float x;
    public float y;

    public readonly vec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(x, y); }
    public readonly vec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new vec2(y, x); }



    #region CONSTRUCTOR
    public vec2(float _x, float _y)
    {
        (x, y) = (_x, _y);
    }
    public vec2(float _xy)
    {
        (x, y) = (_xy, _xy);
    }
    #endregion
    


    #region ADD
    public static vec2 operator +(vec2 _leftVec, vec2 _rightVec)
    {
        return new vec2(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y
        );
    }
    public static vec2 operator +(vec2 _leftVec, float _rightScalar)
    {
        return new vec2(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar
        );
    }
    public static vec2 operator +(float _leftScalar, vec2 _rightVec)
    {
        return new vec2(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y
        );
    }
    #endregion
    
    #region SUBTRACT
    public static vec2 operator -(vec2 _leftVec, vec2 _rightVec)
    {
        return new vec2(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y
        );
    }
    public static vec2 operator -(vec2 _leftVec, float _rightScalar)
    {
        return new vec2(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar
        );
    }
    public static vec2 operator -(float _leftScalar, vec2 _rightVec)
    {
        return new vec2(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y
        );
    }
    #endregion

    #region MULTIPLY
    public static vec2 operator *(vec2 _leftVec, vec2 _rightVec)
    {
        return new vec2(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y
        );
    }
    public static vec2 operator *(vec2 _leftVec, float _rightScalar)
    {
        return new vec2(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar
        );
    }
    public static vec2 operator *(float _leftScalar, vec2 _rightVec)
    {
        return new vec2(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y
        );
    }
    #endregion

    #region DIVIDE
    public static vec2 operator /(vec2 _leftVec, vec2 _rightVec)
    {
        return new vec2(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y
        );
    }
    public static vec2 operator /(vec2 _leftVec, float _rightScalar)
    {
        return new vec2(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar
        );
    }
    public static vec2 operator /(float _leftScalar, vec2 _rightVec)
    {
        return new vec2(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y
        );
    }
    #endregion

    #region NEGATE
    public static vec2 operator -(vec2 _vec)
    {
        return new vec2(
            -_vec.x,
            -_vec.y
        );
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y);
    #endregion



    #region EQUAL
    public readonly          bool Equals(vec2  _vec) => x == _vec.x && y == _vec.y;
    public readonly override bool Equals(object _obj) => (_obj is vec2 _vec) && Equals(_vec     );
    
    public static bool operator ==(vec2 _leftVec, vec2 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(vec2 _leftVec, vec2 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector2       (vec2                           _vec) => new System.Numerics.Vector2       (_vec.x, _vec.y);
    public static implicit operator vec2                          (System.Numerics.Vector2        _vec) => new vec2                          (_vec.X, _vec.Y);
    
    public static implicit operator vec2                          (ivec2                          _vec) => new vec2                          (_vec.x, _vec.y);
    #endregion
    
    
    
    #region OUTPUT
    public readonly override string ToString() => $"({x:F2}, {y:F2})";
    #endregion
}