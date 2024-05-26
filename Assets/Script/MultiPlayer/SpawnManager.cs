using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviourPunCallbacks
{
    private int randomNumber;
    public GameObject[] spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            randomNumber = Random.Range(0, 2);
        }
        GameManager.instance.CreatePlayer(randomNumber);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
