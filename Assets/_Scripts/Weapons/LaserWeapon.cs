using UnityEngine;

public class LaserWeapon : MonoBehaviour, IWeapon
{
    // how many projectiles can be shot per second
    [SerializeField]
    private float fireRate;

    [SerializeField]
    private GameObject laserProjectilePrefab = null;

    // when next projctile can be shot (Time.time)
    private float weaponCooldown;
    
    public bool CanShoot()
    {
        return weaponCooldown < Time.time;
    }

    public void Shoot()
    {
        weaponCooldown = Time.time + 1f / fireRate;
        Instantiate(laserProjectilePrefab, transform.position + transform.forward, transform.rotation);
    }
}
