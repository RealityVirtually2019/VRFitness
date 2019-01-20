using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartExercise : MonoBehaviour
{

    public GameObject exerciseTimeline;
    public GameObject mesh;
    public GameObject otherTrigger;

    private float speed = 0;
    private float endTime = float.PositiveInfinity;

    // Start is called before the first frame update
    void Start()
    {
        exerciseTimeline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mesh.transform.Rotate(Vector3.up, Time.deltaTime * speed);

        if (Time.time >= endTime)
        {
            StartExerciseTimeline();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        endTime = Time.time + 3.0f;
        speed = 140f;
    }

    private void OnTriggerExit(Collider other)
    {
        endTime = float.PositiveInfinity;
        speed = 0;
    }

    private void StartExerciseTimeline()
    {
        exerciseTimeline.SetActive(true);
        Destroy(mesh);
        Destroy(gameObject);
    }

}
