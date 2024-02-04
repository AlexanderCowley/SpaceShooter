using UnityEngine;
using System.Collections.Generic;

public class AddEffect : MonoBehaviour
{
    PowerUpBase PowerUp;

    PickUp _pickUp;

    void OnEnable()
    {
        _pickUp = GetComponent<PickUp>();
        PowerUp = GetComponent<PowerUpBase>();
        _pickUp.PickUpHandler += ApplyEffect;
    }

    void ApplyEffect(Collider collider)
    {
        collider.gameObject.AddComponent(PowerUp.GetType());
    }
}