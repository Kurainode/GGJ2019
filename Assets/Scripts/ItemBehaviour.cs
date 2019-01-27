using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour
{
    public TextAsset json;
    public string startId;
    public Dictionary<string, JsonData> textData;
    string curentId = null;
    ObjectInteraction lastUser;

    [System.Serializable]
    public class JsonData
    {
        public string id;
        public string caption;
        public string label;
        public string emmiter;
        public string require;
        public string nextUnlocked;
        public string nextLocked;
        public string trigger;
        public bool pickable;
        public bool important;
        public bool haveChoice;
        public string choice1;
        public string nextChoice1;
        public string choice2;
        public string nextChoice2;
    }

    [System.Serializable]
    public class JsonWrapper<T>
    {
        public T[] content;
    }

    private void Awake()
    {
        string wrapper = string.Format("{{\"content\":{0}}}", json.text);
        textData = new Dictionary<string, JsonData>();
        foreach (var x in JsonUtility.FromJson<JsonWrapper<JsonData>>(wrapper).content)
        {
            textData.Add(x.id, x);
        }
    }

    public void Interact(GameObject user)
    {
        lastUser = user.GetComponent<ObjectInteraction>();
        curentId = startId;
        GameObject.Find("EventSystem").GetComponent<EventDispatcher>().Talk(textData[curentId]);
    }

    private void Update()
    {
        if (lastUser && lastUser.lastUsed == gameObject && curentId != null && curentId != "")
        {
            if ((!textData[curentId].important && GameObject.Find(textData[curentId].emmiter).GetComponent<SpeechDisplayer>().ended)
                || (textData[curentId].important && GameObject.Find("Important Text Canvas").GetComponent<ImportantText>().interactionText.ended))
            {
                if (textData[curentId].important && textData[curentId].haveChoice)
                {
                    curentId = (GameObject.Find("Important Text Canvas").GetComponent<ImportantText>().selectedChoice == 1) ?
                        textData[curentId].nextChoice1 : textData[curentId].nextChoice2;
                }
                else
                {
                    curentId = textData[curentId].nextUnlocked;
                }
                if (curentId != null && curentId != "")
                    GameObject.Find("EventSystem").GetComponent<EventDispatcher>().Talk(textData[curentId]);
            }
        }
        else
        {
            curentId = null;
        }
    }
}
