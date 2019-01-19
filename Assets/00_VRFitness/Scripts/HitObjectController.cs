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
            if (hitSound == null)
            {
                Debug.Log("Hit sound not set!");
            }
            else
            {
                hitSound.Play(0);
            }

            if (particleEffect == null)
            {
                Debug.Log("Destroy effect not set!");
            }
            else
            {
                GameObject effectObj = Instantiate(particleEffect, transform.position, transform.rotation);
            }  
            Destroy(gameObject);
            Debug.Log("correct entered!");
        }
        else
        {
            if (errorSound == null)
            {
                Debug.Log("Error sound not set!");
            }
            else
            {
                errorSound.Play(0);
            }
        }

        
    }



    }
