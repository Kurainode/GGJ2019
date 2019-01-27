using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject lastUsed;
    public LayerMask objectLayers;

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Action"))
        {
            Vector3 playerBase = transform.position - new Vector3(0.0f, GetComponent<Renderer>().bounds.extents.y);
            var hit = Physics2D.Raycast(playerBase, GetComponent<PlayerMovement>().direction, 0.9f, objectLayers);
            if (hit && hit.collider)
            {
                if (hit.collider.GetComponent<ItemBehaviour>())
                {
                    hit.collider.GetComponent<ItemBehaviour>().Interact(gameObject);
                    lastUsed = hit.collider.gameObject;
                }
                else if (hit.collider.GetComponent<DoorBehaviour>())
                {
                    hit.collider.GetComponent<DoorBehaviour>().ChangeRoom();
                }
            }
        }
    }
}
