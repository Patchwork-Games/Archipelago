Shader "Custom/SailShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_HeightMap("Height Map", 2D) = "white" {}
		_HeightMapScale("Height", Float) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
		Tags { "Queue" = "Transparent" "RenderType" = "Opaque" }
        LOD 200

		Cull Off

		ZWrite On

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
		#pragma glsl

        sampler2D _MainTex;
		sampler2D _HeightMap;

        struct Input
        {
            float2 uv_MainTex;
        };

		half _HeightMapScale;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			float4 heightMap = tex2Dlod(_HeightMap, float4(v.texcoord.xy + float2(0.2, 0.1), 0, 0));
			v.vertex.y *= heightMap.r * _HeightMapScale + (heightMap.r * 10 * sin(v.vertex.x + _Time[1] * 10)/ 10 + (heightMap.r * 10 * sin(v.vertex.z + _Time[1] * 10) / 10));
		}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
