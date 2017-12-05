using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [HideInInspector] public Vector3 topPos, bottomPos, leftPos, rightPos, center, size;
    public Color invalidColor, validColor, placedColor;

    private enum BlockState { invalid, valid, placed };
    private BlockState state;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;

    private bool snapping = false;
    private bool placed = false;

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
        if (!snapping && !placed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, -0.1f);
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

            if (collider.bounds.Contains(mousePosition))
            {
                snapping = true;
                return;
            }

            if (mousePosition.y > otherBlock.center.y && 
                mousePosition.x > otherBlock.center.x - otherBlock.size.x / 2 && 
                mousePosition.x < otherBlock.center.x + otherBlock.size.x)
            {
                transform.position = otherBlock.topPos;
                snapping = true;
            }
            else if (mousePosition.y < otherBlock.center.y &&
                     mousePosition.x > otherBlock.center.x - otherBlock.size.x / 2 &&
                     mousePosition.x < otherBlock.center.x + otherBlock.size.x)
            {
                transform.position = otherBlock.bottomPos;
                snapping = true;
            }
            else if (mousePosition.x > otherBlock.center.x &&
                     mousePosition.y > otherBlock.center.y - otherBlock.size.y / 2 &&
                     mousePosition.y < otherBlock.center.y + otherBlock.size.y)
            {
                transform.position = otherBlock.rightPos;
                snapping = true;
            }
            else if (mousePosition.x < otherBlock.center.x &&
                     mousePosition.y > otherBlock.center.y - otherBlock.size.y / 2 &&
                     mousePosition.y < otherBlock.center.y + otherBlock.size.y)
            {
                transform.position = otherBlock.leftPos;
                snapping = true;
            }
            else
            {
                snapping = false;
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
            snapping = false;
        }
        else
        {
            state = BlockState.valid;
            spriteRenderer.color = validColor;
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

