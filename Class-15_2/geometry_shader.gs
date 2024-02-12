#version 330 core

layout (triangles) in;
layout (triangle_strip, max_vertices = 3) out;


in VS_OUT {
    vec2 texCoords;
} gs_in[];

out vec2 TexCoords;

uniform float time;

vec3 GetNormal() {
    vec3 a = vec3(gl_in[0].gl_Position) - vec3(gl_in[1].gl_Position);
    vec3 b = vec3(gl_in[1].gl_Position) - vec3(gl_in[2].gl_Position);
    return normalize(cross(a, b));
}

vec4 explode(vec4 position, vec3 normal) {
    float magnitude = 2.0;
    vec3 direction = normal * (sin(time) + 1.0) / 2.0 * magnitude;
    return position + vec4(direction, 0.0);
}

void main() {
    vec3 Normal = GetNormal();

    TexCoords = gs_in[0].texCoords;
    explode(gl_in[0].gl_Position, Normal);
    EmitVertex();

    TexCoords = gs_in[1].texCoords;
    explode(gl_in[1].gl_Position, Normal);
    EmitVertex();

    TexCoords = gs_in[2].texCoords;
    explode(gl_in[2].gl_Position, Normal);
    EmitVertex();

    EndPrimitive();
}

/*
in gl_Vertex
{
    vec4  gl_Position;
    float gl_PointSize;
    float gl_ClipDistance[];
} gl_in[];
*/
