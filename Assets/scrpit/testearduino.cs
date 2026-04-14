using UnityEngine;

public class LeitorCor : MonoBehaviour
{
    public string corEsperada = "VERMELHO";

    // Painéis
    public GameObject painelAcerto;
    public GameObject erroAmarelo;
    public GameObject erroVerde;
    public GameObject erroAzul;
    public GameObject erroRoxo;
    public GameObject erroLaranja;

    void DesativarTodos()
    {
        painelAcerto.SetActive(false);
        erroAmarelo.SetActive(false);
        erroVerde.SetActive(false);
        erroAzul.SetActive(false);
        erroRoxo.SetActive(false);
        erroLaranja.SetActive(false);
    }

    public void ReceberCor(string corRecebida)
    {
        Debug.Log("Recebido: " + corRecebida);

        DesativarTodos();

        if (corRecebida == corEsperada)
        {
            painelAcerto.SetActive(true);
        }
        else
        {
            switch (corRecebida)
            {
                case "AMARELO":
                    erroAmarelo.SetActive(true);
                    break;

                case "VERDE":
                    erroVerde.SetActive(true);
                    break;

                case "AZUL":
                    erroAzul.SetActive(true);
                    break;

                case "ROXO":
                    erroRoxo.SetActive(true);
                    break;

                case "LARANJA":
                    erroLaranja.SetActive(true);
                    break;
               
            }
        }
    }
}