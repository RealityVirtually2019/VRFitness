using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;

    private int currPoint = 0;
    private Vector3 target;
    public Transform[] wayPoints;
    private float speed = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Camera");
        target = wayPoints[currPoint].transform.position;
        Debug.Log("Current Position = " + currPoint + " Distance = " + Vector3.Distance(transform.position, target));
    }

    void Update()
    {
        if ((Vector3.Distance(transform.position, target)) < 0.5)
        {
            nextPoint();
        }
        else
        {
            //float dir = 0;
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        }
    }

    private void nextPoint()
    {
        if (currPoint >= wayPoints.Length - 1)
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy destroyed");
            currPoint = 0;
        }
        else
        {
            currPoint++;
        }
        target = wayPoints[currPoint].transform.position;
        Debug.Log("Current Position = " + currPoint + " Distance = " + Vector3.Distance(transform.position, target));
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        Debug.Log("You have been stopped");
    }

}
