using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseFSM : EnemyBaseFSM
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = _player.transform.position - _enemy.transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        _enemy.transform.rotation = Quaternion.RotateTowards(_enemy.transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);

        //_enemy.transform.rotation = Quaternion.Slerp(_enemy.transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed * Time.deltaTime);


        _enemy.transform.Translate(0, 0, Time.deltaTime * _speed);
    }
}
