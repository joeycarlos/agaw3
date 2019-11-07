using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveAmplitude;
    public float moveFrequency;
    public float phaseShift;

    private float elapsedTime;
    private float verticalOffset;
    private float originalY;

    void Start() {
        elapsedTime = 0;
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate() {
        verticalOffset = moveAmplitude * Mathf.Sin(elapsedTime * moveFrequency + phaseShift);
        transform.position = new Vector3(transform.position.x, originalY + verticalOffset, transform.position.z);
        elapsedTime += Time.deltaTime;
    }
}
