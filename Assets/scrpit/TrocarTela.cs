using UnityEngine;

public class TrocarTela : MonoBehaviour
{
    public GameObject canva;
    public GameObject canva2;
    public GameObject canva3;

    public void Trocar()
    {
         Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(true);
        canva3.SetActive(false);
    }
    public void Trocar2()
    {
        Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(true);
    }
    public void Voltar()
    {
        Debug.Log("CLICOU");
        canva.SetActive(true);
        canva2.SetActive(false);
        canva3.SetActive(false);
    }
    public void Voltar2()
    {
        Debug.Log("CLICOU");
        canva.SetActive(false);
        canva2.SetActive(true);
        canva3.SetActive(false);
    }
}
