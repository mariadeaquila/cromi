using UnityEngine;
using Android.BLE;
using System.Text;

public class ReceberBluetooth : MonoBehaviour
{
    public GerenciadorCores gerenciador;

    void Start()
    {
        BleAdapter adapter = FindObjectOfType<BleAdapter>();

        if (adapter != null)
        {
            adapter.OnMessageReceived += ReceberMensagem;
        }
        else
        {
            Debug.Log("BleAdapter não encontrado!");
        }
    }

    void ReceberMensagem(BleObject obj)
    {
        // converte Base64 ? texto
        byte[] data = obj.GetByteMessage();
        string mensagem = Encoding.UTF8.GetString(data);

        Debug.Log("Recebido: " + mensagem);

        // manda pra UI
        if (gerenciador != null)
        {
            gerenciador.ReceberCor(mensagem);
        }
    }
}