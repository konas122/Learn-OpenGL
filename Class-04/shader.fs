#version 330 core
out vec4 FragColor;

in vec3 ourColor;
in vec2 TexCoord;

uniform sampler2D texture1;
uniform sampler2D texture2;

void main()
{
    // 使用 GLSL 内建的 `texture` 函数来采样纹理的颜色
    // - 第一个参数是纹理采样器
    // - 第二个参数是对应的纹理坐标
    // FragColor = texture(ourTexture, TexCoord);

    /**
     * GLSL 内建的 `mix` 函数需要接受两个值作为参数, 并对它们根据第三个参数进行线性插值. 
     * 如果第三个值是 0.0, 它会返回第一个输入;
     * 如果是 1.0, 会返回第二个输入值.
     * 0.2 会返回 80% 的第一个输入颜色和 20% 的第二个输入颜色, 即返回两个纹理的混合色.
    */
    FragColor = mix(texture(texture1, TexCoord), texture(texture2, TexCoord), 0.2);
}