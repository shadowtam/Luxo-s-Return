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
        print("im going to Shoot");
		if(Time.time > fireTime) {
			
			Instantiate(projectile, transform.position, transform.rotation);
			print("Shooting");
			fireTime = Time.time + fireRate;
		
		}
        print("shot");
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
