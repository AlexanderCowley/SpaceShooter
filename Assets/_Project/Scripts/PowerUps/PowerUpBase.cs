using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    public abstract void OnApply();
    public abstract void OnExpire();
}