using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MonoBehaviour
{
    [SerializeField] private WheelCollider frontLeftWheel;
    [SerializeField] private WheelCollider frontRightWheel;
    [SerializeField] private WheelCollider rearLeftWheel;
    [SerializeField] private WheelCollider rearRightWheel;
    [SerializeField] private float motorForce = 1500f;
    [SerializeField] private float brakeForce = 3000f;
    [SerializeField] private float maxSteerAngle = 30f;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;
    private bool isHandbrake;
    private void FixedUpdate()
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
        if(!isHandbrake){
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
