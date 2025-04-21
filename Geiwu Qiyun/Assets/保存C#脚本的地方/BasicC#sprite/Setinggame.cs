using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setinggame : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public Button audioToggleButton;
    private bool isAudioPlaying = true;

    private void Start()
    {
        if (backgroundAudioSource == null)
        {
            Debug.LogError("Background AudioSource not assigned.");
            return;
        }

        if (audioToggleButton == null)
        {
            Debug.LogError("Audio Toggle Button not assigned.");
            return;
        }

        audioToggleButton.onClick.AddListener(ToggleAudio);
    }

    private void ToggleAudio()
    {
        isAudioPlaying = !isAudioPlaying;
        if (isAudioPlaying)
        {
            backgroundAudioSource.Play();
        }
        else
        {
            backgroundAudioSource.Pause();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
