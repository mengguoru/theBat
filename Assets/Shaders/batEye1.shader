Shader "Custom/batEye1" {
	Properties {
		_MainTex ("", 2D) = "white" {}
		_CenterX("Center X",Float) = 0.5
		_CenterY("Center Y",Float) = 0.5
		_Radius("radius",Float) = 1
		_WaveWidth("wave width", Float) = 0.01
		_DisappearRate("disappear rate",Float) = 35
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Pass
		{
			CGPROGRAM
			
			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			sampler2D _CameraDepthTexture;

			struct v2f {
			   float4 pos : SV_POSITION;
			   float4 scrPos:TEXCOORD1;
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

			sampler2D _MainTex;
			uniform float _CenterX;
			uniform float _CenterY;
			float bRunPass = 0;
			float _StartingTime;
			uniform float _DisappearRate;
			float disapearGrid = 0;
			uniform float _Radius;
			uniform float _WaveWidth;

			half4 frag(v2f i):COLOR
			{
				float depthValue = Linear01Depth (tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)).r);
				   half4 orgColor;

				   orgColor.r = depthValue;
				   orgColor.g = depthValue;
				   orgColor.b = depthValue;

				   orgColor.a = 1;

				float distance = sqrt(pow(i.scrPos.x - _CenterX, 2) + pow(i.scrPos.y - _CenterY,2));
				
				if(1 == bRunPass)
				{
					float dis = _Radius*(_Time.y - _StartingTime);
					if(distance < dis)
					{
						return orgColor;
					}else if(distance <dis + _WaveWidth && distance > dis)
					{
						float4 newColor;
						newColor.rgb = (orgColor.r,orgColor.g,orgColor.b);
						newColor.a = 1;
						return newColor;
					}else
					{
						return (0,0,0,1);
					}
				}else
				{
					if(sin(i.scrPos.x *_DisappearRate) + disapearGrid>0.8)
					{
						return (0,0,0,1);
					}
					else
					{
					    return orgColor;
					}
				}
			}
			ENDCG
		}

	}
	FallBack "Diffuse"
}
