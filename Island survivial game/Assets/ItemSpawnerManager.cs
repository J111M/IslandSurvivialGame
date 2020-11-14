﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerManager : MonoBehaviour
{
    public static ItemSpawnerManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] GameObject pickUpItemPrefab;

    public void SpawnItem(Vector3 position, Item item, int count)
    {
         GameObject GO = Instantiate(pickUpItemPrefab, position, Quaternion.identity);
         GO.GetComponent<PickUpItem>().Set(item, count); 
    }
}
