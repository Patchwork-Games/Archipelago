Shader "Custom/TerrainWSplat"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1)
        //_MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
		_Color("Main Color", Color) = (1,1,1,1)
		_Top("Top", 2D) = "white" {}
		_Side("Side", 2D) = "white" {}
		_Sand("Sand", 2D) = "white" {}

		[HideInInspector]_Control("Control (RGBA)", 2D) = "red" {}
		[HideInInspector]_Splat3("Layer 3 (A)", 2D) = "white" {}
		[HideInInspector]_Splat2("Layer 2 (B)", 2D) = "white" {}
		[HideInInspector]_Splat1("Layer 1 (G)", 2D) = "white" {}
		[HideInInspector]_Splat0("Layer 0 (R)", 2D) = "white" {}

    }
    SubShader
    {
        //Tags { "RenderType"="Opaque" }

		Tags
		{
			"SplatCount" = "4"
			"Queue" = "Geometry-100"
			"RenderType" = "Opaque"
		}

        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 4.0

        sampler2D _MainTex;
		sampler2D _Control;
		sampler2D _Splat0, _Splat1, _Splat2, _Splat3;
		sampler2D _Side, _Top, _Sand, _SandNormal;

        struct Input
        {
            float2 uv_MainTex;
			float2 uv_Control : TEXCOORD0;
			float2 uv_Splat0 : TEXCOORD1;
			float2 uv_Splat1 : TEXCOORD2;
			float2 uv_Splat2 : TEXCOORD3;
			float2 uv_Splat3 : TEXCOORD4;

			float3 worldPos;
			float3 worldNormal;
			float2 uv_BumpMap;
			float3 localCoord;
			float3 localNormal;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)


        void surf (Input IN, inout SurfaceOutputStandard o)
        {

			//use the normals of the terrain to choose which texture is rendered
			//everything below y 50 will be sand
			float3 y = 0;
			if (IN.worldPos.y < 50)
			{

				if (IN.worldNormal.y > .8f)
				{
					y = tex2D(_Sand, frac(IN.worldPos.zx * .02)) * abs(IN.worldNormal.y);
				}
				else if (IN.worldNormal.y < 1)
				{
					y = tex2D(_Side, frac(IN.worldPos.zx * .02)) * abs(IN.worldNormal.y);
				}
			}
			else if (IN.worldPos.y > 200)
			{
				if (IN.worldNormal.y > .8f)
				{
					y = tex2D(_Sand, frac(IN.worldPos.zx * .02)) * abs(IN.worldNormal.y);
				}
				else if (IN.worldNormal.y < 1)
				{
					y = tex2D(_Side, frac(IN.worldPos.zx * .02)) * abs(IN.worldNormal.y);
				}
			}
			else
			{

				if (IN.worldNormal.y > .8f)
				{
					y = tex2D(_Top, frac(IN.worldPos.zx * .02)) * abs(IN.worldNormal.y);
				}
				else if (IN.worldNormal.y < 1)
				{
					y = tex2D(_Side, frac(IN.worldPos.zx * .02)) * abs(IN.worldNormal.y);
				}
			}


			// Blending factor of triplanar mapping
			float3 bf = normalize(abs(IN.localNormal));
			bf /= dot(bf, (float3)1);

			// Triplanar mapping
			float2 tx = IN.localCoord.yz * 1;
			float2 ty = IN.localCoord.zx * 1;
			float2 tz = IN.localCoord.xy * 1;

			// Base color
			half4 cx = tex2D(_Side, tx) * bf.x;
			half4 cy = tex2D(_Top, ty) * bf.y;
			half4 cz = tex2D(_Sand, tz) * bf.z;
			half4 color = half4(y * _Color, 1.0f);




			fixed4 splat_control = tex2D(_Control, IN.uv_Control);

			fixed3 col;
			col =  splat_control.r * tex2D(_Splat0, IN.uv_Splat0).rgb;
			col += splat_control.g * tex2D(_Splat1, IN.uv_Splat1).rgb;
			col += splat_control.b * tex2D(_Splat2, IN.uv_Splat2).rgb;
			col += splat_control.a * tex2D(_Splat3, IN.uv_Splat3).rgb;

			half4 finalColour = half4(0,0,0,0);
			
			
			
			if (col.x > 0.6  || col.y > 0.6 || col.z > 0.6)
			{
				finalColour += lerp(color, half4(col, 1.0f), 1);
			}
			else finalColour += lerp(color, half4(col, 1.0f), 0);
			


			o.Albedo = saturate(finalColour);
			o.Alpha = color.a;

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;



        }
        ENDCG
    }
    FallBack "Diffuse"
}
