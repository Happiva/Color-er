using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class StageExit : MonoBehaviour
{
    public Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            ani.Play("door_open");

            SceneManager.LoadScene("GameClear");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ani.SetFloat("reverse", -1f);
            ani.Play("door_open");
        }
    }    
}
