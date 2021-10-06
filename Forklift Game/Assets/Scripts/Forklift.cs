using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forklift : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private bool brake;
    private float currentBrakePower;

    [SerializeField] private float motorPower;
    [SerializeField] private float rotationalPower;
    [SerializeField] private float brakePower;

    [SerializeField] private WheelCollider leftBackWheelCollider;
    [SerializeField] private WheelCollider leftFrontWheelCollider;
    [SerializeField] private WheelCollider rightBackWheelCollider;
    [SerializeField] private WheelCollider rightFrontWheelCollider;

    [SerializeField] private Transform leftBackWheelTransform;
    [SerializeField] private Transform leftFrontWheelTransform;
    [SerializeField] private Transform rightBackWheelTransform;
    [SerializeField] private Transform rightFrontWheelTransform;

    [SerializeField] private GameObject leftFrontWheel;
    [SerializeField] private GameObject rightFrontWheel;


    void Start()
    {
        
    }


    void Update()
    {
        getUserInput();
        moveAndRotateToCar();
        rotateTheWheels();
    }

    void getUserInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        brake = Input.GetKey(KeyCode.Space);
    }

    void moveAndRotateToCar()
    {
        leftFrontWheelCollider.motorTorque = vertical * motorPower;
        rightFrontWheelCollider.motorTorque = vertical * motorPower;

        leftBackWheelCollider.steerAngle = horizontal * rotationalPower;
        rightBackWheelCollider.steerAngle = horizontal * rotationalPower;

        currentBrakePower = brake ? brakePower : 0f;
        if (brake)
        {
            leftFrontWheelCollider.brakeTorque = currentBrakePower;
            rightFrontWheelCollider.brakeTorque = currentBrakePower;
            leftBackWheelCollider.brakeTorque = currentBrakePower;
            leftBackWheelCollider.brakeTorque = currentBrakePower;
        }
        else
        {
            leftFrontWheelCollider.brakeTorque = 0f;
            rightFrontWheelCollider.brakeTorque = 0f;
            leftBackWheelCollider.brakeTorque = 0f;
            leftBackWheelCollider.brakeTorque = 0f;
        }
    }
    
    void rotateTheWheels()
    {
        rotateTheWheelsethod(leftBackWheelCollider, leftBackWheelTransform);
        rotateTheWheelsethod(leftFrontWheelCollider, leftFrontWheelTransform);
        rotateTheWheelsethod(rightBackWheelCollider, rightBackWheelTransform);
        rotateTheWheelsethod(rightFrontWheelCollider, rightFrontWheelTransform);
    }

    void rotateTheWheelsethod(WheelCollider wheelCollider , Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

}
