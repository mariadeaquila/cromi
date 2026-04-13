using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Quiz4Botoes : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelCorreto;
    public GameObject painelErrado;
    public GameObject painelExplicacaoErrado;

    [Header("Navegação")]
    public GameObject painelAtual;
    public GameObject proximoPainel;

    [Header("Botões")]
    public Button[] botoes;
    public Button botaoCorreto;

    [Header("Cores")]
    public Color corCorreto = Color.green;
    public Color corErrado = Color.red;

    

    void Start()
    {
        painelCorreto.SetActive(false);
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(false);
    }

    public void ResponderCorreto()
    {
        PintarBotao(botaoCorreto, corCorreto);

        painelCorreto.SetActive(true);
        TravarBotoes();
    }

    public void ResponderErrado(Button botaoClicado)
    {
        PintarBotao(botaoClicado, corErrado);

        painelErrado.SetActive(true);
        TravarBotoes();
    }

    void PintarBotao(Button botao, Color cor)
{
    if (botao == null) return;

    Image img = botao.targetGraphic as Image;

    if (img != null)
    {
        img.color = cor;
    }
}


    void TravarBotoes()
    {
        foreach (Button b in botoes)
        {
            b.interactable = false;
        }
    }

    void LiberarBotoes()
    {
        foreach (Button b in botoes)
        {
            b.interactable = true;

            var img = b.GetComponent<Image>();
            if (img != null)
            {
                img.color = Color.white;
            }
        }
    }

    public void TentarNovamente()
    {
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(false);

        LiberarBotoes();
    }

    public void ExplicacaoErrado()
    {
        painelErrado.SetActive(false);
        painelExplicacaoErrado.SetActive(true);
    }

    public void Continuar()
    {
        painelCorreto.SetActive(false);

        painelAtual.SetActive(false);
        proximoPainel.SetActive(true);
    }
}