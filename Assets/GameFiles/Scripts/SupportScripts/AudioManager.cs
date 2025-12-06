using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Properties
    public static AudioManager Instance { get; private set; }

    [Header("Components Reference")]
    [SerializeField] private AudioSource audioSource = null;

    [Header("Audioclips Reference")]
    [SerializeField] private AudioClip cardFlipSFX = null;
    [SerializeField] private AudioClip cardMatchSFX = null;
    [SerializeField] private AudioClip cardMismatchSFX = null;
    [SerializeField] private AudioClip gameOverSFX = null;
    [SerializeField] private AudioClip victorySFX = null;
    #endregion

    #region MonoBehaviour Functions
    private void Awake()
    {
        // Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }
    #endregion

    #region Public Core Functions
    public void PlayCardFlipSFX()
    {
        audioSource.PlayOneShot(cardFlipSFX);
    }

    public void PlayCardMatchSFX()
    {
        audioSource.PlayOneShot(cardMatchSFX);
    }

    public void PlayCardMismatchSFX()
    {
        audioSource.PlayOneShot(cardMismatchSFX);
    }

    public void PlayGameOverSFX()
    {
        audioSource.PlayOneShot(gameOverSFX);
    }

    public void PlayVictorySFX()
    {
        audioSource.PlayOneShot(victorySFX);
    }
    #endregion
}
