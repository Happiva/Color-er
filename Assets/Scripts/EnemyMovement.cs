using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = .01f, distance, waitTime;
    private Vector3 pos, nowPos;
    private bool isMoving = true;

    void Start()
    {
        pos = transform.position;
        waitTime = 1.5f;
    }

    void FixedUpdate()
    { 
        nowPos = transform.position;
        if ((nowPos - pos).magnitude <= distance && isMoving)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            nowPos = transform.position;
        }
        else if ((nowPos - pos).magnitude > distance) isMoving = false;

        if ((nowPos - pos).magnitude > distance)
        {
            isMoving = false;
            rotateEnemy();
            Invoke("waitfor3", waitTime);
        }
    }
    
    void rotateEnemy()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        pos = transform.position;
        nowPos = transform.position;
    }
    
    void waitfor3() {
        isMoving = true;
    }
}
