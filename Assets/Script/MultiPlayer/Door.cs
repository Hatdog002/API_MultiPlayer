using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class Door : MonoBehaviourPunCallbacks
{
    public GameManager manager;

    public TextMeshProUGUI txtinteract;

    public bool doorP1;
    public bool door2P1;
    public bool door3P1;
    public bool door4P1;
    public bool door5P1;
    public bool door6P1;
    public bool door7P1;

    public bool doorP2;
    public bool door2P2;
    public bool door3P2;
    public bool door4P2;
    public bool door5P2;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtinteract.text = "Press E to iteract";
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (doorP1)
                {
                    if (manager.Key1P1)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }
                }
               

                if (door2P1)
                {
                    if(manager.Key2P1)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }
                }
                

                if (door3P1)
                {
                    if (manager.Key3P1)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }

                }
               

                if (door4P1)
                {
                    if (manager.Key4P1)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }
                }

                if (door5P1)
                {
                    if (manager.Key5P1)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }

                }
                

                if (door6P1)
                {
                    if (manager.Key6P1)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }
                }
              

                if (door7P1)
                {
                    if (manager.Key7P1)
                    {
                        photonView.RPC("Win", RpcTarget.All);
                      
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }
                }
                

                if (doorP2)
                {
                    if (manager.Key1P2) 
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }
                }
               

                if (door2P2)
                {
                    if (manager.Key2P2)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }

                }
               
                if (door3P2 )
                {
                    if (manager.Key3P2)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }

                }
               
                if (door4P2)
                {
                    if (manager.Key4P2)
                    {
                        Destroy(this.gameObject);
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }

                }
               
                if (door5P2)
                {
                    if (manager.Key5P2)
                    {
                        photonView.RPC("Win2", RpcTarget.All);
                       
                    }
                    else
                    {
                        txtinteract.text = "Your Partner must find the key";
                    }
                }
               
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            txtinteract.text = "";
        }
    }

    [PunRPC]
    void Win (){
        txtinteract.text = "";
        GameManager.instance.Win = true;
        Invoke("Delay", 2f);
    }

    [PunRPC]
    void Win2()
    {
        txtinteract.text = "";
        GameManager.instance.Win2 = true;
        Invoke("Delay", 2f);
    }

    void Delay()
    {
        Destroy(this.gameObject);
    }
}
