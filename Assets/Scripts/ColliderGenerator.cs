using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGenerator : MonoBehaviour
{
    public float depth;

    private void Awake()
    {
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(1.0f, depth / GetComponent<Renderer>().bounds.size.y);
        collider.offset = new Vector2(0.0f, collider.size.y / 2.0f - 0.5f);
    }
}
