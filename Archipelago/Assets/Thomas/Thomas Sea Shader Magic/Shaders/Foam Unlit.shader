// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-9405-RGB,alpha-2433-OUT;n:type:ShaderForge.SFN_Color,id:9405,x:31841,y:32683,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_TexCoord,id:341,x:30761,y:32813,varname:node_341,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:1077,x:30946,y:32926,varname:node_1077,prsc:2|A-341-V,B-3554-OUT;n:type:ShaderForge.SFN_Append,id:5205,x:31223,y:32800,varname:node_5205,prsc:2|A-341-U,B-1077-OUT;n:type:ShaderForge.SFN_Panner,id:9543,x:31471,y:32834,varname:node_9543,prsc:2,spu:0,spv:0.07|UVIN-5205-OUT;n:type:ShaderForge.SFN_Multiply,id:6306,x:32184,y:32964,varname:node_6306,prsc:2|A-3016-R,B-4190-A;n:type:ShaderForge.SFN_Subtract,id:2433,x:32415,y:32964,varname:node_2433,prsc:2|A-6306-OUT,B-6836-OUT;n:type:ShaderForge.SFN_Vector1,id:6836,x:32382,y:33340,varname:node_6836,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:3554,x:30783,y:32993,varname:node_3554,prsc:2,v1:1;n:type:ShaderForge.SFN_VertexColor,id:4190,x:31984,y:33175,varname:node_4190,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:6496,x:31426,y:33213,ptovrint:False,ptlb:Noise G,ptin:_NoiseG,varname:node_4443,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a73f386972dc12a41864b119f519f1cc,ntxv:0,isnm:False|UVIN-9543-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:9655,x:31609,y:33213,varname:node_9655,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-6496-G;n:type:ShaderForge.SFN_Add,id:552,x:31760,y:33213,varname:node_552,prsc:2|A-9655-OUT,B-1787-OUT;n:type:ShaderForge.SFN_Multiply,id:1787,x:31588,y:33447,varname:node_1787,prsc:2|A-341-UVOUT,B-7532-OUT;n:type:ShaderForge.SFN_Vector1,id:7532,x:31400,y:33533,varname:node_7532,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Panner,id:2555,x:31722,y:32834,varname:node_2555,prsc:2,spu:0,spv:0.03|UVIN-552-OUT;n:type:ShaderForge.SFN_Slider,id:5997,x:31847,y:33547,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_4501,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6837607,max:1;n:type:ShaderForge.SFN_Slider,id:257,x:31873,y:33694,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_2412,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3333333,max:1;n:type:ShaderForge.SFN_FragmentPosition,id:8179,x:30496,y:33233,varname:node_8179,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4994,x:31087,y:33241,varname:node_4994,prsc:2|A-6979-OUT,B-7663-OUT;n:type:ShaderForge.SFN_Append,id:6979,x:30708,y:33233,varname:node_6979,prsc:2|A-8179-X,B-8179-Z;n:type:ShaderForge.SFN_Add,id:6841,x:31984,y:32998,varname:node_6841,prsc:2|A-552-OUT,B-4994-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7663,x:30770,y:33379,ptovrint:False,ptlb:VALUE,ptin:_VALUE,varname:node_7663,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Tex2d,id:3016,x:32019,y:32784,ptovrint:False,ptlb:node_3016,ptin:_node_3016,varname:node_3016,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6af2a6a1d3487d14f847669569e5bfff,ntxv:0,isnm:False|UVIN-6841-OUT;proporder:9405-6496-5997-7663-3016;pass:END;sub:END;*/

Shader "Shader Forge/Foam Unlit" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _NoiseG ("Noise G", 2D) = "white" {}
        _Thickness ("Thickness", Range(0, 1)) = 0.6837607
        _VALUE ("VALUE", Float ) = 1
        _node_3016 ("node_3016", 2D) = "white" {}
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
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _NoiseG; uniform float4 _NoiseG_ST;
            uniform sampler2D _node_3016; uniform float4 _node_3016_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _VALUE)
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
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float3 emissive = _Color_var.rgb;
                float3 finalColor = emissive;
                float4 node_2724 = _Time;
                float2 node_9543 = (float2(i.uv0.r,(i.uv0.g+1.0))+node_2724.g*float2(0,0.07));
                float4 _NoiseG_var = tex2D(_NoiseG,TRANSFORM_TEX(node_9543, _NoiseG));
                float2 node_552 = ((_NoiseG_var.g*0.1+0.0)+(i.uv0*0.5));
                float _VALUE_var = UNITY_ACCESS_INSTANCED_PROP( Props, _VALUE );
                float2 node_6841 = (node_552+(float2(i.posWorld.r,i.posWorld.b)*_VALUE_var));
                float4 _node_3016_var = tex2D(_node_3016,TRANSFORM_TEX(node_6841, _node_3016));
                return fixed4(finalColor,((_node_3016_var.r*i.vertexColor.a)-0.0));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
