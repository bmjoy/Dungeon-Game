using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    [SerializeField] GameObject _attack;
    [SerializeField] GameObject _attackOrigin;
    [SerializeField] AudioSource _magicSound;

    int _attackSpeed = 2000;

    Transform _enemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _enemy = other.gameObject.transform;
            GetComponentInParent<Animator>().SetTrigger("Cast");
            _magicSound.Play();

            Invoke("Fire", 0.5f);
            Invoke("Fire", 0.6f);
            Invoke("Fire", 0.7f);
        }
    }

    void Fire()
    {       
        GameObject attackObject = Instantiate(_attack, _attackOrigin.transform.position, _attackOrigin.transform.rotation);
        gameObject.GetComponentInParent<Transform>().LookAt(_enemy);
        Vector3 direction = _enemy.transform.position - _attackOrigin.transform.position;
        attackObject.GetComponent<Rigidbody>().AddForce(direction.normalized * _attackSpeed);
    }
}
