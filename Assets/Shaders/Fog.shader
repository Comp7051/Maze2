// http://willychyr.com/2013/11/unity-shaders-depth-and-normal-textures/

//https://docs.unity3d.com/Manual/PostProcessingWritingEffects.html

// https://www.alanzucconi.com/2015/07/08/screen-shaders-and-postprocessing-effects-in-unity3d/

Shader "Custom/Fog" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader {
		//Tags { "RenderType"="Opaque" }
		//Tags { "RenderType"="Opaque" "Queue"="Geometry" "LightMode"="ForwardBase" }
		//Tags { "Queue" = "Transparent" "RenderType"="Transparent"  }

		Pass{
			//Cull Off ZWrite Off ZTest Always

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _CameraDepthTexture;
			uniform sampler2D _MainTex;

			struct v2f {
			   float4 vertex : SV_POSITION;
			   float2 depth:TEXCOORD0;
			};

			v2f vert( appdata_img v )
			{
			    v2f o;
			    o.vertex = UnityObjectToClipPos (v.vertex);
			    o.depth = v.texcoord;
			    return o;
			}

			//Fragment Shader
			fixed4 frag (v2f i) : COLOR
			{
				float depthValue = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, i.depth);
				depthValue = 1- Linear01Depth (depthValue);
				return tex2D(_MainTex, i.depth) * depthValue;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}