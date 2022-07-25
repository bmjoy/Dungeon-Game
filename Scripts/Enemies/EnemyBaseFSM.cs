using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseFSM : StateMachineBehaviour
{
    public GameObject _enemy;
    public GameObject _player;
    public float _speed = 2f;
    public float _rotationSpeed = 1f;
    public float _accuracy = 2f;
    public GameObject[] _waypoints;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemy = animator.gameObject;
        _player = _enemy.GetComponent<EnemyAI>().GetPlayer();

        _waypoints = _enemy.GetComponent<EnemyAI>()._waypoints;
    }
}
