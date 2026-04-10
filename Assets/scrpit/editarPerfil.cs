using TMPro;
using UnityEngine;

public class PerfilUsuario : MonoBehaviour
{
    public TMP_InputField nomeInput;
    public TMP_InputField idadeInput;
    public TMP_InputField condicaoInput;
    public TMP_InputField emailInput;
    public TMP_InputField senhaInput;

    public TextMeshProUGUI textoBotao;

    public GameObject foto;
    public GameObject foto2;

    private bool editando = false;

    void Start()
    {
        SetCamposEditaveis(false);

        nomeInput.text = PlayerPrefs.GetString("nome", "");

        int idade = PlayerPrefs.GetInt("idade", 0);
        idadeInput.text = idade.ToString();

        emailInput.text = PlayerPrefs.GetString("email", "");
        senhaInput.text = PlayerPrefs.GetString("senha", "");

        condicaoInput.text = PlayerPrefs.GetString("condicao", ""); // 🔥

        textoBotao.text = "Editar";

        int fotoSalva = PlayerPrefs.GetInt("fotoSelecionada", 1);

        if (fotoSalva == 1)
        {
            foto.SetActive(true);
            foto2.SetActive(false);
        }
        else
        {
            foto.SetActive(false);
            foto2.SetActive(true);
        }
    }

    public void BotaoEditar()
    {
        editando = !editando;

        if (editando)
        {
            SetCamposEditaveis(true);
            textoBotao.text = "salvar";
        }
        else
        {
            SalvarDados();
            SetCamposEditaveis(false);
            textoBotao.text = "editar";
        }
    }

    void SetCamposEditaveis(bool valor)
    {
        nomeInput.interactable = valor;
        idadeInput.interactable = valor;
        emailInput.interactable = valor;
        senhaInput.interactable = valor;
        condicaoInput.interactable = valor; // 🔥
    }

    void SalvarDados()
    {
        PlayerPrefs.SetString("nome", nomeInput.text);

        int idade = 0;
        int.TryParse(idadeInput.text, out idade);
        PlayerPrefs.SetInt("idade", idade);

        PlayerPrefs.SetString("email", emailInput.text);
        PlayerPrefs.SetString("senha", senhaInput.text);

        PlayerPrefs.SetString("condicao", condicaoInput.text); // 🔥

        PlayerPrefs.Save();

        Debug.Log("Salvo!");
    }

    public void Trocarfoto()
    {
        foto.SetActive(false);
        foto2.SetActive(true);

        PlayerPrefs.SetInt("fotoSelecionada", 2);
        PlayerPrefs.Save();
    }

    public void Voltarfoto()
    {
        foto.SetActive(true);
        foto2.SetActive(false);

        PlayerPrefs.SetInt("fotoSelecionada", 1);
        PlayerPrefs.Save();
    }
}