using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;
	
	private int scoreCalc = 300;
	public int numEnemies = 0;
	public int maxEnemies = 4;
	
	public float xBoundary = 95;
	public float zBoundary = 35;
	
	public GameObject player;
	
    // Awake Checks - Singleton setup
    void Awake() {

        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }
	
	void Update() {
		//Debug.Log(numEnemies);
		if (maxEnemies < 50){
			if(player.GetComponent<Player>().score > scoreCalc) {
				scoreCalc += 100;
				maxEnemies++;
				Debug.Log(maxEnemies);
			}
		}

	}
	
	public void ManageEnemies(int mod) {
		
		numEnemies += mod;
		
	}

	
}
