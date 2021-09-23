using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;
	
	#region Variables
	[SerializeField] int scoreCalc = 300;//maxEnemies calculation seed
	[SerializeField] internal int numEnemies = 0;//Current number of enemies
	[SerializeField] internal int maxEnemies = 4;//Maximum number of enemies
	
	[SerializeField] internal float xBoundary = 95;//
	[SerializeField] internal float zBoundary = 35;//
	
	[SerializeField] internal GameObject player;//Reference to player object
	[SerializeField] Player playerCS;//Reference to Player script on player object
	[SerializeField] int score;//current game scpre
	[SerializeField] bool end = false;//Game over bool
	
	[SerializeField] float scoreRate = 1.0f;//Rate player gains passive score
	float scoreTime = 2;//Stores score timer time
	[SerializeField] TMP_Text scoreTXT, endScore;//TMP_Text fields for score
	[SerializeField] GameObject endUI;//UI for game over screen

	[SerializeField] GameObject[] bounds;//screen boundry markers
	[SerializeField] internal Vector4 bound;//screen boundry in world space
	DeviceOrientation orientation;

	#endregion
	
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
		playerCS = player.GetComponent<Player>();
		endUI.SetActive(false);
    }

	private void Start() {
		RecalculateBounds();
	}
	
	void Update() {
		if(orientation != Input.deviceOrientation) {
			RecalculateBounds();
			orientation = Input.deviceOrientation;
		}
		//Debug.Log(numEnemies);
		if (maxEnemies < 50){
			if(score > scoreCalc) {
				scoreCalc += 100;
				maxEnemies++;
			}
		}

		if(Time.time > scoreTime && !end) {
			
			score++;
			scoreTime = Time.time + scoreRate;
			
		}

		if(!end){
			scoreTXT.text = "Score: " + score;
		} else{
			endUI.SetActive(true);
			endScore.text = "" + score;
		}

	}

    private void RecalculateBounds() {
        float x,y,z,w;
		x = Camera.main.ScreenToWorldPoint(bounds[0].transform.position).x - 1;
		y = Camera.main.ScreenToWorldPoint(bounds[1].transform.position).x + 1;
		z = Camera.main.ScreenToWorldPoint(bounds[2].transform.position).y - 0.5f;
		w = Camera.main.ScreenToWorldPoint(bounds[3].transform.position).y + 0.5f;

		bound = new Vector4(x, y, z, w);
    }

    internal void ManageEnemies(int mod) {

		numEnemies += mod;
		if(numEnemies < 0) {
			numEnemies = 0;
		}
		
	}

    internal void setEnd(bool END) {
        end = END;
    }

    internal void ChangeScore(int addScore, int addStreak) {
		
		score += addScore;
		playerCS.streak += addStreak;
		
	}

	internal int getScore() {
		return score;
	}
	
	internal bool getEnd() {
		
		return end;
		
	}

	
}
