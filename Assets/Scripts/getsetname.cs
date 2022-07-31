using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getsetname : MonoBehaviour
{
    public TextMeshProUGUI fullName;
    // Start is called before the first frame update
    void Start()
    {
        fullName.text = GameManager.instance.playerName.text + " " + GameManager.instance.playerLastName.text;
    }

}
