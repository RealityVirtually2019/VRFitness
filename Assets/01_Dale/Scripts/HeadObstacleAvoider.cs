using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadObstacleAvoider : ObstacleAvoider
{
	private AudioListener ears = null;
	private AudioLowPassFilter lowPassFilter = null;

	private void Awake()
	{
		ears = Camera.main.gameObject.GetComponent<AudioListener>();
		if (ears == null)
		{
			Debug.LogError("HeadObstacleAvoider: Could not find AudioListener attached to main camera!");
		}

		lowPassFilter = ears.gameObject.AddComponent<AudioLowPassFilter>();
		lowPassFilter.cutoffFrequency = 400.0f;
		lowPassFilter.lowpassResonanceQ = 1.0f;
		lowPassFilter.enabled = false;
	}

	private void OnDestroy()
	{
		Destroy(lowPassFilter);
	}

	protected override void OnObstacleCollisionEnter(Obstacle obstacle)
	{
		lowPassFilter.enabled = true;
	}

	protected override void OnObstacleCollisionExit(Obstacle obstacle)
	{
		lowPassFilter.enabled = false;
	}
}
