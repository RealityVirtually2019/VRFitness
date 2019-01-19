using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPath : MonoBehaviour
{
    public GameObject ObjectPrefab = null;
	public Vector3 ObjectScale = Vector3.one;
    public Transform[] wayPoints;
    public float speed = 2.0f;

    private int currWaypoint = 0;
    private Vector3 target;
    private GameObject obj = null;


    // Start is called before the first frame update
    void Start()
    {
		if (ObjectPrefab == null)
		{
			Debug.LogError("ObjectPath: An Object Prefab must be provided in the inspector!");
		}
		if (wayPoints.Length < 2)
		{
			Debug.LogError("ObjectPath: Must provide at least 2 waypoints in the inspector!");
		}
        obj = Instantiate<GameObject>(ObjectPrefab, wayPoints[0].transform);
		obj.transform.localScale = ObjectScale;
		currWaypoint = 1;
        target = wayPoints[currWaypoint].transform.position;
    }

	private void OnEnable()
	{
		if (obj != null)
		{
			obj.transform.position = wayPoints[0].transform.position;
			currWaypoint = 1;
			target = wayPoints[currWaypoint].transform.position;
			obj.SetActive(true);
		}
	}

	void Update()
    {
        if ((Vector3.Distance(obj.transform.position, target)) < 0.5)
        {
            NextPoint();
        }
        else
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, target, speed * Time.deltaTime);

            //Add Rotation towards the target
            Vector3 dir = target - obj.transform.position;
            dir.x = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, rot, speed * Time.deltaTime);
        }
    }

    private void NextPoint()
    {
        if (currWaypoint >= wayPoints.Length - 1)
        {
			obj.SetActive(false);
            currWaypoint = 0;
			this.enabled = false;	// Disable the path as well, it is no longer needed for now
        }
        else
        {
            currWaypoint++;
        }
        target = wayPoints[currWaypoint].transform.position;
    }
}
