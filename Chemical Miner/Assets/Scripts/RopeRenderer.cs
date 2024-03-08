using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField]
    private Transform startPos;
    private float line_Width = 0.05f;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = line_Width;
        lineRenderer.enabled = false;
    }
    void Start()
    {
        
    }

    public void RenderLine(Vector3 renderPosition, bool enableRenderer)
    {
        if (enableRenderer)
        {
            if (!lineRenderer.enabled)
            {
                lineRenderer.enabled = true;
            }
            lineRenderer.positionCount = 2;
        }
        else
        {
            lineRenderer.positionCount = 0;
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }
        if (lineRenderer.enabled)
        {
            Vector3 temp = startPos.position;
            temp.z = 0f;
            startPos.position = temp;
            temp = renderPosition;
            temp.z = 0f;
            renderPosition = temp;
            lineRenderer.SetPosition(0, startPos.position);
            lineRenderer.SetPosition(1, renderPosition);
        }
    }
}
