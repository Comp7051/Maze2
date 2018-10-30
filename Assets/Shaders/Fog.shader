// https://www.youtube.com/watch?v=Tjl8jP5Nuvc
// https://catlikecoding.com/unity/tutorials/rendering/part-14/

Shader "Custom/Fog"
{
	Properties
	{
		//_MainTex ("Texture", 2D) {} // = "white" {}
		_FogTex ("Texture", 2D) = "white" {}
		_FogColor("Fog Color", Color) = (1, 0, 0, 1) // This always seems to be zero. wtf?
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		//LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			//#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                //float3 worldPos : TEXCOORD1;
                //float3 worldNormal : TEXCOORD2;
                float depth : DEPTH;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			fixed4 _FogColor;

			fixed4 ApplyFog(fixed4 tex, float depth)
			{
				float invert = 1 - depth; // fog distance. Need to address whiting out at very far distances maybe?
				//return (fixed4(invert, invert, invert, 1) * tex) * _FogColor;
				return (fixed4(invert, invert, invert, 1) * tex);
			}
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				//o.depth = mul(UNITY_MATRIX_MV, v.vertex).z * _ProjectionParams.w;
				o.depth = UnityObjectToViewPos(v.vertex).z * _ProjectionParams.w;
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				//UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = ApplyFog(tex2D(_MainTex, i.uv), i.depth);

            	return col;
			}
			ENDCG
		}
	}
}
