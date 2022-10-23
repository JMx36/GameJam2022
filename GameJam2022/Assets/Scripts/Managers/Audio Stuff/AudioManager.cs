using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup sfxGroup;
    [SerializeField] private AudioMixerGroup musicGroup;

    public Sound[] sounds;

    public static AudioManager instance;

    /* HOW TO USE:
     * FindObjectOfType<AudioManager>().Play("SOUND NAME");
     *                                   ^^ Can be replaced with other methods
    */

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
            return;
        }


        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            if (!s.bgm) {
                s.source.outputAudioMixerGroup = sfxGroup;
            } else {
                s.source.outputAudioMixerGroup = musicGroup;
            }
        }

    }

    public Sound Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s != null)
            s.source.Play();

        return s;
    }

    public Sound PlayOneShot(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s != null)
            s.source.PlayOneShot(s.source.clip);

        return s;
    }

    public Sound Stop(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s != null)
            s.source.Stop();

        return s;
    }

    public Sound Pause(string soundName, bool pause)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s != null) {
            if (pause)
                s.source.Pause();
            else
                s.source.UnPause();
        }

        return s;
    }

}
