using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Termos : MonoBehaviour
{
    public Toggle termosToggle;
    public TextMeshProUGUI mensagem;

    public bool AceitouTermos()
    {
        if (!termosToggle.isOn)
        {
            mensagem.text = "Você precisa aceitar os termos!";
            return false;
        }

        return true;
    }
}