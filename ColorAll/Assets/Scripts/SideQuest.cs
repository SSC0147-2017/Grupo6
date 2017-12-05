using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideQuest : MonoBehaviour {

    public GameObject paint;
    public GameObject speechBubble;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        showSpeechBubble();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hideSpeechBubble();
    }

    private void showSpeechBubble()
    {
        paint.GetComponent<SpriteRenderer>().enabled = true;
        speechBubble.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void hideSpeechBubble()
    {
        paint.GetComponent<SpriteRenderer>().enabled = false;
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
    }
}
