using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro;

public class Player : MonoBehaviour
{
    public float playerHP, startHP = 3f;
    public static int score, achievement;

    public static bool playerDead;

    public Text HP;
    public Image HPBar;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        playerDead = false;
        playerHP = startHP;
        score = 0;
        achievement = 0;
        HP.text = playerHP + "";
        scoreText.text = score + "";        
    }

    void Update()
    {
        if (playerHP == 0f) { 
            playerDead = true;
            Destroy(gameObject);
        }

        if (transform.position.y < -15) Damage(3);

        if (playerDead) GameOver();
    }

    public void getScore(int num) {
        score += num;
        scoreText.text = score + "";
    }

    public void Damage(int damage) {
        playerHP -= damage;

        if (playerHP < 0f) playerHP = 0f;

        HPBar.fillAmount = playerHP / startHP;
        HP.text = playerHP + "";

        if (playerHP <= 1f) HPBar.color = Color.red;
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy") {
            FindObjectOfType<AudioManager>().Play("PlayerDamage");
            Damage(1);
        }
    }

    void GameOver() {
        SceneManager.LoadScene("GameOver");
    }
}

