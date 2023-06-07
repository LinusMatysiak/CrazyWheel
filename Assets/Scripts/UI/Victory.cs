using UnityEngine;
using TMPro;
public class Victory : MonoBehaviour
{
    public static TMP_Text VictoryText;
    private void Start()
    {
        VictoryText = GetComponent<TMP_Text>();
    }
}
