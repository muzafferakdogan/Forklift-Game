using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float mooveSpeed;
    [SerializeField] private float leftAngel;
    [SerializeField] private float rightAngel;

    bool moving;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moving = true;
    }

    void Update()
    {
        Moove();
    }

    private void ChangeMoveDir()
    {
        if (transform.rotation.z > rightAngel)
        {
            moving = false;
        }

        if (transform.rotation.z < leftAngel)
        {
            moving = true;
        }
    }

    private void Moove()
    {
        ChangeMoveDir();

        if (moving)
        {
            rb.angularVelocity = new Vector3(0, 0, mooveSpeed);
        }

        if (!moving)
        {
            rb.angularVelocity = new Vector3(0, 0, -1 * mooveSpeed);
        }
    }
}
