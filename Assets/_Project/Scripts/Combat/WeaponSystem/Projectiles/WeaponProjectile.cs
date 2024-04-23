using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class WeaponProjectile : MonoBehaviour
{
    int _damage;
    float _speed;
    Vector3 _direction;
    CancellationTokenSource _tokenSource = new CancellationTokenSource();
    CharacterType _charType = CharacterType.None;

    public async void Init(WeaponData weaponData, 
        Transform direction, CharacterType charType)
    {
        _damage = weaponData.BaseDamage;
        _speed = weaponData.ProjectileTravelSpeed;
        _direction = direction.up;
        _charType = charType;

        var countDownTask = CountDown(2500);

        try
        {
            await countDownTask;
        }
        catch
        {
            countDownTask = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<CombatHealth>(out CombatHealth health))
        {
            //Prevents enemies from damaging each other
            if(_charType == health.CharType)
                return;
            
            _tokenSource.Cancel();
            health.TakeDamage(_damage);
            Destroy(gameObject, 0.10f);
        }
    }

    void OnDisable()
    {
        _tokenSource.Cancel();
        _tokenSource.Dispose();
    }

    async Task CountDown(int delay)
    {
        await Task.Delay(delay, _tokenSource.Token);

        if (_tokenSource.IsCancellationRequested)
            return;

        Destroy(gameObject, 0.15f);
    }

    void Update() => transform.position += _direction * _speed * Time.deltaTime;
}