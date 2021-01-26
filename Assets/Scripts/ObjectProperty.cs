using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperty : MonoBehaviour
{
    private float basicBounciness = 0f;
    private float basicFriction = .6f;

    private float timelimit;

    public static bool changeAble = true;

    private GameObject RemainedTime;

    void Start()
    {
        timelimit = 5f;
        RemainedTime = (GameObject)Resources.Load("RemainedTime");
    }

    void Update()
    {
        if (gameObject.GetComponent<Renderer>().material.color == Color.red && changeAble)
        {
            redMode();            

            changeAble = false;
            PlayerController.abilityOn = true;
        }

        if (gameObject.GetComponent<Renderer>().material.color == Color.yellow && changeAble)
        {
            yellowMode();
            changeAble = false;
            PlayerController.abilityOn = true;
        }
    }

    void redMode()
    {
        changeAble = false;        
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().moveSpeed = 10f;        

        Invoke("BackToNormal", timelimit);
    }

    void yellowMode()
    {
        changeAble = false;
        gameObject.GetComponent<Collider>().material.bounciness = 1f;
        Invoke("BackToNormal", timelimit);
    }

    void BackToNormal()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        gameObject.GetComponent<Collider>().material.bounciness = basicBounciness;
        gameObject.GetComponent<Collider>().material.dynamicFriction = basicFriction;
        gameObject.GetComponent<Collider>().material.staticFriction = basicFriction;

        PlayerController.abilityOn = false;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().moveSpeed = PlayerController.defaultMoveSpeed;
        changeAble = true;
    }
}
