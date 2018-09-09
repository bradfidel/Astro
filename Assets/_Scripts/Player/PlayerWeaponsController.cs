using UnityEngine;

public class PlayerWeaponsController : MonoBehaviour
{
    private const string fire1ButtonName = "Fire1";
    private const string fire2ButtonName = "Fire2";

    [SerializeField]
    private Transform[] weaponSlots;
    private IWeapon[] weapons;

    private void Awake()
    {
        weapons = new IWeapon[weaponSlots.Length];
    }

    private void Update()
    {
        if (Input.GetButton(fire1ButtonName) && weapons[0] != null && weapons[0].CanShoot())
        {
            weapons[0].Shoot();
        }
        if (Input.GetButton(fire2ButtonName) && weapons[1] != null && weapons[1].CanShoot())
        {
            weapons[1].Shoot();
        }
    }

    public void SetWeapon(Transform weapon, int slot)
    {
        if (slot >= weapons.Length || slot < 0)
        {
            Debug.LogError("Weapon slot index out of range!");
            return;
        }
        weapon.SetParent(weaponSlots[slot]);
        weapon.localPosition = Vector3.zero;
        weapons[slot] = weapon.GetComponent<IWeapon>();
    }
}
