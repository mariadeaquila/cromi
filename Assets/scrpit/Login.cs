using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField senhaInput;
    public TextMeshProUGUI mensagem;

    public void Entrar()
    {
        string email = emailInput.text;
        string senha = senhaInput.text;

        if (!BancoDeDados.UsuarioExiste(email))
        {
            mensagem.text = "Não existe conta com esse email!";
            return;
        }

        if (BancoDeDados.LoginCorreto(email, senha))
        {
            SceneManager.LoadScene("Perfil");
        }
        else
        {
            mensagem.text = "Senha incorreta!";
        }
    }
}