using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel, settingsPanel, howToPlayPanel, backPanel;

    private AudioSource music;

    private const string VOLUME_PREFS = "GlobalVolume";

    // Use this for initialization
    void Start()
    {
        music = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat(VOLUME_PREFS);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_PREFS);
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
        PlayerPrefs.SetFloat(VOLUME_PREFS, volume);
    }

    public void SetActiveMenuWindow(int window)
    {
        mainMenuPanel.SetActive(window == 0);
        settingsPanel.SetActive(window == 1);
        howToPlayPanel.SetActive(window == 2);
    }

    public void SetActivePauseMenuWindow(int window)
    {
        if (window > 0)
        {
            Time.timeScale = 0f;
            backPanel.SetActive(true);
            mainMenuPanel.SetActive(window == 1);
            settingsPanel.SetActive(window == 2);
            howToPlayPanel.SetActive(window == 3);
        }
        else
        {
            mainMenuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            howToPlayPanel.SetActive(false);
            backPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
