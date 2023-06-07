using CirclePiecesUI;
using JetBrains.Annotations;
using System.Linq;
using System.Reflection.Emit;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


namespace CirclePiecesUI
{
    public class AdjustmentsCategories : MonoBehaviour
    {
        public TMP_InputField Inputcat;
        public static CirclePieces[] dataPieces = new CirclePieces[12];

        public void apply()
        {
            catadd();
        }
        void catadd()
        {
            string xyz = Inputcat.text; // przypisuje stringowi xyz to co wpisujemy w input box
            if (xyz != string.Empty)
            {
                string[] array = xyz.Split(','); // dzieli tekst w tablicy w miejscu ","
                dataPieces = new CirclePieces[array.Length];
                Debug.Log(dataPieces.Length);
                for (int i = 0; i < array.Length; i++) // wykonuje siê tak d³ugo, ile mamy indexów
                {
                    CirclePieces data = new CirclePieces();
                    data.Label = array[i];

                    dataPieces[i] = data;
                }
            }
        }
    }
}
