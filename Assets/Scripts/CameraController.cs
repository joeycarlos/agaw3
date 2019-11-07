using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float horizontalOffset = 0f;
    public float verticalOffset = 0f;

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(player.transform.position.x + horizontalOffset, verticalOffset, -10.0f);
    }
}
