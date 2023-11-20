using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadWarning : MonoBehaviour
{
    public GameObject warning;
    public GameObject objectToDisable1;
    public GameObject objectToDisable2;
    public GameObject objectToDisable3;
    public GameObject objectToDisable4;

    public void addWarning()
    {
        warning.SetActive(true);
        objectToDisable1.SetActive(false);
        objectToDisable2.SetActive(false);
        objectToDisable3.SetActive(false);
        objectToDisable4.SetActive(false);

    }


}
