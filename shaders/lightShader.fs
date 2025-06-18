#version 330 core
in vec3 Normal;
in vec3 FragPos;

out vec4 FragColor;
  
struct Material {
  vec3 ambient;
  vec3 diffuse;
  vec3 specular;
  float shininess;
}; 
  
uniform Material material;

struct Light {
  vec3 position;

  vec3 ambient;
  vec3 diffuse;
  vec3 specular;
};

uniform Light light;

uniform vec3 viewPos;
uniform vec3 lightPos;
uniform vec3 objectColor;
uniform vec3 lightColor;

void main()
{
  vec3 ambient = material.ambient * lightColor;

  vec3 norm = normalize(Normal);
  vec3 lightDir = normalize(lightPos - FragPos); 
  float diff = max(dot(norm, lightDir), 0.0);
  //vec3 diffuse = (diff * material.diffuse) * lightColor;
  vec3 diffuse = material.diffuse * diff * lightColor;

  float specularStrength = 0.5;
  vec3 viewDir = normalize(viewPos - FragPos);
  vec3 reflectDir = reflect(-lightDir, norm);

  float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
  vec3 specular = specularStrength * spec * lightColor; 

  ambient  = light.ambient * material.ambient;
  diffuse  = light.diffuse * (diff * material.diffuse);
  specular = light.specular * (spec * material.specular);  

  vec3 result = (ambient + diffuse + specular) * objectColor;
  FragColor = vec4(result, 1.0);
}
