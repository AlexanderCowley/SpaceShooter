using UnityEngine;
using System.Collections.Generic;
using BehaviorTree;
using UnityEngine.AI;
public class TestBehaviorTree : BehaviorTree.Tree
{
    [SerializeField] Transform _playerTransform;
    //Replace with Stat Holder Component
    [SerializeField] float Range;
    [SerializeField] TestBehaviorTree _testEnemy;
    Quaternion initialRotation;
    FollowPlayerNode _followPlayerNode;
    void Awake() 
    {
        initialRotation = transform.rotation;
    }
    protected override Node SetUpTree()
    {
        _followPlayerNode = new FollowPlayerNode(this.transform, Range);
        Node root = new SequenceNode(new List<Node>()
        {
            //new AttackNode(this.transform),
            new OutOfRange(this.transform, _playerTransform, Range),
            _followPlayerNode
        });
        return root;
    }

    public void StartEnemy() => _followPlayerNode.MoveEnemy();
    public void AssignEnemy(TestBehaviorTree enemy, bool isRight) =>
        _followPlayerNode.AssignBlockEnemy(enemy, isRight);
}