// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Four"
{
    Properties
    {
        _OutLineColor("OutLineColor",Color)=(0,0,0,1)
        _OutLine("OutLine",Range(0,1))=0.1
    }
    SubShader
    {
      Pass
      {
        Cull Back

        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
        
        float4 vert(float4 v:POSITION):SV_POSITION
        {
            return UnityObjectToClipPos(v);
        }

        float4 frag():SV_Target
        {
            return float4(1,0.25,0.25,1);
        }

        ENDCG
      
      }


      Pass
      {
        Cull Front

        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag

        fixed _OutLine;
        fixed4 _OutLineColor;

        struct a2v
        {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
        };

        struct v2f
        {
            float4 pos : SV_POSITION;
        };

        v2f vert(a2v v)
        {
            v2f o;
            float4 pos = mul(UNITY_MATRIX_MV,v.vertex);
            float3 normal = mul((float3x3)UNITY_MATRIX_IT_MV,v.normal);
            normal.z = -0.5;
            pos = pos + float4(normalize(normal),0)*_OutLine;
            o.pos = mul(UNITY_MATRIX_P,pos);
            return o;
        }

        float4 frag(v2f i):SV_Target
        {
            return float4(_OutLineColor.rgb,1);
        }

        ENDCG
      }
        
    }
}
