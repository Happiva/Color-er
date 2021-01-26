using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    private float moveSpeed = 3f;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void FixedUpdate()
    {       
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.y < -5f) Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "DeadPoint") Destroy(gameObject);
    }
}
