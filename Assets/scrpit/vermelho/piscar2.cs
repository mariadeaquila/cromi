using UnityEngine;
using System.Collections;

public class piscar2 : MonoBehaviour
{
    public GameObject mascoteAberto;
    public GameObject mascotePiscando;

    void Start()
    {
        StartCoroutine(Piscar());
    }

    IEnumerator Piscar()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));

            mascoteAberto.SetActive(false);
            mascotePiscando.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            mascotePiscando.SetActive(false);
            mascoteAberto.SetActive(true);
        }
    }
}