#version 450 core


in vec3 vPosition;
in vec2 vUV;
in vec3 vNormal;


uniform mat4 uPositionMat;
uniform mat4 uRotationMat;
uniform mat4 uScaleMat;

uniform mat4 uScreenMat;


out vec2 fUV;
out vec3 fNormal;
out vec3 fPosition;


void main()
{
    vec4 _position = ((uPositionMat * uRotationMat * uScaleMat) * vec4(vPosition, 1.0));
    
    fUV            = vUV;
    fNormal        = (uRotationMat * vec4(vNormal, 1.0)).xyz;
    fPosition      = _position.xyz;
    
    
    gl_Position    = uScreenMat * _position;
}