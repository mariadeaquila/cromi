using UnityEngine;

public class GerenciadorCores : MonoBehaviour
{
    public GameObject painelVermelho;
    public GameObject painelLaranja;
    public GameObject painelAmarelo;
    public GameObject painelRoxo;
    public GameObject painelVerde;
    public GameObject painelAzul;
    public GameObject painelErro;

    string ultimaCor = "";

    public void ReceberCor(string cor)
    {
        cor = cor.Trim().ToUpper();

        if (cor == ultimaCor)
            return;

        ultimaCor = cor;

        Debug.Log("Cor recebida: " + cor);

        DesativarTodos();

        if (cor == "VERMELHO")
            painelVermelho.SetActive(true);

        else if (cor == "LARANJA")
            painelLaranja.SetActive(true);

        else if (cor == "AMARELO")
            painelAmarelo.SetActive(true);

        else if (cor == "ROXO")
            painelRoxo.SetActive(true);

        else if (cor == "VERDE")
            painelVerde.SetActive(true);

        else if (cor == "AZUL")
            painelAzul.SetActive(true);

        else
            painelErro.SetActive(true);
    }

    void DesativarTodos()
    {
        painelVermelho.SetActive(false);
        painelLaranja.SetActive(false);
        painelAmarelo.SetActive(false);
        painelRoxo.SetActive(false);
        painelVerde.SetActive(false);
        painelAzul.SetActive(false);

        if (painelErro != null)
            painelErro.SetActive(false);
    }
}