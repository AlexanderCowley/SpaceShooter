using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{
    //Singleton
    static EnemyManager _instance;
    public static EnemyManager Instance 
    {
        get {return _instance;} 
        private set {_instance=value;}
    }

    [SerializeField] Transform _playerTransform;
    [SerializeField] float _posOffset;

    //list of active enemies
    [SerializeField] List<ShieldBT> ActiveEnemies = new();
    float col;

    void InitEnemies()
    {
        //Set player Refs
    }

    void SpawnEnemies()
    {
        ShieldBT enemyInstance;
        col = 2.5f;
        for(int i = 0; i < ActiveEnemies.Count; i++)
        {
            //Replace with functions that just add and remove enemies at will
            if(i % 4 == 0)
            {
                col += i/col * 0.8f;
            }
            enemyInstance = Instantiate(ActiveEnemies[i], 
                new Vector3(i * _posOffset, 2.5f, col), Quaternion.identity)
                .GetComponent<ShieldBT>();
            enemyInstance.SetPlayer(_playerTransform);
        }
    }

    void Awake() 
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            SpawnEnemies();
        }
    }
}
