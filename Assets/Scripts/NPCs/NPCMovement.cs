using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour {
    
    public float moveSpeed;
    private Rigidbody2D chickenRigidBody;
    private bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;
    public Collider2D walkArea;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkArea;

    [Header("Dependencies")]
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start() {
        chickenRigidBody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseRandomDirection();

        if(walkArea != null) {
            minWalkPoint = walkArea.bounds.min;
            maxWalkPoint = walkArea.bounds.max;
            hasWalkArea = true;
        }
    }

    void Update() {

        if(isWalking) {
            animator.SetBool("isWalking", true);
            walkCounter -= Time.deltaTime;

            switch(walkDirection) {
                case 0:
                    chickenRigidBody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkArea && transform.position.y > maxWalkPoint.y) {
                        StopWalk();
                    }
                    break;
                case 1:
                    if (PlayerIsLookingLeft()) { // Moving to the right
                        spriteRenderer.flipX = false;
                    }
                    chickenRigidBody.velocity = new Vector2(moveSpeed, 0);
                    if(hasWalkArea && transform.position.x > maxWalkPoint.x) {
                        StopWalk();
                    }
                    break;
                case 2:
                    chickenRigidBody.velocity = new Vector2(0, -moveSpeed);
                    if(hasWalkArea && transform.position.y < minWalkPoint.y) {
                        StopWalk();
                    }
                    break;
                case 3:
                    if (!PlayerIsLookingLeft()) { // Moving to the left
                        spriteRenderer.flipX = true;
                    }
                    chickenRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    if(hasWalkArea && transform.position.x < minWalkPoint.x) {
                        StopWalk();
                    }
                    break;
            }

            if(walkCounter < 0) {
                StopWalk();
            }
        }
        else {
            animator.SetBool("isWalking", false);
            waitCounter -= Time.deltaTime;

            chickenRigidBody.velocity = Vector2.zero;

            if(waitCounter < 0) {
                ChooseRandomDirection();
            }
        }
    }

    private void ChooseRandomDirection() {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

    private void StopWalk() {
        isWalking = false;
        waitCounter = waitTime;
    }

    private bool PlayerIsLookingLeft() {
        return spriteRenderer.flipX;
    }
}
