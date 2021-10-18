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
    [SerializeField] private WheelCollider steeringWheelCollider;

    [SerializeField] private Transform leftBackWheelTransform;
    [SerializeField] private Transform leftFrontWheelTransform;
    [SerializeField] private Transform rightBackWheelTransform;
    [SerializeField] private Transform rightFrontWheelTransform;

    [SerializeField] private GameObject steeringWheel;

    Vector3 steeringWheelVector;

    void Start()
    {
        
    }

    void Update()
    {
        getUserInput();
        moveAndRotateTheCar();
        rotateTheWheels();
        rotateTheSteeringWheel();
    }

    void getUserInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        brake = Input.GetKey(KeyCode.Space);
    }

    void moveAndRotateTheCar()
    {
        leftFrontWheelCollider.motorTorque = vertical * motorPower;
        rightFrontWheelCollider.motorTorque = vertical * motorPower;
        leftBackWheelCollider.motorTorque = vertical * motorPower;
        rightBackWheelCollider.motorTorque = vertical * motorPower;

        leftBackWheelCollider.steerAngle = horizontal * rotationalPower;
        rightBackWheelCollider.steerAngle = horizontal * rotationalPower;
        steeringWheelCollider.steerAngle = horizontal * rotationalPower;

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
        rotateTheWheelsMethod(leftBackWheelCollider, leftBackWheelTransform);
        rotateTheWheelsMethod(leftFrontWheelCollider, leftFrontWheelTransform);
        rotateTheWheelsMethod(rightBackWheelCollider, rightBackWheelTransform);
        rotateTheWheelsMethod(rightFrontWheelCollider, rightFrontWheelTransform);
    }

    void rotateTheWheelsMethod(WheelCollider wheelCollider , Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

    void rotateTheSteeringWheel()
    {
        steeringWheelVector = steeringWheel.transform.localEulerAngles;
        steeringWheelVector.z = steeringWheelCollider.steerAngle;
        steeringWheel.transform.localEulerAngles = steeringWheelVector;
    }
}
