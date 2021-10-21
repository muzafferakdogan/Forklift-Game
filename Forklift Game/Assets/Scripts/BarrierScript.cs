using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    [SerializeField] private Transform[] targetPosition;
    [SerializeField] private float barrierMoveSpeed;
    
    private Vector3 direction;

    int targetPositionIndex = 0;

    void Start()
    {
       
    }
    
    void Update()
    {
        if (Vector3.Distance(targetPosition[targetPositionIndex].position, transform.position) > 0.5f)
        {
            RotateTheBarrier();
        }
        else
        {
            targetPositionIndex++;
            RestToTargetPositionIndex();
            RotateTheBarrier();
        }
    }

    private void RotateTheBarrier()
    {
        direction = targetPosition[targetPositionIndex].position - transform.position;
        transform.position += (direction.normalized) * barrierMoveSpeed * Time.deltaTime ;
    }

    private void RestToTargetPositionIndex()
    {
        if (targetPositionIndex == targetPosition.Length)
        {
            targetPositionIndex = 0;
        }
    }
}
