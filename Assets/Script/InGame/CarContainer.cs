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
    }
    private void FixedUpdate()
    {
    }
}
