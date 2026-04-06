using UnityEngine;
using TMPro;

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
        if (senhaInput.text != confirmarSenhaInput.text)
        {
            mensagem.text = "As senhas não coincidem!";
            return;
        }

        int idade = 0;
        int.TryParse(idadeInput.text, out idade);

        BancoDeDados.SalvarUsuario(
            nomeInput.text,
            idade,
            condicaoInput.text,
            emailInput.text,
            senhaInput.text
        );

        mensagem.text = "Cadastro realizado com sucesso!";
    }
}