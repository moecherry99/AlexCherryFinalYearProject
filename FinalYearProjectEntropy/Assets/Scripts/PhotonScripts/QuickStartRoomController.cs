using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

// Reference : https://www.youtube.com/watch?v=SNhWbHqFUbU&list=PLWeGoBm1YHVhH43SRzCo6Qr3Lm1W4Rw8z&index=3&t=0s
public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex; // Build index finder

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    // Method for joining a room that is ongoing (for second client)
    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
        StartGame();
    }

    // Method for starting a game if one does not exist
    public void StartGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Starting Game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
