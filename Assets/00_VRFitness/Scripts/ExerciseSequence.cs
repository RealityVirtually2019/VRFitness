using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseSequence : MonoBehaviour
{
	public GameObject[] PathPrefabs;
	[Range(1,10)]
	public int BeatMultipleBetweenObjects = 2; 
	public bool Loop = true;

	private const float SecondsBetweenStarting = 0.5f;
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
		if (Time.time >= lastPathStartTime + (SecondsBetweenStarting * BeatMultipleBetweenObjects))
		{
			StartNextPath();
		}
    }

	private void StartNextPath()
	{
		if (currentIndex < PathPrefabs.Length)
		{
			if (PathPrefabs[currentIndex] != null)
			{
				Instantiate<GameObject>(PathPrefabs[currentIndex]);
			}
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
