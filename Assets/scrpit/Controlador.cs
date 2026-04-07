using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    // Agora recebe o nome da cena como parâmetro
    public void CarregarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}