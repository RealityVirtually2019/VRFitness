using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public Transform waypoint;
    public float speed = 2.0f;


    // Start is called before the first frame update
    void Start()
    {     
        InvokeRepeating("Spawner", 3f, 3);
    }

    // Update is called once per frame
   
    void Spawner()
    {
        Instantiate(enemy, waypoint.position, waypoint.rotation);
        Debug.Log("Hi");
    }
}
