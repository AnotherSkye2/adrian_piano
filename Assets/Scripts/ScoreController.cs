using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    [SerializeField] private RowObject rowObject;
	public int scoreCount;
	void Start() {
		rowObject.OnNoteHitOrMiss += RowObject_OnNoteHitOrMiss;
	}

	private void RowObject_OnNoteHitOrMiss(object sender, RowObject.OnNoteHitOrMissEventArgs e) {
        if (e.noteHit) {
			scoreCount++;
		}
	}
}
