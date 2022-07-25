using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameEvent _onTookDamage;
    [SerializeField] GameEvent _onDied;
    [SerializeField] ParticleSystem _damageFX;
    [SerializeField] EnemyType _enemyType;
    [SerializeField] GameObject _bodyPrefab;
    [SerializeField] AudioSource _dieSound;

    public int _health;

    bool _isDead = false;
    Animator _anim;
    CoinSpawn _coinSpawn;

    public EnemyType EnemyType => _enemyType;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _coinSpawn = GetComponentInChildren<CoinSpawn>();
    }

    void OnEnable() => _health = EnemyType.Health;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttack")
            TakeDamage(other.gameObject.GetComponent<Weapon>().WeaponType.Damage);
    }

    void TakeDamage(int damageAmount)
    {
        if (!_isDead)
        {
            _damageFX.Play();
            _onTookDamage?.Invoke();
            _health -= damageAmount;

            if (_health <= 0)
                Die();
        }     
    }

    void Die()
    {
        _dieSound.Play();
        gameObject.tag = "Untagged";
        _onDied?.Invoke();
        _isDead = true;     
        _anim.SetTrigger("Die");
        _coinSpawn.Spawn();
        Invoke("SetInactive", 2);
    }

    void SetInactive()
    {
        Instantiate(_bodyPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}







