﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScriptable : MonoBehaviour
{

    const string GOName = "Inventory";

    public static GameObject objectToPick;

    public Image inventory;
    public AudioClip openSound;
    public AudioClip closeSound;
    public bool possessedByPlayer = false;

    [Header("References")]
    public GridLayoutGroup inventoryGrid;
    public GameObject itemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find(GOName) != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        gameObject.name = GOName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (inventory.gameObject.activeInHierarchy == false) // if inventory is not openned
            {
                if (!GameObject.Find("EventSystem").GetComponent<EventDispatcher>().paused && possessedByPlayer)
                {
                    GetComponent<GlobalMessageEventSender>().GlobalMessage("OpenInventory");
                }
            }
            else
            {
                GetComponent<GlobalMessageEventSender>().GlobalMessage("CloseInventory");
            }
        }
    }

    public void OpenInventory()
    {
        //inventory.gameObject.SetActive(true);
        // TODO: setup layout and default page
        GetComponent<AudioSource>().PlayOneShot(openSound);
        GetComponent<Animator>().SetTrigger("toggleVisibility");
    }

    public void CloseInventory()
    {
        //inventory.gameObject.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(closeSound);
        GetComponent<Animator>().SetTrigger("toggleVisibility");
    }

    public void PickItem()
    {
        if (objectToPick != null)
        {
            objectToPick.SetActive(false);
            GameObject newItem = GameObject.Instantiate(itemPrefab);
            newItem.GetComponent<Image>().sprite = objectToPick.GetComponent<SpriteRenderer>().sprite;
            newItem.transform.SetParent(inventoryGrid.transform);
            newItem.transform.localScale = Vector3.one;
        }
    }
}
