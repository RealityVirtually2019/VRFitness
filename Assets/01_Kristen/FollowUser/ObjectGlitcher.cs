using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGlitcher : MonoBehaviour {

    //public Camera camera;
    public float glitchChance = .05f;

    private Renderer blockRenderer;
    private WaitForSeconds glitchLoopWait = new WaitForSeconds(.2f);
    private WaitForSeconds glitchDuration = new WaitForSeconds(.2f);


    void Awake()
    {
        blockRenderer = GetComponent<Renderer> ();
        //camera.backgroundColor = Color(1, 1, 1, 1);
    }

   /* void Start()
    {
        camera.backgroundColor = Color(1,1,1,1);
    } */

    IEnumerator Start () 
    {
        while (true) 
        {
            float glitchTest = Random.Range (0f, 1f);

            if (glitchTest <= glitchChance) 
            {
                StartCoroutine (Glitch ());
            }
            yield return glitchLoopWait;
        }


    }

    IEnumerator Glitch()
    {
        glitchDuration = new WaitForSeconds(Random.Range(.05f,.2f));
        blockRenderer.material.SetFloat ("_Amount", 1f);
        blockRenderer.material.SetFloat ("_CutoutThresh", .2f);
        blockRenderer.material.SetFloat ("_Amplitude", Random.Range (100, 250));
        blockRenderer.material.SetFloat ("_Speed", Random.Range (1, 10));
        yield return glitchDuration;
        blockRenderer.material.SetFloat ("_Amount", 0f);
        blockRenderer.material.SetFloat ("_CutoutThresh", 0f);
    }

}
