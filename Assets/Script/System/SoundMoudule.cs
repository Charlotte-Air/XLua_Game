using UnityEngine;
using System.Collections;

public class SoundMoudule
{
    public AudioSource sourceEffect;
    public AudioSource sourceMusic;

    public SoundMoudule(AudioSource music, AudioSource effect)
    {
        sourceEffect = effect ;
        sourceMusic =  music;

        _enableMusic = PlayerPrefs.GetInt("enableMusic", 1) == 1;
        _enableEffect = PlayerPrefs.GetInt("enableEffect", 1) == 1;
    }


    bool _enableMusic;
    bool _enableEffect;

    public bool enableMusic
    {
        get
        {
            return _enableMusic;
        }
        set
        {
            if (_enableMusic == value)
                return;

            PlayerPrefs.SetInt("enableMusic", value ? 1 : 0);
            _enableMusic = value;
            if (_enableMusic == true)
            {
                sourceMusic.Play();
            }
            else
            {
                sourceMusic.Stop();
            }
        }
    }

    public bool enableEffect
    {
        get
        {
            return _enableEffect;
        }
        set
        {
            PlayerPrefs.SetInt("enableEffect", value ? 1 : 0);
            _enableEffect = value;
        }
    }

    public void PlaySound(string name)
    {
        AudioClip clip =  ResourceManager.LoadAudioClip ("Sound", name) as AudioClip;
        PlaySoundEffect(clip);
    }
    public void PlaySoundWav(string name)
    {
        AudioClip clip = ResourceManager.LoadAudioClipWAV("Sound", name) as AudioClip;
        PlaySoundEffect(clip);
        
    }
      void PlaySoundEffect(AudioClip clip)
    {
        if (!enableEffect)
            return;

        sourceEffect.priority = 50;
        sourceEffect.PlayOneShot(clip);
    }

    public void PlayMusic(string name, bool loop = true)
    {
        AudioClip clip = ResourceManager.LoadAudioClip("Sound", name);

        if (sourceMusic.isPlaying)
        {
            if (sourceMusic.clip.GetHashCode() == clip.GetHashCode())
                return;
        }

        sourceMusic.clip = clip;
        sourceMusic.priority = 50;
        sourceMusic.loop = loop;

        if (enableMusic)
            sourceMusic.Play();
    }
}
