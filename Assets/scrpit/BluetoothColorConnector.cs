using Android.BLE;
using Android.BLE.Commands;
using System.Text;
using UnityEngine;

public class BluetoothColorConnector : MonoBehaviour
{
    [Header("BLE")]
    [SerializeField] private string targetDeviceName = "cromia";

    // 🔥 UUID FIXO (sem usar inspector bugado)
    private string serviceUuid = "0000ffe0-0000-1000-8000-00805f9b34fb";
    private string characteristicUuid = "0000ffe1-0000-1000-8000-00805f9b34fb";

    [Header("Game")]
    [SerializeField] private ColorGameManager colorGameManager;

    private string deviceAddress = "";
    private bool isConnected = false;

    void Start()
    {
        BleManager.Instance.Initialize();
        Invoke(nameof(StartScan), 1f); // 🔥 delay evita bug
    }

    void StartScan()
    {
        Debug.Log("Procurando dispositivo...");
        BleManager.Instance.QueueCommand(new DiscoverDevices(OnDeviceFound, 10000));
    }

    void OnDeviceFound(string address, string name)
    {
        Debug.Log("Encontrado: " + name);

        if (name == targetDeviceName)
        {
            deviceAddress = address;
            Connect();
        }
    }

    void Connect()
    {
        if (isConnected) return;

        Debug.Log("Conectando...");

        BleManager.Instance.QueueCommand(
            new ConnectToDevice(deviceAddress, OnConnected, OnDisconnected)
        );
    }

    void OnConnected(string address)
    {
        Debug.Log("Conectado!");
        isConnected = true;

        // 🔥 espera antes de subscribe (ESSENCIAL)
        Invoke(nameof(Subscribe), 1.5f);
    }

    void Subscribe()
    {
        Debug.Log("Subscribe iniciado...");

        BleManager.Instance.QueueCommand(
            new SubscribeToCharacteristic(
                deviceAddress,
                serviceUuid,
                characteristicUuid,
                OnDataReceived,
                true
            )
        );
    }

    void OnDataReceived(byte[] data)
    {
        if (data == null || data.Length == 0) return;

        string msg = Encoding.ASCII.GetString(data).Trim().ToUpper();

        Debug.Log("Recebido: " + msg);

        if (colorGameManager != null)
        {
            colorGameManager.ProcessDetectedColor(msg);
        }
        else
        {
            Debug.LogError("ColorGameManager NÃO conectado!");
        }
    }

    void OnDisconnected(string address)
    {
        Debug.Log("Desconectado");
        isConnected = false;
    }
}
