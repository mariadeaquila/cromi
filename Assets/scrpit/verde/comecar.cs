using UnityEngine;

public class comecar : MonoBehaviour
{
    public GameObject canvasAtual;
    public GameObject proximoCanvas;

    public void IrParaProximoCanvas()
    {
        canvasAtual.SetActive(false);
        proximoCanvas.SetActive(true);
    }
}