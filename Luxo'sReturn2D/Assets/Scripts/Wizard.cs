using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy {
    
    // Update is called once per frame
    void Update() {
        Movement();
        
    }

    private void Shoot() {
		if(Time.time > fireTime) {
			
			// Instantiate(projectile, transform.position, transform.rotation);
            PoolManager.Instance.SpawnFromPool("WizardProjectile",transform.position, transform.rotation);
			fireTime = Time.time + fireRate;
		
		}
    }

    private void Movement() {
        position = transform.position;

        if(GameManager.instance.player)
			Look();
		position.y += -transform.up.y * moveSpeed * Time.deltaTime;

        transform.position = position;
        Shoot();
    }
}
