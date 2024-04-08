using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    [SerializeField] private BoardController boardController;
	public int scoreCount;
	void Start() {
		boardController.OnNoteHitOrMissScore += BoardController_OnNoteHitOrMissScore;
	}

	private void BoardController_OnNoteHitOrMissScore(object sender, BoardController.OnNoteHitOrMissScoreEventArgs e) {
		if (e.noteHit) {
			scoreCount++;
		}
		else {
			scoreCount--;
		}
	}
}
