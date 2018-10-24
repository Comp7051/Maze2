// https://wodzuu.github.io/fog/

Shader "Custom/FogEffect" 
{
	Properties 
	{
		_MainTex ("Scene (RGB)", 2D) = "white" {}
	}
	SubShader 
	{
		Pass
		{
			Tags { "RenderType"="Opaque" }
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _CameraDepthTexture;

//			half4 frag (v2f_img i) : COLOR
//			{
//				float4 scene = tex2D(_MainTex, i.uv);
//
//				half4 result;
//				result.rgb = scene.rgb;
//				result.a = 1;
//				return result;
//			}

			half4 frag (v2f_img i) : COLOR
			{
			    float2 invertedUv = float2(i.uv[0], 1.0-i.uv[1]); // the depth texture has inverted vertical coordinate
			    float4 scene = tex2D(_MainTex, i.uv);
			    float4 depth = tex2D(_CameraDepthTexture, invertedUv);
			    float depthValue = depth.r; // the depth is encoded as red color

			    half4 result;
			    result.rgb = depthValue; // assign depthValue to all color channels retulring in grayscale image
			    result.a = 1;
			    return result;
			}
			ENDCG
		}
	}
}