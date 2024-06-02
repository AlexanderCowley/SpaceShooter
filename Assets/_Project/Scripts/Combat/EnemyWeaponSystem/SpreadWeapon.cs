using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadWeapon : BasicEnemyWeapon
{
    float _Offset = 0.3f;
    public override void Fire()
    {
        if (!_canFire) 
            return;

        _canFire = false;
        //Run fire logic from weapons here
        for(int i = 0; i < 3; i++)
        {
            WeaponProjectile projectile = (WeaponProjectile)Instantiate(weaponData.WeaponProjectile,
                new Vector3(_projectileSpawnPoint.position.x + ((i - 1) * _Offset),
                _projectileSpawnPoint.position.y,
                _projectileSpawnPoint.position.z),
                Quaternion.identity);
            projectile.Init(weaponData, transform, CharacterType.Enemy);
        }
        StartCoroutine(FireRateDelay());
    }
}
