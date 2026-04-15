using UnityEngine;
using System.Collections;

public class trocartela2: MonoBehaviour
{
    public GameObject canvasAtual;
    public GameObject proximoCanvas;

    public float tempoDelay = 2f;

    void OnEnable()
    {
        StartCoroutine(TrocarDepoisDoTempo());
    }

    IEnumerator TrocarDepoisDoTempo()
    {
        yield return new WaitForSeconds(tempoDelay);

        canvasAtual.SetActive(false);
        proximoCanvas.SetActive(true);
    }
}