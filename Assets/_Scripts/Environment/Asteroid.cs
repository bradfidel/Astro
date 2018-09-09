using UnityEngine;

public class Asteroid : MonoBehaviour, IDestructible
{
    [SerializeField]
    private new Rigidbody rigidbody = null;

    [SerializeField]
    private float baseMaxHealth;

    [SerializeField]
    private float baseRigidbodyMass;

    [SerializeField]
    private GameObject explosionPrefab = null;

    private bool indestructible = false;
    private float currentHealth;

    public void Initialize(float size, float angularVelocityRange, bool indestructible = false)
    {
        currentHealth = size * baseMaxHealth;
        rigidbody.mass = size * baseRigidbodyMass;
        rigidbody.angularVelocity = new Vector3(Random.Range(-angularVelocityRange, angularVelocityRange), Random.Range(-angularVelocityRange, angularVelocityRange), Random.Range(-angularVelocityRange, angularVelocityRange));
        transform.localScale = Vector3.one * size;
        if (indestructible)
        {
            this.indestructible = true;
        }
    }

    public void ReceiveDamage(float amount)
    {
        if (indestructible)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
