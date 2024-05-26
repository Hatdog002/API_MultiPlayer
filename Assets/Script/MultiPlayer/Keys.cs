using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class Keys : MonoBehaviourPunCallbacks
{
    public GameManager manager;

    public TextMeshProUGUI txtinteract;

    public bool KeyP1;
    public bool Key2P1;
    public bool Key3P1;
    public bool Key4P1;
    public bool Key5P1;
    public bool Key6P1;
    public bool Key7P1;

    public bool KeyP2;
    public bool Key2P2;
    public bool Key3P2;
    public bool Key4P2;
    public bool Key5P2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtinteract.text = "Press E to iteract";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (KeyP1)
                {
                    photonView.RPC("P1Key", RpcTarget.All);
                }
                if (Key2P1)
                {
                  
                    photonView.RPC("P1Key2", RpcTarget.All);
                }

                if (Key3P1)
                {
                 
                    photonView.RPC("P1Key3", RpcTarget.All);
                }

                if (Key4P1)
                {
               
                    photonView.RPC("P1Key4", RpcTarget.All);
                }

                if (Key5P1)
                {
                
                    photonView.RPC("P1Key5", RpcTarget.All);
                }

                if (Key6P1)
                {
                
                    photonView.RPC("P1Key6", RpcTarget.All);
                }

                if (Key7P1)
                {
                  ;
                    photonView.RPC("P1Key7", RpcTarget.All);
                }


                if (KeyP2)
                {
                 
                    photonView.RPC("P2Key", RpcTarget.All);
                }

                if (Key2P2)
                {
                  
                    photonView.RPC("P2Key2", RpcTarget.All);
                }
                if (Key3P2)
                {
                 
                    photonView.RPC("P2Key3", RpcTarget.All);
                }
                if (Key4P2)
                {
                    
                    photonView.RPC("P2Key4", RpcTarget.All);
                }
                if (Key5P2)
                {
               
                    photonView.RPC("P2Key5", RpcTarget.All);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtinteract.text = "";
        }
    }





    [PunRPC]
    private void P1Key()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key1P1 = true;
    }

    [PunRPC]
    private void P1Key2()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key2P1 = true;
    }

    [PunRPC]
    private void P1Key3()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key3P1 = true;
    }

    [PunRPC]
    private void P1Key4()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key4P1 = true;
    }

    [PunRPC]
    private void P1Key5()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key5P1 = true;
    }

    [PunRPC]
    private void P1Key6()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key6P1 = true;
    }

    [PunRPC]
    private void P1Key7()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key7P1 = true;
    }

    [PunRPC]
    private void P2Key()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key1P2 = true;
    }

    [PunRPC]
    private void P2Key2()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key2P2 = true;
    }

    [PunRPC]
    private void P2Key3()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key3P2 = true;
    }

    [PunRPC]
    private void P2Key4()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key4P2 = true;
    }

    [PunRPC]
    private void P2Key5()
    {
        Invoke("DelayDestroy", 2f);
        txtinteract.text = "";
        GameManager.instance.Key5P2 = true;
    }


    void DelayDestroy()
    {
        Destroy(this.gameObject);
    }
}
