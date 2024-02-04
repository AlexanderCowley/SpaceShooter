using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

public class RangedWeapon : MonoBehaviour
{
    //Shot type: Determines input
    //Find out if it is possible to have an async timer that delays execution
    [SerializeField] WeaponData _data;
    [SerializeField] Transform _projectileSpawnPoint;

    string inputName = "Fire";

    PlayerInput _playerActions;
    InputAction _currentAction;

    bool _canFire = true;
    void Awake() => _playerActions = GetComponentInParent<PlayerInput>();

    void OnEnable() => InitPlayerInput();

    void OnDisable()
    {
        _currentAction.started -= Fire;
    }

    public void InitPlayerInput()
    {
        _currentAction = _playerActions.actions[inputName];
        //depends on the type of shot
        _currentAction.started += Fire;
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!_canFire)
            return;
        _canFire = false;

        WeaponProjectile projectile = (WeaponProjectile)Instantiate(_data.WeaponProjectile,
            _projectileSpawnPoint.position, Quaternion.identity);
        projectile.Init(_data, this.transform);

        StartCoroutine(FireRateDelay());
    }

    IEnumerator FireRateDelay()
    {
        yield return new WaitForSeconds(_data.FireRate);
        _canFire = true;
    }
}