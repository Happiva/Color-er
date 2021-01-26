using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlane : MonoBehaviour
{
    public float moveSpeed = 2f, distance;

    private Vector3 pos, nowPos;
    private bool isMoving = true, moveUp;

    void Start()
    {
        pos = transform.position;

        //Plane의 이동 방향을 바꾸기 위한 변수
        moveUp = true;
    }

    void FixedUpdate()
    {
        nowPos = transform.position;
        if ((nowPos - pos).magnitude <= distance && isMoving && moveUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            nowPos = transform.position;
        }

        else if ((nowPos - pos).magnitude <= distance && isMoving && !moveUp)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            nowPos = transform.position;
        }

        if ((nowPos - pos).magnitude > distance)
        {
            isMoving = false;
            moveUp = !moveUp;

            pos = transform.position;
            nowPos = transform.position;

            Invoke("wait", 3f);
        }
    }

    void OnCollisionEnter(Collision other) {
        other.transform.parent = transform;
    }

    void OnCollisionExit(Collision other) {
        other.transform.parent = null;
    }

    void wait()
    {
        //이동을 멈추고 대기
        isMoving = true;
    }
}
