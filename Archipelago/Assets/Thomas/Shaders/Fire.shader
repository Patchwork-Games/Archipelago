// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:35135,y:32503,varname:node_2865,prsc:2|emission-1273-OUT,alpha-5510-OUT;n:type:ShaderForge.SFN_Slider,id:8896,x:32114,y:32657,ptovrint:False,ptlb:node_8896,ptin:_node_8896,varname:node_8896,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.05926982,max:1;n:type:ShaderForge.SFN_Slider,id:6748,x:32125,y:32803,ptovrint:False,ptlb:node_8896_copy,ptin:_node_8896_copy,varname:_node_8896_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:-0.6005692,max:1;n:type:ShaderForge.SFN_Slider,id:8722,x:32104,y:33285,ptovrint:False,ptlb:node_8896_copy_copy,ptin:_node_8896_copy_copy,varname:_node_8896_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7040771,max:1;n:type:ShaderForge.SFN_Slider,id:4088,x:32104,y:33421,ptovrint:False,ptlb:node_8896_copy_copy_copy,ptin:_node_8896_copy_copy_copy,varname:_node_8896_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8921112,max:1;n:type:ShaderForge.SFN_Append,id:9734,x:32465,y:33283,varname:node_9734,prsc:2|A-8722-OUT,B-4088-OUT;n:type:ShaderForge.SFN_TexCoord,id:31,x:32201,y:33045,varname:node_31,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3833,x:32732,y:32872,varname:node_3833,prsc:2|A-31-UVOUT,B-9734-OUT;n:type:ShaderForge.SFN_Append,id:4521,x:32530,y:32672,varname:node_4521,prsc:2|A-8896-OUT,B-6748-OUT;n:type:ShaderForge.SFN_Time,id:9487,x:32530,y:32439,varname:node_9487,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4457,x:32732,y:32682,varname:node_4457,prsc:2|A-9487-T,B-4521-OUT;n:type:ShaderForge.SFN_Add,id:1612,x:32959,y:32712,varname:node_1612,prsc:2|A-4457-OUT,B-3833-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:5425,x:32977,y:33171,ptovrint:False,ptlb:Main Tex,ptin:_MainTex,varname:node_5425,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:32d0bb861b4ec304792fd9fe1c69748a,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8637,x:33206,y:32691,varname:node_8637,prsc:2,tex:32d0bb861b4ec304792fd9fe1c69748a,ntxv:0,isnm:False|UVIN-1612-OUT,TEX-5425-TEX;n:type:ShaderForge.SFN_RemapRange,id:3642,x:33394,y:32691,varname:node_3642,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8637-B;n:type:ShaderForge.SFN_Multiply,id:9599,x:33627,y:32691,varname:node_9599,prsc:2|A-7822-OUT,B-3642-OUT;n:type:ShaderForge.SFN_Slider,id:7822,x:33298,y:32543,ptovrint:False,ptlb:Distortion Intensity,ptin:_DistortionIntensity,varname:node_7822,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4894179,max:1;n:type:ShaderForge.SFN_TexCoord,id:508,x:33627,y:32527,varname:node_508,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:806,x:33877,y:32691,varname:node_806,prsc:2|A-508-UVOUT,B-9599-OUT;n:type:ShaderForge.SFN_Tex2d,id:7928,x:34113,y:32716,varname:node_7928,prsc:2,tex:32d0bb861b4ec304792fd9fe1c69748a,ntxv:0,isnm:False|UVIN-806-OUT,TEX-5425-TEX;n:type:ShaderForge.SFN_Slider,id:657,x:33808,y:33038,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_657,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:7275,x:33855,y:33145,varname:node_7275,prsc:2,tex:32d0bb861b4ec304792fd9fe1c69748a,ntxv:0,isnm:False|TEX-5425-TEX;n:type:ShaderForge.SFN_Multiply,id:1064,x:34219,y:33104,varname:node_1064,prsc:2|A-657-OUT,B-7275-A,C-7928-R;n:type:ShaderForge.SFN_Subtract,id:1755,x:34407,y:33104,varname:node_1755,prsc:2|A-1064-OUT,B-7928-B;n:type:ShaderForge.SFN_Clamp01,id:8368,x:34574,y:33104,varname:node_8368,prsc:2|IN-1755-OUT;n:type:ShaderForge.SFN_Add,id:5932,x:34654,y:32843,varname:node_5932,prsc:2|A-265-OUT,B-4124-OUT;n:type:ShaderForge.SFN_Slider,id:265,x:34273,y:32839,ptovrint:False,ptlb:node_265,ptin:_node_265,varname:node_265,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:4124,x:34295,y:32958,ptovrint:False,ptlb:node_4124,ptin:_node_4124,varname:node_4124,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3078363,max:1;n:type:ShaderForge.SFN_InverseLerp,id:5510,x:34831,y:33082,varname:node_5510,prsc:2|A-265-OUT,B-5932-OUT,V-8368-OUT;n:type:ShaderForge.SFN_Color,id:1661,x:34207,y:32198,ptovrint:False,ptlb:Outer Colour,ptin:_OuterColour,varname:node_1661,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.5102247,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:6078,x:34207,y:32400,ptovrint:False,ptlb:Inner Colour,ptin:_InnerColour,varname:node_6078,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.6324958,c3:0,c4:1;n:type:ShaderForge.SFN_Lerp,id:6854,x:34521,y:32325,varname:node_6854,prsc:2|A-1661-RGB,B-6078-RGB,T-7928-G;n:type:ShaderForge.SFN_Slider,id:5230,x:34542,y:32176,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_5230,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.241079,max:5;n:type:ShaderForge.SFN_Multiply,id:1273,x:34764,y:32287,varname:node_1273,prsc:2|A-5230-OUT,B-6854-OUT;proporder:8896-6748-8722-4088-5425-7822-657-265-4124-1661-6078-5230;pass:END;sub:END;*/

Shader "Shader Forge/Fire" {
    Properties {
        _node_8896 ("node_8896", Range(-1, 1)) = 0.05926982
        _node_8896_copy ("node_8896_copy", Range(-1, 1)) = -0.6005692
        _node_8896_copy_copy ("node_8896_copy_copy", Range(0, 1)) = 0.7040771
        _node_8896_copy_copy_copy ("node_8896_copy_copy_copy", Range(0, 1)) = 0.8921112
        _MainTex ("Main Tex", 2D) = "white" {}
        _DistortionIntensity ("Distortion Intensity", Range(0, 1)) = 0.4894179
        _Thickness ("Thickness", Range(0, 1)) = 1
        _node_265 ("node_265", Range(0, 1)) = 0
        _node_4124 ("node_4124", Range(0, 1)) = 0.3078363
        _OuterColour ("Outer Colour", Color) = (1,0.5102247,0,1)
        _InnerColour ("Inner Colour", Color) = (1,0.6324958,0,1)
        _Brightness ("Brightness", Range(0, 5)) = 1.241079
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896_copy_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896_copy_copy_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _DistortionIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float, _Thickness)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_265)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_4124)
                UNITY_DEFINE_INSTANCED_PROP( float4, _OuterColour)
                UNITY_DEFINE_INSTANCED_PROP( float4, _InnerColour)
                UNITY_DEFINE_INSTANCED_PROP( float, _Brightness)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float _Brightness_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Brightness );
                float4 _OuterColour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OuterColour );
                float4 _InnerColour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _InnerColour );
                float _DistortionIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DistortionIntensity );
                float4 node_9487 = _Time;
                float _node_8896_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896 );
                float _node_8896_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896_copy );
                float _node_8896_copy_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896_copy_copy );
                float _node_8896_copy_copy_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896_copy_copy_copy );
                float2 node_1612 = ((node_9487.g*float2(_node_8896_var,_node_8896_copy_var))+(i.uv0*float2(_node_8896_copy_copy_var,_node_8896_copy_copy_copy_var)));
                float4 node_8637 = tex2D(_MainTex,TRANSFORM_TEX(node_1612, _MainTex));
                float2 node_806 = (i.uv0+(_DistortionIntensity_var*(node_8637.b*2.0+-1.0)));
                float4 node_7928 = tex2D(_MainTex,TRANSFORM_TEX(node_806, _MainTex));
                float3 emissive = (_Brightness_var*lerp(_OuterColour_var.rgb,_InnerColour_var.rgb,node_7928.g));
                float3 finalColor = emissive;
                float _node_265_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_265 );
                float _node_4124_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_4124 );
                float _Thickness_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Thickness );
                float4 node_7275 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                fixed4 finalRGBA = fixed4(finalColor,((saturate(((_Thickness_var*node_7275.a*node_7928.r)-node_7928.b))-_node_265_var)/((_node_265_var+_node_4124_var)-_node_265_var)));
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
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
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896_copy_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _node_8896_copy_copy_copy)
                UNITY_DEFINE_INSTANCED_PROP( float, _DistortionIntensity)
                UNITY_DEFINE_INSTANCED_PROP( float4, _OuterColour)
                UNITY_DEFINE_INSTANCED_PROP( float4, _InnerColour)
                UNITY_DEFINE_INSTANCED_PROP( float, _Brightness)
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float _Brightness_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Brightness );
                float4 _OuterColour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _OuterColour );
                float4 _InnerColour_var = UNITY_ACCESS_INSTANCED_PROP( Props, _InnerColour );
                float _DistortionIntensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DistortionIntensity );
                float4 node_9487 = _Time;
                float _node_8896_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896 );
                float _node_8896_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896_copy );
                float _node_8896_copy_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896_copy_copy );
                float _node_8896_copy_copy_copy_var = UNITY_ACCESS_INSTANCED_PROP( Props, _node_8896_copy_copy_copy );
                float2 node_1612 = ((node_9487.g*float2(_node_8896_var,_node_8896_copy_var))+(i.uv0*float2(_node_8896_copy_copy_var,_node_8896_copy_copy_copy_var)));
                float4 node_8637 = tex2D(_MainTex,TRANSFORM_TEX(node_1612, _MainTex));
                float2 node_806 = (i.uv0+(_DistortionIntensity_var*(node_8637.b*2.0+-1.0)));
                float4 node_7928 = tex2D(_MainTex,TRANSFORM_TEX(node_806, _MainTex));
                o.Emission = (_Brightness_var*lerp(_OuterColour_var.rgb,_InnerColour_var.rgb,node_7928.g));
                
                float3 diffColor = float3(0,0,0);
                float specularMonochrome;
                float3 specColor;
                diffColor = DiffuseAndSpecularFromMetallic( diffColor, 0, specColor, specularMonochrome );
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
