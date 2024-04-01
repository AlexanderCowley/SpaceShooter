using BehaviorTree;
using UnityEngine;

//Base class for enemy behavior trees
public class EnBT : BehaviorTree.Tree
{
    protected Transform _playerTransform;
    protected override Node SetUpTree()
    {
        throw new System.NotImplementedException();
    }
    public void SetPlayer(Transform playerTrans) => _playerTransform = playerTrans;
    public virtual void AssignEnemy(EnBT enemy, bool isRight){}
}
