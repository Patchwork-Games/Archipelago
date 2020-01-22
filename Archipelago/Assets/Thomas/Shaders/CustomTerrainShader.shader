	Shader "CustomTerrainShader" {

	Properties{

		  _Side("SideFail", 2D) = "white" {}
		  _Top("Top", 2D) = "white" {}

		  _Sand("Sand", 2D) = "white" {}
		  _SandNormal("SandNormal", 2D) = "bump" {}

		  _Bottom("Side", 2D) = "white" {}

		  _SideScale("Side Scale", Float) = 2
		  _SandScale("Sand Scale", Float) = 2
		  _TopScale("Top Scale", Float) = 2
		  _BottomScale("Bottom Scale", Float) = 2

		  _TopAngle("Top Angle", Float) = 0.8
		  _SideAngle("Side Angle", Float) = 0.5

		  //splat map control texture
		  [HideInInspector] _Control("Control (RGBA)", 2D) = "red" {}

		  //textures
		  [HideInInspector] _Splat3("Layer 3 (A)", 2D) = "white" {}
		  [HideInInspector] _Splat2("Layer 3 (B)", 2D) = "white" {}
		  [HideInInspector] _Splat1("Layer 3 (G)", 2D) = "white" {}
		  [HideInInspector] _Splat0("Layer 3 (R)", 2D) = "white" {}

		  //normal maps
		  [HideInInspector] _Normal3("Normal 3 (A)", 2D) = "bump" {}
		  [HideInInspector] _Normal2("Normal 3 (B)", 2D) = "bump" {}
		  [HideInInspector] _Normal1("Normal 3 (G)", 2D) = "bump" {}
		  [HideInInspector] _Normal0("Normal 3 (R)", 2D) = "bump" {}


		  _MainTex("Texture", any) = "" {}

	}

	SubShader{

		Tags 
		{

			"Queue" = "Geometry"

			"IgnoreProjector" = "False"

			"RenderType" = "Opaque"

		}

		ZTest Always Cull Off ZWrite Off

		CGINCLUDE

		#include "UnityCG.cginc"
		#include "TerrainTool.cginc"

		sampler2D _MainTex;
		float4 _MainTex_TexelSize;

		sampler2D _BrushTex;
		sampler2D _FilterTex;

		float4 _BrushParams;
		#define BRUSH_STRENGTH      (_BrushParams[0])
		#define BRUSH_TARGETHEIGHT  (_BrushParams[1])

		struct appdata_t 
		{
			float4 vertex : POSITION;
			float2 pcUV : TEXCOORD0;
		};

		struct v2f 
		{
			float4 vertex : SV_POSITION;
			float2 pcUV : TEXCOORD0;
		};

		v2f vert(appdata_t v)
		{
			v2f o;
			o.vertex = UnityObjectToClipPos(v.vertex);
			o.pcUV = v.pcUV;
			return o;
		}
		ENDCG

		//Cull Back

		//ZWrite On



		Pass    // 0 paint splat alphamap
		{
			Name "Paint splat texture"

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment PaintSplatAlphamap

			float ApplyBrush(float height, float brushStrength)
			{
				float targetHeight = 1.0f;
				if (targetHeight > height)
				{
					height += brushStrength;
					height = height < targetHeight ? height : targetHeight;
				}
				else
				{
					height -= brushStrength;
					height = height > targetHeight ? height : targetHeight;
				}
				return height;
			}

			float4 PaintSplatAlphamap(v2f i) : SV_Target
			{
				float2 brushUV = PaintContextUVToBrushUV(i.pcUV);
				float2 normalUV = PaintContextUVToBrushUV(i.pcUV);

				// out of bounds multiplier
				float oob = all(saturate(brushUV) == brushUV) ? 1.0f : 0.0f;

				float brushStrength = BRUSH_STRENGTH * oob * UnpackHeightmap(tex2D(_FilterTex, i.pcUV)) * UnpackHeightmap(tex2D(_BrushTex, brushUV.xy));
				float splatMap = tex2D(_MainTex, i.pcUV).r;
				float targetAlpha = BRUSH_TARGETHEIGHT;

				return lerp(splatMap, targetAlpha, brushStrength);
			}

			ENDCG
		}



































		//CGPROGRAM

		//#pragma surface surf Lambert

		//#pragma exclude_renderers flash
		//

		//sampler2D _Side, _Top, _Bottom, _Sand, _SandNormal;

		//float _SideScale, _TopScale, _SandScale, _BottomScale, _SideAngle, _TopAngle;
		//

		//sampler _Control;

		//struct Input {

		//	float3 worldPos;
		//	float3 worldNormal;
		//	float2 uv_BumpMap;
		//	float2 uv_Control;
		//};

		//fixed4 _Color;

		//half4 SplitMap(half4 map)
		//{
		//	map.r = step(0.1, map.r - map.g - map.b - map.a);
		//	map.r = step(0.1, map.g - map.r - map.b - map.a);
		//	map.r = step(0.1, map.b - map.g - map.r - map.a);
		//	map.r = step(0.1, map.a - map.g - map.b - map.r);
		//	return map;
		//}

		//void surf(Input IN, inout SurfaceOutput o) {

		//	float3 projNormal = saturate(pow(IN.worldNormal * 1.4, 4));



		//	fixed4 c = tex2D(_Control, IN.uv_Control) * _Color;


		//	float3 x = 0;
		//	// SIDE X
		//	if (IN.worldNormal.z > _SideAngle) 
		//	{
		//		x = tex2D(_Side, frac(IN.worldPos.zy * _SideScale)) * abs(IN.worldNormal.x);

		//	}
		//	else 
		//	{
		//		x = tex2D(_Top, frac(IN.worldPos.zy * _SideScale)) * abs(IN.worldNormal.x);
		//	}

		//	//Sand
		//	float3 y = 0;
		//	if (IN.worldPos.y < 50)
		//	{
		//		
		//		if (IN.worldNormal.y > _TopAngle)
		//		{
		//			y = tex2D(_Sand, frac(IN.worldPos.zx * _TopScale)) * abs(IN.worldNormal.y);
		//		}
		//		else
		//		{
		//			y = tex2D(_Bottom, frac(IN.worldPos.zx * _BottomScale)) * abs(IN.worldNormal.y);
		//		}
		//	}
		//	else
		//	{
		//		
		//		if (IN.worldNormal.y > _TopAngle)
		//		{
		//			y = tex2D(_Top, frac(IN.worldPos.zx * _TopScale)) * abs(IN.worldNormal.y);
		//		}
		//		else
		//		{
		//			y = tex2D(_Bottom, frac(IN.worldPos.zx * _BottomScale)) * abs(IN.worldNormal.y);
		//		}
		//	}


		//	// SIDE Z	

		//	float3 z = tex2D(_Side, frac(IN.worldPos.xy * _SideScale)) * abs(IN.worldNormal.z);


		//	//o.Albedo = z;

		//	//o.Albedo = saturate(z, x);// lerp(o.Albedo, x, projNormal.x);

		//	//o.Albedo = saturate(o.Albedo, y);// lerp(o.Albedo, y, projNormal.y);

		//	o.Albedo += y;

		//	//o.Albedo = saturate(y);// saturate(y);// saturate(finalColour);

		//	//o.Normal = UnpackNormal(tex2D (_SandNormal, IN.uv_BumpMap));

		//}
		//ENDCG
	}
	Fallback "Diffuse"

}