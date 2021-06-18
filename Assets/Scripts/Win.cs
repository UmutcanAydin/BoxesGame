using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    OneShotPlayer osp;

    private void Start()
    {
        Time.timeScale = 1;
        osp = FindObjectOfType<OneShotPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Winner"))
        {
            osp.PlayWin();
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }
    }
}
