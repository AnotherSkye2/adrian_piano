using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class PlayerSettings : MonoBehaviour {

	private float _rowApproachRate;

	public float RowApproachRate { get { return _rowApproachRate; } set { _rowApproachRate = value; } }

	static readonly string playerSettingsFile = Application.streamingAssetsPath + @"\PlayerSettings\NoteMapPreferences.txt";

	private void Awake() {
		ReadAndSetPlayerSettings();
	}


	private void ReadAndSetPlayerSettings() {
		if (File.Exists(playerSettingsFile)) {
			List<float> PlayerSettingsInfoList = new List<float> { };
			string PlayerSettingsInfoString = File.ReadAllText(playerSettingsFile);
			string[] PlayerSettingsInfoArray = PlayerSettingsInfoString.Split(",");
			foreach (string playerSettingsInfo in PlayerSettingsInfoArray) {
				float.TryParse(playerSettingsInfo, out float headerInfoFloat);
				PlayerSettingsInfoList.Add(headerInfoFloat);
			}
			RowApproachRate = PlayerSettingsInfoList[0];
		}
	}


}
