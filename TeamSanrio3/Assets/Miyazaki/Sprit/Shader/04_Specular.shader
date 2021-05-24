Shader "Unlit/04_Sp"
{
    
      Properties
    {
        _Shininess ("Shininess", float) = 10
        _SpecColor ("Specular Color (RGB)", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Pass
        {
            Tags { "LightMode"="ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                half3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                half3 normal : TEXCOORD1;
                half3 halfDir : TEXCOORD2;
            };

            half _Shininess;
            half4 _SpecColor;
            // ライトの色を取得するために変数を定義
            half4 _LightColor0;

            v2f vert (appdata v)
            {
                v2f o = (v2f)0;
                o.pos = UnityObjectToClipPos(v.vertex);
                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
                o.normal = UnityObjectToWorldNormal(v.normal);
                half3 eyeDir = normalize(_WorldSpaceCameraPos.xyz - worldPos.xyz);
                o.halfDir = normalize(_WorldSpaceLightPos0.xyz + eyeDir);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                // ライトの色を乗算
                col.rgb = pow(max(0, dot(i.normal, i.halfDir)), _Shininess) * _SpecColor.rgb * _LightColor0.rgb;
                return col;
            }
            ENDCG
        }
    }
}
