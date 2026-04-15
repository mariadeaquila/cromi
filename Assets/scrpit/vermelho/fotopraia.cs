using UnityEngine;

public class InteracaoPraia : MonoBehaviour
{
    public GameObject painelErro;
    public GameObject panelDica;

    public GameObject telaAtual;
    public GameObject proximaTela;

    // Círculos (acerto)
    public GameObject circulo1;
    public GameObject circulo2;
    public GameObject circulo3;

    // Botões
    public GameObject botao1;
    public GameObject botao2;
    public GameObject botao3;

    // 🖼️ IMAGENS (NOVO)
    public GameObject imagem1;
    public GameObject imagem2;
    public GameObject imagem3;

    public int totalCorretos = 3;
    private int acertos = 0;

    public AudioClip narracao;

    AudioManager audioManager;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();

        if (narracao != null)
        {
            audioManager.TocarNarracao(narracao);
        }
    }

    void Acertou(GameObject circulo, GameObject botao, GameObject imagem)
    {
        if (panelDica != null)
            panelDica.SetActive(false);

        // mostra círculo
        circulo.SetActive(true);
        circulo.transform.position = botao.transform.position;
        circulo.transform.SetAsLastSibling();

        // esconde botão
        botao.SetActive(false);

        // 🖼️ mostra imagem
        if (imagem != null)
            imagem.SetActive(true);

        acertos++;

        audioManager.TocarAcerto();

        if (painelErro != null)
            painelErro.SetActive(false);

        if (acertos >= totalCorretos)
        {
            telaAtual.SetActive(false);
            proximaTela.SetActive(true);
        }
    }

    // BOTÕES CERTOS
    public void Acerto1()
    {
        Acertou(circulo1, botao1, imagem1);
    }

    public void Acerto2()
    {
        Acertou(circulo2, botao2, imagem2);
    }

    public void Acerto3()
    {
        Acertou(circulo3, botao3, imagem3);
    }

    // ERRO
    public void Erro()
    {
        if (panelDica != null)
            panelDica.SetActive(false);

        if (painelErro != null)
            painelErro.SetActive(true);

        audioManager.TocarErro();
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