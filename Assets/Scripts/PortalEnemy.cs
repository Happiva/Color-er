using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnemy : MonoBehaviour
{
    public GameObject pos;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.transform.position = pos.transform.position + new Vector3(0, 1.0f, 0);
            other.gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
