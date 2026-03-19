using UnityEngine;

public class introduçãoSetas : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public void Trocar()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}
