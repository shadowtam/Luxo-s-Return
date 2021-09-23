using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
		
	public void menuOnClick() {
		
		SceneManager.LoadScene("Menu");
		
	}
	
	public void playOnClick() {
		
		SceneManager.LoadScene("Transition");
		
	}
	
	public void instOnClick() {
		
		SceneManager.LoadScene("Inst");
		
	}
	
	public void exitOnClick() {
		
		Application.Quit();
		
	}
}
