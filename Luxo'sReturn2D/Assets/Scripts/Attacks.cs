using System;
using LuxosReturn;
using UnityEngine;

public class Attacks : MonoBehaviour {
    [SerializeField] internal bool specialAttack;

    [SerializeField]private GameObject fireBall, lightningBall, acidBall, coldBall;
    private float fireTime;

    [SerializeField] float fireRate, saDuration, saTimer;
    [SerializeField] internal PickupType currentType;

    PoolManager pm;

    private void Awake() {
        pm = PoolManager.Instance;
    }

    internal void Shoot() {
        if(specialAttack) {
            if (saTimer < Time.time) {
                specialAttack = false;
            }
            switch (currentType) {
                case PickupType.LIGHTNING:
                    Lightning();
                    return;

                case PickupType.ACID:
                    Acid();
                    return;

                case PickupType.COLD:
                    Cold();
                    return;

                default:
                    return;
            }
        } else {
            Fireball();
        }
    }

    private void Acid() {
        if(Time.time > fireTime) {
			
			// Instantiate(acidBall, transform.position, transform.rotation);
			pm.SpawnFromPool("Acid",transform.position, transform.rotation);
			fireTime = Time.time + fireRate;
		
		}
    }

    private void Lightning() {
        if(Time.time > fireTime) {
			
			// Instantiate(lightningBall, transform.position, transform.rotation);
			pm.SpawnFromPool("Lightning",transform.position, transform.rotation);
			fireTime = Time.time + fireRate;
		
		}
    }

    void Fireball() {
        if(Time.time > fireTime) {
			
			// Instantiate(fireBall, transform.position, transform.rotation);
			pm.SpawnFromPool("Fireball",transform.position, transform.rotation);
			fireTime = Time.time + fireRate;
		
		}
    }

    internal void Cold() {
        if(Time.time > fireTime) {
			
			// Instantiate(coldBall, transform.position, transform.rotation);
			pm.SpawnFromPool("Cold",transform.position, transform.rotation);
			fireTime = Time.time + fireRate;
		
		}
    }

    internal void activateSA(PickupType type) {
        specialAttack = true;
        saTimer = Time.time + saDuration;
        switch(type){
            case PickupType.LIGHTNING:
                currentType = PickupType.LIGHTNING;
            return;

            case PickupType.ACID:
                currentType = PickupType.ACID;
            return;

            case PickupType.COLD:
                currentType = PickupType.COLD;
            return;

            default:
            return;
        }
    }
}