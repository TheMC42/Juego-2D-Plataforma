using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonIniciar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshRenderer>().enabled = true;
    }
    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("GameScene");
    }
}
