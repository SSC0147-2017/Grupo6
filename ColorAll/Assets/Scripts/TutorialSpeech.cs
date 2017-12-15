using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpeech : MonoBehaviour
{

    public GameObject speechBubble1, speechBubble2, speechBubble3;
    public GameObject Key, leftClick, block, dropplet;
    public bool ready = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Body" && ready)
        {
            speechBubble1.GetComponent<SpriteRenderer>().enabled = true;
            speechBubble2.GetComponent<SpriteRenderer>().enabled = true;
            speechBubble3.GetComponent<SpriteRenderer>().enabled = true;
            Key.GetComponent<SpriteRenderer>().enabled = true;
            leftClick.GetComponent<SpriteRenderer>().enabled = true;
            block.GetComponent<SpriteRenderer>().enabled = true;
            dropplet.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Body" && ready)
        {
            speechBubble1.GetComponent<SpriteRenderer>().enabled = false;
            speechBubble2.GetComponent<SpriteRenderer>().enabled = false;
            speechBubble3.GetComponent<SpriteRenderer>().enabled = false;
            Key.GetComponent<SpriteRenderer>().enabled = false;
            leftClick.GetComponent<SpriteRenderer>().enabled = false;
            block.GetComponent<SpriteRenderer>().enabled = false;
            dropplet.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
