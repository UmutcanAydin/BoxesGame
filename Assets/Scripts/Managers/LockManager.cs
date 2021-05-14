using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockManager : MonoBehaviour
{
    public List<Button> levelButtons;

    private void Start()
    {
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        for (int i  = 0; i < levelButtons.Count; i++)
        {
            if (i <= saveIndex)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }
}
