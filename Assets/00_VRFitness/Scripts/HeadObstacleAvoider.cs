using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadObstacleAvoider : MonoBehaviour
{
	private AudioListener ears = null;
	private AudioLowPassFilter lowPassFilter = null;
	private MeshRenderer meshRenderer = null;

	private void Awake()
	{
		ears = Camera.main.gameObject.GetComponent<AudioListener>();
		if (ears == null)
		{
			Debug.LogError("HeadObstacleAvoider: Could not find AudioListener attached to main camera!");
		}

		meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
		if (meshRenderer == null)
		{
			Debug.LogError("HeadObstacleAvoider: Could not find MeshRenderer attached to this gameobject!");
		}
		meshRenderer.enabled = false;

		lowPassFilter = ears.gameObject.AddComponent<AudioLowPassFilter>();
		lowPassFilter.cutoffFrequency = 400.0f;
		lowPassFilter.lowpassResonanceQ = 1.0f;
		lowPassFilter.enabled = false;
	}

	private void OnDestroy()
	{
		Destroy(lowPassFilter);
	}

	private void OnTriggerEnter(Collider other)
	{
		HeadObstacle obstacle = other.GetComponent<HeadObstacle>();
		if (obstacle != null)
		{
			lowPassFilter.enabled = true;
			meshRenderer.enabled = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		HeadObstacle obstacle = other.GetComponent<HeadObstacle>();
		if (obstacle != null)
		{
			lowPassFilter.enabled = false;
			meshRenderer.enabled = false;
		}
	}

}
