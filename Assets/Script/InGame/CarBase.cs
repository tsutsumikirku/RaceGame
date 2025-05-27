using UnityEngine;

public class CarBase
{
    private CarData _carData;
    private WheelCollider _frontLeftWheel;
    private WheelCollider _frontRightWheel;
    private WheelCollider _rearLeftWheel;
    private WheelCollider _rearRightWheel;
    private float _currentBrakeForce;
    private float _currentSteerAngle;
    bool _isBraking = false; 
    bool _isHandbrake = false;
    public CarBase(CarData setcarData, (WheelCollider frontLeft, WheelCollider frontRight, WheelCollider rearLeft, WheelCollider rearRight) wheels)
    {
        _carData = setcarData;
        _frontLeftWheel = wheels.frontLeft;
        _frontRightWheel = wheels.frontRight;
        _rearLeftWheel = wheels.rearLeft;
        _rearRightWheel = wheels.rearRight;
    }
    public void ManualUpdate()
    {
        HandleMotor();
        HandleSteering();
    }
    private void HandleMotor()
    {
        float verticalInput = Input.GetAxis("Vertical");
        _isBraking = Input.GetKey(KeyCode.Space);
        _isHandbrake = Input.GetKey("b");
        _frontLeftWheel.motorTorque = verticalInput * _carData.MotorForce;
        _frontRightWheel.motorTorque = verticalInput * _carData.MotorForce;
        _rearLeftWheel.motorTorque = verticalInput * _carData.MotorForce;
        _rearRightWheel.motorTorque = verticalInput * _carData.MotorForce;
        _currentBrakeForce = _isBraking || _isHandbrake ? _carData.BrakeForce : 0f;
        ApplyBraking();
    }

    private void ApplyBraking()
    {
        _frontLeftWheel.brakeTorque = _currentBrakeForce;
        _frontRightWheel.brakeTorque = _currentBrakeForce;
        if (!_isHandbrake)
        {
            _rearLeftWheel.brakeTorque = _currentBrakeForce;
            _rearRightWheel.brakeTorque = _currentBrakeForce;
        }
    }

    private void HandleSteering()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _currentSteerAngle = _carData.MaxSteerAngle * horizontalInput;
        _frontLeftWheel.steerAngle = _currentSteerAngle;
        _frontRightWheel.steerAngle = _currentSteerAngle;
    }
}
