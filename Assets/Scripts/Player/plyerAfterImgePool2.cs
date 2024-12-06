﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyerAfterImgePool2 : MonoBehaviour
{
    [SerializeField]
    private GameObject afterImagePrefab;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static plyerAfterImgePool2 Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPoll();
    }
    private void GrowPoll()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(afterImagePrefab);
            instanceToAdd.transform.SetParent(transform);
            AddToPool(instanceToAdd);
        }
    }
    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            GrowPoll();
        }
        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
}
