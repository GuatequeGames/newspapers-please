using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Days : MonoBehaviour
{
    int day;
    int optionSelect;
    string[] option = new string[3];



    private void Start()
    {
        day = 1;
        optionSelect = 0;
        option[0] = "";
        option[1] = "";
        option[2] = "";
        option[3] = "";
    }

    private void Update()
    {
        if (day == 1)
        {
            option[0] = "";
            option[1] = "";
            option[2] = "";
            if (option[0] == GameManager.instance.verb)
            {
                optionSelect = 0;
                GameManager.instance.PublishNewsPaper(0, 0, 0); //Politica, dinero, vericidad
            }
            else if (option[1] == GameManager.instance.verb)
            {
                optionSelect = 1;
                GameManager.instance.PublishNewsPaper(0, 0, 0); //Politica, dinero, vericidad
            }
            else if (option[2] == GameManager.instance.verb)
            {
                optionSelect = 2;
                GameManager.instance.PublishNewsPaper(0, 0, 0); //Politica, dinero, vericidad
            }
        }

        if (day == 2)
        {
            
            option[0] = "";
            option[1] = "";
            option[2] = "";
            if (option[0] == GameManager.instance.verb)
            {

            }
            else if (option[1] == GameManager.instance.verb)
            {

            }
            else if (option[2] == GameManager.instance.verb)
            {

            }
        }
    }

}