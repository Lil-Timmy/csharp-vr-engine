using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct ivec2
{
    public static readonly ivec2 ZERO  = new ivec2( 0,  0);
    public static readonly ivec2 ONE   = new ivec2( 1,  1);
    
    public static readonly ivec2 RIGHT = new ivec2( 1,  0);
    public static readonly ivec2 LEFT  = new ivec2(-1,  0);
    public static readonly ivec2 UP    = new ivec2( 0,  1);
    public static readonly ivec2 DOWN  = new ivec2( 0, -1);
    
    
    public int x;
    public int y;

    public readonly ivec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(x, y); }
    public readonly ivec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new ivec2(y, x); }



    #region CONSTRUCTOR
    public ivec2(int _x, int _y)
    {
        (x, y) = (_x, _y);
    }
    public ivec2(int _xy)
    {
        (x, y) = (_xy, _xy);
    }
    #endregion
    


    #region ADD
    public static ivec2 operator +(ivec2 _leftVec, ivec2 _rightVec)
    {
        return new ivec2(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y
        );
    }
    public static ivec2 operator +(ivec2 _leftVec, int _rightScalar)
    {
        return new ivec2(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar
        );
    }
    public static ivec2 operator +(int _leftScalar, ivec2 _rightVec)
    {
        return new ivec2(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y
        );
    }
    #endregion
    
    #region SUBTRACT
    public static ivec2 operator -(ivec2 _leftVec, ivec2 _rightVec)
    {
        return new ivec2(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y
        );
    }
    public static ivec2 operator -(ivec2 _leftVec, int _rightScalar)
    {
        return new ivec2(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar
        );
    }
    public static ivec2 operator -(int _leftScalar, ivec2 _rightVec)
    {
        return new ivec2(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y
        );
    }
    #endregion

    #region MULTIPLY
    public static ivec2 operator *(ivec2 _leftVec, ivec2 _rightVec)
    {
        return new ivec2(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y
        );
    }
    public static ivec2 operator *(ivec2 _leftVec, int _rightScalar)
    {
        return new ivec2(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar
        );
    }
    public static ivec2 operator *(int _leftScalar, ivec2 _rightVec)
    {
        return new ivec2(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y
        );
    }
    #endregion

    #region DIVIDE
    public static ivec2 operator /(ivec2 _leftVec, ivec2 _rightVec)
    {
        return new ivec2(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y
        );
    }
    public static ivec2 operator /(ivec2 _leftVec, int _rightScalar)
    {
        return new ivec2(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar
        );
    }
    public static ivec2 operator /(int _leftScalar, ivec2 _rightVec)
    {
        return new ivec2(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y
        );
    }
    #endregion

    #region NEGATE
    public static ivec2 operator -(ivec2 _vec)
    {
        return new ivec2(
            -_vec.x,
            -_vec.y
        );
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y);
    #endregion



    #region EQUAL
    public readonly          bool Equals(ivec2  _vec) => x == _vec.x && y == _vec.y;
    public readonly override bool Equals(object _obj) => (_obj is ivec2 _vec) && Equals(_vec     );
    
    public static bool operator ==(ivec2 _leftVec, ivec2 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(ivec2 _leftVec, ivec2 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector2     (ivec2                        _vec) => new System.Numerics.Vector2     (     _vec.x,      _vec.y);
    public static implicit operator ivec2                       (System.Numerics.Vector2      _vec) => new ivec2                       ((int)_vec.X, (int)_vec.Y);
    
    public static implicit operator ivec2                       (vec2                         _vec) => new ivec2                       ((int)_vec.x, (int)_vec.y);
    #endregion
    
    
    
    #region OUTPUT
    public readonly override string ToString() => $"({x}, {y})";
    #endregion
}