using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(CutoutRenderer), PostProcessEvent.AfterStack, "Custom/Cutout")]
[CreateAssetMenu(menuName = "Custom PostProcess Effects/Cutout")]
public class CutoutPostProcess : PostProcessEffectSettings
{
	public Vector2Parameter Position = new Vector2Parameter { value = Vector2.zero };
	public FloatParameter   Radius   = new FloatParameter { value = 0.0f };

	public Vector4Parameter testVec = new Vector4Parameter
	{
		value = Vector4.one
	};

	public Vector4Parameter[] PositionArray = new Vector4Parameter[2]
	{
		new Vector4Parameter(), 
		new Vector4Parameter()
	};
}

public sealed class CutoutRenderer : PostProcessEffectRenderer<CutoutPostProcess>
{
	public override void Render(PostProcessRenderContext _context)
	{
		var _sheet = _context.propertySheets.Get(Shader.Find("MugCup_PostProcess_Effects/CutoutEffect"));
		
		_sheet.properties.SetVector     ("_Position", settings.Position);
		_sheet.properties.SetFloat      ("_Radius"  , settings.Radius);
		
		
		_sheet.properties.SetVectorArray("_PositionArray", new Vector4[2]
		{
			settings.PositionArray[0],
			new Vector4()
			
		});
		
		
		_context.command.BlitFullscreenTriangle(_context.source, _context.destination, _sheet, 0);
	}

	private Vector4[] CastVector4Array()
	{
		Vector4[] _castVectorArray = new Vector4[2];

		for (var _i = 0; _i < 2; _i++)
		{
			_castVectorArray[_i] = settings.PositionArray[0];
		}

		return _castVectorArray;
	}
}

