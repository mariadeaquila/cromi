using UnityEngine;

public class InteracaoPraia : MonoBehaviour
{
    public GameObject circulo;
    public GameObject painelErro;

    public GameObject telaAtual;
    public GameObject proximaTela;

    public int totalCorretos = 3; // quantidade de objetos certos
    private int acertos = 0;

    public void ClicouObjeto(GameObject botao, bool correto)
    {
        // Move o círculo
        circulo.SetActive(true);
        circulo.transform.position = botao.transform.position;

        if (correto)
        {
            acertos++;

            // Desativa o botão pra não contar duas vezes
            botao.SetActive(false);

            // Se acertou todos → troca de tela
            if (acertos >= totalCorretos)
            {
                telaAtual.SetActive(false);
                proximaTela.SetActive(true);
            }
        }
        else
        {
            painelErro.SetActive(true);
        }
    }
}