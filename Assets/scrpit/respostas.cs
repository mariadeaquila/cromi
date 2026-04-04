using UnityEngine;
using UnityEngine.UI;

public class respostas : MonoBehaviour
{
    public GameObject painelCorreto;
    public GameObject painelErrado;

    public GameObject panelexplicacaocorreta;
    public GameObject panelexplicacaoerrado;
    public GameObject tentenovamente;
    public GameObject continuar;

    public Sprite imagemVerde;
    public Sprite imagemVermelha;

    public Button[] botoes; // lista de todos os botões

    void TravarBotoes()
    {
        foreach (Button b in botoes)
        {
            b.interactable = false; // trava
        }
    }

    public void RespostaCorreta(GameObject botao)
    {
        botao.GetComponent<Image>().sprite = imagemVerde;
        painelCorreto.SetActive(true);
        TravarBotoes();
    }

    public void RespostaErrada(GameObject botao)
    {
        botao.GetComponent<Image>().sprite = imagemVermelha;
        painelErrado.SetActive(true);
        TravarBotoes();
    }

    public void ExplicacaoCorreta()
    {
        painelCorreto.SetActive(false); // fecha o de acerto
        panelexplicacaocorreta.SetActive(true); // abre explicação
    }

    public void ExplicacaoErrado()
    {
        painelErrado.SetActive(false); // fecha o de erro
        panelexplicacaoerrado.SetActive(true); // abre explicação
    }

    public void TentarNovamente()
    {
    painelErrado.SetActive(false); // fecha erro
    panelexplicacaoerrado.SetActive(false); // fecha explicação erro

    // reativa botões
    foreach (Button b in botoes)
    {
        b.interactable = true;
    }
    }
    public void Continuar()
    {
        panelexplicacaocorreta.SetActive(false); // fecha explicação correta
        // aqui você pode ir pra próxima fase depois
    }
}