#version 450 core


vec2 vertexPositions[4] = vec2[]
(
    vec2(-1, -1),
    vec2(-1,  1),
    vec2( 1, -1),
    vec2( 1,  1)
);

vec3 vertexColors[4] = vec3[]
(
    vec3(1, 0, 0),
    vec3(0, 1, 0),
    vec3(0, 0, 1),
    vec3(1, 1, 1)
);


in vec3 vPosition;
in vec2 vUV;
in vec3 vNormal;


uniform mat4 uPositionMat;
uniform mat4 uRotationMat;
uniform mat4 uScaleMat;

uniform mat4 uScreenMat;


out vec2 fUV;
out vec3 fNormal;
out vec3 fColor;


void main()
{
    fUV       = vUV;
    fNormal   = (uRotationMat * vec4(vNormal, 1.0)).xyz;
    fColor    = vertexColors[gl_VertexID % 4];
    
    vec4 _position = uScreenMat * ((uPositionMat * uRotationMat * uScaleMat) * vec4(vPosition, 1.0));
    
    gl_Position = _position;
}