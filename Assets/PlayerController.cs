using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update() {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }
}
