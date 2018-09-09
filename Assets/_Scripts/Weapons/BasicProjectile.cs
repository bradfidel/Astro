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
    [SerializeField]
    private float projectileRange;

    private Vector3 previousPosition;
    private bool dealtDamage = false;   // used to avoid situation where both linecast and trigger deal damage

    private int layerMask;

    private void Start()
    {
        rigidbody.velocity = transform.forward * speed;
        previousPosition = transform.position;
        layerMask = LayerMask.GetMask(new string[] { "Default" });

        float projectileLifeTime = projectileRange / speed;
        Destroy(gameObject, projectileLifeTime);
    }

    // TODO [optimization] write global manager to avoid unnecessary FixedUpdate calls in every object
    // TODO compare Linecast with SphereCast
    private void FixedUpdate()
    {
        if (dealtDamage)
        {
            return;
        }

        // Linecast to prevent missing trigger because of projectile high speed
        RaycastHit hit;
        if (Physics.Linecast(previousPosition, transform.position, out hit, layerMask) && hit.rigidbody != null)
        {
            IDestructible destructible = hit.rigidbody.GetComponent<IDestructible>();
            if (destructible != null)
            {
                DealDamage(destructible);
            }
        }

        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (dealtDamage)
        {
            return;
        }

        IDestructible destructible = other.GetComponent<IDestructible>();
        if (destructible != null)
        {
            DealDamage(destructible);
        }
    }

    private void DealDamage(IDestructible destructible)
    {
        destructible.ReceiveDamage(damage);
        Destroy(gameObject);
        dealtDamage = true;
    }
}
