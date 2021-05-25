using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject winScreen;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Winner"))
        {
            GetComponent<OneShotPlayer>().Play();
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }
}
