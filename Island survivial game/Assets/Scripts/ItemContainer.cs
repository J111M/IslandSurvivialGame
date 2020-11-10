using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName ="Data/Item container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1)
    {
        if(item.stackAble == true)
        {
            ItemSlot itemslot = slots.Find(x => x.item == item);
            if(itemslot != null)
            {
                itemslot.count += count;
            }
            else
            {
                itemslot = slots.Find(x => x.item == null);
                if(itemslot != null)
                {
                    itemslot.item = item;
                    itemslot.count = count;
                }
            }
        }
        else
        {
            //voegt niet stackable item toe
            ItemSlot itemslot = slots.Find(x => x.item == null);
            if(itemslot == null)
            {
                itemslot.item = item;
            }
        }
    }
}
