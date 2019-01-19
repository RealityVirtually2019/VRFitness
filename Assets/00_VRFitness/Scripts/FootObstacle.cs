using HTC.UnityPlugin.Vive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FootObstacle : MonoBehaviour
{
	public AudioSource errorSound;
	public ViveRoleProperty foot1Role;
	public ViveRoleProperty foot2Role;

	// Start is called before the first frame update
	void Start()
    {
		if (errorSound == null)
		{
			Debug.Log("FootObstacle: Error sound not set!");
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		VivePoseTracker tracker = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<VivePoseTracker>();

		if (foot1Role == tracker.viveRole || foot2Role == tracker.viveRole)
		{
			errorSound.Play(0);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		VivePoseTracker tracker = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<VivePoseTracker>();

		if (foot1Role == tracker.viveRole || foot2Role == tracker.viveRole)
		{
			// Stop effect and sound
			errorSound.Stop();
		}
	}

}
