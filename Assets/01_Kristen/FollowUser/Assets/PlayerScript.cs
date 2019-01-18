using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //private Camera self;
    //private float timer = 1.0f;


    // Update is called once per frame
    /*void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        self.transform.position = transform.position;
    }*/

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.isTrigger)
        {
            Debug.Log("Okay it's working");
        }
        
    }
}
