using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour {

	private const string ON_NOTE_HIT = "OnNoteHit";

	private Animator animator;

	public void NoteHit() {
		animator = GetComponentInChildren<Animator>();
		animator.SetTrigger(ON_NOTE_HIT);
		DestroySelf();
	}

	public void DestroySelf () {
		Destroy(this);
	}
}
