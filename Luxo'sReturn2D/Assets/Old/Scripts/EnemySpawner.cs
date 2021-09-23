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
	GameManager GM;
	
	// Start is called before the first frame update
    void Start() {
        GM = GameManager.instance;
		startTimer += Time.time + Random.Range(0,8);;
		
    }

    // Update is called once per frame
    void Update() {
		
		if(Time.time > startTimer) {
			
			if(GameManager.instance.getEnd()) {
				
				Destroy(this.gameObject);
				
			}
			
			// pos = transform.position;
			
			SpawnEnemy();
			// Movement();
			
			// transform.position = pos;
			
		}
	
	}
	
	private void SpawnEnemy() {
		
		if(Time.time > spawnTimer) {
		
			if(GameManager.instance.numEnemies < GameManager.instance.maxEnemies) {
				
				Vector2 pos;
				int i = Random.Range(0,2);
				if(i == 0) {
					i = Random.Range(0,2);
					if(i == 0) {
						pos = new Vector2(Random.Range(GM.bound.x, GM.bound.y), GM.bound.z);
					} else{
						pos = new Vector2(Random.Range(GM.bound.x, GM.bound.y), GM.bound.w);
					}
				} else{
					i = Random.Range(0,2);
					if(i == 0) {
						pos = new Vector2(GM.bound.x,Random.Range(GM.bound.z, GM.bound.w));
					} else{
						pos = new Vector2(GM.bound.y,Random.Range(GM.bound.z, GM.bound.w));
					}
				}

				GameObject thisEnemy = Instantiate(enemy, pos, transform.rotation);
				thisEnemy.transform.parent = transform;
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
