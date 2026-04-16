using UnityEngine;
using Android.BLE;
using Android.BLE.Commands;

public class ConectarBluetooth : MonoBehaviour
{
    public string nomeDispositivo = "cromia";

    public void Conectar()
    {
        Debug.Log("Iniciando BLE...");

        BleManager.Instance.Initialize();

        BleManager.Instance.QueueCommand(new ScanCommand((device, isNew) =>
        {
            Debug.Log("Encontrou: " + device.Name);

            if (device.Name == nomeDispositivo)
            {
                Debug.Log("Dispositivo correto encontrado!");

                BleManager.Instance.QueueCommand(
                    new ConnectToDeviceCommand(device.Address, (conectado) =>
                    {
                        if (conectado)
                        {
                            Debug.Log("CONECTADO COM SUCESSO!");
                        }
                        else
                        {
                            Debug.Log("ERRO AO CONECTAR");
                        }
                    })
                );
            }
        }));
    }
}