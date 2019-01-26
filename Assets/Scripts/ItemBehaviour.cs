using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameObject.Find("EventSystem").GetComponent<EventDispatcher>().Talk(textData[curentId].emmiter, textData[curentId].caption, textData[curentId].important);
        curentId = textData[curentId].nextUnlocked;
    }

    private void Update()
    {
        if (lastUser && lastUser.lastUsed == gameObject && curentId != null && curentId != "")
        {
            if (lastUser.GetComponent<SpeechDisplayer>().ended)
            {
                GameObject.Find("EventSystem").GetComponent<EventDispatcher>().Talk(textData[curentId].emmiter, textData[curentId].caption, textData[curentId].important);
                curentId = textData[curentId].nextUnlocked;
            }
        }
        else
        {
            curentId = null;
        }
    }
}
