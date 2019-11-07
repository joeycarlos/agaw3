using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;

    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private int platformLayer;

    public float maxJumpTime = 0.7f;
    private float jumpTimeCounter;
    private bool isJumping;

    void Start() {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        platformLayer = LayerMask.GetMask("Platform");
        isJumping = false;
    }

    void FixedUpdate() {
        transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) {
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true) {
            if (jumpTimeCounter > 0) {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
        }
    }

    bool isGrounded() {
        bool result1;
        bool result2;
        Vector3 raycastOriginOffset = new Vector3(-bc.size.x, -bc.size.y + 0.05f, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastOriginOffset, -Vector2.up, 0.2f, platformLayer);
        if (hit.collider == null) result1 = false;
        else result1 = true;

        raycastOriginOffset = new Vector3(bc.size.x, -bc.size.y + 0.05f, 0);
        hit = Physics2D.Raycast(transform.position + raycastOriginOffset, -Vector2.up, 0.2f, platformLayer);
        if (hit.collider == null) result2 = false;
        else result2 = true;

        if (result1 == true || result2 == true)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("LoseTrigger")) {
            GameManager.Instance.GameOver();
        }
    }
}
