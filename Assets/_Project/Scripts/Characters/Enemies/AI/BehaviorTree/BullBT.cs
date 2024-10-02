using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BullBT : EnBT
{
    [SerializeField] float Speed;
    public delegate void OnBullCharge(EnBT instance);
    public OnBullCharge BullChargeHandler;
    Hitbox _hitbox;
    Vector3 _halfBoxSize = new Vector3(0.4f, 0.5f, -5f);
    protected override Node SetUpTree()
    {
        _hitbox = GetComponent<Hitbox>();
        Node root = new SequenceNode(new List<Node>()
        {
            new SearchNode(transform, _halfBoxSize),
            new RamNode(transform, Speed, _hitbox)
        });
        return root;
    }

    #if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + 
            transform.forward * _halfBoxSize.z, _halfBoxSize*2);
    }
    #endif
}
