using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] Health _health;
    [SerializeField] ParticleSystem _damageFX;
    [SerializeField] ParticleSystem _collectCoinsFX;
    [SerializeField] GameEvent _onTookDamage;
    [SerializeField] GameEvent _onDied;
    [SerializeField] GameObject _arrow;

    public ItemCollection ItemCollection;

    int _initialHealth; 
    HealthBar _healthBar;
    int _maxHealth = 10;

    Animator _anim;

    public Health Health => _health;

    void Start()
    {
        _healthBar = gameObject.GetComponentInChildren<HealthBar>();
        _health.HealthPoints = _maxHealth;
        _initialHealth = _maxHealth;
        _anim = GetComponent<Animator>();
    }

    void Update() => _text.SetText(_health.HealthPoints.ToString());

    void TakeDamage(int damageAmount)
    {
        //_anim.SetTrigger("TakeDamage");
        _damageFX.Play();
        _onTookDamage?.Invoke();
        _health.HealthPoints -= damageAmount;

        float currentHealthPct = (float)_health.HealthPoints / (float)_initialHealth;
        _healthBar.HandleHealthChanged(currentHealthPct);

        if (_health.HealthPoints <= 0)
            Die();
    }

    void Die()
    {
        _onDied?.Invoke();
        _anim.SetTrigger("Die");      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            TakeDamage(other.gameObject.GetComponent<Weapon>().WeaponType.Damage);
            Destroy(other.gameObject, 0.1f);
        }       
        else if (other.gameObject.tag == "Coin")
        {
           // _collectCoinsFX.Play();
        }
    }
}
