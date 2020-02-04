#if !defined(MY_TRIPLANAR_MAPPING_INCLUDED)
#define MY_TRIPLANAR_MAPPING_INCLUDED

#define NO_DEFAULT_UV

#include "My Lighting Input.cginc"

sampler2D _MOHSMap, _TopMOHSMap, _SandMOHSMap;
sampler2D _SandMainTex, _SandNormalMap;
sampler2D _TopMainTex, _TopNormalMap;
sampler2D _Control;

float _MapScale;

float _BlendOffset, _BlendExponent, _BlendHeightStrength;


UNITY_DECLARE_TEX2D(splat0);
UNITY_DECLARE_TEX2D_NOSAMPLER(splat01);
UNITY_DECLARE_TEX2D_NOSAMPLER(splat02);
UNITY_DECLARE_TEX2D_NOSAMPLER(splat03);
UNITY_DECLARE_TEX2D_NOSAMPLER(splat04);


float2 uv_Control : TEXCOORD0;
float2 uv_Splat0  : TEXCOORD1;
float2 uv_Splat1  : TEXCOORD2;
float2 uv_Splat2  : TEXCOORD3;
float2 uv_Splat3  : TEXCOORD4;


struct TriplanarUV 
{
	float2 x, y, z;
};

TriplanarUV GetTriplanarUV (SurfaceParameters parameters)
{
	TriplanarUV triUV;
	float3 p = parameters.position * _MapScale;
	triUV.x = p.zy;
	triUV.y = p.xz;
	triUV.z = p.xy;
	if (parameters.normal.x < 0) 
	{
		triUV.x.x = -triUV.x.x;
	}
	if (parameters.normal.y < 0) 
	{
		triUV.y.x = -triUV.y.x;
	}
	if (parameters.normal.z >= 0) 
	{
		triUV.z.x = -triUV.z.x;
	}
	triUV.x.y += 0.5;
	triUV.z.x += 0.5;
	return triUV;
}

float3 GetTriplanarWeights ( SurfaceParameters parameters, float heightX, float heightY, float heightZ) 
{
	float3 triW = abs(parameters.normal);
	triW = saturate(triW - _BlendOffset);
	triW *= lerp(1, float3(heightX, heightY, heightZ), _BlendHeightStrength);
	triW = pow(triW, _BlendExponent);
	return triW / (triW.x + triW.y + triW.z);
}

float3 BlendTriplanarNormal (float3 mappedNormal, float3 surfaceNormal) 
{
	float3 n;
	n.xy = mappedNormal.xy + surfaceNormal.xy;
	n.z = mappedNormal.z * surfaceNormal.z;
	return n;
}

void MyTriPlanarSurfaceFunction (inout SurfaceData surface, SurfaceParameters parameters) 
{
	TriplanarUV triUV = GetTriplanarUV(parameters);
	



	float3 albedoX = float3(0,0,0);
	float3 albedoY = float3(0,0,0);
	float3 albedoZ = float3(0,0,0);

	float4 mohsX = float4(0,0,0,0);
	float4 mohsY = float4(0,0,0,0);
	float4 mohsZ = float4(0,0,0,0);

	float3 tangentNormalX = float3(0,0,0);
	float4 rawNormalY = float4(0,0,0,0);
	float3 tangentNormalZ = float3(0,0,0);



	if (parameters.normal.y > .8f)	//top surface
	{
		if (parameters.position.y < 35)		//sand
		{
			albedoX = tex2D(_SandMainTex, triUV.x).rgb;
			albedoY = tex2D(_SandMainTex, triUV.y).rgb;
			albedoZ = tex2D(_SandMainTex, triUV.z).rgb;

			mohsX = tex2D(_SandMOHSMap, triUV.x);
			mohsY = tex2D(_SandMOHSMap, triUV.y);
			mohsZ = tex2D(_SandMOHSMap, triUV.z);

			tangentNormalX = UnpackNormal(tex2D(_SandNormalMap, triUV.x));
			rawNormalY = tex2D(_SandNormalMap, triUV.y);
			tangentNormalZ = UnpackNormal(tex2D(_SandNormalMap, triUV.z));
		}
		else  //grass
		{
			albedoX = tex2D(_TopMainTex, triUV.x).rgb;
			albedoY = tex2D(_TopMainTex, triUV.y).rgb;
			albedoZ = tex2D(_TopMainTex, triUV.z).rgb;

			mohsX = tex2D(_MOHSMap, triUV.x);
			mohsY = tex2D(_MOHSMap, triUV.y);
			mohsZ = tex2D(_MOHSMap, triUV.z);

			tangentNormalX = UnpackNormal(tex2D(_TopNormalMap, triUV.x));
			rawNormalY					= tex2D(_TopNormalMap, triUV.y);
			tangentNormalZ = UnpackNormal(tex2D(_TopNormalMap, triUV.z));
		}
	}
	else //side  //rock
	{

		albedoX = tex2D(_MainTex, triUV.x).rgb;
		albedoY = tex2D(_MainTex, triUV.y).rgb;
		albedoZ = tex2D(_MainTex, triUV.z).rgb;

		mohsX = tex2D(_MOHSMap, triUV.x);
		mohsY = tex2D(_MOHSMap, triUV.y);
		mohsZ = tex2D(_MOHSMap, triUV.z);

		tangentNormalX = UnpackNormal(tex2D(_NormalMap, triUV.x));
		rawNormalY = tex2D(_NormalMap, triUV.y);
		tangentNormalZ = UnpackNormal(tex2D(_NormalMap, triUV.z));
	}

	
	float3 tangentNormalY = UnpackNormal(rawNormalY);

	if (parameters.normal.x < 0) 
	{
		tangentNormalX.x = -tangentNormalX.x;
	}
	if (parameters.normal.y < 0) 
	{
		tangentNormalY.x = -tangentNormalY.x;
	}
	if (parameters.normal.z >= 0) 
	{
		tangentNormalZ.x = -tangentNormalZ.x;
	}

	float3 worldNormalX = BlendTriplanarNormal(tangentNormalX, parameters.normal.zyx).zyx;
	float3 worldNormalY = BlendTriplanarNormal(tangentNormalY, parameters.normal.xzy).xzy;
	float3 worldNormalZ = BlendTriplanarNormal(tangentNormalZ, parameters.normal);

	float3 triW = GetTriplanarWeights(parameters, mohsX.z, mohsY.z, mohsZ.z);

	


	fixed4 splat_control = UNITY_SAMPLE_TEX2D(splat0, uv_Control);

	fixed4 col = fixed4(0, 0, 0, 0);
	col += splat_control.r * UNITY_SAMPLE_TEX2D(splat0, uv_Splat0);
	col += splat_control.g * UNITY_SAMPLE_TEX2D_SAMPLER(splat01, splat0, uv_Splat1);
	col += splat_control.b * UNITY_SAMPLE_TEX2D_SAMPLER(splat02, splat0, uv_Splat2);
	col += splat_control.a * UNITY_SAMPLE_TEX2D_SAMPLER(splat03, splat0, uv_Splat3);




	half4 finalColour = half4(0, 0, 0, 0);
	half4 color = half4(albedoX * triW.x + albedoY * triW.y + albedoZ * triW.z,1);

	if (col.x > 0.4 || col.y > 0.4 || col.z > 0.4)
	{
		finalColour += col;
	}
	else finalColour += saturate(color);







	surface.albedo		= col;
	surface.metallic	= 0;
	surface.occlusion	= 0;
	surface.smoothness	= 0;
	surface.normal = normalize(worldNormalX * triW.x + worldNormalY * triW.y + worldNormalZ * triW.z);



	//float4 mohs = mohsX * triW.x + mohsY * triW.y + mohsZ * triW.z;
	//surface.metallic = mohs.x;
	//surface.occlusion = mohs.y;
	//surface.smoothness = mohs.a;


}

#define SURFACE_FUNCTION MyTriPlanarSurfaceFunction

#endif