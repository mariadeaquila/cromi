using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Termos : MonoBehaviour
{
    public Toggle termosToggle;
    public TextMeshProUGUI mensagem;

    public void Aceitar()
    {
        if (!termosToggle.isOn)
        {
            mensagem.text = "Você precisa aceitar os termos!";
            return;
        }

        // Se aceitou → vai pra próxima tela
        SceneManager.LoadScene("Cadastro");
    }
}