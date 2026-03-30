using UnityEngine;

public class TrocarTela : MonoBehaviour
{
    public GameObject canva;
    public GameObject canva2;
    public GameObject canva3;
    public GameObject canva4;
    public GameObject canvaInicio;

    public void Trocar()
    {
         Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(true);
        canva3.SetActive(false);
        canva4.SetActive(false);
    }
    public void Trocar2()
    {
        Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(true);
        canva4.SetActive(false);
    }
    public void Trocar3()
    {
        Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(false);
        canva4.SetActive(true);
    }

    public void Trocar4()
    {
        Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(false);
        canva4.SetActive(false);
        canvaInicio.SetActive(true);
    }
    public void Voltar()
    {
        Debug.Log("CLICOU");
        canva.SetActive(true);
        canva2.SetActive(false);
        canva3.SetActive(false);
        canva4.SetActive(false);
    }
    public void Voltar2()
    {
        Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(true);
        canva3.SetActive(false);
        canva4.SetActive(false);
    }
    public void Voltar3()
    {
        Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(true);
        canva4.SetActive(false);
    }
}
