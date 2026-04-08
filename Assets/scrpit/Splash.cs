using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;
using System.Collections;

public class Splash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("MudaSplash");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MudaSplash()
    {
        yield return new WaitForSeconds(6f);

        SceneManager.LoadScene(1);

    }
}
