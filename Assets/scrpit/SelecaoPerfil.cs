using UnityEngine;
using UnityEngine.UI;

public class SelecaoPerfil : MonoBehaviour
{
    public Image imagemPerfil;
    public Sprite[] avatares;

    private int indiceAtual = 0;

    void Start()
    {
        AtualizarImagem();
    }

    public void Proximo()
    {
        indiceAtual++;

        if (indiceAtual >= avatares.Length)
        {
            indiceAtual = 0;
        }

        AtualizarImagem();
    }

    public void Anterior()
    {
        indiceAtual--;

        if (indiceAtual < 0)
        {
            indiceAtual = avatares.Length - 1;
        }

        AtualizarImagem();
    }

    void AtualizarImagem()
    {
        imagemPerfil.sprite = avatares[indiceAtual];
    }

    public int GetIndiceSelecionado()
    {
        return indiceAtual;
    }
}