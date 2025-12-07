using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");   // exact scene name
    }

    public void LoadCredits()
    {
        SceneManager.LoadSceneAsync("Credits");     // exact scene name
    }
}
