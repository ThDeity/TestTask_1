using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] protected float _timeBetweenAttack, _speed, _attackDistance, _timeOfAttack;
    [SerializeField] private int _maxHealth, _damage;
    protected int _currentHealth, _currentDamage;
    protected float _currentTime, _currentSpeed;
    protected Transform _player, _transform;

    protected virtual void Start()
    {
        _transform = transform;
        _currentTime = _timeBetweenAttack;
        _currentHealth = _maxHealth;
        _currentDamage = _damage;
        _currentSpeed = _speed;
        _player = FindObjectOfType<PlayerMovement>().transform;
        Chase();
    }

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    protected abstract IEnumerator Attack();

    protected virtual void Chase()
    {
        if (Vector2.Distance(_transform.position, _player.position) > _attackDistance)
            _transform.position = Vector2.MoveTowards(_transform.position, _player.position, _speed * Time.deltaTime);
    }
}