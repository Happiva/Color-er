using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public static float defaultMoveSpeed = 8f;
    public GameObject ColorText;

    public GameObject abilitytime;

    public static bool abilityOn;

    private bool isOnLand;
    private float abilitytimelimit;


    void Start() {
        abilitytimelimit = 5f;
        moveSpeed = defaultMoveSpeed;
        isOnLand = true;
        abilityOn = false;
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Plane" || other.gameObject.tag == "ColorPlane")
        {
            isOnLand = true;            
        }
    }

    void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "ColorPlane")
        {
            if (ObjectProperty.changeAble)
                ColorText.SetActive(true);

            else ColorText.SetActive(false);

            if (Input.GetKeyDown(KeyCode.R))
            {
                FindObjectOfType<AudioManager>().Play("ColorChange");
                other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                FindObjectOfType<AudioManager>().Play("ColorChange");
                other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "ColorPlane") ColorText.SetActive(false);
    }

    void Update()
    {
        //Player 조작
        if (!isOnLand && !abilityOn) moveSpeed = defaultMoveSpeed - 2.5f;
        else moveSpeed = defaultMoveSpeed;

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (isOnLand && Input.GetKeyDown(KeyCode.Space)) {
            isOnLand = false;
            GetComponent<Rigidbody>().AddForce(transform.up * 400f);
        }

        //Player가 능력 사용 시 남은 시간 표시
        if (abilityOn)
        {
            abilitytime.SetActive(true);
            abilitytimelimit -= 1 * Time.deltaTime;
            if (abilitytimelimit <= 2f) abilitytime.GetComponent<TextMeshPro>().color = Color.red;

            abilitytime.GetComponent<TextMeshPro>().text = ((int)abilitytimelimit + 1).ToString();
        }
        else
        {
            abilitytime.SetActive(false);
            abilitytimelimit = 5f;

            abilitytime.GetComponent<TextMeshPro>().color = Color.black;
        }
    }
}
