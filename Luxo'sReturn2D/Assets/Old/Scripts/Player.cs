using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	GameManager GM;
	
	private Vector3 position;
	
	public int streak = 0;
	public float healthTime;
		
	public float healthM;
	[SerializeField]float health;
	public float regen;
	
	public GameObject deathEffect;
    // Start is called before the first frame update
    void Start() {
       GM = GameManager.instance;
	   health = healthM;
	   
    }

    // Update is called once per frame
    void Update() {
		
		
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
				GM.ChangeScore(10, 0);
				streak = 0;
			}
		}
		
			
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
			
			GM.setEnd(true);
			Instantiate(deathEffect, transform.position,transform.rotation);
			
		}
		float x = (damage / 100);
		
		
	}
	
	
	
	public float getHealth() {
		return health;
	}
	
}
