using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer ln;

    void Awake()
    {
        ln = GetComponent<LineRenderer>();
        ln.sortingLayerName = "Foreground";
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        ln.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        ln.SetPositions(points);
    }

    public void EndLine()
    {
        ln.positionCount = 0;
    }
}
