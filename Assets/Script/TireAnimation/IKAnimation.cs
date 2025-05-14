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
    public void IKUpdate(IKTarget iKTarget)
    {
        if (iKTarget._leftHand != null)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, iKTarget._leftHand.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, iKTarget._leftHand.rotation);
        }
        if (iKTarget._rightHand != null)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.RightHand, iKTarget._rightHand.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, iKTarget._rightHand.rotation);
        }
    }
}
public struct IKTarget
{
    public Transform _leftHand;
    public Transform _rightHand;
    public Transform _leftFoot;
    public Transform _rightFoot;
}
