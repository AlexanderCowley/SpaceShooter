using UnityEngine;
using BehaviorTree;

public class FollowPlayerNode : Node
{
    Transform _transform;
    float EnemySpeed;
    float _rangeOffset = 1.0f;
    EnBT _blockingEnemyRight;
    EnBT _blockingEnemyLeft;

    bool isStopped = false;
    public FollowPlayerNode(Transform objectTransform, float enemySpeed)
    {
        _transform = objectTransform;
        EnemySpeed = enemySpeed;
    }

    public override NodeStatus Evaluate()
    {
        //Get target unless ref already exists
        Transform target = (Transform)Parent.GetData("target");

        //Assign target to follow player
        Vector3 newTarget = new(target.position.x, 
            _transform.position.y, _transform.position.z);

        //Keeps distance between the enemies the same for enemies on dif rows
        Vector3 DistFromEnemy = new Vector3(_transform.position.x, 2.5f, 2.5f);
        Vector3 DistTo;
        //While they are moving check the dist. between the other enemies
        if(_blockingEnemyRight != null)
        {
          if(_blockingEnemyRight.transform.position.x - _rangeOffset <
              target.position.x)
            {
              DistTo = new Vector3(
                _blockingEnemyRight.transform.position.x, 2.5f, 2.5f);
              if(
              Vector3.Distance(DistFromEnemy,
                DistTo) <= _rangeOffset)
              {
                StopEnemy();
              }
              else isStopped = false;
            }
          else isStopped = false;
        }

        if(_blockingEnemyLeft != null)
        {
        if(_blockingEnemyLeft.transform.position.x  + _rangeOffset > 
              target.position.x)
            {
              DistTo = new Vector3(
                _blockingEnemyLeft.transform.position.x, 2.5f, 2.5f);
              if(
              Vector3.Distance(DistFromEnemy, 
                DistTo) <= _rangeOffset)
              {
                StopEnemy();
              }
              else isStopped = false;
            }
            else isStopped = false;
        }

        
        if(isStopped)
        {
          if(_blockingEnemyRight != null)
          {
            if(
              _blockingEnemyRight.transform.position.x  - _rangeOffset >
              target.position.x)
              {
                if(
                  Vector3.Distance(DistFromEnemy, 
                _blockingEnemyRight.transform.position) <= _rangeOffset)
                    {
                        StopEnemy();
                    }
                    else isStopped = false;
              }
          }
            
          if(_blockingEnemyLeft != null)
          {
            if(_blockingEnemyLeft.transform.position.x  + _rangeOffset >
                target.position.x)
            {
              if(
                  Vector3.Distance(DistFromEnemy, 
                _blockingEnemyLeft.transform.position) <= _rangeOffset)
              {
                StopEnemy();
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

    void StopEnemy()
    {
        EnemySpeed = 0f;
        isStopped = true;
    }

    public void AssignBlockEnemy(EnBT enemy, bool isRight)
    {
        if(isRight) _blockingEnemyRight = enemy;
        else _blockingEnemyLeft = enemy;
    }
    
}