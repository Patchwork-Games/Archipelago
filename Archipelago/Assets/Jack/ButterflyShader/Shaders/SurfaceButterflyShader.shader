Shader "Custom/Butterfly/SurfaceButterflyShader" {
	Properties {
		_MaskTexture("Mask Texture", 2D) = "white" {}
		_TintColour("Tint Colour", Color) = (0,1,1,1)
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_WingAmplitude("Wing Beat Amplitude", Float) = 7
		_WingSpeed("Wing Beat Speed", Float) = 240
		_WingSpanModifier("Wing Span Modifer", Float) = 1
		
	}
	SubShader {
		Tags {"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
		LOD 100

		//Culling off so that the material can be seen on both sides of the mesh.
		Cull Off

		ZWrite On

		CGPROGRAM
		#pragma surface surf Standard vertex:vert addshadow fullforwardshadows alpha:fade

		#pragma target 3.0

		sampler2D _MaskTexture;

		struct Input {
			float2 uv_MaskTexture;
		};

		float _WingAmplitude;
		float _WingSpeed;
		float _WingSpanModifier;

		void vert(inout appdata_full v, out Input o) {
			UNITY_INITIALIZE_OUTPUT(Input, o);
			float wingBeatValue = sin(_Time.x * _WingSpeed) * _WingAmplitude * abs(sign((o.uv_MaskTexture.x * 2) - 1));
			v.vertex.y *= wingBeatValue;
			v.vertex.x *= _WingSpanModifier;
		}

		half _Glossiness;
		half _Metallic;
		fixed4 _TintColour;

		void surf (Input IN, inout SurfaceOutputStandard o) {

			o.Albedo = fixed3(0, 0, 0);

			fixed4 maskSample = tex2D(_MaskTexture, IN.uv_MaskTexture);
			fixed3 tintedWings = maskSample.r * _TintColour.rgb * maskSample.b;
			fixed3 col = tintedWings;
			
			o.Emission = col;

			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = maskSample.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
