using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentIndex;

    private void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void loadMenu()
    {   
        SceneManager.LoadScene(0);
        if (currentIndex == 0) return;
    }

    public void loadLevelMenu()
    {
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (currentIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", currentIndex - 1);
        }

        SceneManager.LoadScene(1);
        if (currentIndex == 1) return;
    }

    public void loadLevelMenuWithoutSaving()
    {
        SceneManager.LoadScene(1);
        if (currentIndex == 1) return;
    }

    public void loadCurrentLevel()
    {
        SceneManager.LoadScene(currentIndex);
    }

    public void loadNextLevel()
    {
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (currentIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", currentIndex - 1);
        }

        currentIndex++;
        SceneManager.LoadScene(currentIndex);
    }

    public void loadLevel(int index)
    {
        SceneManager.LoadScene(index+1);
    }
}
