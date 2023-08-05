using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCraft : MonoBehaviour
{
    public CraftSettings CraftSettings;
    [SerializeField] private Button craftButton;

    private List<ICraft> items = new List<ICraft>();
    private List<GameObject> select = new List<GameObject>();
    void Start()
    {
        craftButton.onClick.AddListener(EnterCraft);
    }
    public void EnterCraft()
    {
        select.Clear();
        items = GetComponent<ICraft>().ToList();
        Debug.Log(items.Count);
        for (int i = 0; i < items.Count; i++)
        {
            if ((MonoBehaviour)items[i]!=null)
            {
               Button button= gameObject.AddComponent<Button>();
                button.onClick.AddListener(()=> {Select(button.gameObject) });
            }
        }
    }

    private void Select(GameObject gameObject)
    {
        if (select.Contains(gameObject))
        {
            select.Remove(gameObject);
            gameObject.GetComponent<Image>().color = new Color(1f,1f,1f,1f);
        }
        else
        {
            select.Add(gameObject);
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
