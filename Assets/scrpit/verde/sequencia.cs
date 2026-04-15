using UnityEngine;
using System.Collections;

public class sequencia : MonoBehaviour
{
    public GameObject[] imagens;
    public float tempoDelay = 1f;

    public GameObject painelAtual;
    public GameObject painelFinal;

    public void IniciarSequencia()
    {
        StartCoroutine(MostrarImagens());
    }

    IEnumerator MostrarImagens()
    {
        // garante que todas começam desligadas
        foreach (GameObject img in imagens)
        {
            img.SetActive(false);
        }

        // mostra uma por uma
        for (int i = 0; i < imagens.Length; i++)
        {
            imagens[i].SetActive(true);

            yield return new WaitForSeconds(tempoDelay);

            imagens[i].SetActive(false);
        }

        // só aqui troca de painel
        painelAtual.SetActive(false);
        painelFinal.SetActive(true);
    }
}