using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAnimator : MonoBehaviour {

	private const string ON_NOTE_HIT = "OnNoteHit";

	[SerializeField] private NoteObject noteObject;

	private Animator animator;

	public void NoteHitAnimation() {
		animator = GetComponent<Animator>();
		animator.SetTrigger(ON_NOTE_HIT);
	}
}
