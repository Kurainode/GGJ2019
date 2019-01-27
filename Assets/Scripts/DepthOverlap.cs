using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthOverlap : MonoBehaviour
{
    private void Update()
    {
        var position = transform.position;
        var renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            renderer = GetComponentInChildren<Renderer>();
        }
        position.z = position.y - renderer.bounds.extents.y + 100.0f;
        transform.position = position;
    }
}
