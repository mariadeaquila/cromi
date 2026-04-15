using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DelayParaScene : MonoBehaviour
{
    public string Fases; // nome da próxima scene
    public float tempoDelay = 3f;

    void OnEnable()
    {
        StartCoroutine(IrParaScene());
    }

    IEnumerator IrParaScene()
    {
        yield return new WaitForSeconds(tempoDelay);

        SceneManager.LoadScene(Fases);
    }
}