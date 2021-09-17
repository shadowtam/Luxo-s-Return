using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    static public int score = 0;    // this is reachable from everywhere
	public void setScore(int sc) {
		score = sc;
	}
}
