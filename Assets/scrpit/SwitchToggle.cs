using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleSwitch : MonoBehaviour
{
    public Toggle toggle;

    public RectTransform handle;
    public Image background;

    public Vector2 onPosition;
    public Vector2 offPosition;

    public Color onColor;
    public Color offColor;

    public float speed = 5f;

    void Start()
    {
        toggle.onValueChanged.AddListener(OnSwitchChanged);

        // Atualiza estado inicial
        OnSwitchChanged(toggle.isOn);
    }

    void OnSwitchChanged(bool isOn)
    {
        StopAllCoroutines();
        StartCoroutine(AnimateSwitch(isOn));
    }

    IEnumerator AnimateSwitch(bool isOn)
    {
        Vector2 startPos = handle.anchoredPosition;
        Vector2 endPos = isOn ? onPosition : offPosition;

        Color startColor = background.color;
        Color endColor = isOn ? onColor : offColor;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * speed;

            handle.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            background.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        handle.anchoredPosition = endPos;
        background.color = endColor;
    }
}