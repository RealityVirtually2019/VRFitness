using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    public string scene;
    public GameObject mesh;
    public AudioSource sound;

    private float speed = 0;
    private float endTime = float.PositiveInfinity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mesh.transform.Rotate(Vector3.up, Time.deltaTime * speed);

        if (Time.time >= endTime)
        {
            ChangeScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        endTime = Time.time + 4.0f;
        speed = 140f;
        sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        endTime = float.PositiveInfinity;
        speed = 0;
        sound.Stop();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }

}
