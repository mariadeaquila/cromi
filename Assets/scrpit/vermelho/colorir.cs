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

    public AudioClip narracao; // 🗣️ opcional

    AudioManager audioManager;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (narracao != null)
        {
            audioManager.TocarNarracao(narracao);
        }

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
            audioManager.TocarAcerto(); // ✅ som

            if (animal.imagemColorida != null)
                animal.imagemColorida.SetActive(true);
        }
        else
        {
            audioManager.TocarErro(); // ❌ som

            if (animal.imagemX != null)
                animal.imagemX.SetActive(true);
        }
    }
}