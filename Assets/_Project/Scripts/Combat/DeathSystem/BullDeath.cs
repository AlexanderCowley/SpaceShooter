using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullDeath : MonoBehaviour
{
    public delegate void OnBullCharge(EnBT instance);
    public event OnBullCharge BullChargeHandler;
    BullBT _bullBT;
    float _timeUntilDeath = 0.9f;
    public bool TimerIsActive = false;

    void Awake() 
    {
        _bullBT = GetComponent<BullBT>();
        BullChargeHandler += KillCharacter;
    }

    void KillCharacter(EnBT instance)
    {
        Destroy(gameObject, 0.75f);
    }

    void OnDisable() 
    {
        BullChargeHandler -= KillCharacter;
    }

    void Update() 
    {
        if(TimerIsActive)
        {
            _timeUntilDeath -= Time.deltaTime;
            if(_timeUntilDeath <= 0.2f)
            {
                TimerIsActive = false;
                BullChargeHandler?.Invoke(_bullBT);
            }
        }
    }
}
