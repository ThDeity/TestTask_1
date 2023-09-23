using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected float _speed, _distance, _lifeTime;
    [SerializeField] protected ParticleSystem _particle;
    [SerializeField] protected LayerMask enemy;
    [SerializeField] protected int _damage;

    private void Start() => Destroy(gameObject, _lifeTime);

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, enemy);

        if (hitInfo.collider != null && hitInfo.transform.tag != "Player")
        {
            hitInfo.transform.TryGetComponent(out IDamagable currentEnemy);

            if (currentEnemy != null)
                currentEnemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}
