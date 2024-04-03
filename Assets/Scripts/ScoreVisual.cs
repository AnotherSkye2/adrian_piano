using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreVisual : MonoBehaviour {

	[SerializeField] private ScoreController scoreController;
	private TextMeshProUGUI scoreText;

	private void Start () {
		scoreText = GetComponent<TextMeshProUGUI>();
	}

	private void Update() {
		scoreText.text = scoreController.scoreCount.ToString();
	}

}
