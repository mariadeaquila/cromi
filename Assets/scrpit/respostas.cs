using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuizManager : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelCorreto;
    public GameObject painelErrado;
    public GameObject painelExplicacaoCorreta;
    public GameObject painelExplicacaoErrado;

    [Header("Navegação")]
    public GameObject painelAtual;
    public GameObject proximoPainel;

    [Header("Botões")]
    public Button[] botoes;

    [Header("Imagens")]
    public Sprite imagemVerde;
    public Sprite imagemVermelha;

    // 🔒 trava botões
    void TravarBotoes()
    {
        foreach (Button b in botoes)
        {
            b.interactable = false;
        }
    }

    // 🔓 libera botões
    void LiberarBotoes()
    {
        foreach (Button b in botoes)
        {
            b.interactable = true;
        }
    }

    // ✅ resposta correta
    public void RespostaCorreta()
    {
        GameObject botao = EventSystem.current.currentSelectedGameObject;
        botao.GetComponent<Image>().sprite = imagemVerde;

        painelCorreto.SetActive(true);
        TravarBotoes();
    }

    // ❌ resposta errada
    public void RespostaErrada()
    {
        GameObject botao = EventSystem.current.currentSelectedGameObject;
        botao.GetComponent<Image>().sprite = imagemVermelha;

        painelErrado.SetActive(true);
        TravarBotoes();
    }

    // 📘 explicação correta
    public void ExplicacaoCorreta()
    {
        painelCorreto.SetActive(false);
        painelExplicacaoCorreta.SetActive(true);
    }

    // 📕 explicação errada
    public void ExplicacaoErrado()
    {
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(true);
    }

    // 🔁 tentar novamente
    public void TentarNovamente()
    {
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(false);
        LiberarBotoes();
    }

    // ➡️ continuar (vai pra próxima atividade)
    public void Continuar()
    {
        painelExplicacaoCorreta.SetActive(false);
        painelCorreto.SetActive(false);

        painelAtual.SetActive(false);
        proximoPainel.SetActive(true);
    }
}