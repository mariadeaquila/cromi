using UnityEngine;
using System.Collections;

public class delay : MonoBehaviour
{
    public GameObject canvasAtual;   // Canvas 3
    public GameObject proximoCanvas; // Canvas 4

    public float tempoDelay = 2f; // tempo em segundos

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