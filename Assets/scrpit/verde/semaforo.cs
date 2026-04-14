using UnityEngine;

public class semaforo : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelCorreto;
    public GameObject painelErrado;
    public GameObject painelExplicacao;

    [Header("Telas")]
    public GameObject telaAtual;
    public GameObject proximaTela;

    // Chamado quando clica em uma resposta
    public void VerificarResposta(bool correto)
    {
        if (correto)
        {
            painelCorreto.SetActive(true);
        }
        else
        {
            painelErrado.SetActive(true);
        }
    }

    // Botão: Tentar novamente
    public void TentarNovamente()
    {
        painelErrado.SetActive(false);
    }

    // Botão: Explicar resposta
    public void ExplicarResposta()
    {
        painelErrado.SetActive(false);
        painelExplicacao.SetActive(true);
    }

    // Botão: Fechar explicação (opcional)
    public void FecharExplicacao()
    {
        painelExplicacao.SetActive(false);
    }

    // Botão: Continuar (no painel correto)
    public void Continuar()
    {
        telaAtual.SetActive(false);
        proximaTela.SetActive(true);
    }
}