using BehaviorTree;
using UnityEngine;

//Base class for enemy behavior trees
public class EnBT : BehaviorTree.Tree
{
    [field: SerializeField] public ScoreObject EnemyScore { get; private set;}
    protected Transform _playerTransform;
    protected override Node SetUpTree()
    {
        throw new System.NotImplementedException();
    }
    public void SetPlayer(Transform playerTrans) => _playerTransform = playerTrans;
    public virtual void AssignEnemy(EnBT enemy, bool isRight){}
}
