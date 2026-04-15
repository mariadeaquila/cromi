using UnityEngine;

public class bolhas : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelErro;
    public GameObject painelCorreto;

    [Header("Telas")]
    public GameObject telaAtual;
    public GameObject proximaTela;
    public GameObject botao;
    public GameObject botao2;
    public GameObject botao3;
    public GameObject imagem;
    public GameObject imagem2;
    public GameObject imagem3;

    [Header("Configuração")]
    public int totalCorretos = 3;
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

    // BOTÃO ERRADO
    public void RespostaErrada()
    {
        painelErro.SetActive(true);
        audioManager.TocarErro(); // ❌ som de erro

    }

    // BOTÃO "TENTAR NOVAMENTE"
    public void TentarNovamente()
    {
        painelErro.SetActive(false);
    }

    // BOTÃO CORRETO
    public void RespostaCorreta()
    {
        botao.SetActive(false);
        imagem.SetActive(true);

        acertos++;

        audioManager.TocarAcerto(); // ✅ som de acerto

        if (acertos >= totalCorretos)
        {
            painelCorreto.SetActive(true);
        }
    }

    // BOTÃO CONTINUAR
    public void Continuar()
    {
        telaAtual.SetActive(false);
        proximaTela.SetActive(true);
    }
}