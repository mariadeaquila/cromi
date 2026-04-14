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

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
        {
            mensagem.text = "Preencha todos os campos!";
            return;
        }

        if (!BancoDeDados.UsuarioExiste(email))
        {
            mensagem.text = "Não existe conta com esse email!";
            return;
        }

        if (!BancoDeDados.LoginCorreto(email, senha))
        {
            mensagem.text = "Senha incorreta!";
            return;
        }

        mensagem.text = "Login realizado!";

        SceneManager.LoadScene("Bemvindo");
    }
}