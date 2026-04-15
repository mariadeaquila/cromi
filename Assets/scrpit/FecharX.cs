using UnityEngine;
using UnityEngine.SceneManagement;

public class FecharX : MonoBehaviour
{
    public void VoltarParaOutraScene()
    {
        SceneManager.LoadScene("PaginaInicial"); 
    }
}