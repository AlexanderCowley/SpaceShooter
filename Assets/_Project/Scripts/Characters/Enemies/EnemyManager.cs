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
    //Turn into 2 dimensional array
    [SerializeField] List<ShieldBT> ActiveEnemies = new();

    void InitEnemies()
    {
        //Set player Refs
    }

    void SpawnEnemies()
    {
        ShieldBT enemyInstance;
        for(int i = 0; i < ActiveEnemies.Count; i++)
        {
            enemyInstance = Instantiate(ActiveEnemies[i], 
                new Vector3(i * _posOffset,2.5f,2.15f), Quaternion.identity)
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
