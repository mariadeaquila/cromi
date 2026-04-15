using UnityEngine;

public class lima : MonoBehaviour
{
    public GameObject painelCorreto;
    public GameObject painelErro;

    public GameObject telaAtual;
    public GameObject proximaTela;

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

    // RESPOSTA CORRETA
    public void RespostaCorreta()
    {
        painelCorreto.SetActive(true);
        audioManager.TocarAcerto(); // ✅ som de acerto
        //audioManager.audioSource.Stop(); // opcional: para narração
    }

    // RESPOSTA ERRADA
    public void RespostaErrada()
    {
        painelErro.SetActive(true);
        audioManager.TocarErro(); // ❌ som de erro
        //audioManager.audioSource.Stop(); // opcional
    }

    // TENTAR NOVAMENTE
    public void TentarNovamente()
    {
        painelErro.SetActive(false);
    }

    // CONTINUAR
    public void Continuar()
    {
        telaAtual.SetActive(false);
        proximaTela.SetActive(true);
    }
}