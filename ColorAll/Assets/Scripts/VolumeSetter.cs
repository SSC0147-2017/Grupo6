using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    private MenuManager menuManager;
    private Slider slider;

    // Use this for initialization
    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        slider = GetComponent<Slider>();

        slider.value = menuManager.GetVolume();
    }

    public void SetVolume()
    {
        menuManager.SetVolume(slider.value);
    }
}
