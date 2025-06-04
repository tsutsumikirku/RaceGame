using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class CarData : ScriptableObject
{
    [SerializeField, Header("エンジン性能表")]
    AnimationCurve _enginePerformanceCurve = new AnimationCurve(
        new Keyframe(0f, 0f),
        new Keyframe(7000f, 206f),
        new Keyframe(8000f, 162f)
    );
    [SerializeField, Header("ギア比表  ギア0はリバース、ギア1はニュートラル")]
    float[] _gearRatios = new float[]
    {
        -3.5f, // ギア0はリバース
        0.0f, // ギア1はニュートラル
        3.5f,
        2.0f,
        1.5f,
        1.0f,
        0.8f,
        0.7f
    };
    [SerializeField, Header("ファイナルギア比")] float _finalDriveRatio = 3.9f;
    [SerializeField, Header("効率")] float _efficiency = 0.95f;
    [SerializeField, Header("ブレーキの力（N·m）")] float _brakeForce = 3000f;
    [SerializeField, Header("最大ステア角（度）")] float _maxSteerAngle = 30f;
    [SerializeField, Header("駆動方式")] DriveType _driveType = DriveType.RearWheelDrive;
    public AnimationCurve EnginePerformanceCurve { get => _enginePerformanceCurve; }
    public float[] GearRatios { get => _gearRatios; }
    public float FinalDriveRatio { get => _finalDriveRatio; }
    public float Efficiency { get => _efficiency; }
    public float BrakeForce { get => _brakeForce; }
    public float MaxSteerAngle { get => _maxSteerAngle; }
    public DriveType DriveType { get => _driveType; }
}
public enum DriveType
{
    FrontWheelDrive,
    RearWheelDrive,
    AllWheelDrive
}