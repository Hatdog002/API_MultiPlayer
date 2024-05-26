using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviourPunCallbacks
{
    private TextMeshProUGUI textMeshPro;
    private Camera toLookAt;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            this.gameObject.SetActive(false);
        }
        toLookAt = Camera.main;
        textMeshPro = GetComponent<TextMeshProUGUI>();
        textMeshPro.text = photonView.Owner.NickName;
    }

    void Update()
    {
        Vector3 v = toLookAt.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(toLookAt.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
