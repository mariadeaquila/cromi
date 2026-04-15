using UnityEngine;
using System.Text;

public class BluetoothManagerController : MonoBehaviour
{
    public ColorGameManager colorGameManager;

    public void StartBluetooth()
    {
        Debug.Log("Start Bluetooth here");
        // Call BlueUnity methods here
    }

    public void ConnectToArduino(string macAddress)
    {
        Debug.Log("Connecting to: " + macAddress);
        // Call BlueUnity connect here
    }

    public void onConnected(string macAddress)
    {
        Debug.Log("Connected to Arduino: " + macAddress);
    }

    public void onDisconnected(string macAddress)
    {
        Debug.Log("Disconnected: " + macAddress);
    }

    public void onError(string error)
    {
        Debug.LogError("Bluetooth error: " + error);
    }

    public void onDataReceived(string data)
    {
        Debug.Log("Bluetooth received: " + data);

        if (colorGameManager != null)
        {
            colorGameManager.ProcessDetectedColor(data);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        onDataReceived("RED");

        if (Input.GetKeyDown(KeyCode.B))
        onDataReceived("BLUE");

        if (Input.GetKeyDown(KeyCode.G))
        onDataReceived("GREEN");
    }
}