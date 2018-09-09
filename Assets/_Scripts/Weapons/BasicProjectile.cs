using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    // TODO pooling
    [SerializeField]
    private new Rigidbody rigidbody = null;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    private void Start()
    {
        rigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDestructible destructible = other.GetComponent<IDestructible>();
        if (destructible != null)
        {
            destructible.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
