using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    public float distance;
    private Vector3 pos, nowPos;

    private bool isMoving = true, moveLeft;

    void Start()
    {
        pos = transform.position;
        moveLeft = true;
    }

    void FixedUpdate()
    {
        nowPos = transform.position;

        if ((nowPos - pos).magnitude <= distance && isMoving && moveLeft)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            nowPos = transform.position;
        }
        else if ((nowPos - pos).magnitude <= distance && isMoving && !moveLeft)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            nowPos = transform.position;
        }

        if ((nowPos - pos).magnitude > distance)
        {
            isMoving = false;
            moveLeft = !moveLeft;

            pos = transform.position;
            nowPos = transform.position;

            Invoke("wait", 3f);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        other.transform.parent = transform;
    }

    void OnCollisionExit(Collision other)
    {
        other.transform.parent = null;
        other.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void wait()
    {
        isMoving = true;
    }
}
