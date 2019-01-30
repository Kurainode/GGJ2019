using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectInteraction))]
public class AutostartItemInteraction : MonoBehaviour
{
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
        item.Interact(gameObject);
        GetComponent<ObjectInteraction>().lastUsed = item.gameObject;
    }
}
