using UnityEngine;

public class ColorGameManager : MonoBehaviour
{
    [Header("Painéis principais")]
    public GameObject panelPergunta;
    public GameObject panelAcerto;

    [Header("Erros por cor")]
    public GameObject panelErroAmarelo;
    public GameObject panelErroAzul;
    public GameObject panelErroVerde;
    public GameObject panelErroRoxo;
    public GameObject panelErroLaranja;

    private string corEsperada = "VERMELHO";

    void Start()
    {
        MostrarApenas(panelPergunta);
        Debug.Log("Esperando cor: VERMELHO");
    }

    public void ProcessDetectedColor(string detectedColor)
    {
        detectedColor = detectedColor.Trim().ToUpper();

        Debug.Log("Cor detectada: " + detectedColor);

        HideAllPanels();

        if (detectedColor == corEsperada)
        {
            // ✅ ACERTO
            panelAcerto.SetActive(true);
        }
        else
        {
            // ❌ ERRO → mostra personagem da cor detectada
            switch (detectedColor)
            {
                case "AMARELO":
                    panelErroAmarelo.SetActive(true);
                    break;
                case "AZUL":
                    panelErroAzul.SetActive(true);
                    break;
                case "VERDE":
                    panelErroVerde.SetActive(true);
                    break;
                case "ROXO":
                    panelErroRoxo.SetActive(true);
                    break;
                case "LARANJA":
                    panelErroLaranja.SetActive(true);
                    break;
                default:
                    Debug.Log("Cor não reconhecida: " + detectedColor);
                    break;
            }
        }
    }

    void MostrarApenas(GameObject panelAtivo)
    {
        HideAllPanels();
        panelAtivo.SetActive(true);
    }

    void HideAllPanels()
    {
        panelPergunta.SetActive(false);
        panelAcerto.SetActive(false);

        panelErroAmarelo.SetActive(false);
        panelErroAzul.SetActive(false);
        panelErroVerde.SetActive(false);
        panelErroRoxo.SetActive(false);
        panelErroLaranja.SetActive(false);
    }
}