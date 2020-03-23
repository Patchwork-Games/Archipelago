Shader "Custom/Fish/UnlitFishShader"
{
	Properties
	{
		_AlbedoMap("Albedo", 2D) = "white" {}
		_NormalMap("NormalMap", 2D) = "white" {}
		_MetallicMap("MetallicMap", 2D) = "white" {}
		_TintColour("Tint Colour", Color) = (0,1,1,1)

		_WingAmplitude("Wing Beat Amplitude", Float) = 7
		_WingSpeed("Wing Beat Speed", Float) = 240
		_WingSpanModifier("Wing Span Modifer", Float) = 1
	}
	SubShader
	{
		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
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

			sampler2D _MaskTexture;
			float4 _MaskTexture_ST;

			float _WingAmplitude;
			float _WingSpeed;
			float _WingSpanModifier;
			
			v2f vert (appdata v)
			{

				v2f o;
				o.uv = TRANSFORM_TEX(v.uv, _MaskTexture);

				float wingBeatValue = sin(_Time.x * _WingSpeed) * _WingAmplitude * abs((v.uv.x * 2)-1);
				v.vertex.y *= wingBeatValue;
				v.vertex.x *= _WingSpanModifier;

				o.vertex = UnityObjectToClipPos(v.vertex);
				
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 _TintColour;
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 maskSample = tex2D(_MaskTexture, i.uv);
				fixed3 tintedWings = maskSample.r * _TintColour.rgb * maskSample.b;
				fixed4 col = fixed4(0,0,0,1) + fixed4(tintedWings, 0);
				col.a *= maskSample.a;
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
