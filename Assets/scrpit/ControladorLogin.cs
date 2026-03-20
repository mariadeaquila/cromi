using UnityEngine;
using UnityEngine.SceneManagement; // Obrigatório para gerenciar cenas [1]

public class ControladorLogin : MonoBehaviour
{
    // Nome da cena que será carregada
    public string Login;

    // Método para ser chamado pelo botão
    public void CarregarCena()
    {
        SceneManager.LoadScene(Login);
    }
}
