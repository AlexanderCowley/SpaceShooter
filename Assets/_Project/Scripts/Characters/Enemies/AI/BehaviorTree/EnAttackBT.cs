using System.Collections.Generic;
using BehaviorTree;

public class EnAttackBT : EnBT
{
    protected override Node SetUpTree()
    {
        Node root = new SequenceNode(new List<Node>()
        {
            new AttackNode(transform)
        });
        return root;
    }
}
