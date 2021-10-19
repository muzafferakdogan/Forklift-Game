using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    [SerializeField] private Transform[] targetPosition;
    [SerializeField] private float barrierMoveSpeed;
    
    private Vector3 direction;

    int counter = 0;

    void Start()
    {
       
    }
    
    void Update()
    {
        if (Vector3.Distance(targetPosition[counter].position, transform.position) > 0.5f)
        {
            RotateTheBarrier();
        }
        else
        {
            counter++;
            RestToTargetPositionIndex();
            RotateTheBarrier();
        }
    }

    private void RotateTheBarrier()
    {
        direction = targetPosition[counter].position - transform.position;
        transform.position += (direction.normalized) * barrierMoveSpeed * Time.deltaTime ;
    }

    private void RestToTargetPositionIndex()
    {
        if (counter == targetPosition.Length)
        {
            counter = 0;
        }
    }
}
