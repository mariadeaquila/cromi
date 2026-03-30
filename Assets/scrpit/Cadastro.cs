using UnityEngine;
using UnityEngine.UI;
using TMPro; // IMPORTANTE

public class Cadastro : MonoBehaviour
{
    public TMP_InputField nomeInput;
    public TMP_InputField idadeInput;
    public TMP_InputField condicaoInput;
    public TMP_InputField emailInput;
    public TMP_InputField senhaInput;
    public TMP_InputField confirmarSenhaInput;

    public Toggle termosToggle;

    public TextMeshProUGUI mensagem;

    public void Registrar()
    {
        string nome = nomeInput.text;
        string idade = idadeInput.text;
        string condicao = condicaoInput.text;
        string email = emailInput.text;
        string senha = senhaInput.text;
        string confirmarSenha = confirmarSenhaInput.text;

        if (nome == "" || idade == "" || condicao == "" || email == "" || senha == "" || confirmarSenha == "")
        {
            mensagem.text = "Preencha todos os campos!";
            return;
        }

        if (!termosToggle.isOn)
        {
            mensagem.text = "Aceite os termos e condições!";
            return;
        }

        if (senha != confirmarSenha)
        {
            mensagem.text = "As senhas não coincidem!";
            return;
        }

        if (PlayerPrefs.HasKey(email))
        {
            mensagem.text = "Usuário já cadastrado!";
            return;
        }

        PlayerPrefs.SetString(email + "_nome", nome);
        PlayerPrefs.SetString(email + "_idade", idade);
        PlayerPrefs.SetString(email + "_condicao", condicao);
        PlayerPrefs.SetString(email, senha);

        PlayerPrefs.Save();

        mensagem.text = "Cadastro realizado com sucesso!";
    }
}