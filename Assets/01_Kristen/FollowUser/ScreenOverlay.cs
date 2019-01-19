using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOverlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       this.gameObject.GetComponent<Renderer>().material.color = new Color(255.0f,0.0f,0.0f,0.5f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
