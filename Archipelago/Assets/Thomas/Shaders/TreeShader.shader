// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-6741-RGB,spec-5541-OUT,gloss-4221-OUT,normal-3612-OUT,clip-5463-OUT,voffset-4523-OUT;n:type:ShaderForge.SFN_Multiply,id:5463,x:31862,y:32626,varname:node_5463,prsc:2|A-6741-A,B-8947-OUT;n:type:ShaderForge.SFN_Tex2d,id:6741,x:31669,y:32534,ptovrint:True,ptlb:Texture Map,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2145-UVOUT;n:type:ShaderForge.SFN_Slider,id:4221,x:31900,y:32806,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:5541,x:32128,y:32684,varname:node_5541,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:3612,x:32119,y:32937,varname:node_3612,prsc:2|A-733-OUT,B-5757-OUT;n:type:ShaderForge.SFN_Multiply,id:733,x:31867,y:32981,varname:node_733,prsc:2|A-977-OUT,B-4759-OUT;n:type:ShaderForge.SFN_Vector1,id:5757,x:31819,y:33122,varname:node_5757,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:4759,x:31459,y:33128,ptovrint:False,ptlb:Normal Strength,ptin:_NormalStrength,varname:node_2489,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7521378,max:1;n:type:ShaderForge.SFN_ComponentMask,id:977,x:31548,y:32897,varname:node_977,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7848-RGB;n:type:ShaderForge.SFN_Tex2d,id:7848,x:31287,y:32880,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_1317,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True|UVIN-2145-UVOUT;n:type:ShaderForge.SFN_Slider,id:8947,x:31512,y:32745,ptovrint:False,ptlb:Alpha Strength,ptin:_AlphaStrength,varname:node_5364,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_TexCoord,id:2145,x:31191,y:32494,varname:node_2145,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:4523,x:32141,y:33348,varname:node_4523,prsc:2|A-8323-RGB,B-1825-RGB,C-7087-OUT,D-4454-XYZ;n:type:ShaderForge.SFN_Transform,id:4454,x:31873,y:33676,varname:node_4454,prsc:2,tffrom:0,tfto:1|IN-6057-OUT;n:type:ShaderForge.SFN_VertexColor,id:8323,x:31873,y:33519,varname:node_8323,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:1825,x:31681,y:33301,ptovrint:False,ptlb:Wind Texture,ptin:_WindTexture,varname:node_6766,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2567-OUT;n:type:ShaderForge.SFN_Slider,id:7087,x:31428,y:33581,ptovrint:False,ptlb:Wind Strength,ptin:_WindStrength,varname:node_3437,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Append,id:6057,x:31596,y:33734,varname:node_6057,prsc:2|A-9160-OUT,B-6039-OUT,C-6039-OUT;n:type:ShaderForge.SFN_Vector1,id:6039,x:31355,y:33798,varname:node_6039,prsc:2,v1:0;n:type:ShaderForge.SFN_Normalize,id:9160,x:30346,y:33412,varname:node_9160,prsc:2|IN-355-X;n:type:ShaderForge.SFN_Multiply,id:2567,x:31423,y:33270,varname:node_2567,prsc:2|A-126-UVOUT,B-2396-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2396,x:31247,y:33447,ptovrint:False,ptlb:UV_Scale,ptin:_UV_Scale,varname:node_359,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Panner,id:126,x:31247,y:33270,varname:node_126,prsc:2,spu:1,spv:0|UVIN-6985-OUT,DIST-7333-OUT;n:type:ShaderForge.SFN_Append,id:6985,x:31053,y:33270,varname:node_6985,prsc:2|A-2850-OUT,B-2417-OUT;n:type:ShaderForge.SFN_Multiply,id:7333,x:30922,y:33705,varname:node_7333,prsc:2|A-4164-TTR,B-5066-OUT;n:type:ShaderForge.SFN_Time,id:4164,x:30712,y:33705,varname:node_4164,prsc:2;n:type:ShaderForge.SFN_Slider,id:5066,x:30604,y:33931,ptovrint:False,ptlb:Wind_Speed,ptin:_Wind_Speed,varname:node_9700,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Dot,id:2850,x:30809,y:33270,varname:node_2850,prsc:2,dt:4|A-9160-OUT,B-7927-R;n:type:ShaderForge.SFN_Dot,id:2417,x:30765,y:33458,varname:node_2417,prsc:2,dt:4|A-8570-OUT,B-7927-G;n:type:ShaderForge.SFN_ComponentMask,id:7927,x:30374,y:33218,varname:node_7927,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-1488-OUT;n:type:ShaderForge.SFN_Normalize,id:8570,x:30259,y:33602,varname:node_8570,prsc:2|IN-355-Z;n:type:ShaderForge.SFN_Abs,id:1488,x:30164,y:33218,varname:node_1488,prsc:2|IN-355-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:355,x:29832,y:33228,varname:node_355,prsc:2;proporder:1825-7087-4759-7848-6741-8947-4221-2396-5066;pass:END;sub:END;*/

Shader "Shader Forge/TreeShader" {
    Properties {
        _WindTexture ("Wind Texture", 2D) = "white" {}
        _WindStrength ("Wind Strength", Range(0, 1)) = 0
        _NormalStrength ("Normal Strength", Range(0, 1)) = 0.7521378
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _MainTex ("Texture Map", 2D) = "white" {}
        _AlphaStrength ("Alpha Strength", Range(0, 1)) = 1
        _Gloss ("Gloss", Range(0, 1)) = 0
        _UV_Scale ("UV_Scale", Float ) = 0
        _Wind_Speed ("Wind_Speed", Range(0, 10)) = 0
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
                float4 node_4164 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_9160 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7927 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_2567 = ((float2(0.5*dot(node_9160,node_7927.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7927.g)+0.5)+(node_4164.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_2567, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                float node_6039 = 0.0;
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float3(node_9160,node_6039,node_6039),0) ).xyz.rgb);
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
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float _NormalStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NormalStrength );
                float3 normalLocal = float3((_NormalMap_var.rgb.rg*_NormalStrength_var),1.0);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 node_4164 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_9160 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7927 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_2567 = ((float2(0.5*dot(node_9160,node_7927.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7927.g)+0.5)+(node_4164.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_2567, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                float node_6039 = 0.0;
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float3(node_9160,node_6039,node_6039),0) ).xyz.rgb);
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
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float _NormalStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NormalStrength );
                float3 normalLocal = float3((_NormalMap_var.rgb.rg*_NormalStrength_var),1.0);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
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
                float4 node_4164 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_9160 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7927 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_2567 = ((float2(0.5*dot(node_9160,node_7927.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7927.g)+0.5)+(node_4164.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_2567, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                float node_6039 = 0.0;
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float3(node_9160,node_6039,node_6039),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
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
                float4 node_4164 = _Time;
                float _Wind_Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Wind_Speed );
                float node_9160 = normalize(mul(unity_ObjectToWorld, v.vertex).r);
                float2 node_7927 = abs(mul(unity_ObjectToWorld, v.vertex).rgb).rb;
                float _UV_Scale_var = UNITY_ACCESS_INSTANCED_PROP( Props, _UV_Scale );
                float2 node_2567 = ((float2(0.5*dot(node_9160,node_7927.r)+0.5,0.5*dot(normalize(mul(unity_ObjectToWorld, v.vertex).b),node_7927.g)+0.5)+(node_4164.a*_Wind_Speed_var)*float2(1,0))*_UV_Scale_var);
                float4 _WindTexture_var = tex2Dlod(_WindTexture,float4(TRANSFORM_TEX(node_2567, _WindTexture),0.0,0));
                float _WindStrength_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WindStrength );
                float node_6039 = 0.0;
                v.vertex.xyz += (o.vertexColor.rgb*_WindTexture_var.rgb*_WindStrength_var*mul( unity_WorldToObject, float4(float3(node_9160,node_6039,node_6039),0) ).xyz.rgb);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
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
