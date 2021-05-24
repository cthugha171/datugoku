Shader "Unlit/Electrical"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _NoiseTex ("NoiseTexture", 2D) = "white" {}
    }
    SubShader
    {
        Cull Off

        Tags 
        {
            "Queue"="AlphaTest"
            "RenderType"="AlphaTest"
        }


        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            sampler2D _NoiseTex;

            float _Border;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed2 noiseUv1 = fixed2(i.uv.x + _Time.y * 1.2,i.uv.y);
                fixed4 noise1 = tex2D(_NoiseTex, noiseUv1 * 0.005);//画像拡大

                fixed noiseUv2 = fixed2(i.uv.x + _Time.y * -1.5, i.uv.y);
                fixed noise2 = tex2D(_NoiseTex, noiseUv2 * 0.005);//画像拡大

                fixed4 noise = noise1 + noise2;

                noise = noise * 10 - 10;//0~2の範囲を-5~5の範囲に
                noise = abs(noise);//絶対値を取り、マイナス値だったものをプラスに変化 0~5の値に変換
                noise = 1 - noise;//白黒反転
                noise = saturate(noise);//0~1に絞る

                fixed4 color = tex2D(_MainTex, i.uv) + noise;//元画像と加算

                if (color.a <= 0)
                {
                    discard;
                }

                return color;
            }
            ENDCG
        }
    }
}
