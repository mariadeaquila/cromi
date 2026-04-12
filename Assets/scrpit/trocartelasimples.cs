using UnityEngine;

public class trocartelasimples : MonoBehaviour
{
    public GameObject canva1;
    public GameObject canva2;
    public GameObject inicio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MostrarTela1()
    {
        canva1.SetActive(true);
        canva2.SetActive(false);
        inicio.SetActive(false);
    }

    // Update is called once per frame
   public void MostrarTela2()
    {
        canva1.SetActive(false);
        canva2.SetActive(true);
        inicio.SetActive(false);
    }

    public void Voltar()
    {
        canva1.SetActive(false);
        canva2.SetActive(false);
        inicio.SetActive(inicio);
    }
}
