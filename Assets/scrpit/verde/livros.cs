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

    [Header("Botões corretos (6)")]
    public GameObject[] botoesCorretos;

    [Header("Imagens dos corretos (6)")]
    public GameObject[] imagensCorretas;

    [Header("Botões errados (6)")]
    public GameObject[] botoesErrados;

    [Header("Imagens dos errados (6)")]
    public GameObject[] imagensErradas;

    private int acertos = 0;

    public AudioClip narracao;

    AudioManager audioManager;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (narracao != null)
        {
            audioManager.TocarNarracao(narracao);
        }
    }

    // ✅ BOTÃO CORRETO
    public void RespostaCorreta()
    {
        GameObject botaoClicado = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < botoesCorretos.Length; i++)
        {
            if (botaoClicado == botoesCorretos[i])
            {
                if (!botoesCorretos[i].activeSelf) return;

                // Esconde botão e mostra imagem correspondente
                botoesCorretos[i].SetActive(false);
                imagensCorretas[i].SetActive(true);

                acertos++;

                audioManager.TocarAcerto();

                if (acertos >= botoesCorretos.Length)
                {
                    painelCorreto.SetActive(true);
                }

                break;
            }
        }
    }

    // ❌ BOTÃO ERRADO
    public void RespostaErrada()
    {
        GameObject botaoClicado = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < botoesErrados.Length; i++)
        {
            if (botaoClicado == botoesErrados[i])
            {
                // Esconde botão e mostra imagem correspondente
                botoesErrados[i].SetActive(false);
                imagensErradas[i].SetActive(true);
                break;
            }
        }

        painelErro.SetActive(true);
        audioManager.TocarErro();
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