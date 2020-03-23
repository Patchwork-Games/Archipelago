Shader "Custom/SailShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_HeightMap("Height Map", 2D) = "white" {}
		_HeightMapScale("Height", Float) = 1
        _TexSize("Texture Size", Float) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
		Tags
        { 
            "Queue" = "Transparent"
            "RenderType" = "Opaque" 
        }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert alpha:blend
        #pragma target 5.0

        sampler2D _MainTex;
		sampler2D _HeightMap;

        struct Input
        {
            float2 uv_MainTex;
            float3 normal;
        };

		half _HeightMapScale;
        half _TexSize;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float3 normalsFromHeight(sampler2D heigthTex, float4 uv, float texelSize)
        {
            float4 adjacentPositions;
            float4 adjacentVectors;


            float4 h;
            h[0] = tex2Dlod(heigthTex, uv + float4(texelSize * float2(0, -1 / _TexSize), 0, 0)).r * _HeightMapScale;
            h[1] = tex2Dlod(heigthTex, uv + float4(texelSize * float2(-1 / _TexSize, 0), 0, 0)).r * _HeightMapScale;
            h[2] = tex2Dlod(heigthTex, uv + float4(texelSize * float2(1 / _TexSize, 0), 0, 0)).r * _HeightMapScale;
            h[3] = tex2Dlod(heigthTex, uv + float4(texelSize * float2(0, 1 / _TexSize), 0, 0)).r * _HeightMapScale;
            float3 n;
            n.z = h[3] - h[0];
            n.x = h[2] - h[1];
            n.y = 2;
            return normalize(n);
        }

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			float4 heightMapColor = tex2Dlod(_HeightMap, float4(v.texcoord.xy + float2(0.2, 0.1), 0, 0));
            float displacement = heightMapColor.r * _HeightMapScale;

            // Output data
            v.vertex.y *= displacement;// +(heightMap.r * 10 * sin(v.vertex.x + _Time[1] * 10) / 10 + (heightMap.r * 10 * sin(v.vertex.z + _Time[1] * 10) / 10));

            o.normal = normalsFromHeight(_HeightMap, float4(v.texcoord.xy + float2(0.2, 0.1), 0, 0), 100);
            //o.texCoordUVs = v.texcoord.xy;
            //o.tangent = float3(0, 0, 0);
		}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            o.Albedo = normalize(IN.normal.rgb);
            o.Albedo = float3(IN.uv_MainTex, 0);

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
