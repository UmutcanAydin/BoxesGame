using UnityEngine;

public class Area : MonoBehaviour
{
    public void Freeze()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(transform.localScale.x, transform.localScale.y), 0);
        foreach (Collider2D collider in colliders)
        {
            RigidbodyType2D type = collider.GetComponent<Rigidbody2D>().bodyType;
            if (type == RigidbodyType2D.Dynamic)
            {
                collider.GetComponent<Drag>().SetFreeze(RigidbodyType2D.Static);
            }
            else if (type == RigidbodyType2D.Static)
            {
                collider.GetComponent<Drag>().SetFreeze(RigidbodyType2D.Dynamic);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector2(transform.localScale.x,transform.localScale.y));
    }
}
