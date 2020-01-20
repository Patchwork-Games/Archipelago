// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7532-RGB,clip-7532-A,voffset-9875-OUT;n:type:ShaderForge.SFN_Tex2d,id:7532,x:32064,y:32624,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_6408,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5fa3ee8319821724ea9bb5b7683dbe4f,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:7437,x:31809,y:33104,varname:node_7437,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9875,x:32032,y:33187,varname:node_9875,prsc:2|A-7437-R,B-2793-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8781,x:31178,y:33224,ptovrint:False,ptlb:Intensity,ptin:_Intensity,varname:node_7986,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Time,id:3587,x:31203,y:33693,varname:node_3587,prsc:2;n:type:ShaderForge.SFN_Cos,id:3847,x:31409,y:33693,varname:node_3847,prsc:2|IN-3587-T;n:type:ShaderForge.SFN_TexCoord,id:6932,x:31203,y:33527,varname:node_6932,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_OneMinus,id:9028,x:31409,y:33537,varname:node_9028,prsc:2|IN-6932-V;n:type:ShaderForge.SFN_Multiply,id:6604,x:31606,y:33561,varname:node_6604,prsc:2|A-9028-OUT,B-3847-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:5712,x:30910,y:33334,varname:node_5712,prsc:2;n:type:ShaderForge.SFN_Sin,id:8430,x:31118,y:33346,varname:node_8430,prsc:2|IN-5712-X;n:type:ShaderForge.SFN_Multiply,id:5117,x:31296,y:33365,varname:node_5117,prsc:2|A-8430-OUT,B-6604-OUT;n:type:ShaderForge.SFN_Multiply,id:3699,x:31505,y:33365,varname:node_3699,prsc:2|A-8781-OUT,B-5117-OUT;n:type:ShaderForge.SFN_Append,id:2793,x:31820,y:33291,varname:node_2793,prsc:2|A-3699-OUT,B-8875-OUT,C-3699-OUT;n:type:ShaderForge.SFN_Vector1,id:8875,x:31576,y:33104,varname:node_8875,prsc:2,v1:0;proporder:7532-8781;pass:END;sub:END;*/

Shader "Shader Forge/GrassUnlit" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Intensity ("Intensity", Float ) = 1
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Intensity)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float _Intensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Intensity );
                float4 node_3587 = _Time;
                float node_3699 = (_Intensity_var*(sin(mul(unity_ObjectToWorld, v.vertex).r)*((1.0 - o.uv0.g)*cos(node_3587.g))));
                float3 node_9875 = (o.vertexColor.r*float3(node_3699,0.0,node_3699));
                v.vertex.xyz += float3(node_9875,node_9875,node_9875);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _MainTex_var.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Intensity)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 posWorld : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float _Intensity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Intensity );
                float4 node_3587 = _Time;
                float node_3699 = (_Intensity_var*(sin(mul(unity_ObjectToWorld, v.vertex).r)*((1.0 - o.uv0.g)*cos(node_3587.g))));
                float3 node_9875 = (o.vertexColor.r*float3(node_3699,0.0,node_3699));
                v.vertex.xyz += float3(node_9875,node_9875,node_9875);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(_MainTex_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
