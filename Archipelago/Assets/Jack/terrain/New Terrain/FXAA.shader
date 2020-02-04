Shader "Hidden/FXAA" 
{
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
	}

	CGINCLUDE
		#include "UnityCG.cginc"

		sampler2D _MainTex;
		float4 _MainTex_TexelSize;

		struct VertexData 
		{
			float4 vertex : POSITION;
			float2 uv : TEXCOORD0;
		};

		struct Interpolators 
		{
			float4 pos : SV_POSITION;
			float2 uv : TEXCOORD0;
		};

		Interpolators VertexProgram (VertexData v) 
		{
			Interpolators i;
			i.pos = UnityObjectToClipPos(v.vertex);
			i.uv = v.uv;
			return i;
		}

		float4 Sample (float2 uv) 
		{
			return tex2D(_MainTex, uv);
		}

		float SampleLuminance (float2 uv) 
		{
			#if defined(LUMINANCE_GREEN)
				return Sample(uv).g;
			#else
				return Sample(uv).a;
			#endif
		}

		float SampleLuminance (float2 uv, float uOffset, float vOffset) 
		{
			uv += _MainTex_TexelSize * float2(uOffset, vOffset);
			return SampleLuminance(uv);
		}

		float4 ApplyFXAA (float2 uv) 
		{
			return SampleLuminance(uv);
		}
	ENDCG

	SubShader {
		Cull Off
		ZTest Always
		ZWrite Off

		Pass  // 0 luminancePass
		{
			CGPROGRAM
				#pragma vertex VertexProgram
				#pragma fragment FragmentProgram
	
				float4 FragmentProgram (Interpolators i) : SV_Target 
				{
					float4 sample = tex2D(_MainTex, i.uv);
					sample.a = LinearRgbToLuminance(saturate(sample.rgb));
					return sample;
				}
			ENDCG
		}

		Pass // 1 fxaaPass
		{ 
			CGPROGRAM
				#pragma vertex VertexProgram
				#pragma fragment FragmentProgram

				#pragma multi_compile _ LUMINANCE_GREEN

				float4 FragmentProgram (Interpolators i) : SV_Target 
				{
					return ApplyFXAA(i.uv);
				}
			ENDCG
		}
	}
}