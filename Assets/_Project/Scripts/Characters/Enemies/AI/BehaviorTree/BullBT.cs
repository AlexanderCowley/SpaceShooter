using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BullBT : EnBT
{
    [SerializeField] float Speed;
    protected override Node SetUpTree()
    {
        Node root = new SequenceNode(new List<Node>()
        {
            new SearchNode(transform),
            new RamNode(transform, Speed)
        });
        return root;
    }
}
