using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFSM : EnemyBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _enemy.GetComponent<EnemyAI>().StartFiring();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy.transform.LookAt(_player.transform.position);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy.GetComponent<EnemyAI>().StopFiring();
    }
}
