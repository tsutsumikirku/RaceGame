using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase
{
    //Wheel Colliders
    private WheelCollider frontLeftWheel;
    private WheelCollider frontRightWheel;
    private WheelCollider rearLeftWheel;
    private WheelCollider rearRightWheel;
    private float motorForce = 1500f;
    private float brakeForce = 3000f;
    private float maxSteerAngle = 30f;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;
    private bool isHandbrake;
    public CarBase(CarData carData)
    {

    }
    public void ManualUpdate()
    {
        HandleMotor();
        HandleSteering();
    }
    private void HandleMotor()
    {
        float verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(KeyCode.Space);
        isHandbrake = Input.GetKey("b");
        frontLeftWheel.motorTorque = verticalInput * motorForce;
        frontRightWheel.motorTorque = verticalInput * motorForce;
        rearLeftWheel.motorTorque = verticalInput * motorForce;
        rearRightWheel.motorTorque = verticalInput * motorForce;
        currentBrakeForce = isBraking || isHandbrake ? brakeForce : 0f;
        ApplyBraking();
    }

    private void ApplyBraking()
    {
        frontLeftWheel.brakeTorque = currentBrakeForce;
        frontRightWheel.brakeTorque = currentBrakeForce;
        if (!isHandbrake)
        {
            rearLeftWheel.brakeTorque = currentBrakeForce;
            rearRightWheel.brakeTorque = currentBrakeForce;
        }
    }

    private void HandleSteering()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheel.steerAngle = currentSteerAngle;
        frontRightWheel.steerAngle = currentSteerAngle;
    }
}
