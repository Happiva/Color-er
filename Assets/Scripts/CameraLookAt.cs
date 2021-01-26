using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = .1f;
    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 pos = target.position + offset;

        Vector3 velo = Vector3.zero;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f);

        transform.LookAt(target);
    }
}
