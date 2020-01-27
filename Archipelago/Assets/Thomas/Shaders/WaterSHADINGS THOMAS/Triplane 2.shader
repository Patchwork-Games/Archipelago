Shader "Tri-Planar World" 
{
	Properties
	{

		  _Side("SideFail", 2D) = "white" {}
		  _Top("Top", 2D) = "white" {}
		  _Color("", Color) = (1, 1, 1, 1)
		  _Sand("Sand", 2D) = "white" {}
		  _SandNormal("SandNormal", 2D) = "bump" {}

		  _Bottom("Side", 2D) = "white" {}

		  _SideScale("Side Scale", Float) = 2
		  _SandScale("Sand Scale", Float) = 2
		  _TopScale("Top Scale", Float) = 2
		  _BottomScale("Bottom Scale", Float) = 2

		  _TopAngle("Top Angle", Float) = 0.8
		  _SideAngle("Side Angle", Float) = 0.5

		  _MapScale("", Float) = 1

	}



		SubShader
		{

			Tags 
			{

				"Queue" = "Geometry"

				"IgnoreProjector" = "False"

				"RenderType" = "Opaque"

			}



			Cull Back

			ZWrite On



			CGPROGRAM

			#pragma surface surf Lambert

			#pragma exclude_renderers flash



			sampler2D _Side, _Top, _Bottom, _Sand, _SandNormal;

			float _SideScale, _TopScale, _SandScale, _BottomScale, _SideAngle, _TopAngle;
			half4 _Color;

			sampler _Control2D;

			half _MapScale;

			struct Input 
			{

				float3 worldPos;
				float3 worldNormal;
				float2 uv_BumpMap;
				float3 localCoord;
				float3 localNormal;
				
			};

			fixed4 _MainTex;

			half4 SplitMap(half4 map)
			{
				map.r = step(0.1, map.r - map.g - map.b - map.a);
				map.r = step(0.1, map.g - map.r - map.b - map.a);
				map.r = step(0.1, map.b - map.g - map.r - map.a);
				map.r = step(0.1, map.a - map.g - map.b - map.r);
				return map;
			}

			void surf(Input IN, inout SurfaceOutput o) 
			{

				float3 projNormal = saturate(pow(IN.worldNormal * 1.4, 4));


				float3 x = 0;
				// SIDE X
				if (IN.worldNormal.z > _SideAngle) 
				{
					x = tex2D(_Side, frac(IN.worldPos.zy * _SideScale)) * abs(IN.worldNormal.x);

				}
				else 
				{
					x = tex2D(_Top, frac(IN.worldPos.zy * _SideScale)) * abs(IN.worldNormal.x);
				}

				//Sand
				float3 y = 0;

				
				

				if (IN.worldPos.y < 50)
				{
					
					if (IN.worldNormal.y > _TopAngle)
					{
						y = tex2D(_Sand, frac(IN.worldPos.zx * _TopScale)) * abs(IN.worldNormal.y);
					}
					else if (IN.worldNormal.y < 1)
					{
						y = tex2D(_Bottom, frac(IN.worldPos.zx * _BottomScale)) * abs(IN.worldNormal.y);
					}
				}
				else
				{
					
					if (IN.worldNormal.y > _TopAngle)
					{
						y = tex2D(_Top, frac(IN.worldPos.zx * _TopScale)) * abs(IN.worldNormal.y);
					}
					else if (IN.worldNormal.y < 1)
					{
						y = tex2D(_Bottom, frac(IN.worldPos.zx * _BottomScale)) * abs(IN.worldNormal.y);
					}
				}



				// SIDE Z	

				float3 z = tex2D(_Side, frac(IN.worldPos.xy * _SideScale)) * abs(IN.worldNormal.z);


				//o.Albedo = z;

				//o.Albedo = saturate(z, x);// lerp(o.Albedo, x, projNormal.x);

				//o.Albedo = saturate(o.Albedo, y);// lerp(o.Albedo, y, projNormal.y);

				o.Albedo = y;// saturate(y);// saturate(finalColour);

				fixed4 c = fixed4(1,1,1,.1f);
				o.Alpha = c.a;
				//o.Normal = UnpackNormal(tex2D (_SandNormal, IN.uv_BumpMap));




				// Blending factor of triplanar mapping
				float3 bf = normalize(abs(IN.localNormal));
				bf /= dot(bf, (float3)1);

				// Triplanar mapping
				float2 tx = IN.localCoord.yz * _MapScale;
				float2 ty = IN.localCoord.zx * _MapScale;
				float2 tz = IN.localCoord.xy * _MapScale;

				// Base color
				half4 cx = tex2D(_Bottom, tx) * bf.x;
				half4 cy = tex2D(_Top, ty) * bf.y;
				half4 cz = tex2D(_Sand, tz) * bf.z;
				half4 color = half4(y * _Color, .5f);

				o.Albedo = SplitMap(color).rgb;

				o.Albedo = color.rgb;
				o.Alpha = color.a;
			}
			ENDCG
		}
	Fallback "Diffuse"
}