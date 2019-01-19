using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPath : MonoBehaviour
{
    public GameObject ObjectPrefab = null;
    public Transform[] wayPoints;
    public float speed = 2.0f;

    private int currWaypoint = 0;
    private Vector3 target;
    private GameObject obj = null;


    // Start is called before the first frame update
    void Start()
    {
        obj = Instantiate<GameObject>(ObjectPrefab, wayPoints[0].transform);
        target = wayPoints[currWaypoint].transform.position;
        //Debug.Log("Current Position = " + currWaypoint + " Distance = " + Vector3.Distance(obj.transform.position, target));
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
        }
    }

    private void NextPoint()
    {
        if (currWaypoint >= wayPoints.Length - 1)
        {
            Destroy(obj);
            //Debug.Log("Enemy destroyed");
            currWaypoint = 0;
        }
        else
        {
            currWaypoint++;
        }
        target = wayPoints[currWaypoint].transform.position;
        //Debug.Log("Current Position = " + currWaypoint + " Distance = " + Vector3.Distance(obj.transform.position, target));
    }
}
