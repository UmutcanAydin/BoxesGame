using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int currentIndex;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void loadGameFromStart()
    {   
        SceneManager.LoadScene(1);
        if (currentIndex == 0) return;
    }

    public void loadCurrentLevel()
    {
        SceneManager.LoadScene(currentIndex);
    }

    public void loadNextLevel()
    {
        currentIndex++;
        SceneManager.LoadScene(currentIndex);
    }
}
