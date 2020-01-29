// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:33308,y:32773,varname:node_2865,prsc:2|diff-7226-OUT,spec-6303-OUT,gloss-2342-OUT,normal-6742-RGB,clip-6122-A,voffset-2446-OUT;n:type:ShaderForge.SFN_Time,id:3601,x:31232,y:32719,varname:node_3601,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:2990,x:31232,y:32904,ptovrint:False,ptlb:Trunk Wind Power,ptin:_TrunkWindPower,varname:node_2990,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:1946,x:31450,y:32771,varname:node_1946,prsc:2|A-3601-T,B-2990-OUT;n:type:ShaderForge.SFN_Sin,id:7817,x:31745,y:32670,varname:node_7817,prsc:2|IN-1946-OUT;n:type:ShaderForge.SFN_Multiply,id:4339,x:31942,y:32670,varname:node_4339,prsc:2|A-7817-OUT,B-5402-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5402,x:31658,y:32862,ptovrint:False,ptlb:Trunk Wind Amplitude,ptin:_TrunkWindAmplitude,varname:node_5402,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:4345,x:32138,y:32695,varname:node_4345,prsc:2|A-4339-OUT,B-691-A;n:type:ShaderForge.SFN_VertexColor,id:691,x:31942,y:32825,varname:node_691,prsc:2;n:type:ShaderForge.SFN_Append,id:5595,x:32320,y:32792,varname:node_5595,prsc:2|A-4345-OUT,B-8556-OUT,C-1533-OUT;n:type:ShaderForge.SFN_Vector1,id:8556,x:32138,y:32859,varname:node_8556,prsc:2,v1:0;n:type:ShaderForge.SFN_Add,id:2446,x:32571,y:32889,varname:node_2446,prsc:2|A-5595-OUT,B-8088-OUT;n:type:ShaderForge.SFN_Slider,id:6303,x:32548,y:32698,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_6303,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Cos,id:8799,x:31593,y:32986,varname:node_8799,prsc:2|IN-1946-OUT;n:type:ShaderForge.SFN_Multiply,id:2323,x:31875,y:32987,varname:node_2323,prsc:2|A-5402-OUT,B-3944-OUT;n:type:ShaderForge.SFN_Vector1,id:3944,x:31574,y:33156,varname:node_3944,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:2225,x:32100,y:32987,varname:node_2225,prsc:2|A-8799-OUT,B-2323-OUT;n:type:ShaderForge.SFN_Multiply,id:1533,x:32278,y:32987,varname:node_1533,prsc:2|A-2225-OUT,B-691-A;n:type:ShaderForge.SFN_Multiply,id:8088,x:32507,y:33117,varname:node_8088,prsc:2|A-4161-OUT,B-5517-R,C-6436-OUT,D-4205-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4205,x:32100,y:33156,ptovrint:False,ptlb:Leaf Wind Amplitude,ptin:_LeafWindAmplitude,varname:node_4205,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.03;n:type:ShaderForge.SFN_NormalVector,id:9268,x:32020,y:33489,prsc:2,pt:True;n:type:ShaderForge.SFN_Vector4Property,id:2111,x:32009,y:33300,ptovrint:False,ptlb:Leaf Wind Direction,ptin:_LeafWindDirection,varname:node_2111,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1,v2:0.5,v3:0.555,v4:0;n:type:ShaderForge.SFN_Add,id:7508,x:32237,y:33310,varname:node_7508,prsc:2|A-2111-XYZ,B-9268-OUT;n:type:ShaderForge.SFN_Normalize,id:4161,x:32465,y:33310,varname:node_4161,prsc:2|IN-7508-OUT;n:type:ShaderForge.SFN_VertexColor,id:5517,x:30966,y:33556,varname:node_5517,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6742,x:32798,y:32795,ptovrint:False,ptlb:Normal Map,ptin:_NormalMap,varname:node_6742,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Pi,id:2870,x:30982,y:33699,varname:node_2870,prsc:2;n:type:ShaderForge.SFN_Time,id:2469,x:30982,y:33824,varname:node_2469,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:9720,x:30982,y:33998,ptovrint:False,ptlb:Leaf Wind Power,ptin:_LeafWindPower,varname:node_9720,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;n:type:ShaderForge.SFN_Multiply,id:1567,x:31237,y:33856,varname:node_1567,prsc:2|A-2469-T,B-9720-OUT;n:type:ShaderForge.SFN_Multiply,id:4798,x:31237,y:33681,varname:node_4798,prsc:2|A-5517-R,B-2870-OUT;n:type:ShaderForge.SFN_Add,id:1620,x:31460,y:33779,varname:node_1620,prsc:2|A-4798-OUT,B-1567-OUT;n:type:ShaderForge.SFN_Multiply,id:6479,x:31671,y:33884,varname:node_6479,prsc:2|A-1620-OUT,B-157-OUT;n:type:ShaderForge.SFN_Vector1,id:157,x:31460,y:33978,varname:node_157,prsc:2,v1:3;n:type:ShaderForge.SFN_Sin,id:6053,x:31861,y:33884,varname:node_6053,prsc:2|IN-6479-OUT;n:type:ShaderForge.SFN_Sin,id:1832,x:31959,y:33705,varname:node_1832,prsc:2|IN-1620-OUT;n:type:ShaderForge.SFN_Add,id:6442,x:32250,y:33884,varname:node_6442,prsc:2|A-1832-OUT,B-1852-OUT;n:type:ShaderForge.SFN_Multiply,id:1852,x:32063,y:33884,varname:node_1852,prsc:2|A-6053-OUT,B-3036-OUT;n:type:ShaderForge.SFN_Vector1,id:3036,x:31877,y:34047,varname:node_3036,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:1547,x:32079,y:34073,varname:node_1547,prsc:2|A-1620-OUT,B-9664-OUT;n:type:ShaderForge.SFN_Vector1,id:9664,x:31877,y:34122,varname:node_9664,prsc:2,v1:5;n:type:ShaderForge.SFN_Cos,id:7619,x:32250,y:34024,varname:node_7619,prsc:2|IN-1547-OUT;n:type:ShaderForge.SFN_Subtract,id:6436,x:32456,y:33884,varname:node_6436,prsc:2|A-6442-OUT,B-7619-OUT;n:type:ShaderForge.SFN_Tex2d,id:6122,x:32763,y:33088,ptovrint:False,ptlb:Base Colour,ptin:_BaseColour,varname:node_6122,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:1974,x:32763,y:33306,ptovrint:False,ptlb:Colour,ptin:_Colour,varname:node_1974,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:7226,x:33004,y:33174,varname:node_7226,prsc:2|A-6122-RGB,B-1974-RGB;n:type:ShaderForge.SFN_Slider,id:2342,x:32957,y:33488,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_2342,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.9883574,max:1;proporder:2990-5402-6303-6742-4205-2111-9720-6122-2342-1974;pass:END;sub:END;*/

Shader "Shader Forge/Wind" {
    Properties {
        _TrunkWindPower ("Trunk Wind Power", Float ) = 0.5
        _TrunkWindAmplitude ("Trunk Wind Amplitude", Float ) = 1
        _Metallic ("Metallic", Range(0, 1)) = 0
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _LeafWindAmplitude ("Leaf Wind Amplitude", Float ) = 0.03
        _LeafWindDirection ("Leaf Wind Direction", Vector) = (1,0.5,0.555,0)
        _LeafWindPower ("Leaf Wind Power", Float ) = 1.5
        _BaseColour ("Base Colour", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 1)) = 0.9883574
        _Colour ("Colour", Color) = (0.5,0.5,0.5,1)
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
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _BaseColour; uniform float4 _BaseColour_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LeafWindDirection)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindPower)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Colour)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
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
                float4 node_3601 = _Time;
                float _TrunkWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindPower );
                float node_1946 = (node_3601.g*_TrunkWindPower_var);
                float _TrunkWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindAmplitude );
                float4 _LeafWindDirection_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindDirection );
                float4 node_2469 = _Time;
                float _LeafWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindPower );
                float node_1620 = ((o.vertexColor.r*3.141592654)+(node_2469.g*_LeafWindPower_var));
                float _LeafWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindAmplitude );
                v.vertex.xyz += (float3(((sin(node_1946)*_TrunkWindAmplitude_var)*o.vertexColor.a),0.0,((cos(node_1946)*(_TrunkWindAmplitude_var*0.5))*o.vertexColor.a))+(normalize((_LeafWindDirection_var.rgb+v.normal))*o.vertexColor.r*((sin(node_1620)+(sin((node_1620*3.0))*0.2))-cos((node_1620*5.0)))*_LeafWindAmplitude_var));
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
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float4 _BaseColour_var = tex2D(_BaseColour,TRANSFORM_TEX(i.uv0, _BaseColour));
                clip(_BaseColour_var.a - 0.5);
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
                float _Metallic_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Metallic );
                float3 specularColor = _Metallic_var;
                float specularMonochrome;
                float4 _Colour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Colour );
                float3 diffuseColor = (_BaseColour_var.rgb*_Colour_var.rgb); // Need this for specular when using metallic
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
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _BaseColour; uniform float4 _BaseColour_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LeafWindDirection)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindPower)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Colour)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
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
                float4 node_3601 = _Time;
                float _TrunkWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindPower );
                float node_1946 = (node_3601.g*_TrunkWindPower_var);
                float _TrunkWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindAmplitude );
                float4 _LeafWindDirection_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindDirection );
                float4 node_2469 = _Time;
                float _LeafWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindPower );
                float node_1620 = ((o.vertexColor.r*3.141592654)+(node_2469.g*_LeafWindPower_var));
                float _LeafWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindAmplitude );
                v.vertex.xyz += (float3(((sin(node_1946)*_TrunkWindAmplitude_var)*o.vertexColor.a),0.0,((cos(node_1946)*(_TrunkWindAmplitude_var*0.5))*o.vertexColor.a))+(normalize((_LeafWindDirection_var.rgb+v.normal))*o.vertexColor.r*((sin(node_1620)+(sin((node_1620*3.0))*0.2))-cos((node_1620*5.0)))*_LeafWindAmplitude_var));
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
                float3 normalLocal = _NormalMap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _BaseColour_var = tex2D(_BaseColour,TRANSFORM_TEX(i.uv0, _BaseColour));
                clip(_BaseColour_var.a - 0.5);
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
                float4 _Colour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Colour );
                float3 diffuseColor = (_BaseColour_var.rgb*_Colour_var.rgb); // Need this for specular when using metallic
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
            uniform sampler2D _BaseColour; uniform float4 _BaseColour_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LeafWindDirection)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindPower)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
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
                float3 normalDir : TEXCOORD5;
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
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3601 = _Time;
                float _TrunkWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindPower );
                float node_1946 = (node_3601.g*_TrunkWindPower_var);
                float _TrunkWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindAmplitude );
                float4 _LeafWindDirection_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindDirection );
                float4 node_2469 = _Time;
                float _LeafWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindPower );
                float node_1620 = ((o.vertexColor.r*3.141592654)+(node_2469.g*_LeafWindPower_var));
                float _LeafWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindAmplitude );
                v.vertex.xyz += (float3(((sin(node_1946)*_TrunkWindAmplitude_var)*o.vertexColor.a),0.0,((cos(node_1946)*(_TrunkWindAmplitude_var*0.5))*o.vertexColor.a))+(normalize((_LeafWindDirection_var.rgb+v.normal))*o.vertexColor.r*((sin(node_1620)+(sin((node_1620*3.0))*0.2))-cos((node_1620*5.0)))*_LeafWindAmplitude_var));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _BaseColour_var = tex2D(_BaseColour,TRANSFORM_TEX(i.uv0, _BaseColour));
                clip(_BaseColour_var.a - 0.5);
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
            uniform sampler2D _BaseColour; uniform float4 _BaseColour_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _TrunkWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindAmplitude)
                UNITY_DEFINE_INSTANCED_PROP( float4, _LeafWindDirection)
                UNITY_DEFINE_INSTANCED_PROP( float, _LeafWindPower)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Colour)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
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
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_3601 = _Time;
                float _TrunkWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindPower );
                float node_1946 = (node_3601.g*_TrunkWindPower_var);
                float _TrunkWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TrunkWindAmplitude );
                float4 _LeafWindDirection_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindDirection );
                float4 node_2469 = _Time;
                float _LeafWindPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindPower );
                float node_1620 = ((o.vertexColor.r*3.141592654)+(node_2469.g*_LeafWindPower_var));
                float _LeafWindAmplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _LeafWindAmplitude );
                v.vertex.xyz += (float3(((sin(node_1946)*_TrunkWindAmplitude_var)*o.vertexColor.a),0.0,((cos(node_1946)*(_TrunkWindAmplitude_var*0.5))*o.vertexColor.a))+(normalize((_LeafWindDirection_var.rgb+v.normal))*o.vertexColor.r*((sin(node_1620)+(sin((node_1620*3.0))*0.2))-cos((node_1620*5.0)))*_LeafWindAmplitude_var));
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
                
                float4 _BaseColour_var = tex2D(_BaseColour,TRANSFORM_TEX(i.uv0, _BaseColour));
                float4 _Colour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Colour );
                float3 diffColor = (_BaseColour_var.rgb*_Colour_var.rgb);
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
