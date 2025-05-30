using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class CarData : ScriptableObject
{
    [SerializeField, Header("エンジンのトルク（N·m）")] public float MotorForce = 1500f;
    [SerializeField,Header("ブレーキの力（N·m）")] public float BrakeForce = 3000f;
    [SerializeField,Header("最大ステア角（度）")] public float MaxSteerAngle = 30f;
}