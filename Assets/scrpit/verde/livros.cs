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

    [Header("Botões e Imagens")]
    public GameObject[] botoesCorretos;

    private int acertos = 0;

    // BOTÃO CORRETO (SEM PARÂMETRO)
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