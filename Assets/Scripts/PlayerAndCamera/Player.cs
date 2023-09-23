using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamagable
{
    private int _currentHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Button _fire;

    public Button GetFire() { return _fire; }

    private void Start() => _currentHealth = _maxHealth;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }
}
