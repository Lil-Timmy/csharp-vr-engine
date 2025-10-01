#version 430 core


in  vec2 fUV;
in  vec3 fNormal;


out vec4 oFragColor;


void main()
{
    oFragColor = vec4(fNormal * 0.5 + 0.5, 1.0);
}