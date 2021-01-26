using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI FinalScore;
    public TextMeshProUGUI FinalTrophy;

    void Start()
    {
        FinalScore.text = "Score " + Player.score.ToString() + " + Time Bonus = " + (Player.score + (int)GameManager.currentTime * 50).ToString();

        if (Player.achievement == 0)
            FinalTrophy.text = "No Trophy...";

        else if (Player.achievement == 1)
            FinalTrophy.text = Player.achievement.ToString();

        else if (Player.achievement == 2)
            FinalTrophy.text = "You Collected All Trophies!";
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Game");
    }
}
