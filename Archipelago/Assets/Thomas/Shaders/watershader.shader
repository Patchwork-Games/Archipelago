// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:3,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:34681,y:33269,varname:node_2865,prsc:2|diff-9978-OUT,spec-358-OUT,gloss-1813-OUT,alpha-1243-OUT,voffset-7107-OUT,tess-3757-OUT;n:type:ShaderForge.SFN_Color,id:6665,x:31455,y:32369,ptovrint:False,ptlb:ColourB,ptin:_ColourB,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6792453,c2:0.1057316,c3:0.1057316,c4:1;n:type:ShaderForge.SFN_Slider,id:358,x:32715,y:32658,ptovrint:False,ptlb:Metallic,ptin:_Metallic,varname:node_358,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:1813,x:32733,y:32754,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Metallic_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8,max:1;n:type:ShaderForge.SFN_Color,id:6735,x:31455,y:32214,ptovrint:False,ptlb:ColourA,ptin:_ColourA,varname:node_6735,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.2142716,c2:0.2124421,c3:0.5849056,c4:1;n:type:ShaderForge.SFN_Lerp,id:2195,x:31961,y:32227,varname:node_2195,prsc:2|A-6735-RGB,B-6665-RGB,T-5058-OUT;n:type:ShaderForge.SFN_Divide,id:3624,x:31503,y:33291,varname:node_3624,prsc:2|A-1290-OUT,B-2994-OUT;n:type:ShaderForge.SFN_DepthBlend,id:1290,x:31123,y:33164,varname:node_1290,prsc:2|DIST-2498-OUT;n:type:ShaderForge.SFN_ViewVector,id:5987,x:30953,y:33560,varname:node_5987,prsc:2;n:type:ShaderForge.SFN_Dot,id:2994,x:31259,y:33528,varname:node_2994,prsc:2,dt:4|A-5987-OUT,B-7634-OUT;n:type:ShaderForge.SFN_NormalVector,id:7634,x:30953,y:33693,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:5890,x:31663,y:32936,ptovrint:False,ptlb:FoamMin,ptin:_FoamMin,varname:node_5890,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:61,x:31663,y:33034,ptovrint:False,ptlb:FoamMax,ptin:_FoamMax,varname:node_61,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3283,x:31994,y:33034,varname:node_3283,prsc:2|IN-5058-OUT,IMIN-5890-OUT,IMAX-61-OUT,OMIN-6811-OUT,OMAX-1971-OUT;n:type:ShaderForge.SFN_Vector1,id:1971,x:31682,y:33190,varname:node_1971,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6811,x:31682,y:33129,varname:node_6811,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:8897,x:32211,y:33292,varname:node_8897,prsc:2|IN-5058-OUT,IMIN-534-OUT,IMAX-3586-OUT,OMIN-2577-OUT,OMAX-1495-OUT;n:type:ShaderForge.SFN_Slider,id:534,x:31745,y:33528,ptovrint:False,ptlb:DepthMin,ptin:_DepthMin,varname:node_534,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Slider,id:3586,x:31745,y:33616,ptovrint:False,ptlb:DepthMax,ptin:_DepthMax,varname:_node_534_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:2577,x:31872,y:33749,varname:node_2577,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1495,x:31872,y:33810,varname:node_1495,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:7219,x:32138,y:33034,varname:node_7219,prsc:2|IN-3283-OUT;n:type:ShaderForge.SFN_Clamp01,id:5058,x:31717,y:33309,varname:node_5058,prsc:2|IN-3624-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4804,x:32601,y:33030,varname:node_4804,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1485-OUT;n:type:ShaderForge.SFN_Multiply,id:7356,x:32747,y:33061,varname:node_7356,prsc:2|A-4804-OUT,B-9236-OUT;n:type:ShaderForge.SFN_Vector1,id:9236,x:32432,y:33209,varname:node_9236,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:1243,x:33300,y:33110,varname:node_1243,prsc:2|IN-8446-OUT;n:type:ShaderForge.SFN_Multiply,id:1180,x:32215,y:32859,varname:node_1180,prsc:2|A-6440-OUT,B-6054-OUT;n:type:ShaderForge.SFN_Clamp01,id:1485,x:32398,y:32859,varname:node_1485,prsc:2|IN-1180-OUT;n:type:ShaderForge.SFN_Add,id:8915,x:32390,y:32345,varname:node_8915,prsc:2|A-2195-OUT,B-1485-OUT;n:type:ShaderForge.SFN_Clamp01,id:9978,x:32574,y:32345,varname:node_9978,prsc:2|IN-8915-OUT;n:type:ShaderForge.SFN_Add,id:8446,x:32971,y:33187,varname:node_8446,prsc:2|A-7356-OUT,B-8897-OUT;n:type:ShaderForge.SFN_OneMinus,id:6054,x:32317,y:33034,varname:node_6054,prsc:2|IN-7219-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6440,x:32021,y:32684,ptovrint:False,ptlb:FoamPower,ptin:_FoamPower,varname:node_6440,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:8;n:type:ShaderForge.SFN_ValueProperty,id:2498,x:30778,y:33363,ptovrint:False,ptlb:DepthValue,ptin:_DepthValue,varname:node_2498,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Slider,id:3757,x:32991,y:33497,ptovrint:False,ptlb:Tesselation,ptin:_Tesselation,varname:node_3757,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Tex2d,id:3793,x:32956,y:33765,ptovrint:False,ptlb:distort,ptin:_distort,varname:node_3793,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:08e1a5ff1865ef84ebbd24b543808f9a,ntxv:3,isnm:True|UVIN-576-UVOUT;n:type:ShaderForge.SFN_Panner,id:576,x:32739,y:33765,varname:node_576,prsc:2,spu:0.5,spv:0.5|UVIN-7225-UVOUT,DIST-1755-TSL;n:type:ShaderForge.SFN_Time,id:1755,x:32393,y:33863,varname:node_1755,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:7225,x:32393,y:33660,varname:node_7225,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_FragmentPosition,id:3610,x:32393,y:34060,varname:node_3610,prsc:2;n:type:ShaderForge.SFN_Add,id:6005,x:32590,y:34060,varname:node_6005,prsc:2|A-3610-X,B-1755-TSL;n:type:ShaderForge.SFN_Multiply,id:1336,x:32781,y:34060,varname:node_1336,prsc:2|A-6005-OUT,B-9885-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9885,x:32576,y:34282,ptovrint:False,ptlb:WaveCount,ptin:_WaveCount,varname:node_9885,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Sin,id:4244,x:32985,y:34060,varname:node_4244,prsc:2|IN-1336-OUT;n:type:ShaderForge.SFN_Multiply,id:6346,x:33202,y:34060,varname:node_6346,prsc:2|A-4244-OUT,B-328-OUT;n:type:ShaderForge.SFN_Add,id:9092,x:33402,y:34060,varname:node_9092,prsc:2|A-6346-OUT,B-7220-OUT;n:type:ShaderForge.SFN_RemapRange,id:4445,x:33585,y:34060,varname:node_4445,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-9092-OUT;n:type:ShaderForge.SFN_ValueProperty,id:328,x:33063,y:34274,ptovrint:False,ptlb:WaveSpread,ptin:_WaveSpread,varname:_WaveCount_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.3;n:type:ShaderForge.SFN_ValueProperty,id:7220,x:33306,y:34274,ptovrint:False,ptlb:WaveWidth,ptin:_WaveWidth,varname:_WaveCount_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;n:type:ShaderForge.SFN_Multiply,id:928,x:33690,y:33864,varname:node_928,prsc:2|A-3793-R,B-4445-OUT;n:type:ShaderForge.SFN_Multiply,id:9720,x:34025,y:33989,varname:node_9720,prsc:2|A-928-OUT,B-8739-OUT;n:type:ShaderForge.SFN_Slider,id:8739,x:33719,y:34238,ptovrint:False,ptlb:Waveheight,ptin:_Waveheight,varname:node_8739,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Vector1,id:7248,x:34017,y:33760,varname:node_7248,prsc:2,v1:0;n:type:ShaderForge.SFN_Append,id:118,x:34226,y:33923,varname:node_118,prsc:2|A-7248-OUT,B-9720-OUT;n:type:ShaderForge.SFN_Append,id:7107,x:34453,y:33923,varname:node_7107,prsc:2|A-118-OUT,B-9604-OUT;n:type:ShaderForge.SFN_Vector1,id:9604,x:34260,y:34086,varname:node_9604,prsc:2,v1:0;proporder:6665-358-1813-6735-5890-61-534-3586-6440-2498-3757-3793-9885-328-7220-8739;pass:END;sub:END;*/

Shader "Shader Forge/watershader" {
    Properties {
        _ColourB ("ColourB", Color) = (0.6792453,0.1057316,0.1057316,1)
        _Metallic ("Metallic", Range(0, 1)) = 0
        _Gloss ("Gloss", Range(0, 1)) = 0.8
        _ColourA ("ColourA", Color) = (0.2142716,0.2124421,0.5849056,1)
        _FoamMin ("FoamMin", Range(0, 1)) = 0
        _FoamMax ("FoamMax", Range(0, 1)) = 1
        _DepthMin ("DepthMin", Range(0, 1)) = 0
        _DepthMax ("DepthMax", Range(0, 1)) = 1
        _FoamPower ("FoamPower", Float ) = 8
        _DepthValue ("DepthValue", Float ) = 10
        _Tesselation ("Tesselation", Range(0, 10)) = 1
        _distort ("distort", 2D) = "bump" {}
        _WaveCount ("WaveCount", Float ) = 10
        _WaveSpread ("WaveSpread", Float ) = 0.3
        _WaveWidth ("WaveWidth", Float ) = 10
        _Waveheight ("Waveheight", Range(0, 1)) = 0.5
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
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _distort; uniform float4 _distort_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourB)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourA)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamMin)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamMax)
                UNITY_DEFINE_INSTANCED_PROP( float, _DepthMin)
                UNITY_DEFINE_INSTANCED_PROP( float, _DepthMax)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _DepthValue)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tesselation)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveCount)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpread)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveWidth)
                UNITY_DEFINE_INSTANCED_PROP( float, _Waveheight)
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
                float4 projPos : TEXCOORD7;
                UNITY_FOG_COORDS(8)
                #if defined(LIGHTMAP_ON) || defined(UNITY_SHOULD_SAMPLE_SH)
                    float4 ambientOrLightmapUV : TEXCOORD9;
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
                float4 node_1755 = _Time;
                float2 node_576 = (o.uv0+node_1755.r*float2(0.5,0.5));
                float3 _distort_var = UnpackNormal(tex2Dlod(_distort,float4(TRANSFORM_TEX(node_576, _distort),0.0,0)));
                float _WaveCount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveCount );
                float _WaveSpread_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpread );
                float _WaveWidth_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveWidth );
                float _Waveheight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Waveheight );
                v.vertex.xyz += float3(float2(0.0,((_distort_var.r*(((sin(((mul(unity_ObjectToWorld, v.vertex).r+node_1755.r)*_WaveCount_var))*_WaveSpread_var)+_WaveWidth_var)*0.5+0.5))*_Waveheight_var)),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float _Tesselation_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tesselation );
                    return _Tesselation_var;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
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
                float _DepthValue_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DepthValue );
                float node_5058 = saturate((saturate((sceneZ-partZ)/_DepthValue_var)/0.5*dot(viewDirection,i.normalDir)+0.5));
                float _FoamPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamPower );
                float _FoamMin_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamMin );
                float _FoamMax_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamMax );
                float node_6811 = 0.0;
                float node_1485 = saturate((_FoamPower_var*(1.0 - saturate((node_6811 + ( (node_5058 - _FoamMin_var) * (1.0 - node_6811) ) / (_FoamMax_var - _FoamMin_var))))));
                float3 diffuseColor = saturate((lerp(_ColourA_var.rgb,_ColourB_var.rgb,node_5058)+node_1485)); // Need this for specular when using metallic
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
                float _DepthMin_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DepthMin );
                float _DepthMax_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DepthMax );
                float node_2577 = 0.0;
                fixed4 finalRGBA = fixed4(finalColor,saturate(((node_1485.r*0.5)+(node_2577 + ( (node_5058 - _DepthMin_var) * (1.0 - node_2577) ) / (_DepthMax_var - _DepthMin_var)))));
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _distort; uniform float4 _distort_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourB)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourA)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamMin)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamMax)
                UNITY_DEFINE_INSTANCED_PROP( float, _DepthMin)
                UNITY_DEFINE_INSTANCED_PROP( float, _DepthMax)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _DepthValue)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tesselation)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveCount)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpread)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveWidth)
                UNITY_DEFINE_INSTANCED_PROP( float, _Waveheight)
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
                float4 projPos : TEXCOORD7;
                LIGHTING_COORDS(8,9)
                UNITY_FOG_COORDS(10)
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
                float4 node_1755 = _Time;
                float2 node_576 = (o.uv0+node_1755.r*float2(0.5,0.5));
                float3 _distort_var = UnpackNormal(tex2Dlod(_distort,float4(TRANSFORM_TEX(node_576, _distort),0.0,0)));
                float _WaveCount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveCount );
                float _WaveSpread_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpread );
                float _WaveWidth_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveWidth );
                float _Waveheight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Waveheight );
                v.vertex.xyz += float3(float2(0.0,((_distort_var.r*(((sin(((mul(unity_ObjectToWorld, v.vertex).r+node_1755.r)*_WaveCount_var))*_WaveSpread_var)+_WaveWidth_var)*0.5+0.5))*_Waveheight_var)),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float _Tesselation_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tesselation );
                    return _Tesselation_var;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
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
                float _DepthValue_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DepthValue );
                float node_5058 = saturate((saturate((sceneZ-partZ)/_DepthValue_var)/0.5*dot(viewDirection,i.normalDir)+0.5));
                float _FoamPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamPower );
                float _FoamMin_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamMin );
                float _FoamMax_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamMax );
                float node_6811 = 0.0;
                float node_1485 = saturate((_FoamPower_var*(1.0 - saturate((node_6811 + ( (node_5058 - _FoamMin_var) * (1.0 - node_6811) ) / (_FoamMax_var - _FoamMin_var))))));
                float3 diffuseColor = saturate((lerp(_ColourA_var.rgb,_ColourB_var.rgb,node_5058)+node_1485)); // Need this for specular when using metallic
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
                float _DepthMin_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DepthMin );
                float _DepthMax_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DepthMax );
                float node_2577 = 0.0;
                fixed4 finalRGBA = fixed4(finalColor * saturate(((node_1485.r*0.5)+(node_2577 + ( (node_5058 - _DepthMin_var) * (1.0 - node_2577) ) / (_DepthMax_var - _DepthMin_var)))),0);
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform sampler2D _distort; uniform float4 _distort_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Tesselation)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveCount)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpread)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveWidth)
                UNITY_DEFINE_INSTANCED_PROP( float, _Waveheight)
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
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float2 uv1 : TEXCOORD2;
                float2 uv2 : TEXCOORD3;
                float4 posWorld : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                float4 node_1755 = _Time;
                float2 node_576 = (o.uv0+node_1755.r*float2(0.5,0.5));
                float3 _distort_var = UnpackNormal(tex2Dlod(_distort,float4(TRANSFORM_TEX(node_576, _distort),0.0,0)));
                float _WaveCount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveCount );
                float _WaveSpread_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpread );
                float _WaveWidth_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveWidth );
                float _Waveheight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Waveheight );
                v.vertex.xyz += float3(float2(0.0,((_distort_var.r*(((sin(((mul(unity_ObjectToWorld, v.vertex).r+node_1755.r)*_WaveCount_var))*_WaveSpread_var)+_WaveWidth_var)*0.5+0.5))*_Waveheight_var)),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float _Tesselation_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tesselation );
                    return _Tesselation_var;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
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
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define SHOULD_SAMPLE_SH ( defined (LIGHTMAP_OFF) && defined(DYNAMICLIGHTMAP_OFF) )
            #define _GLOSSYENV 1
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile LIGHTMAP_OFF LIGHTMAP_ON
            #pragma multi_compile DIRLIGHTMAP_OFF DIRLIGHTMAP_COMBINED DIRLIGHTMAP_SEPARATE
            #pragma multi_compile DYNAMICLIGHTMAP_OFF DYNAMICLIGHTMAP_ON
            #pragma multi_compile_fog
            #pragma target 5.0
            uniform sampler2D _CameraDepthTexture;
            uniform sampler2D _distort; uniform float4 _distort_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourB)
                UNITY_DEFINE_INSTANCED_PROP( float, _Metallic)
                UNITY_DEFINE_INSTANCED_PROP( float, _Gloss)
                UNITY_DEFINE_INSTANCED_PROP( float4, _ColourA)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamMin)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamMax)
                UNITY_DEFINE_INSTANCED_PROP( float, _FoamPower)
                UNITY_DEFINE_INSTANCED_PROP( float, _DepthValue)
                UNITY_DEFINE_INSTANCED_PROP( float, _Tesselation)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveCount)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveSpread)
                UNITY_DEFINE_INSTANCED_PROP( float, _WaveWidth)
                UNITY_DEFINE_INSTANCED_PROP( float, _Waveheight)
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
                float4 projPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.uv2 = v.texcoord2;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 node_1755 = _Time;
                float2 node_576 = (o.uv0+node_1755.r*float2(0.5,0.5));
                float3 _distort_var = UnpackNormal(tex2Dlod(_distort,float4(TRANSFORM_TEX(node_576, _distort),0.0,0)));
                float _WaveCount_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveCount );
                float _WaveSpread_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveSpread );
                float _WaveWidth_var = UNITY_ACCESS_INSTANCED_PROP( Props, _WaveWidth );
                float _Waveheight_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Waveheight );
                v.vertex.xyz += float3(float2(0.0,((_distort_var.r*(((sin(((mul(unity_ObjectToWorld, v.vertex).r+node_1755.r)*_WaveCount_var))*_WaveSpread_var)+_WaveWidth_var)*0.5+0.5))*_Waveheight_var)),0.0);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                    float2 texcoord1 : TEXCOORD1;
                    float2 texcoord2 : TEXCOORD2;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    o.texcoord1 = v.texcoord1;
                    o.texcoord2 = v.texcoord2;
                    return o;
                }
                float Tessellation(TessVertex v){
                    float _Tesselation_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Tesselation );
                    return _Tesselation_var;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    v.texcoord1 = vi[0].texcoord1*bary.x + vi[1].texcoord1*bary.y + vi[2].texcoord1*bary.z;
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : SV_Target {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = 0;
                
                float4 _ColourA_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourA );
                float4 _ColourB_var = UNITY_ACCESS_INSTANCED_PROP( Props, _ColourB );
                float _DepthValue_var = UNITY_ACCESS_INSTANCED_PROP( Props, _DepthValue );
                float node_5058 = saturate((saturate((sceneZ-partZ)/_DepthValue_var)/0.5*dot(viewDirection,i.normalDir)+0.5));
                float _FoamPower_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamPower );
                float _FoamMin_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamMin );
                float _FoamMax_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FoamMax );
                float node_6811 = 0.0;
                float node_1485 = saturate((_FoamPower_var*(1.0 - saturate((node_6811 + ( (node_5058 - _FoamMin_var) * (1.0 - node_6811) ) / (_FoamMax_var - _FoamMin_var))))));
                float3 diffColor = saturate((lerp(_ColourA_var.rgb,_ColourB_var.rgb,node_5058)+node_1485));
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
