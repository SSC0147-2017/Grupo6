using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleExtra : MonoBehaviour {

    public GameObject blockCounterEnd, blockCounterNew;

    private bool firstTime = true;
    private Player player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();
        blockCounterNew.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Body" && firstTime)
        {
            firstTime = false;
            GetComponent<SpriteRenderer>().enabled = false;
            player.maxBlocks++;
            RectTransform rt = blockCounterNew.GetComponent<RectTransform>();
            Vector3 vec = new Vector3(rt.rect.width, 0, 0);
            blockCounterEnd.transform.position += vec;
            blockCounterNew.SetActive(true);
        }
    }
}
