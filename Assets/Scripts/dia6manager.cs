using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dia6manager : MonoBehaviour
{
    public GameObject paperElisaOut;
    public GameObject paperElisaIn;
    void Start()
    {
        // GameManager.instance.elisaStrikes

        if (GameManager.instance.elisaStrikes >= 1)
        {
            paperElisaOut.SetActive(true);
        }
        else
        {
            paperElisaIn.SetActive(true);
        }
    }

}
