using UnityEngine;
using TMPro;

public class EsqueceuSenha : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TextMeshProUGUI mensagem;

    public void Recuperar()
    {
        if (PlayerPrefs.GetString("email") == emailInput.text)
        {
            mensagem.text = "Senha: " + PlayerPrefs.GetString("senha");
        }
        else
        {
            mensagem.text = "Email não encontrado!";
        }
    }
}