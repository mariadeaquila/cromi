using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class finalverde: MonoBehaviour
{
    public string Fases; // nome da próxima scene
    public float tempoDelay = 5f;

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