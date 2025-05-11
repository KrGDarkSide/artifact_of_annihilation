using NUnit.Framework;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // ====================
    //      VARIABLES
    // ====================
    public string weaponName;
    public float fireRate;
    public float damage;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public float aimSpeed;
    public bool isAvayable = false;

    protected float nextShoot;
    protected bool isReloading = false;

    public Transform hipPossition;
    public Transform adsPossition;
    


    // ====================
    //       METHODS
    // ====================
    public abstract void Shoot();

    protected bool CanShoot()
    {
        return Time.time >= nextShoot && !isReloading && currentAmmo > 0;
    }

    protected void SetNextShoot()
    {
        nextShoot = Time.time + fireRate;
    }

    public void Reload()
    {
        // ...
    }
}
