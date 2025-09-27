#version 450 core


in vec2 vPosition;
in vec3 vColor;


uniform vec2 uPosition;


out vec3 fColor;


void main()
{
    fColor      = vColor;
    gl_Position = vec4(vPosition + uPosition * 0.5, 0.0, 1.0);
}