using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class SubWeapon : MonoBehaviour
{
    [Header("Weapon Data")]
    [SerializeField] WeaponData _data;
    [SerializeField] Transform _projectileSpawnPoint;

    [Header("Heat")]
    [SerializeField] CombatStat heatStat;
    [SerializeField] int HeatCost;
    IHeatable _heatCost;

    string inputName = "Special";

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
        _currentAction.started += Fire;

        _heatCost = GetComponent<IHeatable>();
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!_canFire || heatStat.StatValue < HeatCost)
            return;

        _canFire = false;

        WeaponProjectile projectile = (WeaponProjectile)Instantiate(_data.WeaponProjectile,
            _projectileSpawnPoint.position, Quaternion.identity);
        projectile.Init(_data, transform, CharacterType.Player);

        _heatCost?.OnHeatUse(HeatCost);

        StartCoroutine(FireRateDelay());
    }

    IEnumerator FireRateDelay()
    {
        yield return new WaitForSeconds(_data.FireRate);
        _canFire = true;
    }
}