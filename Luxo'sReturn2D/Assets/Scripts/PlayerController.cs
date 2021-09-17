using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    private PlayerControls playerControls;
    private Attacks attacks;
    [SerializeField] private float speed;
    private Touch touch;
    Vector2 fingerSPos;
    Vector2 fingerWPos;
    Rigidbody2D rb;
    [SerializeField] int spriteDir;
    [SerializeField] GameObject boundTop, boundLeft;
    private Vector2 XBound, YBound;

    void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        attacks = GetComponent<Attacks>();
    }

    private void Start() {

    }

    void OnEnable() {
        playerControls.Enable();
    }

    void OnDisable() {
        playerControls.Disable();
    
    }

    void Update() {
        
        Movement();
        LookFinger();
        CheckShoot();

    }

    private void LookFinger() {
        if(CheckTouchBounds(playerControls.Touch.TouchPos0.ReadValue<Vector2>())){
            fingerSPos = playerControls.Touch.TouchPos0.ReadValue<Vector2>();
        } else if(CheckTouchBounds(playerControls.Touch.TouchPos1.ReadValue<Vector2>())){
            fingerSPos = playerControls.Touch.TouchPos1.ReadValue<Vector2>();
        } else {
            return;
        }
        
        fingerWPos = Camera.main.ScreenToWorldPoint(fingerSPos);
        
        Vector2 lookDir = fingerWPos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - spriteDir;
        rb.rotation = angle;


    }

    private bool CheckTouchBounds(Vector2 pos){
        
        bool inBounds = false;
        pos = Camera.main.ScreenToWorldPoint(pos);
        float touchBound = Camera.main.ScreenToWorldPoint(boundLeft.transform.position).x;
        if(pos.x > touchBound) {
            inBounds = true;
        }
        return inBounds;
    }

    private void CheckShoot() {
        bool inBounds = false;
        if(CheckTouchBounds(playerControls.Touch.TouchPos0.ReadValue<Vector2>()) || CheckTouchBounds(playerControls.Touch.TouchPos1.ReadValue<Vector2>())){
            inBounds = true;
        }

        bool touching = false;
        if(playerControls.Touch.Tap.ReadValue<float>() == 1) {
            touching = true;
        }
        if(playerControls.Touch.Tap.ReadValue<float>() == 0){
            touching = false;
        }

        
        if(inBounds && touching) {
            attacks.Shoot();
        }

    }

    private void Movement() {
        Vector2 movementInput = playerControls.Player.Movement.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        if(CheckXBounds(currentPosition.x)){
            currentPosition.x += movementInput.x * speed * Time.deltaTime;
        } else {
            if(currentPosition.x > XBound.x ){
                currentPosition.x -= 0.01f;
            } else {
                currentPosition.x += 0.01f;
            }
        }
        if(CheckYBounds(currentPosition.y)){
            currentPosition.y += movementInput.y * speed * Time.deltaTime;
        } else {
            if(currentPosition.y > -YBound.x ){
                currentPosition.y -= 0.01f;
            } else {
                currentPosition.y += 0.01f;
            }
        }
        transform.position = currentPosition;
    }

    private bool CheckXBounds(float pos) {
        bool inBounds = false;
        
        XBound.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        XBound.y = Camera.main.ScreenToWorldPoint(boundLeft.transform.position).x;
        if((pos < XBound.x) && (pos > XBound.y)) {
            inBounds = true;
        }
        return inBounds;
    }

    private bool CheckYBounds(float pos) {
        bool inBounds = false;

        YBound.x = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        YBound.y = Camera.main.ScreenToWorldPoint(boundTop.transform.position).y;
        
        if((pos > -YBound.x) && (pos < YBound.y)) {
            inBounds = true;
        }
        return inBounds;
    }
}
