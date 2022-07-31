using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsManager : MonoBehaviour
{
    int maxLevelValue;
    int moneyLevel;
    int credibilityLevel;
    int pressureLevel;
    public GameObject lowMoneyEnding,lowCredibilityEnding,highPressureEnding;

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
    public void AlternativeEndings()
    {
        if (elisaStrikes >= 2)
        {
            // Final Elisa es despedida: 2 noticias que perjudiquen a Elisa
            ElisaFiredEnding();
        }
        else if (lastLevelCompleted)
        {
            // Final completando todos los niveles: vida mediocre en el periódico
            MediocreEnding();
        }
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

}
