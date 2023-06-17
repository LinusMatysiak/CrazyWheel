using CirclePiecesUI;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public Button Play;
    public void IfInteractable()
    {
        if (AdjustmentsCategories.dataPieces.Length >= 2 && AdjustmentsGroups.GroupCount >= 1 && AdjustmentsVictory.VictoryScore > 0)
        {
            Play.interactable = true;        }
        //if (adjustmentscategories.datapieces.length <= 0 && adjustmentsgroups.groupcount <= 0 && adjustmentsvictory.victoryscore <= 0)
        //{
        //    play.interactable = false;
        //}
    }
}
