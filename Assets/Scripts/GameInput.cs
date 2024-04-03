using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {

	public event EventHandler<OnKeyPressEventArgs> OnKeyPress;
	public class OnKeyPressEventArgs : EventArgs {
		public int inputColumn;
	}

	private void Update() {

		if (Input.GetKeyDown(KeyCode.A)) {
			OnKeyPress?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 0 });
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			OnKeyPress?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 1 });
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			OnKeyPress?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 2 });
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			OnKeyPress?.Invoke(this, new OnKeyPressEventArgs { inputColumn = 3 });
		}
	}

}
