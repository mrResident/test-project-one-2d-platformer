using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Author: Alexandrov Alexander Alexandrovich
Date: 25/10/2019

Script that implement player character controller
*/
public class PlayerController : MonoBehaviour {

    public Transform playerCamera;
    public float speed = 250.0f;
    public float jumpForce = 12.0f;
    private Rigidbody2D _body;
    private BoxCollider2D _box;
    private Vector3 _camPos;

    void Start() {
        _body = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        _camPos = playerCamera.transform.position;
    }

    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;

        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;

        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);

        bool grounded = false;
        if (hit != null) {
            grounded = true;
        }

        _body.gravityScale = grounded && deltaX == 0 ? 0 : 1;

        if (grounded && Input.GetKeyDown(KeyCode.Space)) {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        MovingPlatform platform = null;

        if (hit != null) {
            platform = hit.GetComponent<MovingPlatform>();
        }

        //Checking if player character stay out on moving platform
        if (platform != null) {
            transform.parent = platform.transform;
        } else {
            transform.parent = null;
        }

        Vector3 pScale = Vector3.one;
    
        if (deltaX != 0) {
            transform.localScale = new Vector3(Mathf.Sign(deltaX)/pScale.x, 1/pScale.y, 1);
        }

        //Checking for player character moving out of screen edge.
        if (transform.position.x > playerCamera.transform.position.x + 9) {
            _camPos.x = _camPos.x + 18;
            playerCamera.transform.position = _camPos;
            playerCamera.GetComponentInChildren<SpriteRenderer>().flipX = !playerCamera.GetComponentInChildren<SpriteRenderer>().flipX;
        } else if (transform.position.x < playerCamera.transform.position.x - 9) {
            _camPos.x = _camPos.x - 18;
            playerCamera.transform.position = _camPos;
            playerCamera.GetComponentInChildren<SpriteRenderer>().flipX = !playerCamera.GetComponentInChildren<SpriteRenderer>().flipX;
        }
    }
}
