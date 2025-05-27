using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimation
{
    Animator _animator;
    public IKAnimation(Animator animator)
    {
        _animator = animator;
    }
    /// <summary>
    /// このメソッドを呼び出すと、IKの更新が行われます。
    /// </summary>
    /// <param name="iKTarget">IKのターゲットが格納されたクラス</param>
    public void IKUpdate(IKTarget iKTarget)
    {
        if (iKTarget._leftHand != null)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, iKTarget._leftHand.InverseTransformPoint(iKTarget._leftHand.position));
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, iKTarget._leftHand.rotation);
        }
        if (iKTarget._rightHand != null)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, iKTarget._rightHand.InverseTransformPoint(iKTarget._rightHand.position));
            _animator.SetIKRotation(AvatarIKGoal.RightHand, iKTarget._rightHand.rotation);
        }
        
    }
}
public class IKTarget
{
    public IKTarget(Transform rightHand, Transform leftHand, Transform rightFoot, Transform leftFoot)
    {
        _rightHand = rightHand;
        _leftHand = leftHand;
        _rightFoot = rightFoot;
        _leftFoot = leftFoot;
    }
    public Transform _leftHand;
    public Transform _rightHand;
    public Transform _leftFoot;
    public Transform _rightFoot;
}
