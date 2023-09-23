using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class RangeAttack : MonoBehaviour
{
    protected float _time;
    protected Transform _transform;
    protected bool _isActive = false;
    [SerializeField] protected Transform _shotPoint;
    [SerializeField] protected GameObject _bullet;
    protected List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] protected float _reloadTime, _offset;

    protected virtual void Start()
    {
        _transform = transform;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) && !_enemies.Contains(enemy))
        {
            _enemies.Add(enemy);
            _isActive = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) && _enemies.Contains(enemy))
            _enemies.Remove(enemy);
    }

    protected virtual void FixedUpdate()
    {
        if (_enemies.Count == 0)
            _isActive = false;

        _time -= Time.deltaTime;

        if (_isActive)//вращает оружие в сторону противника
        {
            Vector3 difference = FindClosestEnemy().position - _transform.position;
            float roatZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.Euler(0f, 0f, roatZ + _offset);
        }
    }

    public virtual void Attack()
    {
        if(_time <= 0)
        {
            Shoot();
            _time = _reloadTime;
        }
    }

    protected void Shoot() => Instantiate(_bullet, _shotPoint.position, _transform.rotation);

    protected virtual Transform FindClosestEnemy()
    {
        float distance = float.MaxValue;
        Transform returningValue = null;

        for(int i = 0; i < _enemies.Count; i++)
        {
            if (Vector2.Distance(_enemies[i].transform.position, _transform.position) < distance)
                returningValue = _enemies[i].transform;
        }

        return returningValue;
    }
}
