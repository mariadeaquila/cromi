using UnityEngine;

public class AudioCanvas : MonoBehaviour
{
    public AudioClip narracao;

    private AudioSource audioSource;

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();

        if (narracao != null)
        {
            audioSource.Stop();
            audioSource.clip = narracao;
            audioSource.Play();
        }
    }
}