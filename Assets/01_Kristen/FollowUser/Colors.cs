using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    private bool CollOccured;
    Rigidbody rigid;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
       rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CollOccured)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 2.0f * Time.deltaTime);
        }
        else
        {
            Debug.Log("ayoo");
            this.rigid.AddForce(new Vector3(1000, 0, 100));

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        //CollOccured = true;
        //this.rigid.AddForce(new Vector3(1000, 0, 100));
    }

}
