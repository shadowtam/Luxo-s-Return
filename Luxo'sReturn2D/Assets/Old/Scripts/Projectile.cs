using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
	public float lifeTime = 3.0f;
	
	public float moveSpeed = 350.0f;
	
	public float damage = 20.0f;
	
	// Start is called before the first frame update
    void Start() {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update() {
        Movement();
    }
	
	private void Movement() {
		
		transform.position += Time.deltaTime * moveSpeed * -transform.up;
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if(other.transform.tag == "Enemy") {
			
			if(other.GetComponent<Enemy>() != null) {
				other.GetComponent<Enemy>().takeDamage(damage);
			} else if (other.GetComponent<Wizard>() != null) {
				other.GetComponent<Wizard>().takeDamage(damage);
			}
			Destroy(this.gameObject);
			
		}
		
	}
	
}
