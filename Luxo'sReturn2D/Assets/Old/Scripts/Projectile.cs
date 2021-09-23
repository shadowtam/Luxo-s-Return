using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuxosReturn;
using System;

public class Projectile : MonoBehaviour, IPooledObject {
    
	#region Variables
	public float lifeTime = 3.0f;
	
	public float moveSpeed = 350.0f;
	
	public float damage = 20.0f;
    [SerializeField] private float lifeTimer, curTime;

    [SerializeField] PickupType type;
    [SerializeField] GameObject[] Enemies;

    [SerializeField] GameObject lTargeter;
    Rigidbody2D rb;
    [SerializeField] bool specialAttack;
    private bool bouncing;
	RadiusIncrease ri;
	[SerializeField] GameObject[] pickups;

    [SerializeField] int pickupDropChance;

    #endregion

    // Start is called before the first frame update

    public void OnObjectSpawn() {
        // Destroy(this.gameObject, lifeTime);
		lifeTimer = Time.time + lifeTime;
		rb = GetComponent<Rigidbody2D>();
		if(specialAttack && (type == PickupType.LIGHTNING)) {
			ri = lTargeter.GetComponent<RadiusIncrease>();
			ri.col.radius = 0;
			ri.lBounces = 0;
			lTargeter.SetActive(false);
			this.GetComponent<Collider2D>().enabled = true;
			this.GetComponent<SpriteRenderer>().enabled = true;

		}
    }

    // Update is called once per frame
    void Update() {
        Movement();
		curTime = Time.time;
		if(lifeTimer < Time.time) {
			this.gameObject.SetActive(false);
		}
		if(type == PickupType.LIGHTNING && specialAttack) {
			if(ri.lBounces > ri.lBounceMax) {
				this.gameObject.SetActive(false);
			}
		}
    }
	
	private void Movement() {
		// }
		transform.position += Time.deltaTime * moveSpeed * -transform.up;
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
			Damage(other);
			if(specialAttack) {
				switch(type) {
					case PickupType.LIGHTNING:
						Lightning(other);
					return;

					case PickupType.ACID:
						Acid();
					return;

					case PickupType.COLD:
						Cold();
					return;
				}
			}
			this.gameObject.SetActive(false);
        }
    }

    private void Cold() {
        throw new NotImplementedException();
    }

    private void Acid() {
        throw new NotImplementedException();
    }

    private void Lightning(Collider2D other) {
		this.GetComponent<Collider2D>().enabled = false;
		this.GetComponent<SpriteRenderer>().enabled = false;
		lTargeter.SetActive(true);
		lTargeter.transform.position = transform.position;
		lTargeter.GetComponent<CircleCollider2D>().radius = 0;
    }

    internal void Damage(Collider2D other) {
        if(!specialAttack){
			System.Random rand  = new System.Random();
			if(rand.Next(0, pickupDropChance) == 0){
				Instantiate(pickups[rand.Next(0,3)], transform.position, new Quaternion());
			}
		}
    	if(other.GetComponent<Enemy>() != null) {
			other.GetComponent<Enemy>().takeDamage(damage);
		} else if (other.GetComponent<Wizard>() != null) {
			other.GetComponent<Wizard>().takeDamage(damage);
		}
    }

    // GameObject GetClosestEnemy (GameObject[] enemies) {
    //     GameObject bestTarget = null;
    //     float closestDistanceSqr = Mathf.Infinity;
    //     Vector3 currentPosition = transform.position;
    //     foreach(GameObject potentialTarget in enemies)
    //     {
    //         Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
    //         float dSqrToTarget = directionToTarget.sqrMagnitude;
    //         if(dSqrToTarget < closestDistanceSqr) {
    //             closestDistanceSqr = dSqrToTarget;
    //             bestTarget = potentialTarget;
    //         }
    //     }
     
    //     return bestTarget;
    // }
	
}
