using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public Image onImage;
    public Image offImage;

    private bool isOn = false;

    void Start()
    {
        UpdateVisual();
    }

    public void Toggle()
    {
        isOn = !isOn;
        UpdateVisual();
    }

    void UpdateVisual()
    {
        onImage.gameObject.SetActive(isOn);
        offImage.gameObject.SetActive(!isOn);
    }
}