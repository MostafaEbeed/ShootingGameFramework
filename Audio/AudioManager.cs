using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    public struct AudioStruct
    {
        public AudioClip audioClip;
        public SFX SFXEnum;
    }
    [Header("SFX")]
    [SerializeField] private AudioMixerGroup sfx;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private List<AudioClip> sfxAudioClips;

    [Space(10)]
    [Header("Music")]
    [SerializeField] private bool muteMusic;
    [SerializeField] private AudioMixerGroup bgMusic;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private List<AudioClip> musicAudioClips;

    private readonly float maxVolume = 0.5f;
    private bool isMusicOn = true;
    private float currentMusicLength;
    private int currentMusicIndex = 0;
    private float startFadeOutAt_Percentage = 0.8f;
    private float decreaseVolumeBy;
    private float currentMusicTime;

    private void Start()
    {
        musicSource.volume = 0.0f;
        currentMusicIndex = -1;
        if (muteMusic)
            MuteMusic(!muteMusic);
        RunNextMusicClip();
    }

    private void Update()
    {
        if (!isMusicOn)
            return;
        currentMusicTime = musicSource.time;
        if (currentMusicTime >= currentMusicLength)
        {
            RunNextMusicClip();
        }
        else if ((currentMusicTime / currentMusicLength) < 0.2f)
        {
            musicSource.volume += decreaseVolumeBy * Time.deltaTime;
            if (musicSource.volume > maxVolume)
                musicSource.volume = maxVolume;
        }
        else if ((currentMusicTime / currentMusicLength) > 0.8f)
        {
            musicSource.volume -= decreaseVolumeBy * Time.deltaTime;
        }
    }

    public void PlaySFX(SFX sfx)
    {
        sfxSource.PlayOneShot(sfxAudioClips[(int)sfx], 1);
    }

    public void RunNextMusicClip()
    {
        currentMusicIndex++;
        if (currentMusicIndex >= musicAudioClips.Count)
            currentMusicIndex = 0;

        musicSource.clip = musicAudioClips[currentMusicIndex];
        currentMusicLength = musicAudioClips[currentMusicIndex].length;
        decreaseVolumeBy = maxVolume / ((1 - startFadeOutAt_Percentage) * musicAudioClips[currentMusicIndex].length);
        musicSource.volume = 0;
        musicSource.Play();
    }

    public void MuteSound(bool isOn)
    {
        if (isOn)
        {
            sfx.audioMixer.SetFloat(sfx.name + "Volume", 0f);
        }
        else
        {
            sfx.audioMixer.SetFloat(sfx.name + "Volume", -80f);
        }
    }

    public void MuteMusic(bool isOn)
    {
        isMusicOn = isOn;
        if (isOn)
        {
            bgMusic.audioMixer.SetFloat(bgMusic.name + "Volume", 0f);
        }
        else
        {
            bgMusic.audioMixer.SetFloat(bgMusic.name + "Volume", -80f);
        }
    }

}

public enum SFX
{
    SFX_Gun,
    SFX_ButtonClick,
    SFX_ButtonExit,
    SFX_Hint,
}