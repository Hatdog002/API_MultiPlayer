using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
using TMPro;
using UnityEngine.SceneManagement;
public class APIReader : MonoBehaviour
{
    private readonly string basePath = "https://apigenerator.dronahq.com/api/IbRJ_nE5/DataMultiplayer";


    public UserData[] users;

    public UserData user;

    public TextMeshProUGUI tmpResponse;
    public void Start()
    {
        Get();
    }

    public void Update()
    {
        
    }
    public void Get()
    {
        RestClient.Get(basePath).Then(response =>
        {
            try
            {
                string jsonResponse = response.Text;
                users = JsonHelper.ArrayFromJson<UserData>(jsonResponse);
                if (users != null)
                {
                    Debug.Log("Number of users: " + users.Length);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "User array is null");
            }
        }).Catch(error =>
           Debug.Log(error.Message)


        );      
    }


    public void Post()
    {
        RestClient.Get(basePath).Then(response =>
        {
            try
            {
                string jsonResponse = response.Text;
                users = JsonHelper.ArrayFromJson<UserData>(jsonResponse);
                if (users != null)
                {
                    // Check if the user already exists
                    bool userExists = Array.Exists(users, u => u.UserName == user.UserName);
                    if (userExists)
                    {
                        tmpResponse.text = "User already exists";

                        Invoke("clear", 2f);
                        
                        Debug.Log("User already exists. Updating...");
                        // Call Patch method to update existing user
                    }
                    else
                    {
                        if (IsPasswordValid(user.Password))
                        {
                            RestClient.Post(basePath, user).Then(postResponse =>
                            {
                                try
                                {
                                    if (postResponse != null)
                                    {
                                        tmpResponse.text = "Account Created";
                                        Invoke("clear", 2f);
                                        Get();
                                    }
                                    else
                                    {
                                        Debug.Log("No response");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Debug.Log(ex + "Error posting data");
                                }
                            }).Catch(postError =>
                                Debug.Log(postError.Message)
                                );
                        }
                        else
                        {
                            tmpResponse.text = "Password is too short";
                            Invoke("clear", 2f);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error getting existing data");
            }
        }).Catch(error =>
            Debug.Log(error.Message)
        );
    }

    public void DeleteUser(int userID)
    {
        RestClient.Delete(basePath + "/" + userID).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Successfully Deleted");
                }
                else
                {
                    Debug.Log("Not Found");
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error posting data");
            }
        }).Catch(error =>
           Debug.Log(error.Message)


       );
    }

    public void Patch()
    {
        RestClient.Patch(basePath + "/" + user.id, user).Then(response =>
        {
            try
            {
                if (response != null)
                {
                    Debug.Log("Successfully Paccth");
                }
                else
                {
                    Debug.Log("Not Found");
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error Patching data");
            }
        }).Catch(error =>
           Debug.Log(error.Message)


       );
    }
    public void LogIn()
    {
        RestClient.Get(basePath).Then(response =>
        {
            try
            {
                string jsonResponse = response.Text;
                users = JsonHelper.ArrayFromJson<UserData>(jsonResponse);
                if (users != null)
                {
                    // Check if the user already exists
                    UserData userExists = Array.Find(users, u => u.UserName == user.UserName);
                    if (userExists != null)
                    {
                        if(userExists.Password == user.Password)
                        {
                            SceneManager.LoadScene("HideAndSeek_Lobby");
                        }
                        else
                        {
                            tmpResponse.text = "Wrong Password";
                            Invoke("clear", 2f);
                        }
                    }
                    else 
                    {
                        tmpResponse.text = "Username Does not exist";
                        Invoke("clear", 2f);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex + "Error getting existing data");
            }
        }).Catch(error =>
            Debug.Log(error.Message)
        );
    }
    void clear()
    {
        tmpResponse.text = "";
    }
    private bool IsPasswordValid(string password)
    {
        // Check minimum length
        if (password.Length < 8)
            return false;


        return true;
    }

}
