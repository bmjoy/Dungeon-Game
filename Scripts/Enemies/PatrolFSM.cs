using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFSM : EnemyBaseFSM
{
    int _currentWP;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        _currentWP = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_waypoints.Length == 0) return;

        if (Vector3.Distance(_waypoints[_currentWP].transform.position, _enemy.transform.position) < _accuracy)
        {
            _currentWP++;

            if (_currentWP >= _waypoints.Length)
            {
                _currentWP = 0;
            }
        }

        var direction = _waypoints[_currentWP].transform.position - _enemy.transform.position;
        _enemy.transform.rotation = Quaternion.Slerp(_enemy.transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed * Time.deltaTime);

        _enemy.transform.Translate(0, 0, Time.deltaTime * _speed);
        
    }
}
