using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMovement : MonoBehaviour
{
	[Range(0.5f,1.5f)]
	public float MovementPerSecond = 1.0f;
	public Vector3 MovementDirection = Vector3.back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.localPosition += MovementDirection * MovementPerSecond * Time.deltaTime;
    }
}
