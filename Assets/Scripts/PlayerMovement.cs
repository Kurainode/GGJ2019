using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 direction;
    public PlayerSpawnPosition playerSpawnPosition;

    private void Awake()
    {
        transform.position = playerSpawnPosition.position;
        // playerSpawnPosition.position = new Vector3(0, -2.0f, 0);
    }

    private void Update()
    {
        if (!GameObject.Find("EventSystem").GetComponent<EventDispatcher>().paused)
        {
            var position = transform.position;
            var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized * Time.deltaTime * speed * Mathf.Pow(0.75f, position.y + 2.0f);
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1)
                direction = new Vector2(movement.x, movement.y).normalized;
            movement.y *= 0.75f;
            position += movement;
            GetComponentInChildren<Animator>().SetFloat("walkSpeed", movement.magnitude);

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (movement.x > 0)
                {
                    GetComponent<Animator>().SetInteger("direction", 3); // 3 == right
                }
                else
                {
                    GetComponent<Animator>().SetInteger("direction", 1); // 1 == left
                }
            } 
            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                if (movement.y > 0)
                {
                    GetComponent<Animator>().SetInteger("direction", 2); // 2 == back
                }
                else
                {
                    GetComponent<Animator>().SetInteger("direction", 0); // 0 == front
                }
            }
            transform.position = position;
        }
        else
        {
            GetComponent<Animator>().SetFloat("walkSpeed", 0.0f);
        }
    }
}
