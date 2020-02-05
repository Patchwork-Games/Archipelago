// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33773,y:32958,varname:node_3138,prsc:2|emission-2454-OUT;n:type:ShaderForge.SFN_TexCoord,id:2153,x:31445,y:32839,varname:node_2153,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:3780,x:31636,y:32839,varname:node_3780,prsc:2,spu:0.05,spv:0.05|UVIN-2153-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:4443,x:31808,y:32839,ptovrint:False,ptlb:Noise G,ptin:_NoiseG,varname:node_4443,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a73f386972dc12a41864b119f519f1cc,ntxv:0,isnm:False|UVIN-3780-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:9328,x:31991,y:32839,varname:node_9328,prsc:2,frmn:0,frmx:1,tomn:0,tomx:0.1|IN-4443-G;n:type:ShaderForge.SFN_Add,id:5068,x:32195,y:32839,varname:node_5068,prsc:2|A-9328-OUT,B-3810-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4688,x:32697,y:32596,ptovrint:False,ptlb:node_4688,ptin:_node_4688,varname:node_4688,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:6af2a6a1d3487d14f847669569e5bfff,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4828,x:32740,y:32843,varname:node_4828,prsc:2,tex:6af2a6a1d3487d14f847669569e5bfff,ntxv:0,isnm:False|UVIN-3795-OUT,TEX-4688-TEX;n:type:ShaderForge.SFN_Subtract,id:2240,x:32940,y:32843,varname:node_2240,prsc:2|A-4828-RGB,B-4594-OUT;n:type:ShaderForge.SFN_Multiply,id:9493,x:33169,y:32843,varname:node_9493,prsc:2|A-2240-OUT,B-2412-OUT;n:type:ShaderForge.SFN_Multiply,id:2454,x:33341,y:33044,varname:node_2454,prsc:2|A-9493-OUT,B-1839-A;n:type:ShaderForge.SFN_Multiply,id:3810,x:31970,y:33073,varname:node_3810,prsc:2|A-2153-UVOUT,B-1736-OUT;n:type:ShaderForge.SFN_Vector1,id:1736,x:31782,y:33157,varname:node_1736,prsc:2,v1:0.5;n:type:ShaderForge.SFN_VertexColor,id:1839,x:33193,y:33227,varname:node_1839,prsc:2;n:type:ShaderForge.SFN_Slider,id:4501,x:32536,y:33204,ptovrint:False,ptlb:Thickness,ptin:_Thickness,varname:node_4501,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6837607,max:1;n:type:ShaderForge.SFN_Slider,id:2412,x:32562,y:33351,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_2412,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3333333,max:1;n:type:ShaderForge.SFN_OneMinus,id:4594,x:32868,y:33108,varname:node_4594,prsc:2|IN-4501-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:6635,x:31171,y:33721,varname:node_6635,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5633,x:31715,y:33581,varname:node_5633,prsc:2|A-5868-OUT,B-8795-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8795,x:31478,y:33918,ptovrint:False,ptlb:Normal Tile,ptin:_NormalTile,varname:node_7037,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Append,id:5868,x:31383,y:33721,varname:node_5868,prsc:2|A-6635-X,B-6635-Z;n:type:ShaderForge.SFN_Add,id:3795,x:32536,y:32945,varname:node_3795,prsc:2|A-3068-UVOUT,B-5633-OUT;n:type:ShaderForge.SFN_Panner,id:3068,x:32380,y:32839,varname:node_3068,prsc:2,spu:0.01,spv:-0.1|UVIN-5068-OUT;proporder:4443-4688-4501-2412-8795;pass:END;sub:END;*/

Shader "Shader Forge/Caustics" {
    Properties {
        _NoiseG ("Noise G", 2D) = "white" {}
        _node_4688 ("node_4688", 2D) = "white" {}
        _Thickness ("Thickness", Range(0, 1)) = 0.6837607
        _Opacity ("Opacity", Range(0, 1)) = 0.3333333
        _NormalTile ("Normal Tile", Float ) = 1
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
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma target 3.0
            uniform sampler2D _NoiseG; uniform float4 _NoiseG_ST;
            uniform sampler2D _node_4688; uniform float4 _node_4688_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Thickness)
                UNITY_DEFINE_INSTANCED_PROP( float, _Opacity)
                UNITY_DEFINE_INSTANCED_PROP( float, _NormalTile)
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
                float4 node_3833 = _Time;
                float2 node_3780 = (i.uv0+node_3833.g*float2(0.05,0.05));
                float4 _NoiseG_var = tex2D(_NoiseG,TRANSFORM_TEX(node_3780, _NoiseG));
                float _NormalTile_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NormalTile );
                float2 node_3795 = ((((_NoiseG_var.g*0.1+0.0)+(i.uv0*0.5))+node_3833.g*float2(0.01,-0.1))+(float2(i.posWorld.r,i.posWorld.b)*_NormalTile_var));
                float4 node_4828 = tex2D(_node_4688,TRANSFORM_TEX(node_3795, _node_4688));
                float _Thickness_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Thickness );
                float _Opacity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Opacity );
                float3 emissive = (((node_4828.rgb-(1.0 - _Thickness_var))*_Opacity_var)*i.vertexColor.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
