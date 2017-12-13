using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCollect : MonoBehaviour {

    public GameObject sam;
    public GameObject speechBubble, speechSideQuest;
    public GameObject bottle;
    public GameObject blockCounter0, blockCounter1, blockCounter2;

    private Player player;
    private bool firstTime = true;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        blockCounter0.SetActive(false);
        blockCounter1.SetActive(false);
        blockCounter2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Body" && firstTime)
        {
            DestroyObject(speechSideQuest);
            firstTime = false;
            GetComponent<SpriteRenderer>().enabled = false;
            showSpeechBubble();
            player.maxBlocks = 3;
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
        blockCounter0.SetActive(true);
        blockCounter1.SetActive(true);
        blockCounter2.SetActive(true);
    }

    private void hideSpeechBubble()
    {
        sam.GetComponent<SpriteRenderer>().enabled = false;
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
    }
}
