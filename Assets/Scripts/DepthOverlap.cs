using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthOverlap : MonoBehaviour
{
    private void Update()
    {
        var position = transform.position;
        position.z = position.y - GetComponentInChildren<Renderer>().bounds.extents.y + 100.0f;
        transform.position = position;
    }
}
