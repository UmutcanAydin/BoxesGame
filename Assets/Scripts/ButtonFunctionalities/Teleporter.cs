using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Button answerButton;
    ParticleSystem ps;
    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void Teleport()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(transform.localScale.x, transform.localScale.y), 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Winner"))
            {
                ps.Play();
                collider.transform.position = new Vector2(answerButton.transform.position.x, answerButton.transform.position.y);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, new Vector2(transform.localScale.x, transform.localScale.y));
    }
}
