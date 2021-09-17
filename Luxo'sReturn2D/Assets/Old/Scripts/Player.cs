using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	public float moveSpeed = 50.0f;
	
	private Vector3 position;
	
	public GameObject projectile;
	public float fireRate = 0.15f;
	private float fireTime;
	
	public int score = 0;
	public int streak = 0;
	public float scoreRate = 1.0f;
	public float scoreTime;
	public float healthTime;
		
	public float healthM;
	[SerializeField]float health;
	public float regen;
	
	public GUIStyle ScoreGUI;
	
	public GameObject deathEffect;
	public GameObject gold;
	public GameObject goScreen;
	
	
	
	public Camera mCam;
	
	public bool end = false;
	
    // Start is called before the first frame update
    void Start() {
       
	   health = healthM;
	   
    }

    // Update is called once per frame
    void Update() {
		
		goScreen.SetActive(end);
		
		if(Time.time > scoreTime && !end) {
			
			score++;
			scoreTime = Time.time + scoreRate;
			
		}
		
		// goldSize = gold.gameObject.transform.localScale;
		
        position = transform.position;
		
		// Movement();
		
		// Boundary();
		
		transform.position = position;
		// gold.gameObject.transform.localScale = goldSize;
		
		// Shoot();
		
		// FaceMouse();
		
		if(streak / 3 > 0) {
			if(Time.time > healthTime) {
				if(health < healthM - regen) {
					health += regen;
					//float x = (20 / 500);
					// goldSize += new Vector3 (x, x, 0);
				} else if (health >= healthM - regen) {
					health = healthM;
					// goldSize = new Vector3 (10, 10, 0);
				}
				score += 10;
				streak = 0;
			}
		}
		
		// changeGold();
			
	}
	
	public bool getEnd() {
		
		return end;
		
	}
	
	private void Shoot() {
		
 		// if(Input.GetMouseButton(0) && Time.time > fireTime) {
			
		// 	Instantiate(projectile, transform.position, transform.rotation);
			
		// 	fireTime = Time.time + fireRate;
		
		// }
		
	}
	
	private void Movement() {
		
		// if(Input.GetKey("d")) {
		// 	position.x += moveSpeed * Time.deltaTime;
		// }
		
		// if(Input.GetKey("a")) {
		// 	position.x -= moveSpeed * Time.deltaTime;
		// }
		
		// if(Input.GetKey("w")) {
		// 	position.z += moveSpeed * Time.deltaTime;
		// }
		
		// if(Input.GetKey("s")) {
		// 	position.z -= moveSpeed * Time.deltaTime;
		// }
		
	}
	
	private void Boundary() {
		
		if(position.x > GameManager.instance.xBoundary) {
			position.x = GameManager.instance.xBoundary;
		} else if (position.x < -GameManager.instance.xBoundary) {
			position.x = -GameManager.instance.xBoundary;
		}
		
		if(position.z > GameManager.instance.zBoundary) {
			position.z = GameManager.instance.zBoundary;
		} else if (position.z < -GameManager.instance.zBoundary) {
			position.z = -GameManager.instance.zBoundary;
		}
		
	}
	
	public void takeDamage(float damage) {
		
		health -= damage;
		streak = 0;
		
		if(health <= 0) {
			
			end = true;
			Instantiate(deathEffect, transform.position,transform.rotation);
			
		}
		float x = (damage / 100);
		
		
	}
	
	public void ChangeScore(int addScore, int addStreak) {
		
		score += addScore;
		streak += addStreak;
		
	}
	
	void FaceMouse() {
		
		// Ray cameraRay = mCam.ScreenPointToRay(Input.mousePosition);
		// Plane gPlane = new Plane(Vector3.up, Vector3.zero);
		// float rayLength;
		
		// if(gPlane.Raycast(cameraRay, out rayLength)) {
		// 	Vector3 lookHere = cameraRay.GetPoint(rayLength);
		// 	transform.LookAt(new Vector3(lookHere.x, transform.position.y, lookHere.z));
		// }
		
		
	}
	
	public int getScore() {
		return score;
	}
	
	public float getHealth() {
		return health;
	}
	
	void OnGUI() {
		if(!end) {
			GUI.Label(new Rect (5, 5, Screen.width, 20), "Score: " + score, ScoreGUI);
		}
		
		
	}
	
}
