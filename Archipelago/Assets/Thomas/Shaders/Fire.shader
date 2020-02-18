// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33740,y:32652,varname:node_2865,prsc:2|diff-9983-OUT,spec-633-OUT,gloss-5990-OUT,alpha-1796-A;n:type:ShaderForge.SFN_Time,id:7410,x:31965,y:32867,varname:node_7410,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:5461,x:32020,y:32775,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_5461,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:23;n:type:ShaderForge.SFN_Multiply,id:7909,x:32206,y:32795,varname:node_7909,prsc:2|A-5461-OUT,B-7410-TSL;n:type:ShaderForge.SFN_TexCoord,id:1373,x:32206,y:32618,varname:node_1373,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:1834,x:32376,y:32676,varname:node_1834,prsc:2,spu:1,spv:1|UVIN-1373-UVOUT,DIST-7909-OUT;n:type:ShaderForge.SFN_Tex2d,id:1796,x:32627,y:32686,varname:node_1796,prsc:2,tex:a73f386972dc12a41864b119f519f1cc,ntxv:0,isnm:False|UVIN-1834-UVOUT,TEX-8895-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:8895,x:32458,y:32822,ptovrint:False,ptlb:node_8895,ptin:_node_8895,varname:node_8895,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a73f386972dc12a41864b119f519f1cc,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:5990,x:32680,y:32878,ptovrint:False,ptlb:node_5990,ptin:_node_5990,varname:node_5990,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2991453,max:1;n:type:ShaderForge.SFN_Slider,id:633,x:32680,y:32966,ptovrint:False,ptlb:node_5990_copy,ptin:_node_5990_copy,varname:_node_5990_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:3518,x:32235,y:33023,varname:node_3518,prsc:2|A-7410-TSL,B-5665-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5665,x:31937,y:33112,ptovrint:False,ptlb:node_5665,ptin:_node_5665,varname:node_5665,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:20;n:type:ShaderForge.SFN_Panner,id:9096,x:32538,y:33121,varname:node_9096,prsc:2,spu:1,spv:1|UVIN-249-UVOUT,DIST-3518-OUT;n:type:ShaderForge.SFN_TexCoord,id:249,x:32349,y:33161,varname:node_249,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Tex2d,id:8210,x:32745,y:33145,ptovrint:False,ptlb:node_8210,ptin:_node_8210,varname:node_8210,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:076268c7029441247981ee33d1bd87dc,ntxv:0,isnm:False|UVIN-9096-UVOUT;n:type:ShaderForge.SFN_Power,id:2571,x:33092,y:33161,varname:node_2571,prsc:2|VAL-8210-RGB,EXP-2217-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2217,x:32927,y:33289,ptovrint:False,ptlb:node_2217,ptin:_node_2217,varname:node_2217,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:7756,x:33260,y:33161,varname:node_7756,prsc:2|A-1796-RGB,B-2571-OUT;n:type:ShaderForge.SFN_Multiply,id:4149,x:33484,y:33080,varname:node_4149,prsc:2|A-1796-RGB,B-7756-OUT;n:type:ShaderForge.SFN_Color,id:4030,x:33161,y:32503,ptovrint:False,ptlb:node_4030,ptin:_node_4030,varname:node_4030,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:9983,x:33333,y:32694,varname:node_9983,prsc:2|A-4030-RGB,B-4149-OUT;proporder:5461-8895-633-5990-5665-8210-2217-4030;pass:END;sub:END;*/

Shader "Shader Forge/Fire" {
    Properties {
        _Speed ("Speed", Float ) = 23
        _node_8895 ("node_8895", 2D) = "white" {}
        _node_5990_copy ("node_5990_copy", Range(0, 1)) = 0
        _node_5990 ("node_5990", Range(0, 1)) = 0.2991453
        _node_5665 ("node_5665", Float ) = 20
        _node_8210 ("node_8210", 2D) = "white" {}
        _node_2217 ("node_2217", Float ) = 1
        _node_4030 ("node_4030", Color) = (1,0,0,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            #pragma target 3.0
            uniform sampler2D _node_8895; uniform float4 _node_8895_ST;
            uniform sampler2D _node_8210; uniform float4 _node_8210_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5990)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5990_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5665)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2217)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_4030)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
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
                UNITY_FOG_COORDS(7)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD8;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
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
                float _node_5990_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5990 );
                float gloss = _node_5990_var;
                float perceptualRoughness = 1.0 - _node_5990_var;
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
                float _node_5990_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5990_copy );
                float3 specularColor = _node_5990_copy_var;
                float specularMonochrome;
                float4 _node_4030_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4030 );
                float _Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Speed );
                float4 node_7410 = _Time;
                float2 node_1834 = (i.uv0+(_Speed_var*node_7410.r)*float2(1,1));
                float4 node_1796 = tex2D(_node_8895,TRANSFORM_TEX(node_1834, _node_8895));
                float _node_5665_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5665 );
                float2 node_9096 = (i.uv0+(node_7410.r*_node_5665_var)*float2(1,1));
                float4 _node_8210_var = tex2D(_node_8210,TRANSFORM_TEX(node_9096, _node_8210));
                float _node_2217_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2217 );
                float3 diffuseColor = (_node_4030_var.rgb*(node_1796.rgb*(node_1796.rgb*pow(_node_8210_var.rgb,_node_2217_var)))); // Need this for specular when using metallic
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
                fixed4 finalRGBA = fixed4(finalColor,node_1796.a);
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
            #pragma target 3.0
            uniform sampler2D _node_8895; uniform float4 _node_8895_ST;
            uniform sampler2D _node_8210; uniform float4 _node_8210_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5990)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5990_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5665)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2217)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_4030)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
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
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
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
                float _node_5990_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5990 );
                float gloss = _node_5990_var;
                float perceptualRoughness = 1.0 - _node_5990_var;
                float roughness = perceptualRoughness * perceptualRoughness;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float LdotH = saturate(dot(lightDirection, halfDirection));
                float _node_5990_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5990_copy );
                float3 specularColor = _node_5990_copy_var;
                float specularMonochrome;
                float4 _node_4030_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4030 );
                float _Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Speed );
                float4 node_7410 = _Time;
                float2 node_1834 = (i.uv0+(_Speed_var*node_7410.r)*float2(1,1));
                float4 node_1796 = tex2D(_node_8895,TRANSFORM_TEX(node_1834, _node_8895));
                float _node_5665_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5665 );
                float2 node_9096 = (i.uv0+(node_7410.r*_node_5665_var)*float2(1,1));
                float4 _node_8210_var = tex2D(_node_8210,TRANSFORM_TEX(node_9096, _node_8210));
                float _node_2217_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2217 );
                float3 diffuseColor = (_node_4030_var.rgb*(node_1796.rgb*(node_1796.rgb*pow(_node_8210_var.rgb,_node_2217_var)))); // Need this for specular when using metallic
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
                fixed4 finalRGBA = fixed4(finalColor * node_1796.a,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
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
            uniform sampler2D _node_8895; uniform float4 _node_8895_ST;
            uniform sampler2D _node_8210; uniform float4 _node_8210_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Speed)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5990)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5990_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_5665)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_2217)
                UNITY_DEFINE_INSTANCED_PROP( float4, _node_4030)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float2 uv2 : TEXCOORD2;
                float4 posWorld : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
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
                
                float4 _node_4030_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4030 );
                float _Speed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Speed );
                float4 node_7410 = _Time;
                float2 node_1834 = (i.uv0+(_Speed_var*node_7410.r)*float2(1,1));
                float4 node_1796 = tex2D(_node_8895,TRANSFORM_TEX(node_1834, _node_8895));
                float _node_5665_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5665 );
                float2 node_9096 = (i.uv0+(node_7410.r*_node_5665_var)*float2(1,1));
                float4 _node_8210_var = tex2D(_node_8210,TRANSFORM_TEX(node_9096, _node_8210));
                float _node_2217_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_2217 );
                float3 diffColor = (_node_4030_var.rgb*(node_1796.rgb*(node_1796.rgb*pow(_node_8210_var.rgb,_node_2217_var))));
                float specularMonochrome;
                float3 specColor;
                float _node_5990_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5990_copy );
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, _node_5990_copy_var, specColor, specularMonochrome );
                float _node_5990_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_5990 );
                float roughness = 1.0 - _node_5990_var;
                o.Albedo = diffColor + specColor * roughness * roughness * 0.5;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
