using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChange : MonoBehaviour {
    
	public static GameManager instance = null;
	public float health;
	public float healthM;
	public Vector3 goldSize;
	bool healthy = false;
	
	void Start() {
		healthM = GameManager.instance.player.GetComponent<Player>().getHealth();
	}

    // Update is called once per frame
    void Update() {
		if(!healthy) {
			healthM = GameManager.instance.player.GetComponent<Player>().getHealth();
			healthy = true;
		}
        health = GameManager.instance.player.GetComponent<Player>().getHealth();
		if(health <= healthM && health > 0){
			float xy =(health / healthM);
			goldSize = new Vector3 (xy, xy, 0);
			transform.localScale = goldSize;
		}
    }
}
