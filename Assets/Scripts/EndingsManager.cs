using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsManager : MonoBehaviour
{
    int maxLevelValue;
    int moneyLevel;
    int credibilityLevel;
    int pressureLevel;
    public GameObject lowMoneyEnding,lowCredibilityEnding,highPressureEnding,alwaysHelpElisa, trueEnding,rojasComplot,outRojas,neutralEnding;

    // Gestionar finales en funcion de los valores de los niveles de las métricas
    public void CriticalEndings(){
        if (GameManager.instance.moneyStat <= 0){
            // Final por pérdida de dinero: quiebra del periódico
            LowMoneyEnding();
            GameManager.instance.criticalEnding = true;
        } else if (GameManager.instance.trueStat <= 0){
            // Final por pérdida de credibilidad: despido del periódico
            LowCredibilityEnding();
            GameManager.instance.criticalEnding = true;
        } else if (GameManager.instance.politicsStat >= 10){
            // Final por ganancia de presión: Muerte misteriosa en un accidente y reemplazo en el periódico
            HighPressureEnding();
            GameManager.instance.criticalEnding = true;
        }
    }

    // Gestionar finales en funcion de los valores de los niveles de las métricas
    public void AlternativeEndings(){
        // siempre la verdad
        if (GameManager.instance.verdades >=7) TrueEnding();
        else if (GameManager.instance.ayudasRojas >=3) AlwaysHelpElisa();
        else if (GameManager.instance.options[7]=="complot") RojasComplot();
        else if (GameManager.instance.elisaStrikes>=3) OutRojas();
        else  NeutralEnding();
    }

    private void LowMoneyEnding(){
        lowMoneyEnding.SetActive(true);
    }
    private void LowCredibilityEnding(){
        lowCredibilityEnding.SetActive(true);
        
    }
    private void HighPressureEnding(){
        highPressureEnding.SetActive(true);
        
    }
    private void AlwaysHelpElisa(){
        alwaysHelpElisa.SetActive(true);
        
    }
    private void TrueEnding(){
        trueEnding.SetActive(true);
        
    }
    private void RojasComplot(){
        rojasComplot.SetActive(true);
        
    }
    private void OutRojas(){
        outRojas.SetActive(true);
        
    }
    private void NeutralEnding(){
        neutralEnding.SetActive(true);
        
    }

}
