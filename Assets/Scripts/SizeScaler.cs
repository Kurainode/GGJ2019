using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeScaler : MonoBehaviour
{
    Vector3 baseScale;

    private void Awake()
    {
        baseScale = transform.localScale;
    }

    private void Update()
    {
        transform.localScale = baseScale * Mathf.Pow(0.75f, transform.position.y + 2.0f);
    }
}
