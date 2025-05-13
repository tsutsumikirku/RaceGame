using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class CarContainer : MonoBehaviour
{
    CarBase _carBase;
    [SerializeField, Tooltip("カーデータをアタッチしてください")] CarData _carData;
    void Awake()
    {
        _carBase = new CarBase(_carData);
    }
    private void FixedUpdate()
    {
        _carBase.ManualUpdate();
    }
}
