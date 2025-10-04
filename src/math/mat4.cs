using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;



namespace Engine;


[StructLayout(LayoutKind.Sequential)]
public struct mat4
{
    // Row-Column Order.
    public vec4 x;
    public vec4 y;
    public vec4 z;
    public vec4 w;


    public static readonly mat4 zero = default;


    public static readonly mat4 identity = new mat4(
        new vec4(1.0f, 0.0f, 0.0f, 0.0f),
        new vec4(0.0f, 1.0f, 0.0f, 0.0f),
        new vec4(0.0f, 0.0f, 1.0f, 0.0f),
        new vec4(0.0f, 0.0f, 0.0f, 1.0f)
    );



    public mat4(
        float _xx, float _xy, float _xz, float _xw, // Row 1.
        float _yx, float _yy, float _yz, float _yw, // Row 2.
        float _zx, float _zy, float _zz, float _zw, // Row 3.
        float _wx, float _wy, float _wz, float _ww  // Row 4.
        )
    {
        x = new vec4(_xx, _xy, _xz, _xw); // Row 1.
        y = new vec4(_yx, _yy, _yz, _yw); // Row 2.
        z = new vec4(_zx, _zy, _zz, _zw); // Row 3.
        w = new vec4(_wx, _wy, _wz, _ww); // Row 4.
    }

    public mat4(vec4 _x, vec4 _y, vec4 _z, vec4 _w)
    {
        (x, y, z, w) = (_x, _y, _z, _w);
    }



    #region ADD
    public static mat4 operator +(mat4 _leftMat, mat4 _rightMat)
    {
        return new mat4(
            _leftMat.x + _rightMat.x,
            _leftMat.y + _rightMat.y,
            _leftMat.z + _rightMat.z,
            _leftMat.w + _rightMat.w
        );
    }
    #endregion
    
    #region SUBTRACT
    public static mat4 operator -(mat4 _leftMat, mat4 _rightMat)
    {
        return new mat4(
            _leftMat.x - _rightMat.x,
            _leftMat.y - _rightMat.y,
            _leftMat.z - _rightMat.z,
            _leftMat.w - _rightMat.w
        );
    }
    #endregion

    #region MULTIPLY
    public static mat4 operator *(mat4 _leftMat, mat4 _rightMat)
    {
        return new mat4 (
            _leftMat.x.x * _rightMat.x + _leftMat.x.y * _rightMat.y + _leftMat.x.z * _rightMat.z + _leftMat.x.w * _rightMat.w,
            _leftMat.y.x * _rightMat.x + _leftMat.y.y * _rightMat.y + _leftMat.y.z * _rightMat.z + _leftMat.y.w * _rightMat.w,
            _leftMat.z.x * _rightMat.x + _leftMat.z.y * _rightMat.y + _leftMat.z.z * _rightMat.z + _leftMat.z.w * _rightMat.w,
            _leftMat.w.x * _rightMat.x + _leftMat.w.y * _rightMat.y + _leftMat.w.z * _rightMat.z + _leftMat.w.w * _rightMat.w
        );
    }

    #endregion


    #region MATH

    public static mat4 Position(vec3 _vec)
    {
        mat4 _mat = identity;

        _mat.w.x = _vec.x;
        _mat.w.y = _vec.y;
        _mat.w.z = _vec.z;

        return _mat;
    }

    public static mat4 Rotation(quat _quat)
    {
        mat4 _mat = identity;

        float _xx = _quat.x * _quat.x;
        float _yy = _quat.y * _quat.y;
        float _zz = _quat.z * _quat.z;

        float _xy = _quat.x * _quat.y;
        float _wz = _quat.z * _quat.w;
        float _xz = _quat.z * _quat.x;
        float _wy = _quat.y * _quat.w;
        float _yz = _quat.y * _quat.z;
        float _wx = _quat.x * _quat.w;

        _mat.x.x = 1.0f - (2.0f * (_yy + _zz));
        _mat.x.y =         2.0f * (_xy + _wz);
        _mat.x.z =         2.0f * (_xz - _wy);

        _mat.y.x =         2.0f * (_xy - _wz);
        _mat.y.y = 1.0f - (2.0f * (_zz + _xx));
        _mat.y.z =         2.0f * (_yz + _wx);

        _mat.z.x =         2.0f * (_xz + _wy);
        _mat.z.y =         2.0f * (_yz - _wx);
        _mat.z.z = 1.0f - (2.0f * (_yy + _xx));
        

        return _mat;
    }
    
    public static mat4 Scale(vec3 _vec)
    {
        mat4 _mat = identity;

        _mat.x.x = _vec.x;
        _mat.y.y = _vec.y;
        _mat.z.z = _vec.z;

        return _mat;
    }

    public static mat4 Projection(XRView _view, float near, float far)
    {
        float _left   = Maths.Tan(_view.angleLeft);
        float _right  = Maths.Tan(_view.angleRight);
        float _down   = Maths.Tan(_view.angleDown);
        float _up     = Maths.Tan(_view.angleUp);

        float _width  = _right - _left;
        float _height = _up    - _down;

        mat4 mat = new mat4
        (
            2f               / _width, 0f                     ,  0f                            ,  0f,
            0f                       , 2f            / _height,  0f                            ,  0f,
            (_right + _left) / _width, (_up + _down) / _height, -(far + near)    / (far - near), -1f,
            0f                       , 0f                     , -2f * far * near / (far - near),  0f
        );

        return mat;
    }
    
    public static mat4 Projection(float _fov, float _aspectRatio, float _near, float _far)
    {
        float _invFov = 1f / (float)Maths.Tan(_fov * 0.5f);

        return new mat4
        (
            _invFov / _aspectRatio, 0f     , 0f                             ,  0f,
            0f              , _invFov, 0f                             ,  0f,
            0f              , 0f     , -(_far + _near) / (_far - _near)   , -1f,
            0f              , 0f     , -2f * _far * _near / (_far - _near),  0f
        );
    }

    #endregion



    #region OUTPUT
    public override readonly string ToString() =>  $"{x}\n{y}\n{z}\n{w}";
    #endregion



    #region CONSTS
    private const MethodImplOptions INLINED = MethodImplOptions.AggressiveInlining;
    #endregion
}