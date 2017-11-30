using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    private bool grounded = false;
    private Rigidbody2D rigidbody2D;
    private Animator anim;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update() 
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Scene"));

        Debug.Log(grounded);
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));
        anim.SetFloat("Jump", Mathf.Abs(rigidbody2D.velocity.y));
        
        if (h * rigidbody2D.velocity.x < maxSpeed)
        {
            rigidbody2D.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
        {
            rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
        }

        if ((h > 0 && !facingRight) || (h < 0 && facingRight))
        {
            Flip();
        }

        if (jump)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
