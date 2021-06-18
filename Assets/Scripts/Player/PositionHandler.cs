using UnityEngine;

public class PositionHandler : MonoBehaviour
{
    Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Retry"))
        {
            transform.position = startPos;
        }
    }
}
