using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----- Audio Clip -----")]
    public AudioClip background;
    public AudioClip meow1;
    public AudioClip meow2;
    public AudioClip trashFalling;
    public AudioClip posterSound;
    public AudioClip paperSound;
    public AudioClip squeak;
    public AudioClip blinds;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PaperSFX()
    {
        SFXSource.PlayOneShot(paperSound);
    }

    public void PosterSFX()
    {
        SFXSource.PlayOneShot(posterSound);
    }
    public void BinSFX()
    {
        SFXSource.PlayOneShot(trashFalling);
    }

    public void SqueakSFX()
    {
        SFXSource.PlayOneShot(squeak);
    }

    public void BlindsSFX()
    {
        SFXSource.PlayOneShot(blinds);
    }
}
