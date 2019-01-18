using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	protected virtual void OnObstacleCollisionEnter(Obstacle obstacle)
	{
		Debug.Log("<color=red>Started hitting an obstacle!</color>");
	}

	protected virtual void OnObstacleCollisionStay(Obstacle obstacle)
	{
		Debug.Log("<color=orange>Hitting an obstacle!</color>");
	}

	protected virtual void OnObstacleCollisionExit(Obstacle obstacle)
	{
		Debug.Log("<color=green>Stopped hitting an obstacle!</color>");
	}

	private void OnTriggerEnter(Collider other)
	{
		Obstacle obstacle = other.GetComponent<Obstacle>();
		if (obstacle != null)
		{
			this.OnObstacleCollisionEnter(obstacle);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		Obstacle obstacle = other.GetComponent<Obstacle>();
		if (obstacle != null)
		{
			this.OnObstacleCollisionExit(obstacle);
		}
	}

}
