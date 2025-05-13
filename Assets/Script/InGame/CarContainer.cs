using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class CarContainer : MonoBehaviour
{
    CarBase _carBase;
    IKAnimation _iKAnimation;
    [SerializeField, Tooltip("カーデータをアタッチしてください")] CarData _carData;
    [SerializeField, Tooltip("キャラクターにアタッチされているAnimatorをアタッチしてください")] Animator _characterAnimator;
    [SerializeField, Tooltip("キャラクターの右手のターゲットをアタッチしてください")] Transform _rightHand;
    [SerializeField, Tooltip("キャラクターの左手のターゲットをアタッチしてください")] Transform _leftHand;
    [SerializeField, Tooltip("キャラクターの右足のターゲットをアタッチしてください")] Transform _rightFoot;
    [SerializeField, Tooltip("キャラクターの左足のターゲットをアタッチしてください")] Transform _leftFoot;
    void Awake()
    {
        _carBase = new CarBase(_carData);
    }
    private void FixedUpdate()
    {
        _carBase.ManualUpdate();
    }
}
