using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    private float destroyTime = .7f;
    private float moveSpeed = 3.5f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }
}
