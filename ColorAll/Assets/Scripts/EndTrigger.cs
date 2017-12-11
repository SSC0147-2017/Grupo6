using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public AudioClip thunderClip;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Body")
        {
            Debug.Log("Player colliding");
            transform.parent.GetComponent<Animator>().SetTrigger("OvercastTrigger");
            AudioSource.PlayClipAtPoint(thunderClip, transform.position, 
                                        GameObject.Find("MenuManager").GetComponent<MenuManager>().GetVolume());
            Destroy(gameObject);
        }
    }
}
