Shader "Unlit/DoubleSide"
{
	Properties
	{
		
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	
	SubShader
	{
		LOD 100

		Tags { "RenderType"="Opaque" }
		
		Pass
		{
			Cull Off
			Lighting Off
			//ZWrite Off
			//Fog { Mode Off }
			//Offset -1, -1
			//ColorMask RGB
			//AlphaTest Greater 0.00
			//Blend SrcAlpha OneMinusSrcAlpha
			//ColorMaterial AmbientAndDiffuse
			
			SetTexture [_MainTex] { combine texture } 
		}
	}
}