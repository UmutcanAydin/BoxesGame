using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] GameObject objectToEffect;
    [SerializeField] GameObject[] objectToPush;

    [SerializeField] float upForce = 4f;
    [SerializeField] float rightForce = 0f;


    bool open = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (GameObject obj in objectToPush)
        {
            if (collision.gameObject == obj.gameObject && !open)
            {
                open = true;
                objectToEffect.GetComponent<Rigidbody2D>().MovePosition(new Vector2(objectToEffect.transform.position.x + rightForce, objectToEffect.transform.position.y + upForce));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        foreach (GameObject obj in objectToPush)
        {
            if (collision.gameObject == obj.gameObject && open)
            {
                open = false;
                objectToEffect.GetComponent<Rigidbody2D>().MovePosition(new Vector2(objectToEffect.transform.position.x - rightForce, objectToEffect.transform.position.y - upForce));
            }
        }        
    }
}
