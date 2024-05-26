using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Create : MonoBehaviour
{
    public APIReader User;
    public TMP_InputField userName;
    public TMP_InputField Password;


    public void GetInfo()
    {
        User.user.UserName = userName.text;
        User.user.Password = Password.text;

        Invoke("clear", 1f);
    }


    void clear()
    {
        Password.text = "";
        userName.text = "";
    }
}

