


namespace Engine;


public static class IK
{
    public static (vec3 _posA, vec3 _posB, quat _rotA, quat _rotB) BendPoint(vec3 _origin, vec3 _target, float _lengthA, float _lengthB, vec3 _influenceDir)
    {
        vec3  _offset = _target  - _origin;
        float _length = _lengthA + _lengthB;
        float _mag    = vec3.Magnitude(_offset);
        vec3  _dir    = _offset * (1f / _mag);
        
        if (_mag > _length)
        {
            _mag    = _length;
            _target = _origin + _dir * _length;
        }
        
        float _rightDirAngle = vec3.Angle(_influenceDir, _dir);
        float _rightIKAngle  = Maths.Acos(Maths.Clamp((_lengthA - (_lengthB - _mag * (_lengthB / (_lengthA + _lengthB)))) / _lengthA, -1f, 1f));
        
        
        vec3 _bendPos = _origin + vec3.Slerp(_dir, vec3.Normalize(_influenceDir), _rightIKAngle / _rightDirAngle) * 0.3f;
        
        return
        (
            (_origin + _bendPos) * 0.5f,
            (_target + _bendPos) * 0.5f,
            quat.LookRotation(vec3.Normalize(_bendPos - _origin ), _influenceDir),
            quat.LookRotation(vec3.Normalize(_target  - _bendPos), _influenceDir)
        );
    }
}