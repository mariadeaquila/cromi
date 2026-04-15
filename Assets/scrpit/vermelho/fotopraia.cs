using UnityEngine;

public class InteracaoPraia : MonoBehaviour
{
    public GameObject painelErro;
    public GameObject panelDica;

    public GameObject telaAtual;
    public GameObject proximaTela;

    public GameObject circulo1;
    public GameObject circulo2;
    public GameObject circulo3;

    public GameObject botao1;
    public GameObject botao2;
    public GameObject botao3;

    public int totalCorretos = 3;
    private int acertos = 0;

    public AudioClip narracao; // 🗣️ narração dessa atividade

    AudioManager audioManager;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (narracao != null)
        {
            audioManager.TocarNarracao(narracao);
        }
    }

    void Acertou(GameObject circulo, GameObject botao)
    {
        if (panelDica != null)
            panelDica.SetActive(false);

        circulo.SetActive(true);
        circulo.transform.SetAsLastSibling();

        circulo.transform.position = botao.transform.position;
        circulo.transform.SetAsLastSibling();

        botao.SetActive(false);

        acertos++;

        audioManager.TocarAcerto(); // ✅ som de acerto

        if (painelErro != null)
            painelErro.SetActive(false);

        if (acertos >= totalCorretos)
        {
            telaAtual.SetActive(false);
            proximaTela.SetActive(true);
        }
    }

    // CADA BOTÃO TEM SUA FUNÇÃO
    public void Acerto1()
    {
        Acertou(circulo1, botao1);
    }

    public void Acerto2()
    {
        Acertou(circulo2, botao2);
    }

    public void Acerto3()
    {
        Acertou(circulo3, botao3);
    }

    // ERRO
    public void Erro()
    {
        if (panelDica != null)
            panelDica.SetActive(false);

        if (painelErro != null)
            painelErro.SetActive(true);

        audioManager.TocarErro(); // ❌ som de erro
    }

    public void TentarNovamente()
    {
        if (painelErro != null)
            painelErro.SetActive(false);
    }

    public void AbrirDica()
    {
        if (panelDica != null)
            panelDica.SetActive(true);
    }
}