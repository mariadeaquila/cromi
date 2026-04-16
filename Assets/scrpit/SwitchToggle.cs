using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] private Image onImage;
    [SerializeField] private Image offImage;

    private bool isOn = false;

    void Start()
    {
        SetState(true); // começa desligado
    }

    public void Toggle()
    {
        SetState(!isOn);
    }

    void SetState(bool state)
    {
        isOn = state;

        if (onImage != null)
            onImage.gameObject.SetActive(isOn);

        if (offImage != null)
            offImage.gameObject.SetActive(!isOn);
    }
}