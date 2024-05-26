using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{

    public static GameManager instance = null;

   
    [SerializeField] PlayerType playerType;
 
    public SpawnManager sPoint;
    public GameObject playerLose;

    public bool Key1P1;
    public bool Key2P1;
    public bool Key3P1;
    public bool Key4P1;
    public bool Key5P1;
    public bool Key6P1;
    public bool Key7P1;


    public bool Key1P2;
    public bool Key2P2;
    public bool Key3P2;
    public bool Key4P2;
    public bool Key5P2;


    public bool Win;
    public bool Win2;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
      
    }

    private void Update()
    {
        if(Win && Win2)
        {
            PhotonNetwork.LoadLevel("Win");
        }
    }
    public void CreatePlayer(int randomNumber)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("InstantiatePlayer", RpcTarget.AllBufferedViaServer, randomNumber);
        }
    }

    [PunRPC]
    void InstantiatePlayer(int randomNumber)
    {
        int idNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        int totalPlayers = PhotonNetwork.CurrentRoom.PlayerCount;

        // Ensure only 2 players are instantiated
        if (totalPlayers > 2)
        {
            Debug.LogError("More than 2 players in the room. Cannot instantiate more players.");
            return;
        }

        // Calculate the spawn number for each player
        int spawnNumber = idNumber -1; // Assuming spawn points are indexed from 0 to totalPlayers - 1

        // Check if the current player should be IT
        bool isTag = (idNumber == 1); // Assuming the player with ActorNumber 1 is IT

        if (isTag)
        {
            playerType = PlayerType.IT;
            PhotonNetwork.Instantiate("P1Prefab", sPoint.spawnPoint[spawnNumber].transform.position, Quaternion.identity);
        }
        else
        {
            playerType = PlayerType.Normal;
            PhotonNetwork.Instantiate("P2Prefab", sPoint.spawnPoint[spawnNumber].transform.position, Quaternion.identity);
        }

    }

    public void GameOver()
    {
        photonView.RPC("SendGameOver",RpcTarget.AllBufferedViaServer);
    }

    [PunRPC]
    public void SendGameOver()
    {
        ShowWinUI();

        // Wait for a brief period before restarting the game
        StartCoroutine(RestartGame());
    }

    private void ShowWinUI()
    {
        playerLose.SetActive(true);

    }
    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2f);
        // Call an RPC to inform all players about the game over event
        PhotonNetwork.LoadLevel("MainGame");
    }
}
