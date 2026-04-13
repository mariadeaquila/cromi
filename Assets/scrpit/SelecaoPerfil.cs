using UnityEngine;
using UnityEngine.UI;

public class AvatarSelector : MonoBehaviour
{
    public Image imagem;     // imagem na tela
    public Sprite[] avatares;

    private int index = 0;

    void Start()
    {
        imagem.sprite = avatares[index];
    }

    public void Direita()
    {
        index++;

        if (index >= avatares.Length)
            index = 0;

        imagem.sprite = avatares[index];
    }

    public void Esquerda()
    {
        index--;

        if (index < 0)
            index = avatares.Length - 1;

        imagem.sprite = avatares[index];
    }

    public int GetIndex()
    {
        return index;
    }
}