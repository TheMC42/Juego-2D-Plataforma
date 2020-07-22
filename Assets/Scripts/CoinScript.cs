using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    Player player;
    bool bandera = false;
    float delay = 0.27f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().Stop(); 
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
           
        }
    }
}
