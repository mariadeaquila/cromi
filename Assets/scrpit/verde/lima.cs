using UnityEngine;

public class lima : MonoBehaviour
{
    public GameObject painelCorreto;
    public GameObject painelErro;

    public GameObject telaAtual;
    public GameObject proximaTela;

    // RESPOSTA CORRETA
    public void RespostaCorreta()
    {
        painelCorreto.SetActive(true);
    }

    // RESPOSTA ERRADA
    public void RespostaErrada()
    {
        painelErro.SetActive(true);
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
