// https://answers.unity.com/questions/1497263/alpha-cutoff-of-sprite-based-on-another-texture.html

Shader "Unlit/CircularTimer"
 {
     Properties
     {
         [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
         _OverlayTex("Overlay Texture",2D) = "white"{}
         _Angle("Angle",Range(0,360)) = 90
     }
     SubShader
     {
         Tags
         { 
             "Queue"="Transparent" 
         }
         LOD 100
 
         Cull Off
         Lighting Off
         ZWrite Off
         Blend One OneMinusSrcAlpha
 
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
             sampler2D _OverlayTex;
 
             float4 _MainTex_ST;
             float _Angle;
             
             v2f vert (appdata v)
             {
                 v2f o;
                 o.vertex = UnityObjectToClipPos(v.vertex);
                 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                 return o;
             }
             
             fixed4 frag (v2f i) : SV_Target
             {
                 float x = i.uv.x * 2 - 1;
                 float y = i.uv.y * 2 - 1;
 
                 float ang = degrees(atan2(y,x)) + 180;
                 
                 if(ang - _Angle < 0){
 
                     fixed4 col = tex2D(_MainTex, i.uv);
                     fixed4 overlay = tex2D(_OverlayTex,i.uv);
                     fixed4 final = col * overlay;
                     return final;
 
                 }
                 else
                     return 0;
             }
             ENDCG
         }
     }
 }