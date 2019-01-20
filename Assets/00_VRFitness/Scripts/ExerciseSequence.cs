using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseSequence : MonoBehaviour
{
	public GameObject[] PathPrefabs;
	public float SecondsBetweenStarting = 1.0f;
	public bool Loop = true;

	private int currentIndex = 0;
	private float lastPathStartTime = 0.0f;

    // Start is called before the first frame update
    void Start()
	{
		if (PathPrefabs.Length > 0)
		{
			StartNextPath();
		}
		else
		{
			Debug.LogError("PathTester: Must supply at least one path to test!");
		}
	}

	// Update is called once per frame
	void Update()
    {
		if (Time.time >= lastPathStartTime + SecondsBetweenStarting)
		{
			StartNextPath();
		}
    }

	private void StartNextPath()
	{
		if (currentIndex < PathPrefabs.Length)
		{
			Instantiate<GameObject>(PathPrefabs[currentIndex], this.gameObject.transform);
			lastPathStartTime = Time.time;
			currentIndex++;
			if (currentIndex >= PathPrefabs.Length)
			{
				if (Loop)
				{
					currentIndex = 0;
				}
			}
		}
	}
}
