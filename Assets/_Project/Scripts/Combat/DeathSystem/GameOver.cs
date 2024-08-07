using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    Canvas[] _canvasChildren;
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
            Destroy(this);
        }
        else
        {
            Instance = this;
            //Perserve Canvas parent object
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += SceneLoadHandler;
        }
        _canvasChildren = GetComponentsInChildren<Canvas>(true);
        _gameOverCanvas = _canvasChildren[4];
        _gameOverCanvas.gameObject.SetActive(false);
    }

    public void SceneLoadHandler(Scene sceneData, LoadSceneMode mode)
    {
        _gameOverCanvas.gameObject.SetActive(false);
        if(sceneData.name != "MainMenu")
        {
            return;
        }
        
        for(int i = 0; i< _canvasChildren.Length; i++)
        {
            _canvasChildren[i].gameObject.SetActive(false);
        }
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
