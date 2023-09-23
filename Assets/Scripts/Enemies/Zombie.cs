using UnityEngine;
using System.Collections;

public class Zombie : Enemy
{
    [SerializeField] private Animator _animator;
    private bool _isAttack = false;

    public bool SayIsAttack() { return _isAttack; }

    public int GetDamage() { return _currentDamage; }

    protected override IEnumerator Attack()
    {
        _animator.Play("Attack");
        _isAttack = true;
        yield return new WaitForSeconds(_timeOfAttack);
        _isAttack = false;
    }

    private void Update()
    {
        Chase();

        _currentTime -= Time.deltaTime;

        if (Vector2.Distance(_player.position, _transform.position) <= _attackDistance && _currentTime <= 0)
        {
            StartCoroutine(Attack());
            _currentTime = _timeBetweenAttack;
        }
    }

    private void OnDrawGizmos() => Gizmos.DrawWireSphere(transform.position, _attackDistance);
}
