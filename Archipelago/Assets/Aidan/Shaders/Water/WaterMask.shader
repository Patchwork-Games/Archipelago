Shader "Mask/WaterMask"
{
   SubShader
   {
       // Set the tags to be transparent so it renders before the water
       Tags
       {
            "Queue" = "Transparent"
       }

       // Don't draw RGB, just depth buffer
       ColorMask 0
       ZWrite On

       // Pass that does nothing
       Pass{}
   }
}
