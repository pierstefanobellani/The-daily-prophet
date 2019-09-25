// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "GreenToTransparent"
{
    Properties {
        _MainTex ("Base", 2D) = "white" {}
        _Threshold ("Yellow", Range(0, 1)) = 0
		_Threshold1 ("Green", Range(0, 1)) = 0
    }
    SubShader {
        Pass {
            Tags { "Queue"="Transparent" "RenderType"="Transparent" }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv1 : TEXCOORD0;
            };
 
            sampler2D _MainTex;
            float4 _MainTex_ST;
 
            v2f vert(appdata_base v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv1 = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }
 
            float _Threshold;
			float _Threshold1;
           
			//original code
            //fixed4 frag(v2f i) : COLOR {
            //    fixed4 col1 = tex2D(_MainTex, i.uv1);
            //    fixed4 val = ceil(saturate(col1.g - col1.r - _Threshold)) * ceil(saturate(col1.g - col1.b - _Threshold));
            //    return lerp(col1, fixed4(0., 0., 0., 0.), val);
            //}

			fixed4 frag(v2f i) : COLOR { //green & yellow
                fixed4 col1 = tex2D(_MainTex, i.uv1);
                fixed4 val = ceil(saturate(col1.g - col1.r - _Threshold)) * ceil(saturate(col1.g - col1.b - _Threshold));
				//fixed4 val1 = ceil(saturate(col1.r - col1.b - _Threshold1)) * ceil(saturate(col1.g - col1.b - _Threshold1));
				fixed4 val1 = ceil(saturate(col1.r - col1.b - _Threshold1)) * ceil(saturate(col1.g - col1.b - _Threshold1));

                return lerp(col1, fixed4(0., 0., 0., 0.), val+val1);
            }

			//fixed4 frag(v2f i) : COLOR { //yellow & red
            //    fixed4 col1 = tex2D(_MainTex, i.uv1);
            //    fixed4 val = ceil(saturate(col1.r - col1.b - _Threshold)) * ceil(saturate(col1.g - col1.b - _Threshold));
			//	fixed4 val1 = ceil(saturate(col1.b - col1.g - _Threshold1)) * ceil(saturate(col1.r - col1.g - _Threshold1));

            //    return lerp(col1, fixed4(0., 0., 0., 0.), val+val1);
            //}
 
            ENDCG
        }
    }
}