using UnityEngine;

public class TempPlayerWeaponsInitializer : MonoBehaviour
{
    public GameObject laserWeaponPrefab;

    private void Start()
    {
        Transform laser1 = Instantiate(laserWeaponPrefab).transform;
        Transform laser2 = Instantiate(laserWeaponPrefab).transform;
        PlayerWeaponsController pwc = GetComponent<PlayerWeaponsController>();
        pwc.SetWeapon(laser1, 0);
        pwc.SetWeapon(laser2, 1);
        Destroy(this);
    }
}
