using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EProjectile : MonoBehaviour, IPooledObject {
    
	public float lifeTime = 3.0f;
	
	public float moveSpeed = 350.0f;
	
	public float damage = 2.0f;
	[SerializeField] bool wizard = false;
	private Rigidbody2D rb;
    [SerializeField] private float spriteDir, lifeTimer;
	// Start is called before the first frame update
    public void OnObjectSpawn() {
        // Destroy(this.gameObject, lifeTime);
		rb = GetComponent<Rigidbody2D>();
		lifeTimer = Time.time + lifeTime;
    }

    // Update is called once per frame
    void Update() {
        Movement();
		if(lifeTimer < Time.time) {
			this.gameObject.SetActive(false);
		}
    }
	
	internal void Movement() {
		if(wizard) {

			Vector2 playerLoc = GameManager.instance.player.transform.position;
			Vector2 lookDir = playerLoc - rb.position;
			float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - spriteDir;
			rb.rotation = angle;

		}
		transform.position += Time.deltaTime * moveSpeed * -transform.up;
		
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		
		if(other.transform.tag == "Player") {
			
			other.GetComponent<Player>().takeDamage(damage);
			
			// Destroy(this.gameObject);
			this.gameObject.SetActive(false);
			
		}
		
	}
	
}
