// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|diff-345-OUT,emission-7608-OUT,alpha-8615-A,clip-8615-A,voffset-8533-OUT;n:type:ShaderForge.SFN_Color,id:6617,x:32091,y:32577,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_6617,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1798683,c2:0.6516378,c3:0.8113208,c4:1;n:type:ShaderForge.SFN_Multiply,id:345,x:32361,y:32677,varname:node_345,prsc:2|A-6617-RGB,B-8090-RGB;n:type:ShaderForge.SFN_Time,id:452,x:31312,y:32976,varname:node_452,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6135,x:31589,y:33022,varname:node_6135,prsc:2|A-452-TSL,B-9082-OUT;n:type:ShaderForge.SFN_Slider,id:9082,x:31157,y:33258,ptovrint:False,ptlb:WaveSpeed,ptin:_WaveSpeed,varname:node_9082,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.991327,max:10;n:type:ShaderForge.SFN_TexCoord,id:7096,x:31545,y:32758,varname:node_7096,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:19,x:31785,y:32977,varname:node_19,prsc:2,spu:1,spv:1|UVIN-7096-UVOUT,DIST-6135-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:7534,x:31524,y:33442,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:node_7534,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:dffef66376be4fa480fb02b19edbe903,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8090,x:31639,y:33263,varname:node_8090,prsc:2,tex:dffef66376be4fa480fb02b19edbe903,ntxv:0,isnm:False|UVIN-19-UVOUT,TEX-7534-TEX;n:type:ShaderForge.SFN_NormalVector,id:1022,x:32050,y:33269,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:8835,x:32005,y:33569,ptovrint:False,ptlb:Amplitude,ptin:_Amplitude,varname:node_8835,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4017099,max:10;n:type:ShaderForge.SFN_Slider,id:9477,x:31912,y:32937,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_9477,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.470086,max:1;n:type:ShaderForge.SFN_Multiply,id:7608,x:32390,y:33015,varname:node_7608,prsc:2|A-9477-OUT,B-8090-RGB,C-6617-RGB;n:type:ShaderForge.SFN_Multiply,id:8533,x:32425,y:33313,varname:node_8533,prsc:2|A-8090-RGB,B-1022-OUT,C-8835-OUT;n:type:ShaderForge.SFN_Slider,id:1783,x:32280,y:33168,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_1783,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:8615,x:32695,y:33332,ptovrint:False,ptlb:node_8615,ptin:_node_8615,varname:node_8615,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0000000000000000f000000000000000,ntxv:0,isnm:False;proporder:6617-9082-7534-9477-8835-1783-8615;pass:END;sub:END;*/

Shader "Shader Forge/FogShader" {
    Properties {
        _Color ("Color", Color) = (0.1798683,0.6516378,0.8113208,1)
        _WaveSpeed ("WaveSpeed", Range(0, 10)) = 1.991327
        _Noise ("Noise", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 1)) = 0.470086
        _Amplitude ("Amplitude", Range(0, 10)) = 0.4017099
        _Opacity ("Opacity", Range(0, 1)) = 0
        _node_8615 ("node_8615", 2D) = "white" {}
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
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _node_8615; uniform float4 _node_8615_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _Amplitude)
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
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_452 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float2 node_19 = (o.uv0+(node_452.r*_WaveSpeed_var)*float2(1,1));
                float4 node_8090 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_19, _Noise),0.0,0));
                float _Amplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Amplitude );
                v.vertex.xyz += (node_8090.rgb*v.normal*_Amplitude_var);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _node_8615_var = tex2D(_node_8615,TRANSFORM_TEX(i.uv0, _node_8615));
                clip(_node_8615_var.a - 0.5);
////// Lighting:
////// Emissive:
                float _Brightness_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Brightness );
                float4 node_452 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float2 node_19 = (i.uv0+(node_452.r*_WaveSpeed_var)*float2(1,1));
                float4 node_8090 = tex2D(_Noise,TRANSFORM_TEX(node_19, _Noise));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 emissive = (_Brightness_var*node_8090.rgb*_Color_var.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,_node_8615_var.a);
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
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform sampler2D _node_8615; uniform float4 _node_8615_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _Amplitude)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_452 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float2 node_19 = (o.uv0+(node_452.r*_WaveSpeed_var)*float2(1,1));
                float4 node_8090 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_19, _Noise),0.0,0));
                float _Amplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Amplitude );
                v.vertex.xyz += (node_8090.rgb*v.normal*_Amplitude_var);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _node_8615_var = tex2D(_node_8615,TRANSFORM_TEX(i.uv0, _node_8615));
                clip(_node_8615_var.a - 0.5);
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
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _Amplitude)
                UNITY_DEFINE_INSTANCED_PROP( float, _Brightness)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_452 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float2 node_19 = (o.uv0+(node_452.r*_WaveSpeed_var)*float2(1,1));
                float4 node_8090 = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_19, _Noise),0.0,0));
                float _Amplitude_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Amplitude );
                v.vertex.xyz += (node_8090.rgb*v.normal*_Amplitude_var);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float _Brightness_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Brightness );
                float4 node_452 = _Time;
                float _WaveSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpeed );
                float2 node_19 = (i.uv0+(node_452.r*_WaveSpeed_var)*float2(1,1));
                float4 node_8090 = tex2D(_Noise,TRANSFORM_TEX(node_19, _Noise));
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                o.Emission = (_Brightness_var*node_8090.rgb*_Color_var.rgb);
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
