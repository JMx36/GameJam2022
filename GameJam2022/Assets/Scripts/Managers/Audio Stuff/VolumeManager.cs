using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private AudioMixer music;
    [SerializeField] private AudioMixer sfx;

    public void setMusicVol(float volume)
    {
        music.SetFloat("MusicVolume", volume);
    }

    public void setSFXVol(float volume)
    {
        sfx.SetFloat("SFXVolume", volume);
    }
}
