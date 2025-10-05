#version 430 core


in  vec2 fUV;
in  vec3 fNormal;
in  vec3 fPosition;


out vec4 oFragColor;


void main()
{
    oFragColor = vec4(int(fPosition.x) % 2 * 0.25, int(fPosition.y) % 2 * 0.25, int(fPosition.z) % 2 * 0.25, 0) + vec4(fNormal * 0.25 + 0.25, 1.0);
}