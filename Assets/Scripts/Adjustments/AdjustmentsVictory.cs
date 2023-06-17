using UnityEngine;
using TMPro;
using System;
public class AdjustmentsVictory : MonoBehaviour
{
    public TMP_InputField InputVictory;
    public static int VictoryScore;
    public void Apply() 
    {
        VictoryScore = Convert.ToInt32(InputVictory.text);
        Debug.Log("Victory Score set to " + VictoryScore);
    }
}