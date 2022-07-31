using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsManager : MonoBehaviour
{
    int maxLevelValue;
    int moneyLevel;
    int credibilityLevel;
    int pressureLevel;

    // Gestionar finales en funcion de los valores de los niveles de las métricas
    public void CriticalEndings(){
        if (moneyLevel <= 0){
            // Final por pérdida de dinero: quiebra del periódico
            if (allTrue) AllwaysTrueEnding(); // Despido con conciencia tranquila
            else LowMoneyEnding();
        } else if (credibilityLevel <= 0){
            // Final por pérdida de credibilidad: despido del periódico
            LowCredibilityEnding();
        } else if (pressureLevel >= maxLevelValue){
            // Final por ganancia de presión: Muerte misteriosa en un accidente y reemplazo en el periódico
            HighPressureEnding();
        }
    }

    // Gestionar finales en funcion de los valores de los niveles de las métricas
    public void AlternativeEndings(){
        if (elisaStrikes >= 2){
            // Final Elisa es despedida: 2 noticias que perjudiquen a Elisa
            ElisaFiredEnding();
        } else if (lastLevelCompleted){
            // Final completando todos los niveles: vida mediocre en el periódico
            MediocreEnding();
        }
    }
}
