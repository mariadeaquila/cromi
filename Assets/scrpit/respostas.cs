using UnityEngine;

public class respostas : MonoBehaviour
{
    public GameObject painelCorreto;
    public GameObject painelErrado;

    public void RespostaCorreta()
    {
        painelCorreto.SetActive(true);
    }

    public void RespostaErrada()
    {
        painelErrado.SetActive(true);
    }
}