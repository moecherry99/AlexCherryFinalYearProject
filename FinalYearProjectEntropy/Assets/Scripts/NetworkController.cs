using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Reference : https://www.youtube.com/watch?v=02P_mrszvzY&list=PLWeGoBm1YHVhH43SRzCo6Qr3Lm1W4Rw8z&index=1
public class NetworkController : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Activates when the game is started
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // Connects to our appropriate Photon server (in this case, EU servers)
        Debug.Log("Yes " + PhotonNetwork.CloudRegion);
    }

    void Update()
    {
        
    }
}
