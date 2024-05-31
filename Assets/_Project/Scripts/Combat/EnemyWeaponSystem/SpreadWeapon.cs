using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadWeapon : BasicEnemyWeapon
{
    public override void Fire()
    {
        if (!_canFire) 
            return;

        _canFire = false;
        //Run fire logic from weapons here
        for(int i = 0; i < 3; i++)
        {
            WeaponProjectile projectile = (WeaponProjectile)Instantiate(weaponData.WeaponProjectile,
                _projectileSpawnPoint.position, Quaternion.identity);
            projectile.Init(weaponData, transform, CharacterType.Enemy);
        }
        StartCoroutine(FireRateDelay());
    }
}
