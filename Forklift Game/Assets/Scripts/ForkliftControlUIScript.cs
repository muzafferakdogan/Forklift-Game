using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftControlUIScript : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private bool brake;
    private float currentBrakePower;

    public bool pressGas;
    public bool pressBrake;

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
        /**Debug.Log(leftBackWheelCollider.motorTorque);**/
        if (pressGas)
        {
            Debug.Log(pressGas);
            leftFrontWheelCollider.motorTorque = motorPower;
            rightFrontWheelCollider.motorTorque = motorPower;
            leftBackWheelCollider.motorTorque = motorPower;
            rightBackWheelCollider.motorTorque = motorPower;
            /**Debug.Log(leftBackWheelCollider.motorTorque);**/

        }          
    }

    public void BrakeDown()
    {

    }

    public void BrakeExit()
    {

    }

    public void GasDown()
    {
        pressGas = true;
    }

    public void GasExit()
    {
        pressGas = false;
    }

    private void MoveTheCar()
    {
        if (pressGas)
        {
            leftFrontWheelCollider.motorTorque = motorPower;
            rightFrontWheelCollider.motorTorque = motorPower;
            leftBackWheelCollider.motorTorque = motorPower;
            rightBackWheelCollider.motorTorque = motorPower;
        }
    }
    void rotateTheWheels()
    {
        rotateTheWheelsMethod(leftBackWheelCollider, leftBackWheelTransform);
        rotateTheWheelsMethod(leftFrontWheelCollider, leftFrontWheelTransform);
        rotateTheWheelsMethod(rightBackWheelCollider, rightBackWheelTransform);
        rotateTheWheelsMethod(rightFrontWheelCollider, rightFrontWheelTransform);
    }

    void rotateTheWheelsMethod(WheelCollider wheelCollider, Transform wheelTransform)
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

}