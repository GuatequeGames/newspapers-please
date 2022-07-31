using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dia7manager : MonoBehaviour
{
    public GameObject branchA;
    public GameObject branchB;
    void Start()
    {

        if (GameManager.instance.elisaStrikes < 3)
        {
            branchA.SetActive(true);
        }
        else
        {
            branchB.SetActive(true);
        }
    }

}
