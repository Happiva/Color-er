using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Item : MonoBehaviour
{
    public int score;
    private GameObject ScoreText;

    void Start()
    {
        ScoreText = (GameObject)Resources.Load("ScoreText");
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1.5f, 0));        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().getScore(score);
            ShowScoreText();
            FindObjectOfType<AudioManager>().Play("GetItem");
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
