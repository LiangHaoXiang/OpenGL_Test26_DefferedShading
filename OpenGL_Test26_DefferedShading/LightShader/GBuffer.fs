#version 330 core
layout (location = 0) out vec3 gPosition;
layout (location = 1) out vec3 gNormal;
layout (location = 2) out vec4 gAlbedoSpec;

in VS_OUT {
    vec3 FragPos;
    vec3 Normal;
    vec2 TexCoords;
} fs_in;

uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;

void main()
{
    // 存储第一个G缓冲纹理中的片段位置向量
    gPosition = fs_in.FragPos;
    // 同样存储对每个逐片段法线到G缓冲中
    gNormal = normalize(fs_in.Normal);
    // 和漫反射对每个逐片段颜色
    gAlbedoSpec.rgb = texture(texture_diffuse1, fs_in.TexCoords).rgb;
    // 存储镜面强度到gAlbedoSpec的alpha分量
    gAlbedoSpec.a = texture(texture_specular1, fs_in.TexCoords).r;
}
