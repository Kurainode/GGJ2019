using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    private void Update()
    {
        var position = transform.position;
        var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized * Time.deltaTime * speed * Mathf.Pow(0.75f, position.y + 2.0f);
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1)
            direction = new Vector2(movement.x, movement.y).normalized;
        movement.y *= 0.75f;
        position += movement;
        GetComponent<Animator>().SetFloat("walkSpeed", movement.magnitude);
        transform.position = position;
    }
}
