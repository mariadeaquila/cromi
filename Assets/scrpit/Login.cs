using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField senhaInput;

    public TextMeshProUGUI mensagem;

    public void Entrar()
    {
        string email = emailInput.text;
        string senha = senhaInput.text;

        if (!PlayerPrefs.HasKey(email))
        {
            mensagem.text = "Usuário não cadastrado!";
            return;
        }

        string senhaSalva = PlayerPrefs.GetString(email);

        if (senha == senhaSalva)
        {
            mensagem.text = "Login realizado!";
            SceneManager.LoadScene("Home"); // sua próxima cena
        }
        else
        {
            mensagem.text = "Email ou senha incorretos!";
        }
    }
}