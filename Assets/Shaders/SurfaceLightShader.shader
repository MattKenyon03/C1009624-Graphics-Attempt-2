Shader "Custom/Surface Light Shader"
{
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
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex   : POSITION;
                float3 normal   : NORMAL;
                float2 uv       : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv       : TEXCOORD0;
                float4 vertex   : SV_POSITION;
                float3 normal  : NORMAL;
                float3 worldPos : POSITIONT;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            float3 camPosition;
            float3 lightPosition;
            float4 lightColour;

            float lightIntensity;
            float lightRange;
            float specularPower;

            v2f vert(appdata v)
            {
                v2f o;
                o.worldPos = mul(UNITY_MATRIX_M, v.vertex).xyz;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);

                float3x3 normalMat = UNITY_MATRIX_M;
                o.normal = mul(normalMat, v.normal);

                return o;
            }

            float LinearAttentuation(float distance) {
                return saturate(1.0f - distance / lightRange);
            }

            float SquareDistanceAttentuation(float distance) {
                return saturate(1.0f / (distance * distance));
            }

            float MixedAttenuation(float distance) {
                float distanceSqr = distance * distance;
                float falloffStart = lightRange * 0.8f;

                float linearAtten = 1.0f - saturate((distance - falloffStart) / (lightRange - falloffStart));

                return saturate((lightRange / (lightRange + distanceSqr)) * linearAtten);
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 textureColour = tex2D(_MainTex, i.uv);

                float distance = length(lightPosition - i.worldPos);
                float3 incident = normalize(lightPosition - i.worldPos);
                float3 normal = normalize(i.normal);

                float diffuseAmount = saturate(dot(incident, normal));
                float4 diffuseColour = lightColour * lightIntensity * diffuseAmount;

                float3 camVec = normalize(camPosition - i.worldPos);
                float3 halfAngle = normalize(incident + camVec);
                float specAmount = saturate(dot(halfAngle, normal));
                specAmount = pow(specAmount, specularPower);

                float4 specularColour = lightColour * lightIntensity * specAmount;
                float attenuation = MixedAttenuation(distance);

                return (((diffuseColour * textureColour) + specularColour) * attenuation);
            }
            ENDCG
        }
    }
}
