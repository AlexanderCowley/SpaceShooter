using UnityEngine;
using BehaviorTree;

public class FollowPlayerNode : Node
{
    Transform _transform;
    float EnemySpeed;
    float _rangeOffset = 3.4f;
    float _prevX;
    EnBT _blockingEnemyRight;
    EnBT _blockingEnemyLeft;
    bool isStopped = false;
    public FollowPlayerNode(Transform objectTransform, float range)
    {
        this._transform = objectTransform;
        this.EnemySpeed = range;
    }

    public override NodeStatus Evaluate()
    {
        //Get target unless ref already exists
        Transform target = (Transform)Parent.GetData("target");

        //Assign target to follow player
        Vector3 newTarget = new(target.position.x, 
            _transform.position.y, _transform.position.z);
        
        //While they are moving check the dist. between the other enemies
        if(_blockingEnemyRight != null)
        {
          if(_blockingEnemyRight.transform.position.x <
              target.position.x)
            {
              if(
              Vector3.Distance(_transform.position, 
                _blockingEnemyRight.transform.position) <= _rangeOffset)
              {
                isStopped = true;
              }
              else isStopped = false;
            }
          else isStopped = false;
        }

        if(_blockingEnemyLeft != null)
        {
        if(_blockingEnemyLeft.transform.position.x > 
              target.position.x)
            {
              if(
              Vector3.Distance(_transform.position, 
                _blockingEnemyLeft.transform.position) <= _rangeOffset)
              {
                isStopped = true;
              }
              else isStopped = false;
            }
            else isStopped = false;
        }

        
        if(isStopped)
        {
          EnemySpeed = 0f;
          if(_blockingEnemyRight != null)
          {
            if(
              _blockingEnemyRight.transform.position.x >
              target.position.x)
              {
                if(
                  Vector3.Distance(_transform.position, 
                _blockingEnemyRight.transform.position) <= _rangeOffset)
                {
                  isStopped = true;
                }
                else isStopped = false;
              }
          }
            
          if(_blockingEnemyLeft != null)
          {
            if(_blockingEnemyLeft.transform.position.x >
                target.position.x)
            {
              if(
                  Vector3.Distance(_transform.position, 
                _blockingEnemyLeft.transform.position) <= _rangeOffset)
              {
                isStopped = true;
              }
              else isStopped = false;
            }
          }
          return NodeStatus.RUNNING;
        }
        
        _transform.position = Vector3.MoveTowards(_transform.position, 
          newTarget, Time.deltaTime * EnemySpeed);

        //Reset Speed
        EnemySpeed = 2f;

        _nodeStatus = NodeStatus.RUNNING;
        return _nodeStatus;
    }

    public void MoveEnemy() => isStopped = false;
    public void AssignBlockEnemy(EnBT enemy, bool isRight)
    {
        if(isRight) _blockingEnemyRight = enemy;
        else _blockingEnemyLeft = enemy;
    }
    
}