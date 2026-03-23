using UnityEngine;

public class TrocarTela : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public void Trocar()
    {
         Debug.Log("CLICOU");
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}
