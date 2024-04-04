using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAnimator : MonoBehaviour {

	private const string ON_NOTE_HIT = "OnNoteHit";

	[SerializeField] NoteObject noteObject;

	private Animator animator;
	private void Awake() {
		animator = GetComponent<Animator>();
	}
	private void Start() {
		noteObject.OnNoteHit += NoteObject_OnNoteHit;
	}

	private void NoteObject_OnNoteHit(object sender, System.EventArgs e) {
		animator.SetTrigger(ON_NOTE_HIT);
	}
}
