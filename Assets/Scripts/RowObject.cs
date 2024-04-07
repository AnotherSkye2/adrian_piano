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

	private int rowId;


	private void BoardController_OnRowHit(object sender, BoardController.OnRowHitEventArgs e) {
		if (e.rowId == rowId) {
			if (noteColumnInfoDict.ContainsKey(e.noteColumn)) {
				noteColumnInfoDict[e.noteColumn].NoteHit();
				noteColumnInfoDict.Remove(e.noteColumn);
				OnNoteHitOrMiss?.Invoke(this, new OnNoteHitOrMissEventArgs { noteHit = true });
			} else {
				OnNoteHitOrMiss?.Invoke(this, new OnNoteHitOrMissEventArgs { noteHit = false });
			}
		}
	}

	public void SetRowId(int rowId) {
		this.rowId = rowId;
	}

	public void SetBoardControllerSubscriber(BoardController boardController) {
		boardController.OnRowHit += BoardController_OnRowHit;
	}


}
