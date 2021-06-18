using UnityEngine;
using UnityEngine.UI;

public class SelectionButton : MonoBehaviour
{
    public GameObject square;
    private void Start()
    {
        transform.GetChild(0).GetComponent<Image>().color = square.GetComponent<SpriteRenderer>().color;
    }

    
}
