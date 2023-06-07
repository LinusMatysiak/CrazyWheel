using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class AdjustmentsGroups : MonoBehaviour
{
    public TMP_InputField InputGroups;
    public static int GroupCount;

    public static string[] groupsarray;

    public void apply()
    {
        Groupadd();
    }
    void Groupadd() 
    {
        string xyz = InputGroups.text; // przypisuje stringowi xyz to co wpisujemy w input box
        if (xyz != string.Empty)  {
            string[] array = xyz.Split(','); // dzieli tekst w tablicy w miejscu ","
            for (int i = 0; i < array.Length; i++) // wykonuje si� tak d�ug, ile mamy index�w
            {
                Debug.Log(array[i]); // wypisuje wszystkie nazwy grupy po kolei
            }
            GroupCount = array.Count(); // przypisuje ilo�� grup nowej zmiennej, wykorzystywane w innym skrypcie
            Debug.Log("there are " + GroupCount + " Groups"); // wypisuje ilo�� grup
            groupsarray = array; // zmienia lokalny array w globalny
        }
    }
}
