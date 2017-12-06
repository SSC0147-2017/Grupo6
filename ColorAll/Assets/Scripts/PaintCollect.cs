using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCollect : MonoBehaviour {

    public GameObject sam;
    public GameObject speechBubble;
    public GameObject bottle;

    private Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Body")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            showSpeechBubble();
            player.maxBlocks = 5;
            bottle.GetComponent<WaterSpawner>().ChangeInterval(0.4f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Body") hideSpeechBubble();
    }

    private void showSpeechBubble()
    {
        sam.GetComponent<SpriteRenderer>().enabled = true;
        speechBubble.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void hideSpeechBubble()
    {
        sam.GetComponent<SpriteRenderer>().enabled = false;
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
    }
}
