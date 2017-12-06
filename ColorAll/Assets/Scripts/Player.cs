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
    public float maxHealth = 100f;
    public Transform groundCheck;
    public GameObject blockPrebab;
    public int blocksPlaced;

    private bool grounded = false;
    private bool placingEnabled = false;
    private bool blockFixed = true;
    private Rigidbody2D rigidbody2D;
    private Animator anim;
    private Block block = null;
    public int maxBlocks = 5;
    private float health;
    private bool paused = false;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        blocksPlaced = 0;
        health = maxHealth;
    }
	
	// Update is called once per frame
	void Update() 
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Scene"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        if (Input.GetButtonDown("Block1") && maxBlocks > 0)
        {
            placingEnabled = !placingEnabled;

            if (!placingEnabled && block)
            {
                Destroy(block.gameObject);
                blockFixed = true;
            }
            
            if (blockFixed && placingEnabled && maxBlocks > 0)
            {
                block = Instantiate(blockPrebab).GetComponent<Block>();
                blockFixed = false;
            }

        }
        if (Input.GetButtonDown("Place") && placingEnabled && blocksPlaced < maxBlocks)
        {
            if (blockFixed = block.PlaceBlock())
            {
                block = Instantiate(blockPrebab).GetComponent<Block>();
                blocksPlaced++;
            }
        }
        if (Input.GetButtonDown("Reset"))
        {
            foreach (Block bl in FindObjectsOfType<Block>())
            {
                Destroy(bl.gameObject);
                placingEnabled = false;
                blocksPlaced = 0;
            }
        }

        if (Input.GetButtonDown("Pause"))
        {
            if (paused)
            {
                FindObjectOfType<MenuManager>().SetActivePauseMenuWindow(0);
            }
            else
            {
                FindObjectOfType<MenuManager>().SetActivePauseMenuWindow(1);
            }
            paused = !paused;
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
            float horizontalJumpForce = 0f;

            if (rigidbody2D.velocity.x != 0f)
            {
                horizontalJumpForce = facingRight ? jumpForce : -jumpForce;
            }

            rigidbody2D.AddForce(new Vector2(horizontalJumpForce, jumpForce));
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

    public void InflictDamage(float damage)
    {
        health -= damage;
    }
}
