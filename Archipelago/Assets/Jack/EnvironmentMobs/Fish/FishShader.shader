Shader "Custom/Fish/UnlitFishShader"
{
	Properties
	{
		_AlbedoMap("Albedo", 2D) = "white" {}
		_NormalMap("NormalMap", 2D) = "white" {}
		_MetallicMap("MetallicMap", 2D) = "white" {}
		_TintColour("Tint Colour", Color) = (0,1,1,1)

		_Amplitude("Amplitude", Float) = 1
		_Wavelength("WaveLength", Float) = 10
		_Speed("Speed", Float) = 5
	}
	SubShader
	{
		Tags {"Queue" = "Geometry" "IgnoreProjector" = "True" }
		LOD 100

		//Culling off so that the material can be seen on both sides of the mesh.
		Cull Off

		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha

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

			sampler2D _AlbedoMap;
			sampler2D _NormalMap;
			sampler2D _MetallicMap;
			float4 _AlbedoMap_ST;


			float _Amplitude, _Wavelength, _Speed;


			
			v2f vert (appdata v)
			{

				v2f o;
				o.uv = TRANSFORM_TEX(v.uv, _AlbedoMap);


				float k = 2 * UNITY_PI / _Wavelength;
				v.vertex.x += _Amplitude * sin(k * (v.vertex.z / 2 + _Speed * _Time.x));

				o.vertex = UnityObjectToClipPos(v.vertex);
				
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 _TintColour;
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 maskSample = tex2D(_AlbedoMap, i.uv);
				fixed3 tintedFish = _TintColour.rgb * maskSample.rgb;
				fixed4 col = fixed4(0,0,0,1) + fixed4(tintedFish, 0);
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
