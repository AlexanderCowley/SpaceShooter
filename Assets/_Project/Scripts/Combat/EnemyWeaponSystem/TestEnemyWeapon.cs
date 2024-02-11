using UnityEngine;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

public class TestEnemyWeapon : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;
    [SerializeField] Transform _projectileSpawnPoint;
    CancellationTokenSource _cancellationToken = new CancellationTokenSource();

    bool _canFire  = true;

    public void Fire()
    {
        if (!_canFire) 
            return;

        _canFire = false;
        //Run fire logic from weapons here
        WeaponProjectile projectile = (WeaponProjectile)Instantiate(weaponData.WeaponProjectile,
            _projectileSpawnPoint.position, Quaternion.identity);
        projectile.Init(weaponData, this.transform);
        StartCoroutine(FireRateDelay());
    }

    IEnumerator FireRateDelay()
    {
        yield return new WaitForSeconds(weaponData.FireRate);
        _canFire = true;
    }

    /*public async void Fire()
    {
        WeaponProjectile projectile = (WeaponProjectile)Instantiate(weaponData.WeaponProjectile,
            _projectileSpawnPoint.position, Quaternion.identity);
        projectile.Init(weaponData, this.transform);

        if (_cancellationToken.IsCancellationRequested)
            return;

        await Task.Delay(weaponData.FireRate, _cancellationToken.Token);
    }*/
}