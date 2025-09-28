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
    public quat(vec3 _euler)
    {
        float _cPitch = MathF.Cos(_euler.x * 0.5f);
        float _sPitch = MathF.Sin(_euler.x * 0.5f);
        
        float _cYaw   = MathF.Cos(_euler.y * 0.5f);
        float _sYaw   = MathF.Sin(_euler.y * 0.5f);
        
        float _cRoll  = MathF.Cos(_euler.z * 0.5f);
        float _sRoll  = MathF.Sin(_euler.z * 0.5f);

        (x, y, z, w) =
        (
            _sPitch * _cYaw * _cRoll + _cPitch * _sYaw * _sRoll,
            _cPitch * _sYaw * _cRoll - _sPitch * _cYaw * _sRoll,
            _cPitch * _cYaw * _sRoll - _sPitch * _sYaw * _cRoll,
            _cPitch * _cYaw * _cRoll + _sPitch * _sYaw * _sRoll
        );
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
    public static vec3 operator *(quat _leftQuat, ivec3 _rightVec)
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



    #region HASH
    public override int GetHashCode() => HashCode.Combine(x, y, z, w);
    #endregion



    #region EQUAL
    public readonly          bool Equals(quat  _vec) => x == _vec.x && y == _vec.y && z == _vec.z && w == _vec.w;
    public readonly override bool Equals(object _obj) => (_obj is quat _vec) && Equals(_vec     );
    
    public static bool operator ==(quat _leftQuat, quat _rightQuat) =>  _leftQuat.Equals(_rightQuat);
    public static bool operator !=(quat _leftQuat, quat _rightQuat) => !_leftQuat.Equals(_rightQuat);
    #endregion



    #region AXES

    public static vec3 AxisX(quat _quat)
    {
        float _x = _quat.x, _y = _quat.y, _z = _quat.z, _w = _quat.w;

        return new vec3(
            1f - 2f * (_y * _y + _z * _z),
            2f * (_x * _y - _w * _z),
            2f * (_x * _z + _w * _y)
        );
    }
    
    public static vec3 AxisY(quat _quat)
    {
        float _x = _quat.x, _y = _quat.y, _z = _quat.z, _w = _quat.w;

        return new vec3(
            2f * (_x * _y + _w * _z),
            1f - 2f * (_x * _x + _z * _z),
            2f * (_y * _z - _w * _x)
        );
    }
    
    public static vec3 AxisZ(quat _quat)
    {
        float _x = _quat.x, _y = _quat.y, _z = _quat.z, _w = _quat.w;

        return new vec3(
            2f * (_x * _z - _w * _y),
            2f * (_y * _z + _w * _x),
            1f - 2f * (_x * _x + _y * _y)
        );
    }

    public static (vec3 _axisX, vec3 _axisY, vec3 _axisZ) Axes(quat _quat)
    {
        float _x = _quat.x, _y = _quat.y, _z = _quat.z, _w = _quat.w;

        float _xx = _x * _x;
        float _yy = _y * _y;
        float _zz = _z * _z;

        float _xy = _x * _y;
        float _xz = _x * _z;
        
        float _yz = _y * _z;

        float _wx = _w * _x;
        float _wy = _w * _y;
        float _wz = _w * _z;
        

        return (
            new vec3(
                1f - 2f * (_yy + _zz),
                2f * (_xy - _wz),
                2f * (_xz + _wy)
            ),
            new vec3(
                2f * (_xy + _wz),
                1f - 2f * (_xx + _zz),
                2f * (_yz - _wx)
            ),
            new vec3(
                2f * (_xz - _wy),
                2f * (_yz + _wx),
                1f - 2f * (_xx + _yy)
            )
        );
    }

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

    public static quat Slerp(quat _leftQuat, quat _rightQuat, float _t)
    {
        float _dotAngle = Dot(_leftQuat, _rightQuat);
        
        _rightQuat *= _dotAngle < 0.0f ? -1.0f : 1.0f;
        _dotAngle = Maths.Abs(_dotAngle);

        float _initialAngle = (float)Maths.Acos(_dotAngle);
        float _interpolatedAngle = _initialAngle * _t; 
        
        float _initialSine = (float)Maths.Sin(_initialAngle);

        if (_initialSine < 0.001f)
        {
            return _leftQuat;
        }
        
        float _interpolatedSine = (float)Maths.Sin(_initialAngle * _t);

        float _slerpA = (float)Maths.Cos(_interpolatedAngle) - _dotAngle * _interpolatedSine / _initialSine;
        float _slerpB = _interpolatedSine / _initialSine;

        return new quat(
            _slerpA * _leftQuat.x + _slerpB * _rightQuat.x,
            _slerpA * _leftQuat.y + _slerpB * _rightQuat.y,
            _slerpA * _leftQuat.z + _slerpB * _rightQuat.z,
            _slerpA * _leftQuat.w + _slerpB * _rightQuat.w
        );
    }
    
    #endregion



    #region CONVERSION
    public static implicit operator System.Numerics.Quaternion      (quat                             _quat) => new System.Numerics.Quaternion      (_quat.x, _quat.y, _quat.z, _quat.w);
    public static implicit operator quat                            (System.Numerics.Quaternion       _quat) => new quat                            (_quat.X, _quat.Y, _quat.Z, _quat.W);
    
    public static implicit operator XrQuaternionf                   (quat                             _quat) => new XrQuaternionf   {x = _quat.x, y = _quat.y, z = _quat.z, w = _quat.w};
    public static implicit operator quat                            (XrQuaternionf                    _quat) => new quat            (    _quat.x,     _quat.y,     _quat.z,     _quat.w);
    
    public static implicit operator quat                            (vec4                             _vec ) => new quat                            (_vec .x, _vec .y, _vec .z, _vec .w);
    #endregion



    #region OUTPUT
    public readonly override string ToString()
    {
        return $"({x}, {y}, {z}, {w})";
    }
    #endregion
}