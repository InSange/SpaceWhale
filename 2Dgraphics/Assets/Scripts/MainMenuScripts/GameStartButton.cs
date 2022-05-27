using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip MainAudio;
    public AudioClip StartButtonAudio;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MainAudio;
        audioSource.Play();
    }
    public void clickStartBtn()
    {
        audioSource.clip = StartButtonAudio;
        audioSource.Play();
        SceneManager.LoadScene("InGame");
    }
}
