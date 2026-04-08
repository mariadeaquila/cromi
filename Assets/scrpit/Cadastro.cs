using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cadastro : MonoBehaviour
{
    public TMP_InputField nomeInput;
    public TMP_InputField idadeInput;
    public TMP_InputField condicaoInput;
    public TMP_InputField emailInput;
    public TMP_InputField senhaInput;
    public TMP_InputField confirmarSenhaInput;

    public TextMeshProUGUI mensagem;

    public void Cadastrar()
    {
        if (string.IsNullOrEmpty(nomeInput.text) ||
            string.IsNullOrEmpty(idadeInput.text) ||
            string.IsNullOrEmpty(condicaoInput.text) ||
            string.IsNullOrEmpty(emailInput.text) ||
            string.IsNullOrEmpty(senhaInput.text) ||
            string.IsNullOrEmpty(confirmarSenhaInput.text))
        {
            mensagem.text = "Preencha todos os campos!";
            return;
        }

        int idade = 0;
        if (!int.TryParse(idadeInput.text, out idade))
        {
            mensagem.text = "Digite uma idade válida!";
            return;
        }

        if (!emailInput.text.Contains("@") || !emailInput.text.Contains("."))
        {
            mensagem.text = "Email inválido!";
            return;
        }

        if (senhaInput.text.Length < 4)
        {
            mensagem.text = "A senha deve ter pelo menos 4 caracteres!";
            return;
        }

        if (senhaInput.text != confirmarSenhaInput.text)
        {
            mensagem.text = "As senhas não coincidem!";
            return;
        }

        if (BancoDeDados.UsuarioExiste(emailInput.text))
        {
            mensagem.text = "Já existe uma conta com esse email!";
            return;
        }

        // 🔥 SALVAR NO BANCO (seu sistema)
        BancoDeDados.SalvarUsuario(
            nomeInput.text,
            idade,
            condicaoInput.text,
            emailInput.text,
            senhaInput.text
        );

        // 🔥 SALVAR NO PLAYERPREFS (IMPORTANTE PRO PERFIL)
        PlayerPrefs.SetString("nome", nomeInput.text);
        PlayerPrefs.SetInt("idade", idade);
        PlayerPrefs.SetString("email", emailInput.text);
        PlayerPrefs.SetString("senha", senhaInput.text);

        PlayerPrefs.Save();

        mensagem.text = "Cadastro realizado com sucesso!";

        SceneManager.LoadScene("Bemvindo"); ;
    }

}