using UnityEngine;

public class CarBase
{
    private CarData _carData;
    private GameObject _handle;
    private WheelCollider _frontLeftWheel;
    private WheelCollider _frontRightWheel;
    private WheelCollider _rearLeftWheel;
    private WheelCollider _rearRightWheel;
    private float _currentBrakeForce;
    private float _currentSteerAngle;
    bool _isBraking = false; 
    bool _isHandbrake = false;
    public CarBase(GameObject handle,CarData setcarData, (WheelCollider frontLeft, WheelCollider frontRight, WheelCollider rearLeft, WheelCollider rearRight) wheels)
    {
        _handle = handle;
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
        
    }
    private void HandleSteering()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        var euler = _handle.transform.localEulerAngles;
        _handle.transform.localRotation = Quaternion.Euler(euler.x, euler.y, horizontalInput * -540f);
        _currentSteerAngle = _carData.MaxSteerAngle * horizontalInput;
        _frontLeftWheel.steerAngle = _currentSteerAngle;
        _frontRightWheel.steerAngle = _currentSteerAngle;
    }
}
