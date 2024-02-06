#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 FragPos;
in vec2 TexCoords;

uniform vec3 viewPos;
uniform float shininess;
uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;

struct Light {
    vec3 position;
    vec3 direction;

    float cutOff;
    float outerCutOff;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;
};

uniform Light light;

void main()
{    
    vec3 lightDir = normalize(light.position - FragPos);

    // ambient
    vec3 ambient = light.ambient * texture(texture_diffuse1, TexCoords).rgb;

    // diffuse
    vec3 norm = normalize(Normal);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * texture(texture_diffuse1, TexCoords).rgb;

    // specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), shininess);
    vec3 specular = light.specular * spec * texture(texture_diffuse1, TexCoords).rgb;

    // spotlight (soft edges)
    float theta = dot(lightDir, normalize(-light.direction));
    float epsilon = light.cutOff - light.outerCutOff;
    // clamp 把第一个参数约束在了 0.0 到 1.0 之间
    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);
    diffuse  *= intensity;
    specular *= intensity;

    // attenuation
    float distance    = length(-light.direction);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));

    ambient  *= attenuation;
    diffuse  *= attenuation;
    specular *= attenuation;

    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);

    // FragColor = texture(texture_diffuse1, TexCoords);
}