using UnityEngine;

public class semaforo : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject painelCorreto;
    public GameObject painelErrado;
    public GameObject painelExplicacao;

    [Header("Telas")]
    public GameObject telaAtual;
    public GameObject proximaTela;

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

    // Chamado quando clica em uma resposta
    public void VerificarResposta(bool correto)
    {
        if (correto)
        {
            painelCorreto.SetActive(true);
            audioManager.TocarAcerto(); // ✅ som de acerto
            //audioManager.audioSource.Stop(); // opcional
        }
        else
        {
            painelErrado.SetActive(true);
            audioManager.TocarErro(); // ❌ som de erro
            //audioManager.audioSource.Stop(); // opcional
        }
    }

    // Botão: Tentar novamente
    public void TentarNovamente()
    {
        painelErrado.SetActive(false);
    }

    // Botão: Explicar resposta
    public void ExplicarResposta()
    {
        painelErrado.SetActive(false);
        painelExplicacao.SetActive(true);
    }

    // Botão: Fechar explicação
    public void FecharExplicacao()
    {
        painelExplicacao.SetActive(false);
    }

    // Botão: Continuar
    public void Continuar()
    {
        telaAtual.SetActive(false);
        proximaTela.SetActive(true);
    }
}