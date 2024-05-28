using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BullBT : EnBT
{
    [SerializeField] float Speed;
    public delegate void OnBullCharge(EnBT instance);
    public OnBullCharge BullChargeHandler;
    protected override Node SetUpTree()
    {
        Node root = new SequenceNode(new List<Node>()
        {
            new SearchNode(transform),
            new RamNode(transform, Speed, this)
        });
        return root;
    }
}
