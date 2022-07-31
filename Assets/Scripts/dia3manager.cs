using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dia3manager : MonoBehaviour
{
    
    string opcionAnterior;
    public GameObject interactablesLorena;
    public GameObject interactablesConstructora;
    public GameObject interactablesNadie;
    // Start is called before the first frame update
    void Start()
    {
        opcionAnterior = GameManager.instance.options[2];
        if (opcionAnterior == null)
        {
            interactablesLorena.SetActive(true);
        }
        else if (opcionAnterior == "constructora")
        {
            interactablesConstructora.SetActive(true);
        }
        else if (opcionAnterior == "nadie")
        {
            interactablesNadie.SetActive(true);
        }
    }

}
