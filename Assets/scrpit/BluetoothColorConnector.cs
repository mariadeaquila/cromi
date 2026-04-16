using Android.BLE;
using Android.BLE.Commands;
using System.Text;
using UnityEngine;

public class BluetoothColorConnector : MonoBehaviour
{
    [Header("BLE")]
    [SerializeField] private string targetDeviceName = "cromia";
    [SerializeField] private string serviceUuid = "12345678-1234-1234-1234-1234567890ab";
    [SerializeField] private string characteristicUuid = "12345678-1234-1234-1234-1234567890ac";
    [SerializeField] private int scanTimeMs = 10000;

    [Header("Game")]
    [SerializeField] private ColorGameManager colorGameManager;

    private string deviceAddress = "";
    private ConnectToDevice connectCommand;
    private SubscribeToCharacteristic subscribeCommand;
    private bool isConnected = false;

    private void Start()
    {
        BleManager.Instance.Initialize();
        StartScan();
    }

    public void StartScan()
    {
        Debug.Log("Starting BLE scan...");
        BleManager.Instance.QueueCommand(new DiscoverDevices(OnDeviceFound, scanTimeMs));
    }

    private void OnDeviceFound(string foundDeviceAddress, string foundDeviceName)
    {
        Debug.Log($"Found device: {foundDeviceName} | {foundDeviceAddress}");

        if (foundDeviceName == targetDeviceName)
        {
            deviceAddress = foundDeviceAddress;
            Connect();
        }
    }

    private void Connect()
    {
        if (isConnected || string.IsNullOrEmpty(deviceAddress))
            return;

        Debug.Log("Connecting to: " + deviceAddress);

        connectCommand = new ConnectToDevice(
            deviceAddress,
            OnConnected,
            OnDisconnected
        );

        BleManager.Instance.QueueCommand(connectCommand);
    }

    private void OnConnected(string connectedDeviceAddress)
    {
        Debug.Log("Connected to: " + connectedDeviceAddress);
        isConnected = true;
        Subscribe();
    }

    private void OnDisconnected(string disconnectedDeviceAddress)
    {
        Debug.Log("Disconnected from: " + disconnectedDeviceAddress);
        isConnected = false;
        deviceAddress = "";
    }

    private void Subscribe()
    {
        if (string.IsNullOrEmpty(deviceAddress))
            return;

        Debug.Log("Subscribing to characteristic...");

        subscribeCommand = new SubscribeToCharacteristic(
            deviceAddress,
            serviceUuid,
            characteristicUuid,
            OnCharacteristicChanged,
            true
        );

        BleManager.Instance.QueueCommand(subscribeCommand);
    }

    private void OnCharacteristicChanged(byte[] value)
    {
        string received = Encoding.ASCII.GetString(value).Trim().ToUpper();

        Debug.Log("BLE received: " + received);

        if (colorGameManager != null)
        {
            colorGameManager.ProcessDetectedColor(received);
        }
    }

    private void OnDestroy()
    {
        subscribeCommand?.Unsubscribe();
        connectCommand?.Disconnect();
    }
}