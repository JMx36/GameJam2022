using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject menuCanvas;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private AudioMixer sfxMixer; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (menuCanvas.activeInHierarchy)
            {
                menuCanvas.SetActive(false);
                GameStateManager.PauseGame(1);
            }
            else
            {
                menuCanvas.SetActive(true);
                GameStateManager.PauseGame(0);
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetSfxVolume(float volume)
    {
        sfxMixer.SetFloat("SFXVolume", volume);
    }

    public void Quit()
    {
        GameStateManager.Quit();
    }

    public void Restart()
    {
        GameStateManager.PauseRestart();
    }
}
