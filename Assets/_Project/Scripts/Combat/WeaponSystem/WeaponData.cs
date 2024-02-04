using UnityEngine;
[CreateAssetMenu(menuName = "Weapons/New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Data")]
    [SerializeField] int baseDamage;
    [SerializeField] float fireRate;
    [SerializeField] float travelSpeedInSeconds;

    [Header("Projectile Object")]
    //inject damage and travel speed before hand prevent race condition
    [SerializeField] WeaponProjectile projectile;
    public int BaseDamage => baseDamage;
    public float FireRate => fireRate;
    public float ProjectileTravelSpeed => travelSpeedInSeconds;

    public WeaponProjectile WeaponProjectile => projectile;
}