Shader "Unlit/Float"
{
    //Makes object float in the air
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex      vert //Vertex shader function
            #pragma fragment    frag //Fragment (pixel) shader function

            #include "UnityCG.cginc" //Include Unity's common shader functions

            //Input structure for the vertex shader
            struct appdata
            {
                float4 vertex   : POSITION; //Vertex position
                float2 uv       : TEXCOORD0; //Texture coordinate
            };

            //Output structure for controlling movement
            struct v2f
            {
                float2 uv       : TEXCOORD0; //Texture coordinate
                float4 vertex   : SV_POSITION; //Screen space vertex position
            };

            //Variable for controlling movement
            float movement;

            v2f vert(appdata v)
            {
                v2f output;

                //Apply sine wave to the vertex position
                float4 localSpace = v.vertex;
                localSpace.y += sin(movement);

                //Transform vertex to clip space
                output.vertex = UnityObjectToClipPos(localSpace);
                output.uv = v.uv;
                return output;
            }

            sampler2D   _MainTex;

            fixed4 frag(v2f input) : SV_Target
            {
                fixed4 col = fixed4(0.0, 1.0, 0.0, 1.0); //Green colour with alpha

                return col;
            }
            ENDCG
        }
    }
}
