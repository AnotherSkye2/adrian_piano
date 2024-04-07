using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour {

	// RowObject subscribes to BoardController GameInput event
	// Refcator input registering
	// get the RowObject moving + timer 

	public event EventHandler<OnNoteHitOrMissScoreEventArgs> OnNoteHitOrMissScore;
	public class OnNoteHitOrMissScoreEventArgs : EventArgs {
		public bool noteHit;
	}

	public event EventHandler<OnRowHitEventArgs> OnRowHit;
	public class OnRowHitEventArgs : EventArgs {
		public int rowId;
		public int noteColumn;
	}

	[SerializeField] private GameInput gameInput;


	public void Start() {
		gameInput.OnKeyPressInput += GameInput_OnKeyPressInput;
	}

	private void GameInput_OnKeyPressInput(object sender, GameInput.OnKeyPressEventArgs e) {
		OnRowHit?.Invoke(this, new OnRowHitEventArgs {
			rowId = 0,
			noteColumn = e.inputColumn,
		});
	}

	public void AddRowObjectSubscriber(RowObject rowObject) {
		rowObject.OnNoteHitOrMiss += RowObject_OnNoteHitOrMiss;
	}

	// Subtract subscriber

	private void RowObject_OnNoteHitOrMiss(object sender, RowObject.OnNoteHitOrMissEventArgs e) {
		OnNoteHitOrMissScore?.Invoke(this, new OnNoteHitOrMissScoreEventArgs { noteHit = e.noteHit });
	}
}
