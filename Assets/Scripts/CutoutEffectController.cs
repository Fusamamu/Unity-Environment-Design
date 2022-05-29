using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CutoutEffectController : MonoBehaviour
{
	[SerializeField] private GameObject testObject;
	[SerializeField] private Vector2 testPosition;
	
	[SerializeField] private PostProcessVolume ppVolume;
	[SerializeField] private CutoutPostProcess cutoutPostProcess;


	void Start()
	{
		//cutoutPostProcess.enabled.Override(true);

		//PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, cutoutPostProcess);
		
		//ppVolume.sharedProfile.settings.Add(cutoutPostProcess);

		if(ppVolume.profile.TryGetSettings(out CutoutPostProcess _cutout))
		{
			cutoutPostProcess = _cutout;
		}
		
		//cutoutPostProcess.Position = 

		// Create an instance of a vignette
		// m_Vignette = ScriptableObject.CreateInstance<Vignette>();
		// m_Vignette.enabled.Override(true);
		// m_Vignette.intensity.Override(1f);
		// // Use the QuickVolume method to create a volume with a priority of 100, and assign the vignette to this volume
		// m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
		// void Update()
		// {
		// 	// Change vignette intensity using a sinus curve
		// 	m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
		// }
		// void OnDestroy()
		// {
		// 	RuntimeUtilities.DestroyVolume(m_Volume, true, true);
		// }
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			UpdatePosition();
			Debug.Log("ajf;klsfd");
		}
	}

	private void UpdatePosition()
	{
		cutoutPostProcess.enabled.Override(true);
		//cutoutPostProcess.Position.Override(testPosition);

		for (var _i = 0; _i < cutoutPostProcess.PositionArray.Length; _i++)
		{
			cutoutPostProcess.PositionArray[_i].Override(testPosition);
		}
		


	}
}
