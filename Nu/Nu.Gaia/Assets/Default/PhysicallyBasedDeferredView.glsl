#shader vertex
#version 410

layout (location = 0) in vec3 position;
layout (location = 1) in vec2 texCoords;

out vec2 texCoordsOut;

void main()
{
    texCoordsOut = texCoords;
    gl_Position = vec4(position, 1.0);
}

#shader fragment
#version 410

uniform mat4 view;
uniform sampler2D positionTexture;
uniform sampler2D normalPlusTexture;

in vec2 texCoordsOut;

layout (location = 0) out vec4 positionView;
layout (location = 1) out vec4 normalPlusView;

void main()
{
    // ensure position was written, otherwise the cleared zero values are fine
    vec4 position = texture(positionTexture, texCoordsOut);
    if (position.w == 1.0)
    {
        positionView = view * position;
        positionView.w = 1.0; // may be redundant since should already be 1.0, but making sure in case view is degenerate...
        vec4 normalPlus = texture(normalPlusTexture, texCoordsOut);
        normalPlusView.xyz = mat3(view) * normalPlus.xyz;
        normalPlusView.w = normalPlus.w;
    }
    else
    {
        positionView = vec4(0.0);
        normalPlusView = vec4(0.0);
    }
}
