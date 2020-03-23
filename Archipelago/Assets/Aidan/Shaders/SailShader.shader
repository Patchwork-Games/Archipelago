// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/SailShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_HeightMap("Height Map", 2D) = "white" {}
		_HeightMapScale("Height", Float) = 1
        _TexSize("Texture Size", Float) = 1
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
		Tags
        { 
            "Queue" = "Transparent"
            "RenderType" = "Opaque" 
        }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert alpha:blend
        #pragma target 5.0

        sampler2D _MainTex;
		sampler2D _HeightMap;

        struct Input
        {
            float2 uv_MainTex;
            float3 normal;
        };

		half _HeightMapScale;
        half _TexSize;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float3 normalsFromHeight(sampler2D heigthTex, float4 uv, float height, float4 vertPos, float distBetweenVerts)
        {
            float4 textureColor;
            float4 adjacentHeightValues;
            float verticesWidth = 1.0f / 21.0f;
            float verticesHeight = 1.0f / 21.0f;

            // Calculate the adjacent height values
            textureColor = tex2Dlod(heigthTex, float4(uv.xy + float2(0, -verticesHeight), 0, 0));
            adjacentHeightValues[0] = textureColor.r * height;

            textureColor = tex2Dlod(heigthTex, float4(uv.xy + float2(verticesHeight, 0), 0, 0));
            adjacentHeightValues[1] = textureColor.r * height;

            textureColor = tex2Dlod(heigthTex, float4(uv.xy + float2(0, verticesHeight), 0, 0));
            adjacentHeightValues[2] = textureColor.r * height;

            textureColor = tex2Dlod(heigthTex, float4(uv.xy + float2(-verticesWidth, 0), 0, 0));
            adjacentHeightValues[3] = textureColor.r * height;

            // Calculate the positions of the surrounding vertices
            /*float3 northPos = float4(vertPos.x, adjacentHeightValues[0], vertPos.z + distBetweenVerts, vertPos.w);
            float3 eastPos = float4(vertPos.x + distBetweenVerts, adjacentHeightValues[1], vertPos.z, vertPos.w);
            float3 southPos = float4(vertPos.x, adjacentHeightValues[2], vertPos.z - distBetweenVerts, vertPos.w);
            float3 westPos = float4(vertPos.x - distBetweenVerts, adjacentHeightValues[3], vertPos.z, vertPos.w);*/

            float3 northPos = float4(vertPos.x, adjacentHeightValues[0], vertPos.z + distBetweenVerts, vertPos.w).xyz;
            float3 eastPos = float4(vertPos.x + distBetweenVerts, adjacentHeightValues[1], vertPos.z, vertPos.w).xyz;
            float3 southPos = float4(vertPos.x, adjacentHeightValues[2], vertPos.z - distBetweenVerts, vertPos.w).xyz;
            float3 westPos = float4(vertPos.x - distBetweenVerts, adjacentHeightValues[3], vertPos.z, vertPos.w).xyz;

            // Calculate the vectors between the surrounding vertices and the current vertex
            float3 northVec = normalize(northPos - vertPos);
            float3 eastVec = normalize(eastPos - vertPos);
            float3 southVec = normalize(southPos - vertPos);
            float3 westVec = normalize(westPos - vertPos);

            // Calculate the cross product of the vectors
            float3 northNormal = normalize(cross(northVec, eastVec));
            float3 eastNormal = normalize(cross(eastVec, southVec));
            float3 southNormal = normalize(cross(southVec, westVec));
            float3 westNormal = normalize(cross(westVec, northVec));

            // Return the average of the normals
            float3 average = (northNormal + eastNormal + southNormal + westNormal) / 4;
            return normalize(average);
        }

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			float4 heightMapColor = tex2Dlod(_HeightMap, float4(v.texcoord.xy + float2(0.2, 0.1), 0, 0));
            float displacement = heightMapColor.r * _HeightMapScale;

            // Output data
            v.vertex.y *= displacement;// +(heightMap.r * 10 * sin(v.vertex.x + _Time[1] * 10) / 10 + (heightMap.r * 10 * sin(v.vertex.z + _Time[1] * 10) / 10));

            float3 nFH = normalsFromHeight(_HeightMap, float4(v.texcoord.xy + float2(0.2, 0.1), 0, 0), _HeightMapScale, v.vertex, 1);
            float3 newNormals = mul(unity_WorldToObject, nFH);
            o.normal = newNormals;
		}

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Normal = normalize(IN.normal.rgb);

            o.Albedo = normalize(IN.normal.rgb);
            //o.Albedo = float3(IN.uv_MainTex, 0);

            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
