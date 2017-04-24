using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationValue : StateMachineBehaviour
{
    public string valueName;
    public bool value;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool(valueName, value);
	}
}
