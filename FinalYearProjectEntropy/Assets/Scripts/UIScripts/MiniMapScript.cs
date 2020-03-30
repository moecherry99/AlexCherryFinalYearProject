using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for Mini Map Camera attachment
// Reference : https://www.youtube.com/watch?v=28JTTXqMvOU
public class MiniMapScript : MonoBehaviour
{

    public Transform player;

    // use LateUpdate as it only updates after player has moved (not FixedUpdate or Update)
    void LateUpdate() 
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        // for camera to rotate with player
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
