using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform SP;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnT;

    private float respawnTS;

    private bool respawn;

    private CinemachineVirtualCamera CVC;

    private void Start()
    {
        CVC = GameObject.Find("Player Cam").GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        CheckRespawn();
    }
    public void Respawn()
        {
        respawnTS= Time.time;
        respawn = true;
    }

    private void CheckRespawn()
    {
        if (Time.time >= respawnTS + respawnT && respawn)
        {

            var playerTemp = Instantiate(player, SP);
            CVC.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }

}
