using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    private Transform player;
    private const float SMTH = 0.3f;
    private Vector3 vel = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //TO BE ADDED: rooms with bounds; if the player leaves the room, smooth follow to the new room
        //if (player.position.x > right || player.position.x < left || player.position.y > up || player.position < down) {}
        //else {}
        //follow the player 
        Vector3 targetPos = player.TransformPoint(new Vector3(0f,0f,-10f));
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, SMTH);
    }
}
