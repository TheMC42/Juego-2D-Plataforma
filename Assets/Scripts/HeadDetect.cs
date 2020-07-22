using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect : MonoBehaviour
{
    GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;  
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        GetComponent<Collider2D>().enabled = false;
        if(trig.tag == "Player")
            Enemy.GetComponent<AudioSource>().Play();
        Enemy.GetComponent<SpriteRenderer>().flipY = true;
        Enemy.GetComponent<Collider2D>().enabled = false;
        Enemy.GetComponent<EnemyMove>().enabled = false;
        Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        Enemy.transform.position += movement * Time.deltaTime;
    }
    private void Update()
    {
        if (Enemy.transform.position.y < 7)
        {
            Destroy(this.Enemy);
        }
    }
}
