using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Achievement : MonoBehaviour
{ 
    public GameObject hiddenTrophy;

    public int score;
    private GameObject ScoreText;

    void Start()
    {
        ScoreText = (GameObject)Resources.Load("ScoreText");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "Trophy")
        {
            Player.achievement++;

            other.gameObject.GetComponent<Player>().getScore(score);
            ShowScoreText();

            FindObjectOfType<GameManager>().AlertMessage("You Got a Trophy!");
            FindObjectOfType<AudioManager>().Play("GetTrophy");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player" && gameObject.tag == "Key")
        {            
            hiddenTrophy.SetActive(true);
            FindObjectOfType<AudioManager>().Play("GetItem");
            FindObjectOfType<GameManager>().AlertMessage("Hidden Trophy Appeared!");

            Destroy(gameObject);
        }
    }

    void ShowScoreText()
    {
        //획득한 아이템의 점수 띄움        
        GameObject text = Instantiate(ScoreText, transform.position, Quaternion.identity, transform);

        text.transform.SetParent(GameObject.Find("Items").transform);
        text.transform.localScale = new Vector3(1, 1, 1);
        text.GetComponent<TextMeshPro>().color = Color.black;
        text.GetComponent<TextMeshPro>().text = "+" + score.ToString();
    }
}
