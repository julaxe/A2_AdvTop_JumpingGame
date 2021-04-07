using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float velocityX;

    private float currentVel;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(Random.Range(0,2) == 0)
        {
            currentVel = velocityX;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            currentVel = -velocityX;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkScreenBorders();

    }

    void checkScreenBorders()
    {
        Vector2 newVel = rb.velocity;
        if (transform.position.x < -2.5f)
        {
            currentVel = velocityX;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (transform.position.x > 2.5f)
        {
            currentVel = -velocityX;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        newVel.x = currentVel;
        rb.velocity = newVel;
    }
}
