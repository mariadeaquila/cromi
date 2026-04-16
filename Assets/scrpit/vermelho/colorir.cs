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
        public GameObject proximopainel;
        public GameObject painelatual;
    }

    [Header("Animais")]
    public Animal[] animais;

    public AudioClip narracao;

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
            audioManager.TocarAcerto();

            if (animal.imagemColorida != null)
            {
                animal.imagemColorida.SetActive(true);
            }

            // 👉 TROCA DE PAINEL (corrigido)
            if (animal.proximopainel != null)
                animal.proximopainel.SetActive(true);

            if (animal.painelatual != null)
                animal.painelatual.SetActive(false);
        }
        else
        {
            audioManager.TocarErro();

            if (animal.imagemX != null)
            {
                animal.imagemX.SetActive(true);
            }
        }
    }
}