using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravityValue = 7.0f;

    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private int platformLayer;

    public float maxJumpTime = 0.7f;
    private float jumpTimeCounter;
    private bool isJumping;

    public float isGroundedRememberTime = 0.15f;
    private float isGroundedRemember;

    void Start() {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        platformLayer = LayerMask.GetMask("Platform");
        isJumping = false;
        isGroundedRemember = 0;
        rb.gravityScale = 0;
    }

    void FixedUpdate() {
        if (GameManager.Instance.gameIsRunning == true)
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
    }

    void Update() {
        isGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded() || isGroundedRemember > 0)) {
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
        if (isGroundedRemember > 0)
            isGroundedRemember -= Time.deltaTime;

        bool result1;
        bool result2;
        Vector3 raycastOriginOffset = new Vector3(-(bc.size.x), -bc.size.y + 0.05f, 0);
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastOriginOffset, -Vector2.up, 0.2f, platformLayer);
        if (hit.collider == null) result1 = false;
        else result1 = true;

        raycastOriginOffset = new Vector3(bc.size.x, -bc.size.y + 0.05f, 0);
        hit = Physics2D.Raycast(transform.position + raycastOriginOffset, -Vector2.up, 0.2f, platformLayer);
        if (hit.collider == null) result2 = false;
        else result2 = true;

        if (result1 == true || result2 == true) {
            isGroundedRemember = isGroundedRememberTime;
            return true;
        } else
            return false;
    }

    public void EnableGravity() {
        rb.gravityScale = gravityValue;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("LoseTrigger")) {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("WinTrigger")) {
            GameManager.Instance.Win();
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Pickup")) {
            Pickup p = col.gameObject.GetComponent<Pickup>();
            GameManager.Instance.AddScore(p.scoreValue);
            p.DestroyPickup();
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Milestone")) {
            Milestone m = col.gameObject.GetComponent<Milestone>();
            moveSpeed += m.speedIncrease;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == LayerMask.NameToLayer("Platform")) {
            Platform p = col.gameObject.GetComponent<Platform>();
            p.ChangeSprite();
        }
    }
}
