using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject musicPlayer;

    void Awake()
    {
        musicPlayer = GameObject.Find("MusicPlayer");
        if (musicPlayer == null)
        {
            
            musicPlayer = this.gameObject;
            musicPlayer.name = "MusicPlayer";
            DontDestroyOnLoad(musicPlayer);
        }
        else
        {
            if (this.gameObject.name != "MusicPlayer")
            {             
                Destroy(this.gameObject);
            }
        }
    }
}
