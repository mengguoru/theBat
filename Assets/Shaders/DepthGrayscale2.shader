Shader "Custom/DepthGrayscale_Optimized" {
SubShader {
Tags { "RenderType"="Opaque" }

Pass{
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

sampler2D _CameraDepthTexture;

struct v2f {
   fixed4 pos : SV_POSITION;
   fixed4 scrPos:TEXCOORD1;
};

//Vertex Shader
v2f vert (appdata_base v){
   v2f o;
   o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
   o.scrPos=ComputeScreenPos(o.pos);
   //for some reason, the y position of the depth texture comes out inverted
   //o.scrPos.y = 1 - o.scrPos.y;
   return o;
}

//Fragment Shader
fixed4 frag (v2f i) : COLOR{
   fixed4 depthValue = Linear01Depth (tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r);
   fixed4 depth;

   depth.r = depthValue;
   depth.g = depthValue;
   depth.b = depthValue;

   depth.a = 1;
   return depth;
}
ENDCG
}
}
FallBack "Diffuse"
}