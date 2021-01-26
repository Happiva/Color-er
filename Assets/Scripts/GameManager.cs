using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GameManager : MonoBehaviour
{
    public static float currentTime = 0f;
    float startTime = 100f;

    public Text timeText;
    public TextMeshProUGUI text;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timeText.text = ((int)currentTime).ToString();
        if (currentTime < 0) currentTime = 0f;
        if (currentTime == 0f) Player.playerDead = true;
        if (currentTime <= 10f) timeText.color = Color.red;
    }

    public void AlertMessage(string msg) {
        text.gameObject.SetActive(true);
        text.GetComponent<TextMeshProUGUI>().text = msg;
        Invoke("TextOff", 1.5f);
    }

    void TextOff()
    {
        text.gameObject.SetActive(false);        
    }
}
