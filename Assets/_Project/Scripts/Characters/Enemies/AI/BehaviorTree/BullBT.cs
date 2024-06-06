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
    protected override Node SetUpTree()
    {
        _hitbox = GetComponent<Hitbox>();
        Node root = new SequenceNode(new List<Node>()
        {
            new SearchNode(transform),
            new RamNode(transform, Speed, _hitbox)
        });
        return root;
    }
}
