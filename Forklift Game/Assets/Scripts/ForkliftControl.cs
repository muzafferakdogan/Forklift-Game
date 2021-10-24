using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlMode { Keyboard = 1, Touch = 2 };

public class ForkliftControl : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    private bool brake;
    private float currentBrakePower;

    [SerializeField] private Rigidbody rb;

    public bool pressGas;
    public bool pressBrake;
    public bool pressRight;
    public bool pressLeft;

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

    public ControlMode control;
    public GameObject UI;

    void Start()
    {

    }

    void Update()
    {
        if (control == ControlMode.Keyboard)
        {
            GetUserInputForKeyboard();
            MoveTheCarForKeyboard();
            RotateTheCarForKeyboard();
            UI.SetActive (false);
        }

        else
        {
            UI.SetActive(true);
            MoveTheCarForUI();
            RotateTheCarForUI();
        }
      
        RotateTheWheels();
        RotateTheSteeringWheel();
    }

    private void GetUserInputForKeyboard()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        brake = Input.GetKey(KeyCode.Space);
    }

    private void MoveTheCarForKeyboard()
    {
        leftFrontWheelCollider.motorTorque = vertical * motorPower;
        rightFrontWheelCollider.motorTorque = vertical * motorPower;
        leftBackWheelCollider.motorTorque = vertical * motorPower;
        rightBackWheelCollider.motorTorque = vertical * motorPower;

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
    private void RotateTheCarForKeyboard()
    {
        leftBackWheelCollider.steerAngle = horizontal * rotationalPower;
        rightBackWheelCollider.steerAngle = horizontal * rotationalPower;
        steeringWheelCollider.steerAngle = horizontal * -rotationalPower;
    }


    private void MoveTheCarForUI()
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

    private void RotateTheCarForUI()
    {
        if (pressRight)
        {
            leftBackWheelCollider.steerAngle = rotationalPower;
            rightBackWheelCollider.steerAngle = rotationalPower;
            steeringWheelCollider.steerAngle = -rotationalPower;
        }
        
        else
        {
            leftBackWheelCollider.steerAngle = 0f;
            rightBackWheelCollider.steerAngle = 0f;
            steeringWheelCollider.steerAngle = 0f;
        }

        if (pressLeft)
        {
            leftBackWheelCollider.steerAngle = -rotationalPower;
            rightBackWheelCollider.steerAngle = -rotationalPower;
            steeringWheelCollider.steerAngle = -rotationalPower;
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