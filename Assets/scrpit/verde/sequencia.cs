using UnityEngine;
using System.Collections;

public class sequencia : MonoBehaviour
{
    public GameObject[] imagens;
    public float tempoDelay = 5f;

    public GameObject painelAtual;
    public GameObject painelFinal;

    public void IniciarSequencia()
    {
        StartCoroutine(MostrarImagens());
    }

    IEnumerator MostrarImagens()
    {
        // ESCONDE O PAINEL ATUAL (ESSA ERA A PARTE QUE FALTAVA)
        painelAtual.SetActive(false);

        // garante tudo desligado
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

        // abre painel final
        painelFinal.SetActive(true);
    }
}