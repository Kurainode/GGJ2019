using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutostartItemInteraction : MonoBehaviour
{

    public PlayerMovement player;
    public ItemBehaviour item;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelayed());
    }

    IEnumerator StartDelayed()
    {
        yield return new WaitForSeconds(delay);
        item.Interact(player.gameObject);
        player.GetComponent<ObjectInteraction>().lastUsed = item.gameObject;
    }
}
