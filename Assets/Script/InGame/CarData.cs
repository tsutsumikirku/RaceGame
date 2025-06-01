using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class CarData : ScriptableObject
{
    [SerializeField,Header("エンジン性能表")]public AnimationCurve EnginePerformanceCurve = new AnimationCurve(
        new Keyframe(0f, 0f),
        new Keyframe(1000f, 100f),
        new Keyframe(2000f, 200f),
        new Keyframe(3000f, 300f),
        new Keyframe(4000f, 400f)
    );
    [SerializeField, Header("エンジンのトルク（N·m）")] public float MotorForce = 1500f;
    [SerializeField,Header("ブレーキの力（N·m）")] public float BrakeForce = 3000f;
    [SerializeField,Header("最大ステア角（度）")] public float MaxSteerAngle = 30f;
}