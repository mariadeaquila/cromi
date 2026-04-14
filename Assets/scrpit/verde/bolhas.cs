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

    // BOTÃO ERRADO
    public void RespostaErrada()
    {
        painelErro.SetActive(true);
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