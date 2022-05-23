using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float moveSpeed;
    private Vector2 movement;

    private Rigidbody2D rbody;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        if(movement == Vector2.zero) return;
        rbody.MovePosition(rbody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
