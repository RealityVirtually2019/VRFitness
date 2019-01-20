using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGlitcher : MonoBehaviour {

    public Material regularBlock;
    public Material glitchBlock;

    public float glitchChance = .05f;

    private Renderer blockRenderer;
    private WaitForSeconds glitchLoopWait = new WaitForSeconds(.2f);
    private WaitForSeconds glitchDuration = new WaitForSeconds(.2f);


    void Awake()
    {
        blockRenderer = GetComponent<Renderer> ();
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
        blockRenderer.material = glitchBlock;
        yield return glitchDuration;
        blockRenderer.material = regularBlock;
    }

}
