using Random = System.Random;
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
    [SerializeField] List<EnBT> ActiveEnemies = new();
    float col;
    int _enemyCount = 0;
    //Enemy Prefabs
    [SerializeField] EnBT[] EnemyTypes = new EnBT[2];
    Random randInstance = new Random();

    void InitEnemies()
    {
        //Set player Refs
    }

    void SpawnEnemies()
    {
        EnBT enemyInstance;
        col = 2.5f;
        _enemyCount = ActiveEnemies.Count;
        for(int i = 0; i < ActiveEnemies.Count; i++)
        {
            //Replace with functions that just add and remove enemies at will
            if(i % 4 == 0)
            {
                col += i/col * 0.8f;
            }
            enemyInstance = Instantiate(ActiveEnemies[i], 
                new Vector3(i * _posOffset, 2.5f, col), Quaternion.identity)
                .GetComponent<EnBT>();
            //Enemy Refs set
            //Set player transform
            enemyInstance.SetPlayer(_playerTransform);
            //Set score and enemy count event for enemy death
            if(enemyInstance.TryGetComponent<CombatHealth>(out CombatHealth health))
            {
                health.DeathEventHandler += OnEnemyDeath;
            }

            if(enemyInstance.TryGetComponent<BullDeath>(out BullDeath deathObj))
            {
                deathObj.BullChargeHandler += OnEnemyDeath;
            }
            //Remove enemy from list
            ActiveEnemies.Remove(enemyInstance);
        }
    }

    void OnEnemyDeath(EnBT enemyInstance)
    {
        LevelScore.Instance.AddScore(enemyInstance.EnemyScore.Score);
        UpdateEnemyCount();

        void UpdateEnemyCount()
        {
            _enemyCount -= 1;
            if(_enemyCount <= 0) 
                NextWave();
        }
    }

    public void NextWave()
    {
        
        //Increments wave count
        EnemyWaves.NextWave();
        //Generate a new list of enemies
        for(int i = 0; i < 6; i++)
        {
            ActiveEnemies[i] = EnemyTypes[GenerateRandEnemyIndex()];
        }
        
        int GenerateRandEnemyIndex()
        {
            if(EnemyTypes.Length < 0)
            {
                return 0;
            }
            return randInstance.Next(0, EnemyTypes.Length);
        }
        SpawnEnemies();

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
