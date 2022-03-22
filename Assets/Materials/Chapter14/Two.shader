// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Two"
{
    Properties
    {
        _OutLine("OutLine",Range(0,1)) = 0.1
        _Color("Color",Color) = (0,0,0,1)
    }
    SubShader
    {
       Pass
       {
        Cull Back
        CGPROGRAM

        #pragma vertex vert
        #pragma fragment frag
        #include "UnityCG.cginc"

        fixed4 _Color;
        fixed _OutLine;

        struct v2f
        {
            float4 pos:SV_POSITION;
            fixed4 color:COLOR;
        };
       
       v2f vert(appdata_base v)
       {
          v2f o;
          o.pos = UnityObjectToClipPos(v.vertex);
          float3 ObjViewDir = normalize(ObjSpaceViewDir(v.vertex));
          float3 normal = normalize(v.normal);
          float factor = step(_OutLine,dot(normal,ObjViewDir));
          o.color = _Color * factor;
          return o;
       }

       float4 frag(v2f i):SV_Target
       {
            return i.color;
       }
       ENDCG
       }
    }
}
