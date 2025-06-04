using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;

public class CarBase
{
    public int CurrentGear { get => _currentGear; }
    public float RPM { get => _rpm; }
    private CarData _carData;
    private GameObject _handle;
    private WheelCollider _frontLeftWheel;
    private WheelCollider _frontRightWheel;
    private WheelCollider _rearLeftWheel;
    private WheelCollider _rearRightWheel;
    private float _currentSteerAngle;
    private float _accel = 0f;
    private float _rpm;
    private int _currentGear = 0;
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
        Gear();
        HandleMotor();
        Brake();
        HandleSteering();
    }
    private void Gear()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_currentGear < _carData.GearRatios.Length - 2) 
            {
                _currentGear++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_currentGear > -1) // ギア0はリバース
            {
                _currentGear--;
            }
        }
    }
    private void HandleMotor()
    {
        _accel = Input.GetAxis("Vertical");
        _rpm = _accel * _carData.EnginePerformanceCurve.keys[_carData.EnginePerformanceCurve.length - 1].time;
        float motorTorque = _carData.EnginePerformanceCurve.Evaluate(_rpm) * _carData.GearRatios[_currentGear + 1] * _carData.FinalDriveRatio * _carData.Efficiency;
        switch (_carData.DriveType)
        {
            case DriveType.AllWheelDrive:
                _rearLeftWheel.motorTorque = motorTorque;
                _rearRightWheel.motorTorque = motorTorque;
                _frontLeftWheel.motorTorque = motorTorque;
                _frontRightWheel.motorTorque = motorTorque;
                break;
            case DriveType.RearWheelDrive:
                _rearLeftWheel.motorTorque = motorTorque;
                _rearRightWheel.motorTorque = motorTorque;
                break;
            case DriveType.FrontWheelDrive:
                _frontLeftWheel.motorTorque = motorTorque;
                _frontRightWheel.motorTorque = motorTorque;
                break;
        }
    }
    private void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float brakeForce = _carData.BrakeForce;
            // ブレーキを適用
            _frontLeftWheel.brakeTorque = brakeForce;
            _frontRightWheel.brakeTorque = brakeForce;
            _rearLeftWheel.brakeTorque = brakeForce;
            _rearRightWheel.brakeTorque = brakeForce;
        }
        else
        {
            // ブレーキを解除
            _frontLeftWheel.brakeTorque = 0f;
            _frontRightWheel.brakeTorque = 0f;
            _rearLeftWheel.brakeTorque = 0f;
            _rearRightWheel.brakeTorque = 0f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float brakeForce = _carData.BrakeForce * 2f; // シフトキーでブレーキを強化
            // ブレーキを適用
            _rearLeftWheel.brakeTorque = brakeForce;
            _rearRightWheel.brakeTorque = brakeForce;
        }
        else
        {
            // ブレーキを解除
            _rearLeftWheel.brakeTorque = 0f;
            _rearRightWheel.brakeTorque = 0f;
        }
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
