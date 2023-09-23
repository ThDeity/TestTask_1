using UnityEngine;

public class HandAttack : MonoBehaviour
{
    private Zombie _zombie;

    private void Start() => _zombie = transform.GetComponentInParent<Zombie>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(_zombie.SayIsAttack());

        if (collision.TryGetComponent(out IDamagable player) && _zombie.SayIsAttack() && collision.tag == "Player")
            player.TakeDamage(_zombie.GetDamage());
        else
            Debug.Log($"{collision.tag} {_zombie.SayIsAttack()}");
    }
}
