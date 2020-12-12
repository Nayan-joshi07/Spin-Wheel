using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Claim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] TextMeshProUGUI scoreBox;
    string[] score = {"1000","1500","2000","2500","3000","3500","4000","4500","5000","5500","6000","6500"};
    int scoreText;
    public SpinWheel spinWheel;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        ClaimText();
    }
    private void ClaimText()
    {
        scoreText = spinWheel.angle;
        switch (scoreText)
        {
            case 0:
                textBox.text = score[0];
                break;
            case 1:
                textBox.text = score[1];
                break;
            case 2:
                textBox.text = score[2];
                break;
            case 3:
                textBox.text = score[3];
                break;
            case 4:
                textBox.text = score[4];
                break;
            case 5:
                textBox.text = score[5];
                break;
            case 6:
                textBox.text = score[6];
                break;
            case 7:
                textBox.text = score[7];
                break;
            case 8:
                textBox.text = score[8];
                break;
            case 9:
                textBox.text = score[9];
                break;
            case 10:
                textBox.text = score[10];
                break;
            case 11:
                textBox.text = score[11];
                break;
            case 12:
                textBox.text = score[12];
                break;
        }
    }
    public void ClaimButton()
    {
        int totalScore = int.Parse(scoreBox.text);
        totalScore += int.Parse(score[scoreText]);
        scoreBox.text = totalScore.ToString();
        spinWheel.ClaimToWheel();
    }
}
