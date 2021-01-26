using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private GameObject instance;
    private Vector3 pos;

    private float respawntime;

    void Start()
    {
        pos = transform.position + new Vector3(0, 1.0f, 0);
        respawntime = 3f;

        InvokeRepeating("CreateEnemy", 1.0f, respawntime);
    }

    void CreateEnemy() {
        instance = (GameObject)Instantiate(enemy, pos, Quaternion.Euler(0, 90, 0));
        instance.transform.SetParent(GameObject.Find("Enemies").transform);
    }
}
