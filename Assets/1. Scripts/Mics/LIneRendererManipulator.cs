using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LIneRendererManipulator : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private GameObject lookAtObject;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void AddSource(GameObject gameObject)
    {
        lineRenderer.enabled = true;
        lookAtObject = gameObject;
    }

    public void ClearDirection()
    {
        lineRenderer.enabled = false;
        lookAtObject = null;
    }

    private void Update()
    {
        if (!lookAtObject)
            return;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.TransformPoint(Vector2.up * 3));
    }
}
