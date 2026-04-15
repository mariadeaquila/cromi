using UnityEngine;

public class ColorGameManager : MonoBehaviour
{
    public GameObject panelVermelho;
    public GameObject panelAmarelo;
    public GameObject panelVerde;
    public GameObject panelAzul;
    public GameObject panelRoxo;
    public GameObject panelLaranja;

public void ProcessDetectedColor(string detectedColor)
{
    detectedColor = detectedColor.Trim().ToUpper();

    HideAllPanels();

    switch (detectedColor)
    {
        case "VERMELHO":
            panelVermelho.SetActive(true);
            break;
        case "AZUL":
            panelAzul.SetActive(true);
            break;
        case "VERDE":
            panelVerde.SetActive(true);
            break;
        case "AMARELO":
            panelAmarelo.SetActive(true);
            break;
        case "ROXO":
            panelRoxo.SetActive(true);
            break;
        case "LARANJA":
            panelLaranja.SetActive(true);
            break;
        default:
            Debug.Log("Cor não mapeada: " + detectedColor);
            break;
    }
}

    void HideAllPanels()
    {
        panelVermelho.SetActive(false);
        panelAmarelo.SetActive(false);
        panelVerde.SetActive(false);
        panelAzul.SetActive(false);
        panelRoxo.SetActive(false);
        panelLaranja.SetActive(false);
    }
}