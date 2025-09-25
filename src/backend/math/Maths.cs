using System;



namespace Engine;



public static class Maths
{
    #region General

    public const float pi  = 3.14159265359f;
    public const float tau = 6.28318530718f;
    
    public const float rad = 57.2957795131f;
    public const float deg = 0.01745329251f;
    

    #region Absolute
    public static int Abs(int _value) => Math.Abs(_value);
    public static float Abs(float _value) => MathF.Abs(_value);
    public static double Abs(double _value) => Math.Abs(_value);
    #endregion

    #region Min
    public static int Min(int _valueA, int _valueB) => _valueA < _valueB ? _valueA : _valueB;
    public static float Min(float _valueA, float _valueB) => _valueA < _valueB ? _valueA : _valueB;
    public static double Min(double _valueA, double _valueB) => _valueA < _valueB ? _valueA : _valueB;
    #endregion

    #region Max
    public static int Max(int _valueA, int _valueB) => _valueA > _valueB ? _valueA : _valueB;
    public static float Max(float _valueA, float _valueB) => _valueA > _valueB ? _valueA : _valueB;
    public static double Max(double _valueA, double _valueB) => _valueA > _valueB ? _valueA : _valueB;
    #endregion

    #region Clamp
    public static int Clamp(int _value, int _valueMin, int _valueMax) => _value < _valueMin ? _valueMin : (_value > _valueMax ? _valueMax : _value);
    public static float Clamp(float _value, float _valueMin, float _valueMax) => _value < _valueMin ? _valueMin : (_value > _valueMax ? _valueMax : _value);
    public static double Clamp(double _value, double _valueMin, double _valueMax) => _value < _valueMin ? _valueMin : (_value > _valueMax ? _valueMax : _value);
    #endregion

    #region Sqrt
    public static double Sqrt(int _value) => Math.Sqrt(_value);
    public static float Sqrt(float _value) => MathF.Sqrt(_value);
    public static double Sqrt(double _value) => Math.Sqrt(_value);
    #endregion

    #region Round
    public static int Round(float _value) => (int)MathF.Round(_value);
    public static int Round(double _value) => (int)Math.Round(_value);
    #endregion

    #region Floor
    public static int Floor(float _value) => (int)MathF.Floor(_value);
    public static int Floor(double _value) => (int)Math.Floor(_value);
    #endregion

    #region Ceil
    public static int Ceil(float _value) => (int)MathF.Ceiling(_value);
    public static int Ceil(double _value) => (int)Math.Ceiling(_value);
    #endregion

    #region Sign
    public static int Sign(int _value) => Math.Sign(_value);
    public static int Sign(float _value) => MathF.Sign(_value);
    public static int Sign(double _value) => Math.Sign(_value);
    #endregion

    #region Lerp
    public static float Lerp(float _valueA, float _valueB, float _time) => _valueA + (_valueB - _valueA) * _time;
    public static double Lerp(double _valueA, double _valueB, double _time) => _valueA + (_valueB - _valueA) * _time;
    #endregion

    #region InverseLerp
    public static float InverseLerp(float _valueA, float _valueB, float _value) => (_value - _valueA) / (_valueB - _valueA);
    public static double InverseLerp(double _valueA, double _valueB, double _value) => (_value - _valueA) / (_valueB - _valueA);
    #endregion

    #region Remap
    public static float Remap(float _value, float _fromA, float _fromB, float _toA, float _toB) 
        => _toA + (_value - _fromA) * (_toB - _toA) / (_fromB - _fromA);
    public static double Remap(double _value, double _fromA, double _fromB, double _toA, double _toB) 
        => _toA + (_value - _fromA) * (_toB - _toA) / (_fromB - _fromA);
    #endregion

    #region Pow
    public static double Pow(int _valueA, int _valueB) => Math.Pow(_valueA, _valueB);
    public static float Pow(float _valueA, float _valueB) => MathF.Pow(_valueA, _valueB);
    public static double Pow(double _valueA, double _valueB) => Math.Pow(_valueA, _valueB);
    #endregion

    #region Exp
    public static double Exp(int _value) => Math.Exp(_value);
    public static float Exp(float _value) => MathF.Exp(_value);
    public static double Exp(double _value) => Math.Exp(_value);
    #endregion

    #region Log
    public static double Log(int _value) => Math.Log(_value);
    public static float Log(float _value) => MathF.Log(_value);
    public static double Log(double _value) => Math.Log(_value);
    #endregion

    #region Log10
    public static double Log10(int _value) => Math.Log10(_value);
    public static float Log10(float _value) => MathF.Log10(_value);
    public static double Log10(double _value) => Math.Log10(_value);
    #endregion

    #region Log2
    public static float Log2(int _value) => MathF.Log(_value, 2);
    public static float Log2(float _value) => MathF.Log(_value, 2f);
    public static double Log2(double _value) => Math.Log(_value, 2d);
    #endregion

    #region FastInvSqrt
    public static float InvSqrt(float _value)
    {
        float _approximation = BitConverter.Int32BitsToSingle(0x5f3759df - (BitConverter.SingleToInt32Bits(_value) >> 1));
        return _approximation * (1.5f - (_value * 0.5f * _approximation * _approximation));
    }
    #endregion

    #region Sin
    public static float Sin(float _value) => MathF.Sin(_value);
    public static double Sin(double _value) => Math.Sin(_value);
    #endregion

    #region Cos
    public static float Cos(float _value) => MathF.Cos(_value);
    public static double Cos(double _value) => Math.Cos(_value);
    #endregion

    #region Tan
    public static float Tan(float _value) => MathF.Tan(_value);
    public static double Tan(double _value) => Math.Tan(_value);
    #endregion

    #region Asin
    public static float Asin(float _value) => MathF.Asin(_value);
    public static double Asin(double _value) => Math.Asin(_value);
    #endregion

    #region Acos
    public static float Acos(float _value) => MathF.Acos(_value);
    public static double Acos(double _value) => Math.Acos(_value);
    #endregion

    #region Atan
    public static float Atan(float _value) => MathF.Atan(_value);
    public static double Atan(double _value) => Math.Atan(_value);
    #endregion

    #region Atan2
    public static float Atan2(float _y, float _x) => MathF.Atan2(_y, _x);
    public static double Atan2(double _y, double _x) => Math.Atan2(_y, _x);
    #endregion

    #region Truncate
    public static int Truncate(float _value) => (int)MathF.Truncate(_value);
    public static int Truncate(double _value) => (int)Math.Truncate(_value);
    #endregion

    #region Frac
    public static float Frac(float _value) => _value - MathF.Floor(_value);
    public static double Frac(double _value) => _value - Math.Floor(_value);
    #endregion

    #endregion

    #region Noise
    public static uint seed => seedX;
    private static uint seedX;
    private static uint seedY;

    static Maths()
    {
        SetSeed(0);
    }

    public static void SetSeed(uint _seed)
    {
        seedX = _seed;
        seedY = Random(~seedX);
    }

    public static uint Random(uint _value)
    {
        _value ^= seed;
        _value = ((_value >> 16) ^ _value) * 0x45d9f3b;
        _value = ((_value >> 16) ^ _value) * 0x45d9f3b;
        _value =  (_value >> 16) ^ _value;
        return _value;
    }

    public static uint Random(uint _value, ulong _valueCount)
    {
        return (uint)((Random(_value) * _valueCount) >> 32);
    }

    public static uint Random(uint _x, uint _y)
    {
        _x ^= seedX;
        _x = ((_x >> 16) ^ _x) * 0x45d9f3b;
        _x = ((_x >> 16) ^ _x) * 0x45d9f3b;
        _x =  (_x >> 16) ^ _x;

        _y ^= seedY;
        _y = ((_y >> 16) ^ _y) * 0x45d9f3b;
        _y = ((_y >> 16) ^ _y) * 0x45d9f3b;
        _y =  (_y >> 16) ^ _y;

        return _x ^ _y;
    }

    public static uint Random(uint _x, uint _y, ulong _valueCount)
    {
        return (uint)((Random(_x, _y) * _valueCount) >> 32);
    }

    #endregion
}