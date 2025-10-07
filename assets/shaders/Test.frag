#version 430 core


in  vec2 fUV;
in  vec3 fNormal;
in  vec3 fPosition;


out vec4 oFragColor;


void main()
{
    vec3 _pos    = fPosition * 10.0;
    vec3 _colorA = vec3(0.1, 0.1, 0.1) * (fNormal * 0.5 + 0.5);
    vec3 _colorB = vec3(0.2, 0.2, 0.2) * (fNormal * 0.5 + 0.5);
    
    oFragColor = vec4((int(mod(_pos.x, 2)) + int(mod(_pos.y, 2)) + int(mod(_pos.z, 2))) % 2 == 0 ? _colorA : _colorB, 1.0);
}