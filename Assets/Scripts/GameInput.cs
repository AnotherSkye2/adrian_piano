using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

	public event EventHandler<OnKeyPressEventArgs> OnKeyPressInput;
	public class OnKeyPressEventArgs : EventArgs {
		public float inputColumn;
	}

	private void Start() {
		KeyboardInputActions keyboardInputActions = new KeyboardInputActions();
		keyboardInputActions.Keyboard.Enable();

		keyboardInputActions.Keyboard.NoteColumn0.performed += ctx =>
		OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs {
			inputColumn = ctx.ReadValue<float>()
		});
		keyboardInputActions.Keyboard.NoteColumn1.performed += ctx =>
		OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs {
			inputColumn = ctx.ReadValue<float>()
		}) ;
		keyboardInputActions.Keyboard.NoteColumn2.performed += ctx =>
		OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs {
		inputColumn = ctx.ReadValue<float>()
		});
		keyboardInputActions.Keyboard.NoteColumn3.performed += ctx =>
		OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs {
		inputColumn = ctx.ReadValue<float>()
		});
	}

}
