using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftControlUIScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private bool pressGas;
    [SerializeField] private bool pressBrake;
    [SerializeField] private bool pressRight;
    [SerializeField] private bool pressLeft;

    [SerializeField] private float motorPower;
    [SerializeField] private float rotationalPower;
    [SerializeField] private float brakePower;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

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
        MoveTheCar();
        RotateTheCar();
        RotateTheWheels();
        RotateTheSteeringWheel();
    }

    private void MoveTheCar()
    {
        speed = rb.velocity.sqrMagnitude;

        if (speed < maxSpeed)
        {
            if (pressGas)
            {

                leftFrontWheelCollider.motorTorque = motorPower;
                rightFrontWheelCollider.motorTorque = motorPower;
                leftBackWheelCollider.motorTorque = motorPower;
                rightBackWheelCollider.motorTorque = motorPower;
            }
            else
            {
                leftFrontWheelCollider.motorTorque = 0f;
                rightFrontWheelCollider.motorTorque = 0f;
                leftBackWheelCollider.motorTorque = 0f;
                rightBackWheelCollider.motorTorque = 0f;
            }
        }

        if (pressBrake)
        {
            leftFrontWheelCollider.brakeTorque = brakePower;
            rightFrontWheelCollider.brakeTorque = brakePower;
            leftBackWheelCollider.brakeTorque = brakePower;
            leftBackWheelCollider.brakeTorque = brakePower;
        }
        else
        {
            leftFrontWheelCollider.brakeTorque = 0f;
            rightFrontWheelCollider.brakeTorque = 0f;
            leftBackWheelCollider.brakeTorque = 0f;
            leftBackWheelCollider.brakeTorque = 0f;
        }
    }

    private void RotateTheCar()
    {
        if (pressRight)
        {
            leftBackWheelCollider.steerAngle = rotationalPower;
            rightBackWheelCollider.steerAngle = rotationalPower;
            steeringWheelCollider.steerAngle = rotationalPower;
        }
        else
        {
            leftBackWheelCollider.steerAngle = 0f;
            rightBackWheelCollider.steerAngle = 0f;
            steeringWheelCollider.steerAngle = 0f;
        }

        if (pressRight)
        {
            rb.AddTorque(Vector3.up * rotationalPower * 10);
        }
        else
        {
            rb.AddTorque(Vector3.up * 0);
        }

        if (pressLeft)
        {
            rb.AddTorque(Vector3.down * rotationalPower * -10);
        }
    }

    private void RotateTheWheels()
    {
        RotateTheWheelsMethod(leftBackWheelCollider, leftBackWheelTransform);
        RotateTheWheelsMethod(leftFrontWheelCollider, leftFrontWheelTransform);
        RotateTheWheelsMethod(rightBackWheelCollider, rightBackWheelTransform);
        RotateTheWheelsMethod(rightFrontWheelCollider, rightFrontWheelTransform);
    }

    private void RotateTheWheelsMethod(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;

        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.position = position;
        wheelTransform.rotation = rotation;
    }

    private void RotateTheSteeringWheel()
    {
        steeringWheelVector = steeringWheel.transform.localEulerAngles;
        steeringWheelVector.z = steeringWheelCollider.steerAngle;
        steeringWheel.transform.localEulerAngles = steeringWheelVector;
    }
    public void GasDown()
    {
        pressGas = true;
    }

    public void GasExit()
    {
        pressGas = false;
    }

    public void BrakeDown()
    {
        pressBrake = true;
    }

    public void BrakeExit()
    {
        pressBrake = false;
    }

    public void RightDown()
    {
        pressRight = true;
    }
 
    public void RightExit()
    {
        pressRight = false;
    }

    public void LeftDown()
    {
        pressLeft = true;
    }

    public void LeftExit()
    {
        pressLeft = false;
    }
}