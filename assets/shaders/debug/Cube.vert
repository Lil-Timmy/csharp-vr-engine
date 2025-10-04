#version 450 core


uniform mat4 uWorldMat;
uniform mat4  uScreenMat;


const vec3 LINES[24] = vec3[](
    vec3(-0.5, -0.5, -0.5), vec3( 0.5, -0.5, -0.5),
    vec3( 0.5, -0.5, -0.5), vec3( 0.5, -0.5,  0.5),
    vec3( 0.5, -0.5,  0.5), vec3(-0.5, -0.5,  0.5),
    vec3(-0.5, -0.5,  0.5), vec3(-0.5, -0.5, -0.5),

    vec3(-0.5,  0.5, -0.5), vec3( 0.5,  0.5, -0.5),
    vec3( 0.5,  0.5, -0.5), vec3( 0.5,  0.5,  0.5),
    vec3( 0.5,  0.5,  0.5), vec3(-0.5,  0.5,  0.5),
    vec3(-0.5,  0.5,  0.5), vec3(-0.5,  0.5, -0.5),

    vec3(-0.5, -0.5, -0.5), vec3(-0.5,  0.5, -0.5),
    vec3( 0.5, -0.5, -0.5), vec3( 0.5,  0.5, -0.5),
    vec3( 0.5, -0.5,  0.5), vec3( 0.5,  0.5,  0.5),
    vec3(-0.5, -0.5,  0.5), vec3(-0.5,  0.5,  0.5)
);


void main()
{
    vec4 _position = vec4(LINES[gl_VertexID], 1.0);

    gl_Position = uScreenMat * (uWorldMat * _position);
}