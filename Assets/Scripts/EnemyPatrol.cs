using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private bool isMovingRight;
    private Vector3 moveVector;

    private BoxCollider2D bc;
    private int platformLayer;

    void Start() {
        isMovingRight = true;
        bc = GetComponent<BoxCollider2D>();
        platformLayer = LayerMask.GetMask("Platform");
    }

    void FixedUpdate() {
        CheckDirectionSwitch();

        if (isMovingRight) {
            moveVector = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else {
            moveVector = new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }

        if (GameManager.Instance.gameIsRunning)
            transform.Translate(moveVector);
    }

    void CheckDirectionSwitch() {

        Vector3 raycastOriginOffset;
        if (isMovingRight)
            raycastOriginOffset = new Vector3(bc.size.x/2.0f, -bc.size.y + 0.05f, 0);
        else
            raycastOriginOffset = new Vector3(-bc.size.x/2.0f, -bc.size.y + 0.05f, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastOriginOffset, -Vector2.up, 0.2f, platformLayer);

        if (hit.collider == null) isMovingRight = !isMovingRight;
    }
}
