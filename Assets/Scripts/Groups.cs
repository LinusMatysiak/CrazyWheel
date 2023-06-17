using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Groups : MonoBehaviour
{
    public static GameObject VictoryText;
    public TMP_Text DisplayText;
    public TMP_Text Score;
    public TMP_InputField InputScore;
    int score; int scoreadd;
    System.Random random = new System.Random();
    //Victory
    [SerializeField] private GameObject VictoryPanel;
    //Victory
    private void Awake() {
        VictoryPanel = GameObject.FindWithTag("VictoryPanel");
    }
    private void Start() {
        VictoryPanel.SetActive(false);
        DisplayText.text = gameObject.name;
        Color();
    }
    public void ChangeScore() {
        scoreadd = Convert.ToInt32(InputScore.text);
        score += scoreadd;
        Score.text = score.ToString();
        InputScore.text = null;
    }
    private void FixedUpdate() {
        if (score >= AdjustmentsVictory.VictoryScore) {
            VictoryPanel.SetActive(true);
            Victory.VictoryText.text = DisplayText.text + " Wins!";
        }
    }
    void Color()
    {
        Color randomColor = new Color(1, UnityEngine.Random.value, UnityEngine.Random.value);
        GetComponent<Image>().color = randomColor;
    }
}
