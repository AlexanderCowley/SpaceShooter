using UnityEngine;
using System.Collections.Generic;
using BehaviorTree;
public class TestBehaviorTree : BehaviorTree.Tree
{
    [SerializeField] Transform _playerTransform;
    //Replace with Stat Holder Component
    [SerializeField] float Range;
    protected override Node SetUpTree()
    {
        Node root = new SequenceNode(new List<Node>()
        {
            new AttackNode(this.transform),
            new OutOfRange(this.transform, _playerTransform, Range),
            new FollowPlayerNode(this.transform, Range),
        });
        return root;
    }
}