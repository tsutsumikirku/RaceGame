using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class CarContainer : MonoBehaviour
{
    CarBase _carBase;
    public Text GearText;
    public Text RPMText;
    [SerializeField] GameObject _handle;
    [SerializeField] WheelCollider _frontLeftWheel;
    [SerializeField] WheelCollider _frontRightWheel;
    [SerializeField] WheelCollider _rearLeftWheel;
    [SerializeField] WheelCollider _rearRightWheel;
    [SerializeField, Tooltip("カーデータをアタッチしてください")] CarData _carData;
    void Awake()
    {
        _carBase = new CarBase(_handle, _carData,
            (_frontLeftWheel, _frontRightWheel, _rearLeftWheel, _rearRightWheel
        ));
    }
    void Update()
    {
        _carBase.ManualUpdate();
        UpdateUI();
    }
    void UpdateUI()
    {
        if (GearText != null)
        {
            GearText.text = "ギア: " + _carBase.CurrentGear;
        }
        if (RPMText != null)
        {
            RPMText.text = "RPM: " + _carBase.RPM.ToString("F1");
        }
    }
}
