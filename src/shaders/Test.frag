#version 430 core


in  vec3 fColor;


out vec4 oFragColor;


void main()
{
    oFragColor = vec4(fColor, 1.0);
}