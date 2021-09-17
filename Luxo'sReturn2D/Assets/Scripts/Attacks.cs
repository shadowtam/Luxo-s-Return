using System;
using UnityEngine;

public class Attacks : MonoBehaviour {
    [SerializeField] internal bool specialAttack;
    [SerializeField] internal String sAName;
    [SerializeField]private GameObject fireBall, lightningBall, acidBall, windBall;
    private float fireTime;

    [SerializeField] float fireRate;

    internal void Shoot() {
        if(specialAttack) {
            if(sAName.Equals("Lightning")) {
                Lightning();
            } else if(sAName.Equals("Acid")) {
                Acid();
            } else if(sAName.Equals("Wind")) {
                Wind();
            } else {}
        } else {
            Fireball();
        }
    }

    private void Wind() {
        throw new NotImplementedException();
    }

    private void Acid() {
        throw new NotImplementedException();
    }

    private void Lightning() {
        throw new NotImplementedException();
    }

    void Fireball() {
        if(Time.time > fireTime) {
			
			Instantiate(fireBall, transform.position, transform.rotation);
			
			fireTime = Time.time + fireRate;
		
		}
    }
}