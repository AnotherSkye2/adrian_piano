using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

	public event EventHandler<OnKeyPressEventArgs> OnKeyPressInput;
	public class OnKeyPressEventArgs : EventArgs {
		public int inputColumn;
	}

	private void Update() {

		if (Input.GetKeyDown(KeyCode.A)) {
			OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 0 });
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 1 });
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 2 });
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			OnKeyPressInput?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 3 });
		}
	}

}
