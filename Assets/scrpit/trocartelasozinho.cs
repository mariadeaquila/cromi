using UnityEngine;
using System.Collections;

public class trocartelasozinho : MonoBehaviour
{
    public GameObject canvasAnterior;
    public GameObject canvasSeguinte;

    public float tempo = 5f;

    void Start()
    {
        StartCoroutine(Trocar());
    }

    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(tempo);

        canvasAnterior.SetActive(false);
        canvasSeguinte.SetActive(true);
    }
}