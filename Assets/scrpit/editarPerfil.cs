using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PerfilUsuario : MonoBehaviour
{
    public TMP_InputField nomeInput;
    public TMP_InputField idadeInput;
    public TMP_InputField emailInput;
    public TMP_InputField senhaInput;

    public TextMeshProUGUI textoBotao;

    public GameObject telaPerfil; 
    public GameObject telaConfiguracoes;
    public GameObject telaTermos;

    public GameObject foto;
    public GameObject foto2;

    private bool editando = false;

    void Start()
    {
        // Começa travado
        SetCamposEditaveis(false);

        // Carregar dados
        nomeInput.text = PlayerPrefs.GetString("nome", "");
        idadeInput.text = PlayerPrefs.GetString("idade", "");
        emailInput.text = PlayerPrefs.GetString("email", "");
        senhaInput.text = PlayerPrefs.GetString("senha", "");

        textoBotao.text = "editar";

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
    }

    void SalvarDados()
    {
        PlayerPrefs.SetString("nome", nomeInput.text);
        PlayerPrefs.SetString("idade", idadeInput.text);
        PlayerPrefs.SetString("email", emailInput.text);
        PlayerPrefs.SetString("senha", senhaInput.text);
        PlayerPrefs.Save();

        Debug.Log("Salvo!");
    }

    public void AbrirConfiguracoes()
    {
        Debug.Log("CLICOU");
        telaPerfil.SetActive(false);
        telaConfiguracoes.SetActive(true);
        telaTermos.SetActive(false);
       
    }

    public void AbrirTermos()
    {
        Debug.Log("CLICOU");
        telaPerfil.SetActive(false);
        telaConfiguracoes.SetActive(false);
        telaTermos.SetActive(true);
    }
    public void FecharConfiguracoes()
    {
        Debug.Log("CLICOU");
        telaPerfil.SetActive(true);
        telaConfiguracoes.SetActive(false);
        telaTermos.SetActive(false);
    }

    public void FecharTermos()
    {
        Debug.Log("CLICOU");
        telaPerfil.SetActive(true);
        telaConfiguracoes.SetActive(false);
        telaTermos.SetActive(false);
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
