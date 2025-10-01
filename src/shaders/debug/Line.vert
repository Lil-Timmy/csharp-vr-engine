#version 450 core


uniform vec3 uStart;
uniform vec3 uEnd;

uniform mat4 uScreenMat;


void main()
{
    vec4 _position = vec4(gl_VertexID == 0 ? uStart : uEnd, 1.0);

    gl_Position = uScreenMat * _position;
}