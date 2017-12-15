using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public AudioClip thunderClip;
    public GameObject fadeOutPanel;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Body")
        {
            Debug.Log("Player colliding");
            transform.parent.GetComponent<Animator>().SetTrigger("OvercastTrigger");
            AudioSource.PlayClipAtPoint(thunderClip, transform.position, 
                                        GameObject.Find("MenuManager").GetComponent<MenuManager>().GetVolume());

            FindObjectOfType<Player>().SetEndTriggerOn();

            fadeOutPanel.GetComponent<Animator>().SetTrigger("FadeOutTrigger");

            Invoke("LoadMenu", 10f);

           // Destroy(gameObject);

        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("00 Start Menu");
    }
}
