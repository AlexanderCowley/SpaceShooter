using UnityEngine;

public class GameOver : MonoBehaviour
{
    Canvas _gameOverCanvas;

    //Singleton
    static GameOver _instance;
    public static GameOver Instance 
    {
        get {return _instance;} 
        private set {_instance=value;}
    }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            //Prevents nre by destroying the gameobject itself without losing the ref
            Destroy(Instance.gameObject);
        }
        else
        {
            Instance = this;
            //Perserve Canvas parent object
            DontDestroyOnLoad(gameObject);
        }
        _gameOverCanvas = transform.GetChild(4).GetComponent<Canvas>();
        _gameOverCanvas.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        CombatHealth.PlayerDeathHandler += GameOverHandler;
    }

    void OnDisable() 
    {
        CombatHealth.PlayerDeathHandler -= GameOverHandler;
    }

    void GameOverHandler()
    {
        _gameOverCanvas.gameObject.SetActive(true);
    }
}
