using System;
using System.Runtime.InteropServices;


namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct quat
{
    public static readonly quat IDENTITY = new quat(0f, 0.0f, 0.0f, 1f);
    
    
    public float x;
    public float y;
    public float z;
    public float w;



    public quat(float _x, float _y, float _z, float _w)
    {
        (x, y, z, w) = (_x, _y, _z, _w);
    }



    #region ADD
    public static quat operator +(quat _leftQuat, quat _rightQuat)
    {
        return new quat(
            _leftQuat.x + _rightQuat.x,
            _leftQuat.y + _rightQuat.y,
            _leftQuat.z + _rightQuat.z,
            _leftQuat.w + _rightQuat.w
        );
    }
    #endregion
    
    #region SUBTRACT
    public static quat operator -(quat _leftQuat, quat _rightQuat)
    {
        return new quat(
            _leftQuat.x - _rightQuat.x,
            _leftQuat.y - _rightQuat.y,
            _leftQuat.z - _rightQuat.z,
            _leftQuat.w - _rightQuat.w
        );
    }
    #endregion

    #region MULTIPLY
    public static quat operator *(quat _leftQuat, quat _rightQuat)
    {
        float _xL = _leftQuat.x, _yL = _leftQuat.y, _zL = _leftQuat.z, _wL = _leftQuat.w;
        float _xR = _rightQuat.x, _yR = _rightQuat.y, _zR = _rightQuat.z, _wR = _rightQuat.w;

        return new quat(
            _wL * _xR + _xL * _wR + _yL * _zR - _zL * _yR,
            _wL * _yR - _xL * _zR + _yL * _wR + _zL * _xR,
            _wL * _zR + _xL * _yR - _yL * _xR + _zL * _wR,
            _wL * _wR - _xL * _xR - _yL * _yR - _zL * _zR
        );
    }
    
    public static quat operator *(quat _leftQuat, float _rightScalar)
    {
        return new quat(
            _leftQuat.x * _rightScalar,
            _leftQuat.y * _rightScalar,
            _leftQuat.z * _rightScalar,
            _leftQuat.w * _rightScalar
        );
    }
    public static quat operator *(float _leftScalar, quat _rightQuat)
    {
        return new quat(
            _leftScalar * _rightQuat.x,
            _leftScalar * _rightQuat.y,
            _leftScalar * _rightQuat.z,
            _leftScalar * _rightQuat.w
        );
    }

    public static vec3 operator *(quat _leftQuat, vec3 _rightVec)
    {
        float _xQ = _leftQuat.x, _yQ = _leftQuat.y, _zQ = _leftQuat.z, _wQ = _leftQuat.w;
        float _xV = _rightVec.x, _yV = _rightVec.y, _zV = _rightVec.z;

        float _vecCrossX = 2.0f * (_yQ * _zV - _zQ * _yV);
        float _vecCrossY = 2.0f * (_zQ * _xV - _xQ * _zV);
        float _vecCrossZ = 2.0f * (_xQ * _yV - _yQ * _xV);

        float _quatCrossX = _yQ * _vecCrossZ - _zQ * _vecCrossY;
        float _quatCrossY = _zQ * _vecCrossX - _xQ * _vecCrossZ;
        float _quatCrossZ = _xQ * _vecCrossY - _yQ * _vecCrossX;

        return new vec3(
            _xV + _wQ * _vecCrossX + _quatCrossX,
            _yV + _wQ * _vecCrossY + _quatCrossY,
            _zV + _wQ * _vecCrossZ + _quatCrossZ
        );
    }
    #endregion

    #region DIVIDE
    public static quat operator /(quat _leftQuat, quat _rightQuat)
    {
        float _xL = _leftQuat.x, _yL = _leftQuat.y, _zL = _leftQuat.z, _wL = _leftQuat.w;
        float _xR = _rightQuat.x, _yR = _rightQuat.y, _zR = _rightQuat.z, _wR = _rightQuat.w;

        float _inverseSqrLength = 1.0f / (_xR * _xR + _yR * _yR + _zR * _zR + _wR * _wR);

        float _xInv = -_xR * _inverseSqrLength;
        float _yInv = -_yR * _inverseSqrLength;
        float _zInv = -_zR * _inverseSqrLength;
        float _wInv =  _wR * _inverseSqrLength;

        return new quat(
            _wL * _xInv + _xL * _wInv + _yL * _zInv - _zL * _yInv,
            _wL * _yInv + _yL * _wInv + _zL * _xInv - _xL * _zInv,
            _wL * _zInv + _zL * _wInv + _xL * _yInv - _yL * _xInv,
            _wL * _wInv - _xL * _xInv - _yL * _yInv - _zL * _zInv
        );
    }
    #endregion
    
    #region NEGATE
    public static quat operator -(quat _quat)
    {
        return new quat(
            -_quat.x,
            -_quat.y,
            -_quat.z,
            -_quat.w
        );
    }
    #endregion



    #region HASH
    public override int GetHashCode() => HashCode.Combine(x, y, z, w);
    #endregion



    #region EQUAL
    public readonly          bool Equals(quat  _vec) => x == _vec.x && y == _vec.y && z == _vec.z && w == _vec.w;
    public readonly override bool Equals(object _obj) => (_obj is quat _vec) && Equals(_vec     );
    
    public static bool operator ==(quat _leftQuat, quat _rightQuat) =>  _leftQuat.Equals(_rightQuat);
    public static bool operator !=(quat _leftQuat, quat _rightQuat) => !_leftQuat.Equals(_rightQuat);
    #endregion



    #region MATH

    public static quat Conjugate(quat _quat)
    {
        return new quat(
            -_quat.x,
            -_quat.y,
            -_quat.z,
             _quat.w  
        );
    }

    public static float Length(quat _quat)
    {
        return Maths.Sqrt(
            _quat.x * _quat.x +
            _quat.y * _quat.y +
            _quat.z * _quat.z +
            _quat.w * _quat.w
        );
    }

    public static float SqrLength(quat _quat)
    {
        return
            _quat.x * _quat.x +
            _quat.y * _quat.y +
            _quat.z * _quat.z +
            _quat.w * _quat.w
        ;
    }

    public static quat Normalize(quat _quat)
    {
        float _length = Length(_quat);

        return new quat(
            _quat.x / _length,
            _quat.y / _length,
            _quat.z / _length,
            _quat.w / _length
        );
    }

    public static quat Inverse(quat _quat)
    {
        float _x = _quat.x, _y = _quat.y, _z = _quat.z, _w = _quat.w;

        float _inverseSqrLength = 1.0f / (_x * _x + _y * _y + _z * _z + _w * _w);
        
        return new quat(
            -_x * _inverseSqrLength,
            -_y * _inverseSqrLength,
            -_z * _inverseSqrLength,
             _w * _inverseSqrLength
        );
    }

    public static float Dot(quat _leftQuat, quat _rightQuat)
    {
        return 
            _leftQuat.x * _rightQuat.x +
            _leftQuat.y * _rightQuat.y +
            _leftQuat.z * _rightQuat.z +
            _leftQuat.w * _rightQuat.w
        ;
    }

    public static quat Lerp(quat _leftQuat, quat _rightQuat, float _t)
    {
        return Normalize(_leftQuat * (1f - _t) + _rightQuat * _t);
    }
    public static quat Slerp(quat _leftQuat, quat _rightQuat, float _t)
    {
        float _difference = Dot(_leftQuat, _rightQuat);

        if (_difference < 0f)
        {
            _rightQuat = -_rightQuat;
            _difference = -_difference;
        }

        _difference  = Maths.Min (_difference, 1f);

        float _diffAngle  = Maths.Acos(_difference);
        float _diffFactor = Maths.Sin (_diffAngle );

        if (_diffFactor < 0.001f)
        {
            return Lerp(_leftQuat, _rightQuat, _t);
        }

        float _leftWeight  = Maths.Sin((1f - _t) * _diffAngle) / _diffFactor;
        float _rightWeight = Maths.Sin(      _t  * _diffAngle) / _diffFactor;

        return new quat
        (
            _leftWeight * _leftQuat.x + _rightWeight * _rightQuat.x,
            _leftWeight * _leftQuat.y + _rightWeight * _rightQuat.y,
            _leftWeight * _leftQuat.z + _rightWeight * _rightQuat.z,
            _leftWeight * _leftQuat.w + _rightWeight * _rightQuat.w
        );
    }

    
    public static quat Scale(quat _quat, float _factor)
    {
        float _angle  = Maths.Acos(               _quat.w) * _factor;
        float _length = Maths.Sqrt(1f - _quat.w * _quat.w);

        if (_length < 0.001f)
        {
            return new quat
            (
                Maths.Sin(_angle),
                0f,
                0f,
                Maths.Cos(_angle)
            );
        }

        return new quat
        (
            Maths.Sin(_angle) * _quat.x / _length,
            Maths.Sin(_angle) * _quat.y / _length,
            Maths.Sin(_angle) * _quat.z / _length,
            Maths.Cos(_angle)
        );
    }
    
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Quaternion      (quat                             _quat     ) => new System.Numerics.Quaternion      (_quat.x, _quat.y, _quat.z, _quat.w);
    public static implicit operator quat                            (System.Numerics.Quaternion       _quat     ) => new quat                            (_quat.X, _quat.Y, _quat.Z, _quat.W);
    
    public static implicit operator XrQuaternionf                   (quat                             _quat     ) => new XrQuaternionf   {x = _quat.x, y = _quat.y, z = _quat.z, w = _quat.w};
    public static implicit operator quat                            (XrQuaternionf                    _quat     ) => new quat            (    _quat.x,     _quat.y,     _quat.z,     _quat.w);
    
    public static implicit operator quat                            (vec4                             _vec      ) => new quat                            (_vec .x, _vec .y, _vec .z, _vec .w);
    
    public static explicit operator quat                            (vec3                             _euler    )
    {
        float _cPitch = Maths.Cos(_euler.x * 0.5f);
        float _sPitch = Maths.Sin(_euler.x * 0.5f);
        
        float _cYaw   = Maths.Cos(_euler.y * 0.5f);
        float _sYaw   = Maths.Sin(_euler.y * 0.5f);
        
        float _cRoll  = Maths.Cos(_euler.z * 0.5f);
        float _sRoll  = Maths.Sin(_euler.z * 0.5f);

        return new quat
        (
            _sPitch * _cYaw * _cRoll + _cPitch * _sYaw * _sRoll,
            _cPitch * _sYaw * _cRoll - _sPitch * _cYaw * _sRoll,
            _cPitch * _cYaw * _sRoll - _sPitch * _sYaw * _cRoll,
            _cPitch * _cYaw * _cRoll + _sPitch * _sYaw * _sRoll
        );
    }
    #region CONVERSION
    public static explicit operator quat                            (axisAngle                        _axisAngle)
    {
        float _s = Maths.Sin(_axisAngle.angle * 0.5f);
        
        return new quat
        (
            _axisAngle.axis.x * _s,
            _axisAngle.axis.y * _s,
            _axisAngle.axis.z * _s,
            Maths.Cos(_axisAngle.angle * 0.5f)
        );
    }
    #endregion
    #endregion



    #region OUTPUT
    public readonly override string ToString() => $"({x:F2}, {y:F2}, {z:F2}, {w:F2})";
    #endregion
}