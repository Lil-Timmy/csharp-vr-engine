using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct uvec2
{
    public static readonly uvec2 ZERO  = new uvec2( 0,  0);
    public static readonly uvec2 ONE   = new uvec2( 1,  1);
    
    public static readonly uvec2 RIGHT = new uvec2( 1,  0);
    public static readonly uvec2 UP    = new uvec2( 0,  1);
    
    
    public uint x;
    public uint y;

    public readonly uvec2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(x, y); }
    public readonly uvec2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(y, x); }
    
    public readonly uvec2 _y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(0, y); }
    public readonly uvec2 x_ { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => new uvec2(x, 0); }



    #region CONSTRUCTOR
    public uvec2(uint _x, uint _y)
    {
        (x, y) = (_x, _y);
    }
    public uvec2(uint _xy)
    {
        (x, y) = (_xy, _xy);
    }
    #endregion
    


    #region ADD
    public static uvec2 operator +(uvec2 _leftVec, uvec2 _rightVec)
    {
        return new uvec2(
            _leftVec.x + _rightVec.x,
            _leftVec.y + _rightVec.y
        );
    }
    public static uvec2 operator +(uvec2 _leftVec, uint _rightScalar)
    {
        return new uvec2(
            _leftVec.x + _rightScalar,
            _leftVec.y + _rightScalar
        );
    }
    public static uvec2 operator +(uint _leftScalar, uvec2 _rightVec)
    {
        return new uvec2(
            _leftScalar + _rightVec.x,
            _leftScalar + _rightVec.y
        );
    }
    #endregion
    
    #region SUBTRACT
    public static uvec2 operator -(uvec2 _leftVec, uvec2 _rightVec)
    {
        return new uvec2(
            _leftVec.x - _rightVec.x,
            _leftVec.y - _rightVec.y
        );
    }
    public static uvec2 operator -(uvec2 _leftVec, uint _rightScalar)
    {
        return new uvec2(
            _leftVec.x - _rightScalar,
            _leftVec.y - _rightScalar
        );
    }
    public static uvec2 operator -(uint _leftScalar, uvec2 _rightVec)
    {
        return new uvec2(
            _leftScalar - _rightVec.x,
            _leftScalar - _rightVec.y
        );
    }
    #endregion

    #region MULTIPLY
    public static uvec2 operator *(uvec2 _leftVec, uvec2 _rightVec)
    {
        return new uvec2(
            _leftVec.x * _rightVec.x,
            _leftVec.y * _rightVec.y
        );
    }
    public static uvec2 operator *(uvec2 _leftVec, uint _rightScalar)
    {
        return new uvec2(
            _leftVec.x * _rightScalar,
            _leftVec.y * _rightScalar
        );
    }
    public static uvec2 operator *(uint _leftScalar, uvec2 _rightVec)
    {
        return new uvec2(
            _leftScalar * _rightVec.x,
            _leftScalar * _rightVec.y
        );
    }
    #endregion

    #region DIVIDE
    public static uvec2 operator /(uvec2 _leftVec, uvec2 _rightVec)
    {
        return new uvec2(
            _leftVec.x / _rightVec.x,
            _leftVec.y / _rightVec.y
        );
    }
    public static uvec2 operator /(uvec2 _leftVec, uint _rightScalar)
    {
        return new uvec2(
            _leftVec.x / _rightScalar,
            _leftVec.y / _rightScalar
        );
    }
    public static uvec2 operator /(uint _leftScalar, uvec2 _rightVec)
    {
        return new uvec2(
            _leftScalar / _rightVec.x,
            _leftScalar / _rightVec.y
        );
    }
    #endregion



    #region HASH
    public readonly override int GetHashCode() => HashCode.Combine(x, y);
    #endregion



    #region EQUAL
    public readonly          bool Equals(uvec2  _vec) => x == _vec.x && y == _vec.y;
    public readonly override bool Equals(object _obj) => (_obj is uvec2 _vec) && Equals(_vec     );
    
    public static bool operator ==(uvec2 _leftVec, uvec2 _rightVec) =>  _leftVec.Equals(_rightVec);
    public static bool operator !=(uvec2 _leftVec, uvec2 _rightVec) => !_leftVec.Equals(_rightVec);
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Vector2     (uvec2                        _vec) => new System.Numerics.Vector2     (     _vec.x,      _vec.y);
    public static implicit operator uvec2                       (System.Numerics.Vector2      _vec) => new uvec2                       ((uint)_vec.X, (uint)_vec.Y);
    
    public static implicit operator uvec2                       (vec2                         _vec) => new uvec2                       ((uint)_vec.x, (uint)_vec.y);
    #endregion
    
    
    
    #region OUTPUT
    public readonly override string ToString() => $"({x}, {y})";
    #endregion
}