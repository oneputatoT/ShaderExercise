// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Chapter8-AlphaTest"
{
    Properties
    {
        _Color("Color",color)=(1,1,1,1)
        _MainTex("MainTex",2D)="white"{}
        _Cutoff("Alpha Cutoff",Range(0,1))=0.5
    }
    SubShader
    {
    Tags{"Queue"="AlphaTest""IgnoreProjector"="Ture""RenderType"="TransparentCutout"}
        Pass
        {
            Tags{"LightMode"="ForwardBase"}
            Cull Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "lighting.cginc"

            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed _Cutoff;

            struct a2v{
            float4 vertex:POSITION;
            float3 normal:NORMAL;
            float4 texcoord:TEXCOORD0;
            };

            struct v2f{
            float4 pos:SV_POSITION;
            float3 WorldNormal:TEXCOORD0;
            float3 WorldPos:TEXCOORD1;
            float2 uv:TEXCOORD2;
            };

            v2f vert(a2v v){
            v2f o;
            o.pos=UnityObjectToClipPos(v.vertex);
            o.WorldNormal=UnityObjectToWorldNormal(v.normal);
            o.WorldPos=(unity_ObjectToWorld,v.vertex);
            o.uv=TRANSFORM_TEX(v.texcoord,_MainTex);
            return o;
            }
 
            fixed4 frag(v2f i):SV_Target{
            fixed3 worldNormal =normalize(i.WorldNormal);
            fixed3 worldLightDir =normalize(UnityWorldSpaceLightDir(i.WorldPos));

            fixed4 texColor = tex2D(_MainTex,i.uv);
            clip (texColor.a-_Cutoff);

            fixed3 albedo = texColor.rgb * _Color.rgb;
            fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
            fixed3 diffuse = _LightColor0.rgb * albedo * max(0,dot(worldNormal,worldLightDir));

            return fixed4(ambient+diffuse,1.0);
            }
            ENDCG
        }
    
    }
   FallBack "Transparent/Cutout/VertexLit"
}
