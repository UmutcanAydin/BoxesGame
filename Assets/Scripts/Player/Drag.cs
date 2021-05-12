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

    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    bool jumpHandled = false;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        line = GetComponent<Line>();
        GetComponent<LineRenderer>().startColor = GetComponent<SpriteRenderer>().color;
        GetComponent<LineRenderer>().endColor = new Color(0,0,0,0);
    }

    void Update()
    {
        Vector3 midRayPos = transform.position;
        Vector3 leftRayPos = transform.position + new Vector3(-transform.localScale.x, 0, 0) / 3;
        Vector3 rightRayPos = transform.position + new Vector3(transform.localScale.x, 0, 0) / 3;

        RaycastHit2D[] hitsMid = Physics2D.RaycastAll(midRayPos, Vector2.down, groundRaycastLength, LayerMask.GetMask("Floor") | LayerMask.GetMask("DraggableObject"));
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(leftRayPos,Vector2.down, groundRaycastLength, LayerMask.GetMask("Floor") | LayerMask.GetMask("DraggableObject"));
        RaycastHit2D[] hitsRight = Physics2D.RaycastAll(rightRayPos, Vector2.down, groundRaycastLength, LayerMask.GetMask("Floor") | LayerMask.GetMask("DraggableObject"));

        for (int i = 1; i < hitsMid.Length; i++)
        {
            if (!hitsMid[i]) return;
            HandleDrag();
        }
        for (int i = 1; i < hitsLeft.Length; i++)
        {
            if (!hitsLeft[i] ||jumpHandled) return;
            HandleDrag();
        }
        for (int i = 1; i < hitsRight.Length; i++)
        {
            if (!hitsRight[i] || jumpHandled) return;
            HandleDrag();
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
}
