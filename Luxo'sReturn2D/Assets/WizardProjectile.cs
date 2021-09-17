using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float spriteDir;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        print("projectile spawned");
    }

    internal void Movement() {
		// if(GameManager.instance.player) {
		// 	Look();
			
		// }
		transform.position += Time.deltaTime * moveSpeed * -transform.up;
		
	}

    internal void Look() {
		Vector2 playerLoc = GameManager.instance.player.transform.position;
        Vector2 lookDir = playerLoc - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - spriteDir;
        rb.rotation = angle;
    }

    public float lifeTime = 3.0f;
	
	public float moveSpeed = 350.0f;
	
	public float damage = 2.0f;
	
	// Start is called before the first frame update
    void Start() {
        Destroy(this.gameObject, lifeTime);
    }
	
	private void OnTriggerEnter2D(Collider2D other) {
		
		if(other.transform.tag == "Player") {
			
			other.GetComponent<Player>().takeDamage(damage);
			
			Destroy(this.gameObject);
			
		}
		
	}
}
