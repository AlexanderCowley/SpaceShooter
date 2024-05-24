using System.Collections;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;

public class BullBT : EnBT
{
    protected override Node SetUpTree()
    {
        Node root = new SequenceNode(new List<Node>()
        {
            //new AttackNode(transform)
        });
        return root;
    }
}
