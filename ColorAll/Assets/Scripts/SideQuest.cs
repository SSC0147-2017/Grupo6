using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuest : MonoBehaviour {

    public GameObject paint;
    public GameObject speechBubble;
    public GameObject arrow;
    public GameObject droplet;
    public GameObject speechBubbleWarning;
    public GameObject x;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Body") showSpeechBubble();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Body") hideSpeechBubble();
    }

    private void showSpeechBubble()
    {
        arrow.GetComponent<SpriteRenderer>().enabled = true;
        paint.GetComponent<SpriteRenderer>().enabled = true;
        speechBubble.GetComponent<SpriteRenderer>().enabled = true;
        speechBubbleWarning.GetComponent<SpriteRenderer>().enabled = true;
        droplet.GetComponent<SpriteRenderer>().enabled = true;
        x.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void hideSpeechBubble()
    {
        arrow.GetComponent<SpriteRenderer>().enabled = false;
        paint.GetComponent<SpriteRenderer>().enabled = false;
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
        speechBubbleWarning.GetComponent<SpriteRenderer>().enabled = false;
        droplet.GetComponent<SpriteRenderer>().enabled = false;
        x.GetComponent<SpriteRenderer>().enabled = false;
    }
}
