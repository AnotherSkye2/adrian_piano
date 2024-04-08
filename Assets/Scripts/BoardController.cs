using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameInput;

public class BoardController : MonoBehaviour {

	// TODO:

	// Mechanics:
	// rowMiss at the bottom of the screen => Destroy rowObject
	// noteTrigger accuracy
	// rowApproachRate + const rowSpeed
	// row moves or Board moves?

	// Visuals:
	// note/row sprite
	// Background

	// New Mechanics:
	// long Notes

	[SerializeField] private GameInput gameInput;

	public event EventHandler<OnNoteHitOrMissScoreEventArgs> OnNoteHitOrMissScore;
	public class OnNoteHitOrMissScoreEventArgs : EventArgs {
		public bool noteHit;
	}

	public event EventHandler<OnRowHitEventArgs> OnRowHit;
	public class OnRowHitEventArgs : EventArgs {
		public int noteColumn;
	}

	public void Start() {
		gameInput.OnKeyPressInput += GameInput_OnKeyPressInput;
	}

	private void GameInput_OnKeyPressInput(object sender, GameInput.OnKeyPressEventArgs e) {
		OnRowHit?.Invoke(this, new OnRowHitEventArgs {
			noteColumn = (int)e.inputColumn
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
