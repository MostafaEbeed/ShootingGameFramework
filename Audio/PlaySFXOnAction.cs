using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFXOnAction : MonoBehaviour
{
    [SerializeField] private SFX sFXOnClick;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PlaySFX()
    {
        if (!audioManager)
        {
            Debug.LogError($"No AudioManager found to play the SFX");
            return;
        }
        audioManager.PlaySFX(sFXOnClick);
    }

    public void PlaySFX(SFX sFX)
    {
        if (!audioManager)
        {
            Debug.LogError($"No AudioManager found to play the SFX");
            return;
        }
        audioManager.PlaySFX(sFX);
    }
}
