using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dia5manager : MonoBehaviour
{
    string opcionAnterior;
    public GameObject interactablesHermano;
    public GameObject interactablesElisaDia5;
    public GameObject interactablesIglesiaDia5;
    // Start is called before the first frame update
    void Start()
    {
        opcionAnterior = GameManager.instance.options[4];

        if (opcionAnterior == null)
        {
            interactablesHermano.SetActive(true);
        }
        else if (opcionAnterior == "elisa")
        {
            interactablesElisaDia5.SetActive(true);
        }
        else if (opcionAnterior == "iglesia")
        {
            interactablesIglesiaDia5.SetActive(true);
        }
    }

}
