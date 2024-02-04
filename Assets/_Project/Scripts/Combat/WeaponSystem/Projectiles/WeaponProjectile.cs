using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class WeaponProjectile : MonoBehaviour
{
    int _damage;
    float _speed;
    IDamagable _damagable;
    Vector3 _direction;

    CharacterController _holder;

    CancellationTokenSource _tokenSource = new CancellationTokenSource();

    public async void Init(WeaponData weaponData, Transform direction)
    {
        this._damage = weaponData.BaseDamage;
        this._speed = weaponData.ProjectileTravelSpeed;
        this._direction = direction.up;

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
            _holder = direction.GetComponentInParent<CharacterController>();
            Physics.IgnoreCollision(_holder, this.GetComponent<Collider>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        _tokenSource.Cancel();
        _damagable = other.GetComponent<IDamagable>();
        _damagable?.TakeDamage(_damage);
        
        Destroy(this.gameObject, 0.10f);
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

        Destroy(this.gameObject, 0.15f);
    }

    void Update() => transform.position += _direction * _speed * Time.deltaTime;
}