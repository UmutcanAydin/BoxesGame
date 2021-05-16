using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] float power = 2f;
    Rigidbody2D rgbd;

    [SerializeField] Vector2 minPower;
    [SerializeField] Vector2 maxPower;
    [SerializeField] float forceLimit = 0.3f;
    [SerializeField] float groundRaycastLength = 1;

    Line line;
    SpriteRenderer sprt;
    Color firstColor;

    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    bool jumpHandled = false;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        line = GetComponent<Line>();
        sprt = GetComponent<SpriteRenderer>();
        firstColor = sprt.color;
        GetComponent<LineRenderer>().startColor = GetComponent<SpriteRenderer>().color;
        GetComponent<LineRenderer>().endColor = new Color(0,0,0,0);
    }

    void Update()
    {
      
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, transform.localScale,0, Vector2.down,groundRaycastLength, LayerMask.GetMask("Floor") | LayerMask.GetMask("DraggableObject"));
        
        for (int i = 1; i < hits.Length; i++)
        {
            if (hits[i] && !jumpHandled)
            {
                HandleDrag();
            }
        }
        jumpHandled = false;
    }

    private void HandleDrag()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //}
        if (Input.GetMouseButtonDown(0))
        {           
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }
        if (Input.GetMouseButton(0))
        {          
            Vector3 currentPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            line.RenderLine(startPoint, currentPoint);           
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            if (Mathf.Abs(force.x) < forceLimit && Mathf.Abs(force.y) < forceLimit)
            {
                force = Vector2.zero;
            }
            rgbd.AddForce(force * power, ForceMode2D.Impulse);
            line.EndLine();
        }
        jumpHandled = true;
    }

    public void SetFreeze(RigidbodyType2D type)
    {
        rgbd.bodyType = type;
        switch (rgbd.bodyType)
        {
            case RigidbodyType2D.Static:
                sprt.color = new Color32(83, 53, 74, 255);
                break;

            case RigidbodyType2D.Dynamic:
                sprt.color = firstColor;
                break;
        }
    }
}
