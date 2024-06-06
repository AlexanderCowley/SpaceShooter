using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadWeapon : BasicEnemyWeapon
{
    float _Offset = 0.15f;
    public override void Fire()
    {
        if (!_canFire) 
            return;

        _canFire = false;
        //Run fire logic from weapons here
        for(int i = 0; i < 3; i++)
        {
            //Changing index to angle the projectiles
            //i-1 (determines angle)
            //-45 and -180 is so that they don't cross each other when firing
            int index = ((i - 1) * -30) - 180;
            //Spawning the projectiles
            WeaponProjectile projectile = 
                (WeaponProjectile)Instantiate(weaponData.WeaponProjectile,
                new Vector3(_projectileSpawnPoint.position.x + ((i - 1) * _Offset),
                _projectileSpawnPoint.position.y,
                _projectileSpawnPoint.position.z),
                Quaternion.Euler(new Vector3(0f, index, 0f)));
            projectile.Init(weaponData, transform, CharacterType.Enemy);
        }
        StartCoroutine(FireRateDelay());
    }
}
