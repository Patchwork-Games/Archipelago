Shader "Custom/OceanShader"
{
    Properties
    {
        _WaterColor ("Water Color", Color) = (1,1,1,1)
		_FresnelWaterColor("Fresnel water Color", Color) = (1,1,1,1)
		[PowerSlider(4)] _FresnelWaterColorExponent("Fresnel Water Color Exponent", Range(0.25, 4)) = 1

        _OceanFoamTex ("Ocean Foam Texture", 2D) = "white" {}
		_OceanFoamTexScale("Ocean Foam Texture Scale", Float) = 1
		_OceanFoamColor("Ocean Foam Color", Color) = (1,1,1,1)
		_OceanFoamDistortion("Ocean Foam Distortion (Speed, Amplitude, Frequency, 0)", Vector) = (1,1,1,1)

		_WaveA("Wave A (dir, steepness, wavelength)", Vector) = (1,0,0.5,10)
		_WaveB("Wave B", Vector) = (0,1,0.25,20)
		_WaveC("Wave C", Vector) = (1,1,0.15,10)
		_WaveSpeed("Wave Speed", Float) = 1

		_WaterFogColor("Water Fog Color", Color) = (0, 0, 0, 0)
		_WaterFogDensity("Water Fog Density", Range(0, 2)) = 0.1
		_RefractionStrength("Refraction Strength", Range(0, 1)) = 0.25

		_DepthMaxDistance("Depth Maximum Distance", Float) = 1
		_SurfaceNoise("Surface Noise", 2D) = "white" {}
		_SurfaceNoiseScale("Surface NoiseScale", Float) = 1
		_SurfaceNoiseCutoff("Surface Noise Cutoff", Range(0, 1)) = 0.777
		_FoamMaxDistance("Foam Maximum Distance", Float) = 0.4
		_FoamMinDistance("Foam Minimum Distance", Float) = 0.04
		_SurfaceNoiseScroll("Surface Noise Scroll Amount", Vector) = (0.03, 0.03, 0, 0)
		_SurfaceDistortion("Surface Distortion", 2D) = "white" {}
		_SurfaceDistortionAmount("Surface Distortion Amount", Range(0, 1)) = 0.27

        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags 
		{
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
        LOD 200

		GrabPass { "_WaterBackground" }

		Blend SrcAlpha OneMinusSrcAlpha
		ZWrite Off

        CGPROGRAM
		#define SMOOTHSTEP_AA 0.01

		#pragma surface surf Standard alpha finalcolor:ResetAlpha vertex:vert  // Physically based Standard lighting model, and enable shadows on all light types
        #pragma target 3.0 // Use shader model 3.0 target, to get nicer looking lighting

		#include "UnityCG.cginc"
		#include "LookingThroughWater.cginc"

        sampler2D _OceanFoamTex;

		float4 alphaBlend(float4 top, float4 bottom)
		{
			float3 color = (top.rgb * top.a) + (bottom.rgb * (1 - top.a));
			float alpha = top.a + bottom.a * (1 - top.a);

			return float4(color, alpha);
		}

        struct Input
        {
            float2 uv_OceanFoamTex;
			float3 worldPos;
			float3 worldNormal;
			float3 viewDir;
			float4 screenPos;
			float2 noiseUV;
			float2 distortUV;
			float3 viewNormal;
			INTERNAL_DATA
        };

        half _Glossiness;
        half _Metallic;
		half _OceanFoamTexScale;
		float4 _OceanFoamDistortion;
		float4 _WaveA, _WaveB, _WaveC;
		float _WaveSpeed;
		float4 _FresnelWaterColor;
		float _FresnelWaterColorExponent;
		float _DepthMaxDistance;
		float _SurfaceNoiseCutoff;
		float _FoamMaxDistance;
		float _FoamMinDistance;
		float2 _SurfaceNoiseScroll;
		float _SurfaceNoiseScale;
		fixed4 _WaterColor;
		fixed4 _OceanFoamColor;

		void ResetAlpha(Input IN, SurfaceOutputStandard o, inout fixed4 color)
		{
			color.a = 1;
		}

		float3 GerstnerWave(float4 wave, float3 p, inout float3 tangent, inout float3 binormal)
		{
			float steepness = wave.z;
			float wavelength = wave.w;
			float k = 2 * UNITY_PI / wavelength;
			float c = sqrt(_WaveSpeed / k);
			float2 d = normalize(wave.xy);
			float f = k * (dot(d, p.xz) - c * _Time.y);
			float a = steepness / k;

			tangent += float3(
				-d.x * d.x * (steepness * sin(f)),
				d.x * (steepness * cos(f)),
				-d.x * d.y * (steepness * sin(f))
				);
			binormal += float3(
				-d.x * d.y * (steepness * sin(f)),
				d.y * (steepness * cos(f)),
				-d.y * d.y * (steepness * sin(f))
				);
			return float3(
				d.x * (a * cos(f)),
				a * sin(f),
				d.y * (a * cos(f))
				);
		}

		sampler2D _SurfaceNoise;
		float4 _SurfaceNoise_ST;

		sampler2D _SurfaceDistortion;
		float4 _SurfaceDistortion_ST;

		float _SurfaceDistortionAmount;

		void vert(inout appdata_full v, out Input o)
		{
			// Initialise the output to the fragment shader
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.noiseUV = TRANSFORM_TEX(v.texcoord.xy, _SurfaceNoise);
			o.distortUV = TRANSFORM_TEX(v.texcoord.xy, _SurfaceDistortion);
			o.viewNormal = COMPUTE_VIEW_NORMAL;

			float3 gridPoint = v.vertex.xyz;
			float3 tangent = float3(1, 0, 0);
			float3 binormal = float3(0, 0, 1);
			float3 p = gridPoint;

			p += GerstnerWave(_WaveA, gridPoint, tangent, binormal);
			p += GerstnerWave(_WaveB, gridPoint, tangent, binormal);
			p += GerstnerWave(_WaveC, gridPoint, tangent, binormal);

			float3 normal = normalize(cross(binormal, tangent));
			v.vertex.xyz = p;
			v.normal = normal;
		}

		sampler2D _CameraNormalsTexture;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Sample the ocean foam texture with distorted world position UVs
			float waveLength = 1 / (6.28 * _OceanFoamDistortion.z);
			float2 oceanFoamUVs = IN.worldPos.xz * _OceanFoamTexScale;
			float2 distortedOceanFoamUVs = _OceanFoamDistortion.y * sin((oceanFoamUVs.x / waveLength) + (_Time.y * _OceanFoamDistortion.x)) + _OceanFoamDistortion.y * sin((oceanFoamUVs.y / waveLength) + (_Time.y * _OceanFoamDistortion.x));
			float4 texColor = tex2D(_OceanFoamTex, oceanFoamUVs + distortedOceanFoamUVs) * _OceanFoamColor;

			// Apply fresnel lerping of colours
			float fresnel = dot(IN.worldNormal, IN.viewDir);
			fresnel = saturate(1 - fresnel);
			fresnel = pow(fresnel, _FresnelWaterColorExponent);
			float3 fresnelColour = fresnel * _FresnelWaterColor;
			float4 combinedWaterColor = lerp(_WaterColor, _FresnelWaterColor, fresnel);

			// Depth color
			float existingDepth01 = tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(IN.screenPos)).r;
			float existingDepthLinear = LinearEyeDepth(existingDepth01);
			float depthDifference = existingDepthLinear - IN.screenPos.w;
			float waterDepthDifference01 = saturate(depthDifference / _DepthMaxDistance);
			float4 waterColor = lerp(_WaterColor, _WaterFogColor, waterDepthDifference01);

			// Edge foam
			//float2 distortSample = (tex2D(_SurfaceDistortion, IN.distortUV).xy * 2 - 1) * _SurfaceDistortionAmount;
			//float2 noiseUV = float2((IN.worldPos.x + _Time.y * _SurfaceNoiseScroll.x) + distortSample.x, (IN.worldPos.y + _Time.y * _SurfaceNoiseScroll.y) + distortSample.y) * _SurfaceNoiseScale;
			float2 noiseUV = float2((IN.noiseUV.x + _Time.y * _SurfaceNoiseScroll.x), (IN.noiseUV.y + _Time.y * _SurfaceNoiseScroll.y)) * _SurfaceNoiseScale;


			float surfaceNoiseSample = tex2D(_SurfaceNoise, noiseUV).r;
			float3 existingNormal = tex2Dproj(_CameraNormalsTexture, UNITY_PROJ_COORD(IN.screenPos));
			float3 normalDot = saturate(dot(existingNormal, IN.viewNormal));
			float foamDistance = lerp(_FoamMaxDistance, _FoamMinDistance, normalDot);
			float foamDepthDifference01 = saturate(depthDifference / foamDistance);
			float surfaceNoiseCutoff = foamDepthDifference01 * _SurfaceNoiseCutoff;
			float surfaceNoise = smoothstep(surfaceNoiseCutoff - SMOOTHSTEP_AA, surfaceNoiseCutoff + SMOOTHSTEP_AA, surfaceNoiseSample);
			float4 surfaceNoiseColor = _OceanFoamColor;
			surfaceNoiseColor.a *= surfaceNoise;
			
			// Final color
			texColor = saturate(texColor + alphaBlend(surfaceNoiseColor, combinedWaterColor));
			fixed4 c = texColor;
            o.Albedo = c.rgb;

			//o.Albedo = texColor + surfaceNoiseColor;

			// Calculate the foam for edges of objects
			float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, IN.uv_OceanFoamTex);
			depth = Linear01Depth(depth);
			depth * unity_CameraWorldClipPlanes[5];

			o.Emission = ColorBelowWater(IN.screenPos, o.Normal) * (1 - c.a);

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
}
