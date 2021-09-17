using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public float moveSpeed = 65.0f;
	public float health = 20.0f;
	
	public float damage;
	public float damageRate = 0.2f;
	public float damageTime;
	
	public float fireRate = 0.15f;
	internal float fireTime;
	public GameObject projectile;
	
	public GameObject deathEffect;
	
	public System.String race;
	
	internal Vector3 position;
	public Vector3 origin;

    internal Rigidbody2D rb;

    [SerializeField] internal float spriteDir;

	private void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

    // Start is called before the first frame update
    void Start() {
		rb = GetComponent<Rigidbody2D>();
        
		if(race == "Orc"){
			if(GameManager.instance.player) {
				Look();
			}
		}
		
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.instance.player.GetComponent<Player>().getEnd()) {
			
			Destroy(this.gameObject);
			
		}
		position = transform.position;
		
		if(race == "Orc") {
			
			position = transform.position;
			OMovement();
			
		} else if(race == "Dwarf") {
			
			DMovement();
			
		} else if(race == "Elf") {
			
			EMovement();
			
		} else if(race == "Human") {
			
			HMovement();
			
		}
		
		transform.position = position;
		
		
    }
	
	private void DMovement() {
		
		if(GameManager.instance.player) {
			Look();
		}
		
		position += transform.up * moveSpeed * Time.deltaTime;
		Boundary();
		
	}

    internal void Look() {
		Vector2 playerLoc = GameManager.instance.player.transform.position;
        Vector2 lookDir = playerLoc - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - spriteDir;
        rb.rotation = angle;
    }

    private void OMovement() {
		
		position += transform.up * moveSpeed * Time.deltaTime;
		Boundary();		
		
	}
	
	private void EMovement() {
			
		if(GameManager.instance.player) {
			
			Look();
			
		}
		
		position.y += -transform.up.y * moveSpeed * Time.deltaTime;
		Shoot();
		
		Boundary();
		
	}
	
	private void HMovement() {
		
		if(GameManager.instance.player) {
			Look();
		}		
		Shoot();
		Boundary();
		
	}
	
	
	private void Boundary() {
		
		if(position.x > (GameManager.instance.xBoundary + 41) || position.x < -(GameManager.instance.xBoundary + 41) || position.z > GameManager.instance.zBoundary || position.z < -GameManager.instance.zBoundary) {
			Destroy(this.gameObject);
			GameManager.instance.ManageEnemies(-1);
		} 
		
	}
	
	
	public void takeDamage(float damage) {
		
		health -= damage;
		
		if(health <= 0) {
			
			GameManager.instance.player.GetComponent<Player>().ChangeScore(3, 1);
			Destroy(this.gameObject);
			Instantiate(deathEffect, transform.position,transform.rotation);
			GameManager.instance.ManageEnemies(-1);
			
		}
		
	}
	
	private void OnTriggerStay2D(Collider2D other) {
		
		
		if(other.transform.tag == "Player" && Time.time > damageTime) {
			
			other.GetComponent<Player>().takeDamage(damage);
			damageTime = Time.time + damageRate;
			Destroy(this.gameObject);
			Instantiate(deathEffect, transform.position,transform.rotation);
			GameManager.instance.ManageEnemies(-1);
			
		}
		
	}
	
	private void Shoot() {
		
		if(Time.time > fireTime) {
			
			Instantiate(projectile, transform.position, transform.rotation);
			
			fireTime = Time.time + fireRate;
		
		}
		
	}
	
}
