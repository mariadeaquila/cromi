using UnityEngine;

public class BancoDeDados : MonoBehaviour
{
    public static void SalvarUsuario(string nome, int idade, string condicao, string email, string senha)
    {
        PlayerPrefs.SetString("nome", nome);
        PlayerPrefs.SetInt("idade", idade);
        PlayerPrefs.SetString("condicao", condicao);
        PlayerPrefs.SetString("email", email);
        PlayerPrefs.SetString("senha", senha);
        PlayerPrefs.Save();
    }

    public static bool UsuarioExiste(string email)
    {
        return PlayerPrefs.GetString("email") == email;
    }

    public static bool LoginCorreto(string email, string senha)
    {
        return PlayerPrefs.GetString("email") == email &&
               PlayerPrefs.GetString("senha") == senha;
    }
}