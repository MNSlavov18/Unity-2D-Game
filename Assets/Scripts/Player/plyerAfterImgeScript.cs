﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plyerAfterImgeScript : MonoBehaviour
{
    [SerializeField]
    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaSet = 0.8f;
    [SerializeField]
    private float alphaMoltipl = 0.85f;

    private Transform player;

    private SpriteRenderer sr;
    private SpriteRenderer playersr;

    private Color color;
    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playersr = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        sr.sprite = playersr.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }
    private void Update()
    {
        alpha -= alphaMoltipl * Time.deltaTime;
        color = new Color(1f, 1f, 1f, alpha);
        sr.color = color;

        if (Time.time >= (timeActivated = activeTime))
        {
            plyerAfterImgePool2.Instance.AddToPool(gameObject);
        }
    }
}
