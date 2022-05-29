Shader "MugCup_PostProcess_Effects/CutoutEffect"
{
    HLSLINCLUDE

        #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
    
        TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);

        float2 _Position;

        float2 _PositionArray[2];
    
        float  _Radius;
            
        float _Blend;
    
        float4 Frag(VaryingsDefault i) : SV_Target
        {
            float4 _srcTex =  SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);

            i.texcoord -= .5;
            
            float dx = ddx(i.texcoord.x);
            float dy = ddy(i.texcoord.y);
            
            float aspect = dy/dx;
            
            i.texcoord.x *= aspect;

            // float _dist = 0;
            //
            // for (int _i = 0; _i < 2; _i++)
            // {
            //     float _newArea = distance(i.texcoord.xy, _PositionArray[_i]) - _Radius;
            //     
            //     _newArea = saturate(_newArea);
            //     _newArea = step(_newArea, 0.5);
            //
            //     _dist = max(_newArea, _dist);
            // }


            float _dist = distance(i.texcoord.xy, _PositionArray[0]) - _Radius;
            _dist = saturate(_dist);
            _dist = step(_dist, 0.5);
            //
            //
            //
            // float _sub = distance(i.texcoord.xy, float2(0.0, 0.0));
            // _sub = saturate(_sub);
            // _sub = step(_sub, 0.5);
            //
            // _dist = max(_dist, _sub);
            

            
            float4 _cutout = float4(_dist, _dist, _dist, _dist);

            return _cutout * _srcTex;

        }
  
    ENDHLSL
    
    SubShader
    {
        Tags {"Queue"="Transparent"  "RenderType"="Transparent"}
        
        LOD 100
        
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM
              #pragma vertex   VertDefault
              #pragma fragment Frag
              #pragma target 4.0
            ENDHLSL
        }
    }
}
