using UnityEngine;
using System.Collections;
using System.Threading;

public class BasicEnemyWeapon : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected Transform _projectileSpawnPoint;
    CancellationTokenSource _cancellationToken = new CancellationTokenSource();

    protected bool _canFire  = true;

    public virtual void Fire()
    {
        if (!_canFire) 
            return;

        _canFire = false;
        //Run fire logic from weapons here
        WeaponProjectile projectile = (WeaponProjectile)Instantiate(weaponData.WeaponProjectile,
            _projectileSpawnPoint.position, Quaternion.Euler(0f, 180f, 0f));
        projectile.Init(weaponData, transform, CharacterType.Enemy);
        StartCoroutine(FireRateDelay());
    }

    protected IEnumerator FireRateDelay()
    {
        yield return new WaitForSeconds(weaponData.FireRate);
        _canFire = true;
    }

}