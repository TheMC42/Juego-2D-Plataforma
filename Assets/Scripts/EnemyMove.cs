using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMoveDirection;

    private void Start()
    {
        GetComponent<AudioSource>().Stop();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        if (hit.distance < 0.7f)
        {
            Flip();
        }

        if (transform.position.y < 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Flip()
    {
        if (XMoveDirection > 0 )
        {

            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
