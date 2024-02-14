#version 330 core
layout (location=0) in vec3 aPos;
layout (location=1) in vec3 aNormal;
layout (location=2) in vec2 aTexcoord;

out vec3 FragPos;
out vec3 Normal;
out vec2 Texcoords;

uniform mat4 projection;
uniform mat4 view;

void main() {
    FragPos = aPos;
    Normal = aNormal;
    Texcoords = aTexcoord;
    gl_Position = projection * view * vec4(aPos, 1.0);
}
