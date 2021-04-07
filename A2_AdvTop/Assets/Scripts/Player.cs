using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Score;

    [SerializeField]
    private AudioSource backgroundMusic;

    [SerializeField]
    private AudioSource jumpSound;

    [SerializeField]
    private float velocityX;

    [SerializeField]
    private LayerMask platformMask;

    [SerializeField]
    private float jumpVelocity;

    [SerializeField]
    private float gravity;


    private Rigidbody2D rb;
    private Animator animator;
    private float currentVel;
    private bool grounded;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentVel = velocityX;
        Score = 0;
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        checkScreenBorders();
        if(rb.velocity.y < 0)
        {
            gameObject.layer = 7; // collide with platforms
        }
        else
        {
            gameObject.layer = 8; // don't collide with platforms
        }

        if(grounded)
        {
            if(Input.touchCount > 0)
            {
                Jump();
            }
        }

        Vector3 changeInPosition = rb.velocity * Time.deltaTime;
        changeInPosition.x = 0.0f;
        PlatformManager.MovePlatforms(-changeInPosition);
        transform.position += -changeInPosition;


    }

    void checkScreenBorders()
    {
        Vector2 newVel = rb.velocity;
        if (transform.position.x < -2.5f)
        {
            currentVel = velocityX;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (transform.position.x > 2.5f)
        {
            currentVel = -velocityX;
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        newVel.x = currentVel;
        rb.velocity = newVel;

    }

    private void isGrounded(bool b)
    {
        if(b)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            rb.gravityScale = 0.0f;
        }
        else
        {
            rb.gravityScale = gravity;
        }

        grounded = b;
        animator.SetBool("isJumping", !grounded);
        
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        transform.position = new Vector3(transform.position.x, -1.45f, transform.position.z);
        isGrounded(false);
        Score += 1;
        jumpSound.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded(true);
        }
        else
        {
            GameOver();
        }

    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
