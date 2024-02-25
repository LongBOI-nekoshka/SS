using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Linq;
using System;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public int containerSize = 5;
    public float radius = 2.0f;
    Collider2D[] hitColliders;
    List<GameObject> itemList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitColliders = Physics2D.OverlapCircleAll(transform.position, radius, 1 << LayerMask.NameToLayer("Item"));
        PickUpItem();
    }

    void PickUpItem()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Add();
        }
        
    }

    void Add()
    {
        if(hitColliders.Length != 0 )
        {
            itemList.Add(hitColliders[GetNearest()].gameObject);
            Transform item = itemList[itemList.Count - 1].transform;
            item.SetParent(transform);
            item.transform.localScale = new Vector3(1,1,0);
            item.transform.localPosition = Vector2.right * 0.06f;
            item.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public float GetDistance(Transform itemPos) 
    {
        return Vector2.Distance(transform.position,itemPos.position);
    }

    int GetNearest()
    {
        float[] arrayDistance = new float[hitColliders.Length];
        for(int i = 0;i < hitColliders.Length; i++)
        {
            Collider2D item = hitColliders[i].GetComponent<Collider2D>();
            if(item != null)
            {
                arrayDistance[i] = GetDistance(item.transform);
            }
        }
        int minIndex = Array.IndexOf(arrayDistance, arrayDistance.Min());
        return minIndex;
    }
}
