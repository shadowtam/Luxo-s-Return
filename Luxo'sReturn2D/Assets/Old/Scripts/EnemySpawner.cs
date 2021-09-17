using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    
	public GameObject enemy;
	
	public float spawnMove = 1.0f;
	
	public float spawnRate = 2.0f;
	private float spawnTimer;
	public float startTimer;
	
	public float My;
	public float mY;
	public float Mx;
	public float mX;

	
	public bool moveY;
	public bool moveX;
	
	private Vector3 pos;
	
	private bool dir = true;
	
	// Start is called before the first frame update
    void Start() {
        
		startTimer += Time.time + 5;
		
    }

    // Update is called once per frame
    void Update() {
		
		if(Time.time > startTimer) {
			
			if(GameManager.instance.player.GetComponent<Player>().getEnd()) {
				
				Destroy(this.gameObject);
				
			}
			
			pos = transform.position;
			
			SpawnEnemy();
			Movement();
			
			transform.position = pos;
			
		}
	
	}
	
	private void SpawnEnemy() {
		
		if(Time.time > spawnTimer) {
		
			if(GameManager.instance.numEnemies < GameManager.instance.maxEnemies) {
		
				Instantiate(enemy, transform.position, transform.rotation);
				
				spawnTimer = Time.time+ spawnRate;
			
				GameManager.instance.ManageEnemies(1);
				
			}
			
		}
		
	}
	
	private void Movement() {
		
		if(moveY) {
			if (dir) {
				pos.y += Time.deltaTime * spawnMove;
			} else if (!dir) {
				pos.y -= Time.deltaTime * spawnMove;
			}
			
			if(pos.y >= mY && dir) {
				dir = false;
			} else if(pos.y <= My && !dir) {
				dir = true;
			} 
			
		} 
		if(moveX) {
			
			if (dir) {
				pos.x += Time.deltaTime * spawnMove;
			} else if (!dir) {
				pos.x -= Time.deltaTime * spawnMove;
			}
			
			if(pos.x >= mX && dir) {
				dir = false;
			} else if(pos.x <= Mx && !dir) {
				dir = true;
			} 
			
		}
		
		
	}
	
}
