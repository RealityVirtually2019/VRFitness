using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;

public class HitObjectController : MonoBehaviour
{

    public ViveRoleProperty objectRole;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            audioSource.Play(0);
            Destroy(gameObject);
            Debug.Log("correct entered!");
        } 

        
    }


}
