Shader "Unlit/Lambert"
{
 Properties
  {
   _Color("Color",Color)=(0,0,0,1)
  }
  SubShader
  {
    Pass
	{
	  CGPROGRAM

	  #pragma vertex verte
	  #pragma fragment frag
	  #include "UnityCG.cginc"

	   fixed4 _Color;

	  struct appdate
	  {
	    float4 vertex : POSITION;
	    float3 normal : NORMAL;
	  };
	  struct v2f
	  {
	  	  float4 vertex : SV_POSITION;
		  float3 normal : NORMAL;
	  };
	  v2f verte(appdate v)
	  {
		 
	     v2f o;
		 o.vertex = UnityObjectToClipPos(v.vertex);
		 o.normal=mul(v.normal,(float3x3)unity_WorldToObject);
		 
		 return o;
		
	  }
	   
	  fixed4 frag(v2f i) : SV_Target
	  {
	      //fixed4 color = fixed4(0,1,0,1) ;
	  	  float intensity = smoothstep(0.4f,0.5,dot(normalize(i.normal),_WorldSpaceLightPos0))*0.5;
		  return float4(intensity,intensity,intensity,1)*_Color;
	  }
	  ENDCG
	}
  }
}
