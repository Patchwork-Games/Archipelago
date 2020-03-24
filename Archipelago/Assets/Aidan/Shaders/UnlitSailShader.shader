Shader "Unlit/UnlitSailShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Albedo (RGB)", 2D) = "white" {}
        _HeightMap("Height Map", 2D) = "white" {}
        _HeightMapScale("Height", Float) = 1
        _HeightMapOffset("Height Map Offset", Vector) = (0.2,0.1,0,0)
        _WindSpeed("Wind Speed", Float) = 100
        _WindAmplitude("Wind Amplitude", Float) = 2
        _WindFrequency("Wind Frequency", Float) = 10
    }
    SubShader
    {
        Tags 
        {
            "Queue" = "Geometry"
            "RenderType"="Opaque"
        }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _HeightMap;
            float4 _MainTex_ST;
            half _HeightMapScale;
            float4 _HeightMapOffset;
            float _WindSpeed;
            float _WindAmplitude;
            float _WindFrequency;

            v2f vert (appdata v)
            {
                v2f o;

                float4 heightMapColor = tex2Dlod(_HeightMap, float4(v.uv.xy + _HeightMapOffset, 0, 0));
                float displacement = heightMapColor.r * _HeightMapScale;
                v.vertex.y += displacement + (heightMapColor.r * _WindAmplitude * sin((v.vertex.x + _Time[1] * _WindSpeed)/ _WindFrequency) + (heightMapColor.r * _WindAmplitude * sin((v.vertex.z + _Time[1] * _WindSpeed)/ _WindFrequency)));

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
