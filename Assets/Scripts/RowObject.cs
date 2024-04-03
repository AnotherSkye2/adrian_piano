using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInput;

public class RowObject : MonoBehaviour {

	public event EventHandler<OnNoteHitOrMissEventArgs> OnNoteHitOrMiss;
	public class OnNoteHitOrMissEventArgs : EventArgs {
		public int noteColumn;
		public bool noteHit;
	}

	[SerializeField] private GameInput gameInput;

	public List<int> noteColumnInfoList;


	public void Start() {
		gameInput.OnKeyPress += GameInput_OnKeyPress;
	}

	private void GameInput_OnKeyPress(object sender, GameInput.OnKeyPressEventArgs e) {
		if (noteColumnInfoList.Contains(e.inputColumn)) {
				// Note was in the inputted colum
				OnNoteHitOrMiss?.Invoke(this, new OnNoteHitOrMissEventArgs { noteColumn = e.inputColumn, noteHit = true });
		}
		// Note was not in the inputted column
		OnNoteHitOrMiss?.Invoke(this, new OnNoteHitOrMissEventArgs { noteColumn = e.inputColumn, noteHit = false });

	}
}
