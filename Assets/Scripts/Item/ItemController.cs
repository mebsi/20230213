using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public static ItemController Instance;

    [SerializeField] private List<Item> items;
    [SerializeField] private Transform parent;
    private void Awake()
    {
        Instance = this;
    }

    // 아이템트랍
    public void Spawn(Transform trans = null)
    {
        int rand = Random.Range(0, 100);
        //int itemIndex = 2;

       // if (rand <= 3)//boom 0
       // {
       //
       // }
       // else if(rand <= 10)//power 1
       // {
       //
       // }
       // else//coin 2
       // {
       //
       // }

        //조건 ? 참 : 거짓
       int itemIndex = rand <= 3 ? 0 : rand <= 10 ? 1 : 2;

        if (trans != null)
        {
            Item item = Instantiate(items[itemIndex], trans);
            item.transform.SetParent(parent);
        }
        else
        {
            Instantiate(items[itemIndex], parent);
        }
    }
}
