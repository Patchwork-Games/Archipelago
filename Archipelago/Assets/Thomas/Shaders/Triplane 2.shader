Shader "Tri-Planar World" {

	Properties{

		  _Side("SideFail", 2D) = "white" {}

		  _Top("Top", 2D) = "white" {}

		  _Sand("Sand", 2D) = "white" {}

		  _SandNormal("SandNormal", 2D) = "bump" {}

		  _Bottom("Side", 2D) = "white" {}

		  _SideScale("Side Scale", Float) = 2

		  _TopScale("Top Scale", Float) = 2

		  _BottomScale("Bottom Scale", Float) = 2

		  _TopAngle("Top Angle", Float) = 0.8

		  _SideAngle("Side Angle", Float) = 0.5
	}



		SubShader{

			Tags {

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

			float _SideScale, _TopScale, _BottomScale, _SideAngle, _TopAngle;
			


			struct Input {

				float3 worldPos;
				float3 worldNormal;
				float2 uv_BumpMap;
			};



			void surf(Input IN, inout SurfaceOutput o) {

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
				if (IN.worldPos.y < 20)
				{
					
					if (IN.worldNormal.y > _TopAngle)
					{
						y = tex2D(_Sand, frac(IN.worldPos.zx * _TopScale)) * abs(IN.worldNormal.y);
					}
					else
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
					else
					{
						y = tex2D(_Bottom, frac(IN.worldPos.zx * _BottomScale)) * abs(IN.worldNormal.y);
					}
				}


				// SIDE Z	

				float3 z = tex2D(_Side, frac(IN.worldPos.xy * _SideScale)) * abs(IN.worldNormal.z);



				o.Albedo = z;

				o.Albedo = x;// lerp(o.Albedo, x, projNormal.x);

				o.Albedo = y;// lerp(o.Albedo, y, projNormal.y);

				//o.Normal = UnpackNormal(tex2D (_SandNormal, IN.uv_BumpMap));

			}

			ENDCG

		  }

			  Fallback "Diffuse"

}