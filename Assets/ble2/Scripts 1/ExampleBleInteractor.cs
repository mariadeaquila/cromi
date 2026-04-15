using Android.BLE;
using Android.BLE.Commands;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExampleBleInteractor : MonoBehaviour
{
    [SerializeField]
    TMP_InputField InputNomeBlueTooh;

    // [SerializeField]
    string nomeBlueTooth;

    [SerializeField]
    Button botaoScan;

    //aqui
    [SerializeField]
    Text status;

    [SerializeField]
    private GameObject _deviceButton;
    // [SerializeField]
    // private Transform _deviceList;

    [SerializeField]
    private int _scanTime = 10;

    private float _scanTimer = 0f;

    private bool _isScanning = false;

    //para a conexão
    private string _deviceUuid = string.Empty;
    private string _deviceName = string.Empty;
    private ConnectToDevice _connectCommand;
    private bool _isConnected = false;



    private void Start()
    {
        if (PlayerPrefs.HasKey("nomeBlueTooth"))
            nomeBlueTooth = PlayerPrefs.GetString("nomeBlueTooth");

        InputNomeBlueTooh.onValueChanged.AddListener(OnInputFieldValueChanged);
        botaoScan.GetComponentInChildren<Text>().text = "CONECTE AQUI " + nomeBlueTooth;
    }

    private void OnInputFieldValueChanged(string arg0)
    {
        nomeBlueTooth = arg0;
        botaoScan.GetComponentInChildren<Text>().text = "CONECTE AQUI " + nomeBlueTooth;

    }

    public void ScanForDevices()
    {
        if (!_isScanning)
        {
            _isScanning = true;
            BleManager.Instance.QueueCommand(new DiscoverDevices(OnDeviceFound, _scanTime * 1000));
        }
    }

    private void Update()
    {
        if (_isScanning)
        {
            _scanTimer += Time.deltaTime;
            if (_scanTimer > _scanTime)
            {
                _scanTimer = 0f;
                _isScanning = false;
            }
        }
    }

    private void OnDeviceFound(string name, string device)
    {
        if (device == nomeBlueTooth)
        {
            _deviceUuid = name;
            _deviceName = device;
            _isScanning = false;
            _scanTimer = 0f;
            Connect();
        }

    }

    public void Connect()
    {
        if (!_isConnected)
        {
            _connectCommand = new ConnectToDevice(_deviceUuid, OnConnected, OnDisconnected);
            BleManager.Instance.QueueCommand(_connectCommand);
        }

    }

    public void SubscribeToExampleService()
    {
        GerenciarComunicacao gc = GameObject.Find("Comunicacao").GetComponent<GerenciarComunicacao>();
        gc.SubscribeServico(_deviceUuid);
    }

    private void OnConnected(string deviceUuid)
    {
        _isConnected = true;
        botaoScan.gameObject.SetActive(false);

        SubscribeToExampleService();
    }





    private void OnDisconnected(string deviceUuid)
    {
        _isConnected = false;
        _deviceUuid = string.Empty;
        _deviceName = string.Empty;
        _scanTimer = 0f;
        _connectCommand.Disconnect();
        _isScanning = false;
        botaoScan.gameObject.SetActive(true);
    }

    public void OnNavega(string cena)
    {
        PlayerPrefs.SetString("nomeBlueTooth", nomeBlueTooth);
        gameObject.SetActive(false);
        SceneManager.LoadScene(cena);
    }

}
