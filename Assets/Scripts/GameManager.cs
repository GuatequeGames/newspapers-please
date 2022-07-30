using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int politicsStat;
    int moneyStat;
    int trueStat;

    public bool newspaperTrigger;
    public string verb;
    public TMP_InputField playerName, playerLastName;
    public GameObject verbObject, topInk, bottonInk;
    public List<string> verbList = new List<string>();
    //int[] verb;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        if (playerName.text != "" && playerLastName.text != "")
        {
            topInk.SetActive(false);
            newspaperTrigger = true;
            bottonInk.SetActive(true);
        }
        else
        {
            topInk.SetActive(true);
            newspaperTrigger = false;
            bottonInk.SetActive(false);
        }
    }

    public void PublishNewsPaper(int _politics, int _money, int _true)
    {
        politicsStat += _politics;
        moneyStat += _money;
        trueStat += _true;
    }

    public void EditNewsPaper(string _verb,GameObject _verbObject)
    {
        verb = _verb;
        verbObject = _verbObject;
    }



}
