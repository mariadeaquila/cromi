using UnityEngine;
using TMPro;

public class RecuperarSenha : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField novaSenhaInput;

    public TextMeshProUGUI mensagem;

    public void RedefinirSenha()
    {
        string email = emailInput.text;
        string novaSenha = novaSenhaInput.text;

        if (!PlayerPrefs.HasKey(email))
        {
            mensagem.text = "Email não encontrado!";
            return;
        }

        PlayerPrefs.SetString(email, novaSenha);
        PlayerPrefs.Save();

        mensagem.text = "Senha redefinida com sucesso!";
    }
}