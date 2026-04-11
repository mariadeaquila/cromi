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

    [Header("Áudio")]
    public AudioSource audioSource;
    public AudioClip somAcerto;
    public AudioClip somErro;

    void Start()
    {
        painelCorreto.SetActive(false);
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(false);
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

    void ResetarBotoes()
{
    if (EventSystem.current != null)
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}

    public void RespostaCorreta()
    {
        if (audioSource != null && somAcerto != null)
        {
            audioSource.PlayOneShot(somAcerto);
        }

        painelCorreto.SetActive(true);
        TravarBotoes();
    }

    public void RespostaErrada()
    {
        if (audioSource != null && somErro != null)
        {
            audioSource.PlayOneShot(somErro);
        }

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
    painelErrado.SetActive(false);
    painelExplicacaoErrado.SetActive(false);

    LiberarBotoes();

    StartCoroutine(ResetFocus());
}

IEnumerator ResetFocus()
{
    yield return new WaitForEndOfFrame();

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