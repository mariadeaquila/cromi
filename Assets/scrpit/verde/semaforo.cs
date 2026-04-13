using UnityEngine;

public class semaforo : MonoBehaviour
{
    public GameObject painelErro;
    public GameObject painelAcerto;

    public GameObject telaAtual;
    public GameObject proximaTela;
    public GameObject painelExplicacao;

    // Chamado pelos botões
    public void Resposta(bool correta)
    {
        if (correta)
        {
            painelAcerto.SetActive(true);
        }
        else
        {
            painelErro.SetActive(true);
        }
    }

    // Botão: Tentar novamente
    public void TentarNovamente()
    {
        painelErro.SetActive(false);
    }
    //botao: explique
    public void Explicacao()
    {
        painelErro.SetActive(false);
        painelExplicacao.SetActive(true);
    }
    // Botão: Continuar
    public void Continuar()
    {
        painelAcerto.SetActive(false);
        telaAtual.SetActive(false);
        proximaTela.SetActive(true);
    }
}