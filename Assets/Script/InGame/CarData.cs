using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarData", order = 1)]
public class CarData : ScriptableObject
{
    [SerializeField,Header("エンジン性能表 () ")]public AnimationCurve EnginePerformanceCurve = new AnimationCurve(
        
    );
    [SerializeField,Header("ギア比表")]public float[] GearRatios = new float[]
    {
        3.5f, // ギア1
        2.0f, // ギア2
        1.5f, // ギア3
        1.0f, // ギア4
        0.8f, // ギア5
        0.7f  // ギア6
    };
    [SerializeField, Header("ファイナルギア比")]public float FinalDriveRatio = 3.9f;
    [SerializeField, Header("ギア比効率")]public float GearEfficiency = 0.95f; 
    [SerializeField, Header("ブレーキの力（N·m）")] public float BrakeForce = 3000f;
    [SerializeField,Header("最大ステア角（度）")] public float MaxSteerAngle = 30f;
}