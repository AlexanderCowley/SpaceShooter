using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static void ChangeScene()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(++currentBuildIndex);
    }

    public static void GoToShop() => SceneManager.LoadScene(0);
    public static void GoToTestScene() => SceneManager.LoadScene(1);
}