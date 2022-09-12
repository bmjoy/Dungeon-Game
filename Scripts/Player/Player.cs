using UnityEngine;

public class Player : MonoBehaviour
{
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

    int _coinsBeforeLevelStart;
    [SerializeField] ItemType _coin;

    //int diamondsBeforeLevelStart;
    //[SerializeField] ItemType _diamond;

    public Health Health => _health;
    public int CoinsBeforeLevelStart => _coinsBeforeLevelStart;

    void Start()
    {
        _healthBar = gameObject.GetComponentInChildren<HealthBar>();
        _health.HealthPoints = _maxHealth;
        _initialHealth = _maxHealth;
        _anim = GetComponent<Animator>();

        _coinsBeforeLevelStart = ItemCollection.CountOf(_coin);
        //diamondsBeforeLevelStart = ItemCollection.CountOf(_diamond);
    }

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

        ItemCollection.Remove(ItemCollection.CountOf(_coin) - _coinsBeforeLevelStart, _coin);
        //ItemCollection.Remove(ItemCollection.CountOf(_diamond) - diamondsBeforeLevelStart, _diamond);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttack")
        {
            TakeDamage(other.gameObject.GetComponent<Attack>()._weaponAttachedTo.Damage);
            Destroy(other.gameObject, 0.1f);
        }       
        else if (other.gameObject.tag == "Coin")
        {
           // _collectCoinsFX.Play();
        }
    }
}
