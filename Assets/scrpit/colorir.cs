using UnityEngine;
using UnityEngine.UI;

public class colorir : MonoBehaviour
{
    [System.Serializable]
    public class Animal
    {
        public Button botao;
        public GameObject imagemColorida;
        public GameObject imagemX;
        public bool isCorreto;
    }

    [Header("Animais")]
    public Animal[] animais;

    [Header("Áudio")]
    public AudioSource audioSource;
    public AudioClip somAcerto;
    public AudioClip somErro;

    public void Start()
    {
        for (int i = 0; i < animais.Length; i++)
        {
            Animal a = animais[i];

            if (a.imagemColorida != null)
                a.imagemColorida.SetActive(false);

            if (a.imagemX != null)
                a.imagemX.SetActive(false);

            a.botao.onClick.RemoveAllListeners();
            a.botao.onClick.AddListener(() => ClicarAnimal(a));
        }
    }

    public void ClicarAnimal(Animal animal)
    {
        if (animal.isCorreto)
        {
            if (audioSource != null && somAcerto != null)
                audioSource.PlayOneShot(somAcerto);

            if (animal.imagemColorida != null)
                animal.imagemColorida.SetActive(true);
        }
        else
        {
            if (audioSource != null && somErro != null)
                audioSource.PlayOneShot(somErro);

            if (animal.imagemX != null)
                animal.imagemX.SetActive(true);
        }
    }
}