using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour {

	// Miss is for points

	public event EventHandler OnNoteHit;

	private RowObject rowObject;
	
	[SerializeField] private int noteColumn;

	private void Start () {
		rowObject.OnNoteHitOrMiss += RowObject_OnNoteHitOrMiss;
	}

	private void RowObject_OnNoteHitOrMiss(object sender, RowObject.OnNoteHitOrMissEventArgs e) {
		if (noteColumn == e.noteColumn) {
			Debug.Log("NoteHit");
			OnNoteHit?.Invoke(this, EventArgs.Empty);
			rowObject.OnNoteHitOrMiss -= RowObject_OnNoteHitOrMiss;
			DestroySelf();
		}	
	}

	public void SetRowObject(RowObject rowObject) {
		this.rowObject = rowObject;
	}

	private void DestroySelf () {
		Destroy(this);
	}
}
