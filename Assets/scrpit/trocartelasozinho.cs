using System.Collections;

using UnityEngine;

using System.Collections.Generic;

public class tROCAPainel : MonoBehaviour

{
    public GameObject painel1;

    public GameObject painel2;


    public void Troca()

    {

        painel1.SetActive(false);

        StartCoroutine("Espera");

    }

    IEnumerator Espera()

    {

        yield return new WaitForSeconds(5);

        painel2.SetActive(true);

    }

    // Update is called once per frame

    void Update()

    {

    }

}

 