using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageSelector : MonoBehaviour
{
    [SerializeField] public Image[] PossibleImages;
    [SerializeReference] Image FinalImage;

    private void Start()
    {
        for (int i=0; i == CirclePiecesUI.AdjustmentsCategories.CircleLenght; i++) 
        {
            FinalImage = PossibleImages[i];
        }
    }
}
