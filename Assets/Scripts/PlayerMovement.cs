using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        var position = transform.position;
        var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized * Time.deltaTime * speed * Mathf.Pow(0.75f, position.y + 2.0f);
        movement.y *= 0.75f;
        position += movement;
        transform.position = position;
    }
}
