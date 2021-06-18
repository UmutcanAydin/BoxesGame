using UnityEngine;

public class OneShotPlayer : MonoBehaviour
{

    [SerializeField] AudioClip jumpEffect;
    [SerializeField] AudioClip winEffect;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpEffect);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winEffect);
    }
}
