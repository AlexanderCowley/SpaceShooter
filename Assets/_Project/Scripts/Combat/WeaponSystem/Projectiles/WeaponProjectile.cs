using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class WeaponProjectile : MonoBehaviour
{
    int _damage;
    float _speed;
    IDamagable _damagable;
    Vector3 _direction;

    Collider _holder;

    CancellationTokenSource _tokenSource = new CancellationTokenSource();

    public async void Init(WeaponData weaponData, Transform direction)
    {
        _damage = weaponData.BaseDamage;
        _speed = weaponData.ProjectileTravelSpeed;
        _direction = direction.up;

        IgnoreCharacterCollisions();

        var countDownTask = CountDown(2500);

        try
        {
            await countDownTask;
        }
        catch
        {
            countDownTask = null;
        }

        void IgnoreCharacterCollisions()
        {
            if(direction.TryGetComponent<Collider>(out _holder))
                Physics.IgnoreCollision(_holder, GetComponent<Collider>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        _tokenSource.Cancel();
        _damagable = other.GetComponent<IDamagable>();
        _damagable?.TakeDamage(_damage);
        
        Destroy(gameObject, 0.10f);
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