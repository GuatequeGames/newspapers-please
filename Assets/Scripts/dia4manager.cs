using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dia4manager : MonoBehaviour
{
    string opcionAnterior;
    public GameObject interactablesNadie;
    public GameObject interactablesInvestigadores;
    public GameObject interactablesDesconocido;
    // Start is called before the first frame update
    void Start()
    {
        opcionAnterior = GameManager.instance.options[3];

        if (opcionAnterior == null)
        {
            interactablesNadie.SetActive(true);
        }
        else if (opcionAnterior == "investigadores")
        {
            interactablesInvestigadores.SetActive(true);
        }
        else if (opcionAnterior == "desconocido")
        {
            interactablesDesconocido.SetActive(true);
        }
    }

}
