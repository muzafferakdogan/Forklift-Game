using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePendulumScript : MonoBehaviour
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

    void ChangeMoveDir()
    {
        if (transform.rotation.x > rightAngel)
        {
            moving = false;
        }

        if (transform.rotation.x < leftAngel)
        {
            moving = true;
        }
    }

    void Moove()
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
