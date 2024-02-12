#version 330 core

layout (points) in;
layout (triangle_strip, max_vertices = 5) out;


in VS_OUT {
    vec3 color;
} gs_in[];

out vec3 fColor;

void buildHouse(vec4 position) {
    fColor = gs_in[0].color;
    gl_Position = position + vec4(-0.2, -0.2, 0.0, 0.0);
    EmitVertex();
    gl_Position = position + vec4( 0.2, -0.2, 0.0, 0.0);
    EmitVertex();
    gl_Position = position + vec4(-0.2,  0.2, 0.0, 0.0);
    EmitVertex();
    gl_Position = position + vec4( 0.2,  0.2, 0.0, 0.0);
    EmitVertex();
    gl_Position = position + vec4( 0.0,  0.4, 0.0, 0.0);
    fColor = vec3(1.0, 1.0, 1.0);   // 将最后一个顶点的颜色设置为白色
    EmitVertex();

    EndPrimitive();
}

void main() {
    buildHouse(gl_in[0].gl_Position);
}

/*
in gl_Vertex
{
    vec4  gl_Position;
    float gl_PointSize;
    float gl_ClipDistance[];
} gl_in[];
*/
