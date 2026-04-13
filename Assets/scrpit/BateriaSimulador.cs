using UnityEngine;
using TMPro;

public class BateriaSimulada : MonoBehaviour
{
    public TextMeshProUGUI bateriaTexto;

    public float tempoParaDiminuir = 5f; // tempo em segundos para perder 1%

    private float timer = 0f;
    private int bateria = 100;

    void Start()
    {
        AtualizarTexto();
    }

    void Update()
    {
        if (bateria <= 0) return;

        timer += Time.deltaTime;

        if (timer >= tempoParaDiminuir)
        {
            bateria--;
            timer = 0f;

            AtualizarTexto();
        }
    }

    void AtualizarTexto()
    {
        bateriaTexto.text = bateria + "%";
    }
}