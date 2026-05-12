using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private int Damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(Damage);

            Debug.Log("получен урон");
        }
    }
}
