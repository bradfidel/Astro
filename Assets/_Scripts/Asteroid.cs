using UnityEngine;

public class Asteroid : MonoBehaviour, IDestructible
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;

    [SerializeField]
    private GameObject explosionPrefab = null;

    [SerializeField]
    private float initialRotationRange;

    private void Awake()
    {
        currentHealth = maxHealth;
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-initialRotationRange, initialRotationRange), Random.Range(-initialRotationRange, initialRotationRange), Random.Range(-initialRotationRange, initialRotationRange));
    }

    public void DealDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
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
