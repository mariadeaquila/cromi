using UnityEngine;
using UnityEngine.EventSystems;

public class livros : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelErro;
    public GameObject painelCorreto;

    [Header("Telas")]
    public GameObject telaAtual;
    public GameObject proximaTela;

    [Header("Botões corretos")]
    public GameObject[] botoesCorretos;

    private int acertos = 0;

    public AudioClip narracao; // 🗣️ narração dessa atividade

    AudioManager audioManager;

    void Start()
{
    audioManager = FindAnyObjectByType<AudioManager>();

    if (narracao != null)
    {
        audioManager.TocarNarracao(narracao);
    }
}

    // BOTÃO CORRETO
    public void RespostaCorreta()
    {
        GameObject botaoClicado = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < botoesCorretos.Length; i++)
        {
            if (botaoClicado == botoesCorretos[i])
            {
                if (!botoesCorretos[i].activeSelf) return;

                botoesCorretos[i].SetActive(false);

                acertos++;

                audioManager.TocarAcerto(); // ✅ som de acerto
                //audioManager.audioSource.Stop(); // opcional: para narração

                if (acertos >= botoesCorretos.Length)
                {
                    painelCorreto.SetActive(true);
                }

                break;
            }
        }
    }

    // BOTÃO ERRADO
    public void RespostaErrada()
    {
        painelErro.SetActive(true);
        audioManager.TocarErro(); // ❌ som de erro
        //audioManager.audioSource.Stop(); // opcional
    }

    public void TentarNovamente()
    {
        painelErro.SetActive(false);
    }

    public void Continuar()
    {
        telaAtual.SetActive(false);
        proximaTela.SetActive(true);
    }
}