// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:False,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-2306-OUT,spec-358-OUT,gloss-1813-OUT,voffset-1880-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:32245,y:32316,ptovrint:False,ptlb:ColourB,ptin:_ColourB,varname:_ColourB,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.05882353,c3:0.6235294,c4:1;n:type:ShaderForge.SFN_Slider,id:358,x:32250,y:32780,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:_Metallic,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32250,y:32882,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Color,id:2279,x:32245,y:32105,ptovrint:False,ptlb:ColourA,ptin:_ColourA,varname:_ColourA,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.0509804,c2:1,c3:0.9803922,c4:1;n:type:ShaderForge.SFN_Fresnel,id:1948,x:32245,y:32484,varname:node_1948,prsc:2|EXP-6212-OUT;n:type:ShaderForge.SFN_Vector1,id:6212,x:32083,y:32504,varname:node_6212,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:2306,x:32475,y:32232,varname:node_2306,prsc:2|A-2279-RGB,B-6665-RGB,T-1948-OUT;n:type:ShaderForge.SFN_Vector4Property,id:3545,x:31102,y:33151,ptovrint:False,ptlb:Wave 1 Direction,ptin:_Wave1Direction,varname:_Wave1Direction,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_FragmentPosition,id:6575,x:31102,y:33317,varname:node_6575,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:3561,x:31265,y:33317,varname:node_3561,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6575-XYZ;n:type:ShaderForge.SFN_Append,id:4955,x:31265,y:33171,varname:node_4955,prsc:2|A-3545-X,B-3545-Y;n:type:ShaderForge.SFN_Dot,id:5168,x:31483,y:33171,varname:node_5168,prsc:2,dt:0|A-4955-OUT,B-3561-OUT;n:type:ShaderForge.SFN_Code,id:1880,x:31752,y:33074,varname:node_1880,prsc:2,code:ZgBsAG8AYQB0ACAAcABoAGEAcwBlAEMAbwBuAHMAdAAgAD0AIABTAHAAZQBlAGQAIAAqACAAVwBhAHYAZQBsAGUAbgBnAHQAaAA7AAoAZgBsAG8AYQB0ACAAeABWAGEAbAAgAD0AIABTAHQAZQBlAHAAbgBlAHMAcwAgACoAIABBAG0AcABsAGkAdAB1AGQAZQAgACoAIABEAGkAcgBlAGMAdABpAG8AbgBWAGUAYwAuAHgAIAAqACAAYwBvAHMAKABXAGEAdgBlAGwAZQBuAGcAdABoACAAKgAgAEQAbwB0AFAAcgBvAGQAIAArACAAVABpAG0AZQAgACoAIABwAGgAYQBzAGUAQwBvAG4AcwB0ACkAOwAKAGYAbABvAGEAdAAgAHkAVgBhAGwAIAA9ACAAQQBtAHAAbABpAHQAdQBkAGUAIAAqACAAcwBpAG4AKABXAGEAdgBlAGwAZQBuAGcAdABoACAAKgAgAEQAbwB0AFAAcgBvAGQAIAArACAAVABpAG0AZQAgACoAIABwAGgAYQBzAGUAQwBvAG4AcwB0ACkAOwAKAGYAbABvAGEAdAAgAHoAVgBhAGwAIAA9ACAAUwB0AGUAZQBwAG4AZQBzAHMAIAAqACAAQQBtAHAAbABpAHQAdQBkAGUAIAAqACAARABpAHIAZQBjAHQAaQBvAG4AVgBlAGMALgB5ACAAKgAgAGMAbwBzACgAVwBhAHYAZQBsAGUAbgBnAHQAaAAgACoAIABEAG8AdABQAHIAbwBkACAAKwAgAFQAaQBtAGUAIAAqACAAcABoAGEAcwBlAEMAbwBuAHMAdAApADsACgByAGUAdAB1AHIAbgAgAGYAbABvAGEAdAAzACgAeABWAGEAbAAsACAAeQBWAGEAbAAsACAAegBWAGEAbAApADsA,output:2,fname:GerstnersWave,width:811,height:188,input:0,input:0,input:0,input:0,input:0,input:0,input:1,input_1_label:Steepness,input_2_label:Amplitude,input_3_label:Wavelength,input_4_label:Speed,input_5_label:Time,input_6_label:DotProd,input_7_label:DirectionVec|A-1051-OUT,B-4928-OUT,C-4878-OUT,D-9254-OUT,E-6742-OUT,F-5168-OUT,G-4955-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1655,x:31102,y:32836,ptovrint:False,ptlb:Wave Steepness,ptin:_WaveSteepness,varname:_WaveSharpness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:5669,x:31102,y:32912,ptovrint:False,ptlb:Wave Height,ptin:_WaveHeight,varname:node_5669,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:4706,x:31466,y:33961,ptovrint:False,ptlb:Sway Frequency,ptin:_SwayFrequency,varname:node_4706,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tau,id:7840,x:31499,y:34028,varname:node_7840,prsc:2;n:type:ShaderForge.SFN_Time,id:7423,x:31466,y:34141,varname:node_7423,prsc:2;n:type:ShaderForge.SFN_Slider,id:2373,x:31738,y:34059,ptovrint:False,ptlb:Sway Intensity,ptin:_SwayIntensity,varname:node_2373,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:24,x:31724,y:34129,varname:node_24,prsc:2|A-4706-OUT,B-7840-OUT,C-7423-T;n:type:ShaderForge.SFN_Sin,id:8947,x:31895,y:34129,varname:node_8947,prsc:2|IN-24-OUT;n:type:ShaderForge.SFN_Multiply,id:2854,x:32066,y:34129,varname:node_2854,prsc:2|A-2373-OUT,B-8947-OUT;n:type:ShaderForge.SFN_Add,id:8336,x:32251,y:34129,varname:node_8336,prsc:2|A-2854-OUT,B-7423-T;n:type:ShaderForge.SFN_Set,id:8412,x:32421,y:34129,varname:TimeSway,prsc:2|IN-8336-OUT;n:type:ShaderForge.SFN_Get,id:6742,x:31462,y:33109,varname:node_6742,prsc:2|IN-8412-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2439,x:31102,y:32988,ptovrint:False,ptlb:Wavelength,ptin:_Wavelength,varname:node_2439,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:7432,x:31102,y:33072,ptovrint:False,ptlb:Wave Speed,ptin:_WaveSpeed,varname:node_7432,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Set,id:7622,x:31257,y:33072,varname:WaveSpeed,prsc:2|IN-7432-OUT;n:type:ShaderForge.SFN_Set,id:4931,x:31257,y:32988,varname:Wavelength,prsc:2|IN-2439-OUT;n:type:ShaderForge.SFN_Set,id:9991,x:31257,y:32912,varname:WaveHeight,prsc:2|IN-5669-OUT;n:type:ShaderForge.SFN_Set,id:2432,x:31257,y:32836,varname:WaveSteepness,prsc:2|IN-1655-OUT;n:type:ShaderForge.SFN_Get,id:1051,x:31462,y:32912,varname:node_1051,prsc:2|IN-8412-OUT;n:type:ShaderForge.SFN_Get,id:4928,x:31462,y:32960,varname:node_4928,prsc:2|IN-9991-OUT;n:type:ShaderForge.SFN_Get,id:9254,x:31462,y:33057,varname:node_9254,prsc:2|IN-7622-OUT;n:type:ShaderForge.SFN_Get,id:4878,x:31462,y:33011,varname:node_4878,prsc:2|IN-4931-OUT;proporder:6665-358-1813-2279-3545-5669-4706-2373-2439-7432;pass:END;sub:END;*/

Shader "Shader Forge/ToonWater" {
    Properties {
        _ColourB ("ColourB", Color) = (0,0.05882353,0.6235294,1)
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _ColourA ("ColourA", Color) = (0.0509804,1,0.9803922,1)
        _Wave1Direction ("Wave 1 Direction", Vector) = (0,0,0,0)
        _WaveHeight ("Wave Height", Float ) = 1
        _SwayFrequency ("Sway Frequency", Float ) = 1
        _SwayIntensity ("Sway Intensity", Range(0, 1)) = 0
        _Wavelength ("Wavelength", Float ) = 1
        _WaveSpeed ("Wave Speed", Float ) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 d3d11_9x 
            #pragma target 3.0
            float3 GerstnersWave( float Steepness , float Amplitude , float Wavelength , float Speed , float Time , float DotProd , float2 DirectionVec ){
            float phaseConst = Speed * Wavelength;
            float xVal = Steepness * Amplitude * DirectionVec.x * cos(Wavelength * DotProd + Time * phaseConst);
            float yVal = Amplitude * sin(Wavelength * DotProd + Time * phaseConst);
            float zVal = Steepness * Amplitude * DirectionVec.y * cos(Wavelength * DotProd + Time * phaseConst);
            return float3(xVal, yVal, zVal);
            }
            
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourB)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourA)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Wave1Direction)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveHeight)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayFrequency)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wavelength)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                UNITY_FOG_COORDS(6)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                #ifdef LIGHTMAP_ON
                    o.ambientOrLightmapUV.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                    o.ambientOrLightmapUV.zw = 0;
                #elif UNITY_SHOULD_SAMPLE_SH
                #endif
                #ifdef DYNAMICLIGHTMAP_ON
                    o.ambientOrLightmapUV.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
                #endif
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float _SwayIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayIntensity );
                float _SwayFrequency_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayFrequency );
                float4 node_7423 = _Time;
                float TimeSway = ((_SwayIntensity_var*sin((_SwayFrequency_var*6.28318530718*node_7423.g)))+node_7423.g);
                float _WaveHeight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveHeight );
                float WaveHeight = _WaveHeight_var;
                float _Wavelength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wavelength );
                float Wavelength = _Wavelength_var;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float WaveSpeed = _WaveSpeed_var;
                float4 _Wave1Direction_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wave1Direction );
                float2 node_4955 = float2(_Wave1Direction_var.r,_Wave1Direction_var.g);
                v.vertex.xyz += GerstnersWave( TimeSway , WaveHeight , Wavelength , WaveSpeed , TimeSway , dot(node_4955,mul(unity_ObjectToWorld, v.vertex).rgb.r) , node_4955 );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float gloss = _Gloss_var;
                float perceptualRoughness = 1.0 - _Gloss_var;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                    d.ambient = 0;
                    d.lightmapUV = i.ambientOrLightmapUV;
                #else
                    d.ambient = i.ambientOrLightmapUV;
                #endif
                #if UNITY_SPECCUBE_BLENDING || UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMin[0] = unity_SpecCube0_BoxMin;
                    d.boxMin[1] = unity_SpecCube1_BoxMin;
                #endif
                #if UNITY_SPECCUBE_BOX_PROJECTION
                    d.boxMax[0] = unity_SpecCube0_BoxMax;
                    d.boxMax[1] = unity_SpecCube1_BoxMax;
                    d.probePosition[0] = unity_SpecCube0_ProbePosition;
                    d.probePosition[1] = unity_SpecCube1_ProbePosition;
                #endif
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                Unity_GlossyEnvironmentData ugls_en_data;
                ugls_en_data.roughness = 1.0 - gloss;
                ugls_en_data.reflUVW = viewReflectDirection;
                UnityGI gi = UnityGlobalIllumination(d, 1, normalDirection, ugls_en_data );
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float _Metallic_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic );
                float3 specularColor = _Metallic_var;
                float specularMonochrome;
                float4 _ColourA_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourA );
                float4 _ColourB_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourB );
                float3 diffuseColor = lerp(_ColourA_var.rgb,_ColourB_var.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                half surfaceReduction;
                #ifdef UNITY_COLORSPACE_GAMMA
                    surfaceReduction = 1.0-0.28*roughness*perceptualRoughness;
                #else
                    surfaceReduction = 1.0/(roughness*roughness + 1.0);
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                indirectSpecular *= surfaceReduction;
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += gi.indirect.diffuse;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 d3d11_9x 
            #pragma target 3.0
            float3 GerstnersWave( float Steepness , float Amplitude , float Wavelength , float Speed , float Time , float DotProd , float2 DirectionVec ){
            float phaseConst = Speed * Wavelength;
            float xVal = Steepness * Amplitude * DirectionVec.x * cos(Wavelength * DotProd + Time * phaseConst);
            float yVal = Amplitude * sin(Wavelength * DotProd + Time * phaseConst);
            float zVal = Steepness * Amplitude * DirectionVec.y * cos(Wavelength * DotProd + Time * phaseConst);
            return float3(xVal, yVal, zVal);
            }
            
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourB)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourA)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Wave1Direction)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveHeight)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayFrequency)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wavelength)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
                float3 tangentDir : TEXCOORD4;
                float3 bitangentDir : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float _SwayIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayIntensity );
                float _SwayFrequency_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayFrequency );
                float4 node_7423 = _Time;
                float TimeSway = ((_SwayIntensity_var*sin((_SwayFrequency_var*6.28318530718*node_7423.g)))+node_7423.g);
                float _WaveHeight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveHeight );
                float WaveHeight = _WaveHeight_var;
                float _Wavelength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wavelength );
                float Wavelength = _Wavelength_var;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float WaveSpeed = _WaveSpeed_var;
                float4 _Wave1Direction_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wave1Direction );
                float2 node_4955 = float2(_Wave1Direction_var.r,_Wave1Direction_var.g);
                v.vertex.xyz += GerstnersWave( TimeSway , WaveHeight , Wavelength , WaveSpeed , TimeSway , dot(node_4955,mul(unity_ObjectToWorld, v.vertex).rgb.r) , node_4955 );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float gloss = _Gloss_var;
                float perceptualRoughness = 1.0 - _Gloss_var;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float _Metallic_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic );
                float3 specularColor = _Metallic_var;
                float specularMonochrome;
                float4 _ColourA_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourA );
                float4 _ColourB_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourB );
                float3 diffuseColor = lerp(_ColourA_var.rgb,_ColourB_var.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0)); // Need this for specular when using metallic
                diffuseColor = DiffuseAndSpecularFromMetallic( diffuseColor, specularColor, specularColor, specularMonochrome );
                specularMonochrome = 1.0-specularMonochrome;
                float NdotV = abs(dot( normalDirection, viewDirection ));
                float NdotH = saturate(dot( normalDirection, halfDirection ));
                float VdotH = saturate(dot( viewDirection, halfDirection ));
                float visTerm = SmithJointGGXVisibilityTerm( NdotL, NdotV, roughness );
                float normTerm = GGXTerm(NdotH, roughness);
                float specularPBL = (visTerm*normTerm) * UNITY_PI;
                #ifdef UNITY_COLORSPACE_GAMMA
                    specularPBL = sqrt(max(1e-4h, specularPBL));
                #endif
                specularPBL = max(0, specularPBL * NdotL);
                #if defined(_SPECULARHIGHLIGHTS_OFF)
                    specularPBL = 0.0;
                #endif
                specularPBL *= any(specularColor) ? 1.0 : 0.0;
                float3 directSpecular = attenColor*specularPBL*FresnelTerm(specularColor, LdotH);
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float nlPow5 = Pow5(1-NdotL);
                float nvPow5 = Pow5(1-NdotV);
                float3 directDiffuse = ((1 +(fd90 - 1)*nlPow5) * (1 + (fd90 - 1)*nvPow5) * NdotL) * attenColor;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 d3d11_9x 
            #pragma target 3.0
            float3 GerstnersWave( float Steepness , float Amplitude , float Wavelength , float Speed , float Time , float DotProd , float2 DirectionVec ){
            float phaseConst = Speed * Wavelength;
            float xVal = Steepness * Amplitude * DirectionVec.x * cos(Wavelength * DotProd + Time * phaseConst);
            float yVal = Amplitude * sin(Wavelength * DotProd + Time * phaseConst);
            float zVal = Steepness * Amplitude * DirectionVec.y * cos(Wavelength * DotProd + Time * phaseConst);
            return float3(xVal, yVal, zVal);
            }
            
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Wave1Direction)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveHeight)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayFrequency)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wavelength)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                V2F_SHADOW_CASTER;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                float _SwayIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayIntensity );
                float _SwayFrequency_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayFrequency );
                float4 node_7423 = _Time;
                float TimeSway = ((_SwayIntensity_var*sin((_SwayFrequency_var*6.28318530718*node_7423.g)))+node_7423.g);
                float _WaveHeight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveHeight );
                float WaveHeight = _WaveHeight_var;
                float _Wavelength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wavelength );
                float Wavelength = _Wavelength_var;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float WaveSpeed = _WaveSpeed_var;
                float4 _Wave1Direction_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wave1Direction );
                float2 node_4955 = float2(_Wave1Direction_var.r,_Wave1Direction_var.g);
                v.vertex.xyz += GerstnersWave( TimeSway , WaveHeight , Wavelength , WaveSpeed , TimeSway , dot(node_4955,mul(unity_ObjectToWorld, v.vertex).rgb.r) , node_4955 );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma only_renderers d3d11 d3d11_9x 
            #pragma target 3.0
            float3 GerstnersWave( float Steepness , float Amplitude , float Wavelength , float Speed , float Time , float DotProd , float2 DirectionVec ){
            float phaseConst = Speed * Wavelength;
            float xVal = Steepness * Amplitude * DirectionVec.x * cos(Wavelength * DotProd + Time * phaseConst);
            float yVal = Amplitude * sin(Wavelength * DotProd + Time * phaseConst);
            float zVal = Steepness * Amplitude * DirectionVec.y * cos(Wavelength * DotProd + Time * phaseConst);
            return float3(xVal, yVal, zVal);
            }
            
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourB)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourA)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Wave1Direction)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveHeight)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayFrequency)
                UNITY_DEFINE_INSTANCED_PROP( float, _SwayIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wavelength)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float3 normalDir : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float _SwayIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayIntensity );
                float _SwayFrequency_var = UNITY_ACCESS_INSTANCED_PROP( Props, _SwayFrequency );
                float4 node_7423 = _Time;
                float TimeSway = ((_SwayIntensity_var*sin((_SwayFrequency_var*6.28318530718*node_7423.g)))+node_7423.g);
                float _WaveHeight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveHeight );
                float WaveHeight = _WaveHeight_var;
                float _Wavelength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wavelength );
                float Wavelength = _Wavelength_var;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float WaveSpeed = _WaveSpeed_var;
                float4 _Wave1Direction_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wave1Direction );
                float2 node_4955 = float2(_Wave1Direction_var.r,_Wave1Direction_var.g);
                v.vertex.xyz += GerstnersWave( TimeSway , WaveHeight , Wavelength , WaveSpeed , TimeSway , dot(node_4955,mul(unity_ObjectToWorld, v.vertex).rgb.r) , node_4955 );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 _ColourA_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourA );
                float4 _ColourB_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourB );
                float3 diffColor = lerp(_ColourA_var.rgb,_ColourB_var.rgb,pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0));
                float specularMonochrome;
                float3 specColor;
                float _Metallic_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic );
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _Metallic_var, specColor, specularMonochrome );
                float _Gloss_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Gloss );
                float roughness = 1.0 - _Gloss_var;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
