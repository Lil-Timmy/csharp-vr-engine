#version 430 core


in  vec2 fUV;
in  vec3 fNormal;
in  vec3 fPosition;


out vec4 oFragColor;


void main()
{
    float _dir   = dot(vec3(-0.57735, -0.57735, -0.57735), -fNormal);
    vec3  _light = 
        (_dir > 0.9) ? 
            vec3(1.0, 1.0, 1.0) : 
        ((_dir > 0.3) ? 
            vec3(0.5, 0.5, 0.6) : 
        ((_dir > -0.3) ? 
            vec3(0.3, 0.3, 0.5) : 
            vec3(0.1, 0.1, 0.2)));
    
    vec3 _pos    = fPosition * 10.0;
    vec3 _colorA = clamp(_light    * vec3(0.9, 0.9, 0.9) * (fNormal * 0.5 + 0.5), vec3(0.0), vec3(1.0));
    vec3 _colorB = clamp(_light    * vec3(1.0, 1.0, 1.0) * (fNormal * 0.5 + 0.5), vec3(0.0), vec3(1.0));
    
    
    oFragColor = vec4((int(mod(_pos.x, 2)) + int(mod(_pos.y, 2)) + int(mod(_pos.z, 2))) % 2 == 0 ? _colorA : _colorB, 1.0);
}