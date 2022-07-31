using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dia2manager : MonoBehaviour
{
    string opcionAnterior;
    public GameObject interactablesAmante;
    public GameObject interactablesAmiga;
    // Start is called before the first frame update
    void Start()
    {
        opcionAnterior = GameManager.instance.options[1];
        if (opcionAnterior == null)
        {
            interactablesAmiga.SetActive(true);
        }
        else if (opcionAnterior == "amante")
        {
            interactablesAmante.SetActive(true);
        }
    }

}
