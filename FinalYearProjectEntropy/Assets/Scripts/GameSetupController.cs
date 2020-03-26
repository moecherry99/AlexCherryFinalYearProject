using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

// Reference : https://www.youtube.com/watch?v=SNhWbHqFUbU&list=PLWeGoBm1YHVhH43SRzCo6Qr3Lm1W4Rw8z&index=3&t=0s
public class GameSetupController : MonoBehaviour
{

    public Transform respawn;
    void Start()
    {
        // Create the player object in Unity
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonPlayer"), respawn.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
