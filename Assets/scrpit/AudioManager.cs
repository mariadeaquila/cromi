using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip somAcerto;
    public AudioClip somErro;

 void Awake()
{
    if (FindObjectsOfType<AudioManager>().Length > 1)
    {
        Destroy(gameObject);
        return;
    }

    DontDestroyOnLoad(gameObject);
}
    public void TocarAcerto()
    {
        audioSource.PlayOneShot(somAcerto);
    }

    public void TocarErro()
    {
        audioSource.PlayOneShot(somErro);
    }

    // 🗣️ agora recebe qualquer narração
    public void TocarNarracao(AudioClip narracao)
    {
        audioSource.clip = narracao;
        audioSource.Play();
    }
}