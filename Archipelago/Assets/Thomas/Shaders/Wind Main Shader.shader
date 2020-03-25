// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:2,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-7736-RGB,spec-9621-OUT,gloss-1813-OUT,normal-7914-OUT,emission-6226-OUT,clip-6343-OUT,voffset-2757-OUT;n:type:ShaderForge.SFN_Multiply,id:6343,x:32114,y:32712,varname:node_6343,prsc:2|A-7736-A,B-5364-OUT;n:type:ShaderForge.SFN_Tex2d,id:7736,x:31921,y:32620,ptovrint:True,ptlb:Texture Map,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-8187-UVOUT;n:type:ShaderForge.SFN_Slider,id:1813,x:32152,y:32892,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:9621,x:32380,y:32770,varname:node_9621,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:7914,x:32371,y:33023,varname:node_7914,prsc:2|A-8243-OUT,B-1920-OUT;n:type:ShaderForge.SFN_Multiply,id:8243,x:32119,y:33067,varname:node_8243,prsc:2|A-5920-OUT,B-2489-OUT;n:type:ShaderForge.SFN_Vector1,id:1920,x:32071,y:33208,varname:node_1920,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:2489,x:31711,y:33214,ptovrint:False,ptlb:Normal Strength,ptin:_NormalStrength,varname:node_2489,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7521378,max:1;n:type:ShaderForge.SFN_ComponentMask,id:5920,x:31800,y:32983,varname:node_5920,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1317-RGB;n:type:ShaderForge.SFN_Tex2d,id:1317,x:31539,y:32966,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_1317,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-8187-UVOUT;n:type:ShaderForge.SFN_Slider,id:5364,x:31764,y:32831,ptovrint:False,ptlb:Alpha Strength,ptin:_AlphaStrength,varname:node_5364,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_TexCoord,id:8187,x:31443,y:32580,varname:node_8187,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:2757,x:32393,y:33434,varname:node_2757,prsc:2|A-1592-RGB,B-6766-RGB,C-3437-OUT,D-4159-XYZ;n:type:ShaderForge.SFN_Transform,id:4159,x:32125,y:33762,varname:node_4159,prsc:2,tffrom:0,tfto:1|IN-3394-OUT;n:type:ShaderForge.SFN_VertexColor,id:1592,x:32125,y:33605,varname:node_1592,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6766,x:31933,y:33387,ptovrint:False,ptlb:Wind Texture,ptin:_WindTexture,varname:node_6766,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-5057-OUT;n:type:ShaderForge.SFN_Slider,id:3437,x:31680,y:33667,ptovrint:False,ptlb:Wind Strength,ptin:_WindStrength,varname:node_3437,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Append,id:3394,x:31848,y:33820,varname:node_3394,prsc:2|A-795-OUT,B-701-OUT;n:type:ShaderForge.SFN_Vector1,id:3836,x:31607,y:33884,varname:node_3836,prsc:2,v1:0;n:type:ShaderForge.SFN_Normalize,id:795,x:30598,y:33498,varname:node_795,prsc:2|IN-3733-X;n:type:ShaderForge.SFN_Multiply,id:5057,x:31675,y:33356,varname:node_5057,prsc:2|A-8970-UVOUT,B-359-OUT;n:type:ShaderForge.SFN_ValueProperty,id:359,x:31499,y:33533,ptovrint:False,ptlb:UV_Scale,ptin:_UV_Scale,varname:node_359,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Panner,id:8970,x:31499,y:33356,varname:node_8970,prsc:2,spu:1,spv:0|UVIN-422-OUT,DIST-5154-OUT;n:type:ShaderForge.SFN_Append,id:422,x:31305,y:33356,varname:node_422,prsc:2|A-4334-OUT,B-6792-OUT;n:type:ShaderForge.SFN_Multiply,id:5154,x:31174,y:33791,varname:node_5154,prsc:2|A-9194-TTR,B-9700-OUT;n:type:ShaderForge.SFN_Time,id:9194,x:30964,y:33791,varname:node_9194,prsc:2;n:type:ShaderForge.SFN_Slider,id:9700,x:30856,y:34017,ptovrint:False,ptlb:Wind_Speed,ptin:_Wind_Speed,varname:node_9700,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Dot,id:4334,x:31061,y:33356,varname:node_4334,prsc:2,dt:4|A-795-OUT,B-5978-R;n:type:ShaderForge.SFN_Dot,id:6792,x:31017,y:33544,varname:node_6792,prsc:2,dt:4|A-1182-OUT,B-5978-G;n:type:ShaderForge.SFN_ComponentMask,id:5978,x:30626,y:33304,varname:node_5978,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-1957-OUT;n:type:ShaderForge.SFN_Normalize,id:1182,x:30565,y:33599,varname:node_1182,prsc:2|IN-3733-Z;n:type:ShaderForge.SFN_Abs,id:1957,x:30416,y:33304,varname:node_1957,prsc:2|IN-3733-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:3733,x:30084,y:33314,varname:node_3733,prsc:2;n:type:ShaderForge.SFN_Normalize,id:701,x:30565,y:33777,varname:node_701,prsc:2|IN-3733-Y;n:type:ShaderForge.SFN_ValueProperty,id:6226,x:32442,y:32929,ptovrint:False,ptlb:Emmision6,ptin:_Emmision6,varname:node_6226,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:7736-1813-2489-1317-5364-6766-3437-359-9700-6226;pass:END;sub:END;*/

Shader "Shader Forge/GrassShader" {
    Properties {
        _MainTex ("Texture Map", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 1)) = 0
        _NormalStrength ("Normal Strength", Range(0, 1)) = 0.7521378
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _AlphaStrength ("Alpha Strength", Range(0, 1)) = 1
        _WindTexture ("Wind Texture", 2D) = "white" {}
        _WindStrength ("Wind Strength", Range(0, 1)) = 0
        _UV_Scale ("UV_Scale", Float ) = 0
        _Wind_Speed ("Wind_Speed", Range(0, 10)) = 0
        _Emmision6 ("Emmision6", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float, _NormalStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _AlphaStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _WindStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _UV_Scale)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wind_Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _Emmision6)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD10;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
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
                float4 node_9194 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_795 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_5978 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_5057 = ((float2(0.5*dot(node_795,node_5978.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_5978.g)+0.5)+(node_9194.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_5057, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float2(node_795,normalize(mul(unity_ObjectToWorld, v.vertex).g)),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float _NormalStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NormalStrength );
                float3 normalDirection = float3((_NormalMap_var.rgb.rg*_NormalStrength_var),1.0);
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float _AlphaStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AlphaStrength );
                clip((_MainTex_var.a*_AlphaStrength_var) - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
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
                float3 specularColor = 0.0;
                float specularMonochrome;
                float3 diffuseColor = _MainTex_var.rgb; // Need this for specular when using metallic
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
////// Emissive:
                float _Emmision6_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Emmision6 );
                float3 emissive = float3(_Emmision6_var,_Emmision6_var,_Emmision6_var);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
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
            Cull Off
            
            
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
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float, _NormalStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _AlphaStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _WindStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _UV_Scale)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wind_Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _Emmision6)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float3 normalDir : TEXCOORD4;
                float3 tangentDir : TEXCOORD5;
                float3 bitangentDir : TEXCOORD6;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(7,8)
                UNITY_FOG_COORDS(9)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_9194 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_795 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_5978 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_5057 = ((float2(0.5*dot(node_795,node_5978.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_5978.g)+0.5)+(node_9194.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_5057, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float2(node_795,normalize(mul(unity_ObjectToWorld, v.vertex).g)),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float _NormalStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NormalStrength );
                float3 normalDirection = float3((_NormalMap_var.rgb.rg*_NormalStrength_var),1.0);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float _AlphaStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AlphaStrength );
                clip((_MainTex_var.a*_AlphaStrength_var) - 0.5);
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
                float3 specularColor = 0.0;
                float specularMonochrome;
                float3 diffuseColor = _MainTex_var.rgb; // Need this for specular when using metallic
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
            Cull Off
            
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
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _AlphaStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _WindStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _UV_Scale)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wind_Speed)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                float4 node_9194 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_795 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_5978 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_5057 = ((float2(0.5*dot(node_795,node_5978.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_5978.g)+0.5)+(node_9194.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_5057, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float2(node_795,normalize(mul(unity_ObjectToWorld, v.vertex).g)),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float _AlphaStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _AlphaStrength );
                clip((_MainTex_var.a*_AlphaStrength_var) - 0.5);
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
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _WindTexture; uniform float4 _WindTexture_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float, _WindStrength)
                UNITY_DEFINE_INSTANCED_PROP( float, _UV_Scale)
                UNITY_DEFINE_INSTANCED_PROP( float, _Wind_Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _Emmision6)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.vertexColor = v.vertexColor;
                float4 node_9194 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_795 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_5978 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_5057 = ((float2(0.5*dot(node_795,node_5978.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_5978.g)+0.5)+(node_9194.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_5057, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float2(node_795,normalize(mul(unity_ObjectToWorld, v.vertex).g)),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float _Emmision6_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Emmision6 );
                o.Emission = float3(_Emmision6_var,_Emmision6_var,_Emmision6_var);
                
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float3 diffColor = _MainTex_var.rgb;
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0.0, specColor, specularMonochrome );
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
