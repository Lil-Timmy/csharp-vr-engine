#version 450 core


uniform mat4 uWorldMat;
uniform mat4  uScreenMat;


const vec3 AXES[3][2] = vec3[][]
(
    vec3[2] 
    (
        vec3(1,0,0),
        vec3(0,1,0)
    ),
    vec3[2] 
    (
        vec3(1,0,0),
        vec3(0,0,1)
    ),
    vec3[2] 
    (
        vec3(0,1,0),
        vec3(0,0,1)
    )
);


void main()
{
    float _angle = gl_VertexID * (6.283185 / 24.0);
    float _a = cos(_angle);
    float _b = sin(_angle);

    vec4 _position = vec4
    (
        _a * AXES[gl_InstanceID][0] +
        _b * AXES[gl_InstanceID][1],
        1.0
    );

    gl_Position = uScreenMat * (uWorldMat * _position);
}