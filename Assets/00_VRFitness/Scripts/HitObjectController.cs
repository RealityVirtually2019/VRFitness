using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class HitObjectController : MonoBehaviour
{

    public ViveRoleProperty objectRole;
    public AudioSource hitSound;
    public AudioSource errorSound;
    public GameObject particleEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        VivePoseTracker tracker = other.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<VivePoseTracker>();
        

        Debug.Log("Object role: " + objectRole + " ,Tracker role: " + tracker.viveRole);

        if (objectRole == tracker.viveRole)
        {
            hitSound.Play(0);
            GameObject effectObj = Instantiate(particleEffect, transform.position, transform.rotation);  
            Destroy(gameObject);
            Debug.Log("correct entered!");
        } else
        {
            errorSound.Play(0);
        }

        
    }



    }
