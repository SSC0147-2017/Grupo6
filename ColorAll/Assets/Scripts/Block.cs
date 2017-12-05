using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [HideInInspector] public Vector3 topPos, bottomPos, leftPos, rightPos, center, size;
    public Color invalidColor, validColor, placedColor;
    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;

    private enum BlockState { invalid, valid, placed };
    private BlockState state;
    private SpriteRenderer spriteRenderer;

    private bool placed = false;

    private Vector3 lastMousePos = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        state = BlockState.valid;
        spriteRenderer.color = validColor;
        boxCollider.isTrigger = true;
        circleCollider.enabled = false;

        size = boxCollider.bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition != lastMousePos && !placed)
        {
            transform.position = new Vector3(mousePosition.x, mousePosition.y, -0.1f);
            lastMousePos = mousePosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Block otherBlock = collider.GetComponent<Block>();

        if (placed)
        {
            return;
        }

        if (!otherBlock || otherBlock.state != Block.BlockState.placed)
        {
            state = BlockState.invalid;
            spriteRenderer.color = invalidColor;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Block otherBlock = collider.GetComponent<Block>();

        if (placed)
        {
            return;
        }

        if (otherBlock)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePosition.y > otherBlock.center.y && 
                mousePosition.x > otherBlock.center.x - otherBlock.size.x / 2 && 
                mousePosition.x < otherBlock.center.x + otherBlock.size.x)
            {
                transform.position = otherBlock.topPos;
            }
            else if (mousePosition.y < otherBlock.center.y &&
                     mousePosition.x > otherBlock.center.x - otherBlock.size.x / 2 &&
                     mousePosition.x < otherBlock.center.x + otherBlock.size.x)
            {
                transform.position = otherBlock.bottomPos;
            }
            else if (mousePosition.x > otherBlock.center.x &&
                     mousePosition.y > otherBlock.center.y - otherBlock.size.y / 2 &&
                     mousePosition.y < otherBlock.center.y + otherBlock.size.y)
            {
                transform.position = otherBlock.rightPos;
            }
            else if (mousePosition.x < otherBlock.center.x &&
                     mousePosition.y > otherBlock.center.y - otherBlock.size.y / 2 &&
                     mousePosition.y < otherBlock.center.y + otherBlock.size.y)
            {
                transform.position = otherBlock.leftPos;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Block otherBlock = collider.GetComponent<Block>();

        if (placed)
        {
            return;
        }

        if (otherBlock)
        {
        }
        else
        {
            state = BlockState.valid;
            spriteRenderer.color = validColor;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && placed)
        {
            Destroy(gameObject);
        }
    }

    public bool PlaceBlock()
    {
        if (state != BlockState.invalid)
        {
            state = BlockState.placed;
            spriteRenderer.color = placedColor;
            boxCollider.isTrigger = false;
            circleCollider.enabled = true;
            placed = true;


            center = boxCollider.bounds.center;
            topPos = new Vector3(center.x, center.y + boxCollider.bounds.size.y, -0.1f);
            bottomPos = new Vector3(center.x, center.y - boxCollider.bounds.size.y, -0.1f);
            rightPos = new Vector3(center.x + boxCollider.bounds.size.x, center.y, -0.1f);
            leftPos = new Vector3(center.x - boxCollider.bounds.size.x, center.y, -0.1f);

            return true;
        }
        else
        {
            return false;
        }
    }
}

