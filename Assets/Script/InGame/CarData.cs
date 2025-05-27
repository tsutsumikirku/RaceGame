using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class CarData : ScriptableObject
{
    [Tooltip("エンジンのトルク（N·m）")]
    [SerializeField] private float _motorForce = 1500f;

    [Tooltip("ブレーキの力（N·m）")]
    [SerializeField] private float _brakeForce = 3000f;

    [Tooltip("最大ステア角（度）")]
    [SerializeField] private float _maxSteerAngle = 30f;

    public float MotorForce => _motorForce;
    public float BrakeForce => _brakeForce;
    public float MaxSteerAngle => _maxSteerAngle;
}