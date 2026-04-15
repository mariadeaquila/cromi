using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelCorreto;
    public GameObject painelErrado;
    public GameObject painelExplicacaoErrado;

    [Header("Navegação")]
    public GameObject painelAtual;
    public GameObject proximoPainel;

    [Header("Botões")]
    public Button[] botoes;

    public AudioClip narracao; // 🗣️ opcional

    AudioManager audioManager;

    void Start()
    {
        painelCorreto.SetActive(false);
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(false);

        LiberarBotoes();

        audioManager = FindAnyObjectByType<AudioManager>();

        if (narracao != null)
        {
            audioManager.TocarNarracao(narracao);
        }
    }

    void TravarBotoes()
    {
        foreach (Button b in botoes)
        {
            b.interactable = false;
        }
    }

    void LiberarBotoes()
    {
        foreach (Button b in botoes)
        {
            b.interactable = true;
        }
    }

    public void RespostaCorreta()
    {
        audioManager.TocarAcerto(); // ✅ som

        painelCorreto.SetActive(true);
        TravarBotoes();
    }

    public void RespostaErrada()
    {
        audioManager.TocarErro(); // ❌ som

        painelErrado.SetActive(true);
        TravarBotoes();
    }

    public void ExplicacaoErrado()
    {
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(true);
    }

    public void TentarNovamente()
    {
        StartCoroutine(ResetCanvas());
    }

    IEnumerator ResetCanvas()
    {
        yield return new WaitForEndOfFrame();

        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(false);
        painelCorreto.SetActive(false);

        painelAtual.SetActive(true);

        LiberarBotoes();

        yield return null;

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    public void Continuar()
    {
        painelCorreto.SetActive(false);

        painelAtual.SetActive(false);
        proximoPainel.SetActive(true);
    }
}