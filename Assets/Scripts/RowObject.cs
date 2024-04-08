using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowObject : MonoBehaviour {

	public event EventHandler<OnNoteHitOrMissEventArgs> OnNoteHitOrMiss;
	public class OnNoteHitOrMissEventArgs : EventArgs {
		public bool noteHit;
	}

	public Dictionary<int, NoteObject> noteColumnInfoDict = new Dictionary<int, NoteObject>();

	private BoardController boardController;
	private bool subscribed;
	private float rowSpeed;
	private Vector3 boardTrigger = new Vector3(0, -1, 0);
	private Vector3 boardEntryPoint = new Vector3(0, 5, 0);

	private void Update() {
		if (transform.position.y <= boardEntryPoint.y && !subscribed) {
			boardController.OnRowHit += BoardController_OnRowHit;
			subscribed = true;
		}
		MoveRow();
	}

	private void BoardController_OnRowHit(object sender, BoardController.OnRowHitEventArgs e) {
		if (transform.position.y <= boardTrigger.y + 0.5f && transform.position.y >= boardTrigger.y - 0.5f) {
			if (noteColumnInfoDict.ContainsKey(e.noteColumn)) {
				noteColumnInfoDict[e.noteColumn].NoteHit();
				noteColumnInfoDict.Remove(e.noteColumn);
				OnNoteHitOrMiss?.Invoke(this, new OnNoteHitOrMissEventArgs { noteHit = true });
			} else {
				OnNoteHitOrMiss?.Invoke(this, new OnNoteHitOrMissEventArgs { noteHit = false });
			}
		}
	}

	private void MoveRow() {
		transform.position += -transform.up * rowSpeed * Time.deltaTime;
	}


	public void SetRowData(float rowSpeed, BoardController boardController) {
		this.rowSpeed = rowSpeed;
		this.boardController = boardController;
	}

}
