using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSprite : MonoBehaviour
{
    public Transform target;
    public float maxDistance = 20f;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        if ((target.position - transform.position).magnitude > maxDistance)
        {
            var direction = (target.position - transform.position);
            if (direction.magnitude > speed)
            {
                direction = direction.normalized * ((target.position - transform.position).magnitude - maxDistance) * speed;
            }
            transform.position += direction;
        }
    }
}
