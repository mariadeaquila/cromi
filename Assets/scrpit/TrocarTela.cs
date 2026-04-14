using UnityEngine;

public class GerenciadorTelas : MonoBehaviour
{
    public GameObject canva1;
    public GameObject canva2;
    public GameObject canva3;
    public GameObject canva4;
    public GameObject canva5;
    public GameObject canva6;

    public void MostrarTela1()
    {
        canva1.SetActive(true);
        canva2.SetActive(false);
        canva3.SetActive(false);
        canva4.SetActive(false);
        canva5.SetActive(false);
        canva6.SetActive(false);
    }

    public void MostrarTela2()
    {
        canva1.SetActive(false);
        canva2.SetActive(true);
        canva3.SetActive(false);
        canva4.SetActive(false);
        canva5.SetActive(false);
        canva6.SetActive(false);
    }

    public void MostrarTela3()
    {
        canva1.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(true);
        canva4.SetActive(false);
        canva5.SetActive(false);
        canva6.SetActive(false);
    }

    public void MostrarTela4()
    {
        canva1.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(false);
        canva4.SetActive(true);
        canva5.SetActive(false);
        canva6.SetActive(false);
    }

    public void MostrarTela5()
    {
        canva1.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(false);
        canva4.SetActive(false);
        canva5.SetActive(true);
        canva6.SetActive(false);
    }
    public void MostrarTela6()
    {
        canva1.SetActive(false);
        canva2.SetActive(false);
        canva3.SetActive(false);
        canva4.SetActive(false);
        canva5.SetActive(false);
        canva6.SetActive(true);
    }
}
