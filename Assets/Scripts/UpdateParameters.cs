using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateParameters : MonoBehaviour
{
    
    public void UpdateStats()
    {
        // Primer d�a: fotograf�a presentador
        if (GameManager.instance.actualDay == 1)
        {
            if (GameManager.instance.options[1]==null)
            {
                GameManager.instance.PublishNewsPaper(0, -1, 1); //Politica, dinero, vericidad
                GameManager.instance.verdades ++;
            }
            else if (GameManager.instance.options[1] == "amante")
            {
                GameManager.instance.PublishNewsPaper(0, 1, -1); //Politica, dinero, vericidad
            }
        }

        // Segundo d�a: derrumbe del colegio
        if (GameManager.instance.actualDay == 2)
        {
            if (GameManager.instance.options[2] == null)
            {
                GameManager.instance.PublishNewsPaper(2, 2, 1); //Politica, dinero, vericidad
                GameManager.instance.verdades ++;
            }
            else if (GameManager.instance.options[2] == "constructora")
            {
                GameManager.instance.PublishNewsPaper(1, 2, -2); //Politica, dinero, vericidad
            }
            else if (GameManager.instance.options[2] == "nadie")
            {
                GameManager.instance.PublishNewsPaper(0, 0, -1); //Politica, dinero, vericidad
            }
        }

        // Tercer d�a: refrescos sin azucar
        if (GameManager.instance.actualDay == 3)
        {

            if (GameManager.instance.options[3] == null)
            {
                GameManager.instance.PublishNewsPaper(1, -2, 1); //Politica, dinero, vericidad
                GameManager.instance.verdades ++;
            }
            else if (GameManager.instance.options[3] == "investigadores")
            {
                GameManager.instance.PublishNewsPaper(0, 2, -2); //Politica, dinero, vericidad
            }
            else if (GameManager.instance.options[3] == "desconocido")
            {
                GameManager.instance.PublishNewsPaper(0, 1, -1); //Politica, dinero, vericidad
            }
        }
        // Cuarto d�a: para�so fiscal
        if (GameManager.instance.actualDay == 4)
        {

            if (GameManager.instance.options[4] == null)
            {
                GameManager.instance.PublishNewsPaper(0, 1, 1); //Politica, dinero, vericidad
                GameManager.instance.verdades ++;
                GameManager.instance.elisaStrikes++; 
            }
            else if (GameManager.instance.options[4] == "elisa")
            {
                GameManager.instance.PublishNewsPaper(-1, 2, -2); //Politica, dinero, vericidad
                GameManager.instance.elisaStrikes+=2; 
            }
            else if (GameManager.instance.options[4] == "iglesia")
            {
                GameManager.instance.PublishNewsPaper(2, 1, -1); //Politica, dinero, vericidad
                GameManager.instance.ayudasRojas ++;
            }
        }
        // Quinto d�a: la felicidad
        if (GameManager.instance.actualDay == 5)
        {

            if (GameManager.instance.options[5] == null)
            {
                GameManager.instance.PublishNewsPaper(1, 1, 0); //Politica, dinero, vericidad
                GameManager.instance.verdades ++;
            }
            else if (GameManager.instance.options[5] == "personas")
            {
                GameManager.instance.PublishNewsPaper(0, -1, 1); //Politica, dinero, vericidad
            }
            else if (GameManager.instance.options[5] == "familia")
            {
                GameManager.instance.PublishNewsPaper(0, -1, 1); //Politica, dinero, vericidad
            }
        }
        // Sexto d�a: paquete medidas
        if (GameManager.instance.actualDay == 6)
        {
            //elisa sola
            if (GameManager.instance.options[6] == null)
            {
                GameManager.instance.PublishNewsPaper(1, 0, 1); //Politica, dinero, vericidad
                GameManager.instance.elisaStrikes++;
                GameManager.instance.verdades ++;

            }
            //elisa + vice
            else if (GameManager.instance.options[6] == "vice")
            {
                GameManager.instance.PublishNewsPaper(-2, 1, -2); //Politica, dinero, vericidad
                GameManager.instance.elisaStrikes += 2;
            }
            //vice
            else if (GameManager.instance.options[6] == "elisa")
            {
                GameManager.instance.PublishNewsPaper(2, -1, -1); //Politica, dinero, vericidad
                GameManager.instance.ayudasRojas ++;
            }
        }
        
        // Septimo d�a: elisa sigue
        if (GameManager.instance.actualDay == 7 && GameManager.instance.elisaStrikes<3)
        {
            //elisa sola
            if (GameManager.instance.options[7] == null)
            {
                GameManager.instance.PublishNewsPaper(1, 2, 2); //Politica, dinero, vericidad
                GameManager.instance.verdades ++;

            }
            //oposicion
            else if (GameManager.instance.options[7] == "oposicion")
            {
                GameManager.instance.PublishNewsPaper(2, 1, -1); //Politica, dinero, vericidad
                GameManager.instance.ayudasRojas ++;
            }
            //elisa
            else if (GameManager.instance.options[7] == "elisa")
            {
                GameManager.instance.PublishNewsPaper(2, -1, -1); //Politica, dinero, vericidad
                GameManager.instance.elisaStrikes += 3;
            }
        }
        // Septimo d�a: elisa fuera
        else if (GameManager.instance.actualDay == 7  && GameManager.instance.elisaStrikes>=3)
        {
            //complot
            if (GameManager.instance.options[7] == null)
            {
                GameManager.instance.PublishNewsPaper(7, 2, 3); //Politica, dinero, vericidad
                GameManager.instance.verdades ++;

            }
            //planes
            else if (GameManager.instance.options[7] == "planes")
            {
                GameManager.instance.PublishNewsPaper(-1, -2, -3); //Politica, dinero, vericidad
            }
        }

    }

}