using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAndRowSpawner : MonoBehaviour {

	[SerializeField] List<Transform> prefabList;
	[SerializeField] GameInput gameInput;
	[SerializeField] BoardController boardController;
	[SerializeField] PlayerSettings playerSettings;

	static readonly string noteMapFile = Application.streamingAssetsPath + @"/NoteMaps/NoteMap1.txt";

	private string[] noteMapInfoArray, noteMapInfoArrayWithoutHeader;
	private float rowFrequency;
	private float rowSpawnOffset;
	private float rowApproachRate;
	private float noteTriggerArea = 0.15f;

	private void Start() {
		Debug.Log(noteMapFile);
		noteMapInfoArray = GetNoteMapInfoArray();
		noteMapInfoArrayWithoutHeader = GetHeader(noteMapInfoArray);
		rowApproachRate = playerSettings.RowApproachRate;
		noteTriggerArea = rowApproachRate * noteTriggerArea; //Adjust noteTrigger area to be on the noteTrigger are for the same amount of time
		RowSpawner(noteMapInfoArrayWithoutHeader);
	}


	private void RowSpawner(string[] rowInfoArray) {
		foreach (string rowInfo in rowInfoArray) {
			Transform rowObjectTransform = Instantiate(prefabList[0]);
			RowObject rowObject = rowObjectTransform.GetComponent<RowObject>();
			boardController.AddRowObjectSubscriber(rowObject);
			rowObject.SetRowData(rowApproachRate, noteTriggerArea, boardController);
			rowObject.transform.position = new Vector3(0, rowSpawnOffset, 0);
			NoteSpawner(rowInfo, rowObject);

			Debug.Log(rowApproachRate);
			Debug.Log(rowFrequency);
			Debug.Log(rowApproachRate / rowFrequency);

			rowSpawnOffset += rowApproachRate/rowFrequency;
		}
	}

	private void NoteSpawner(string rowInfo, RowObject rowParent) {
		string[] noteInfoList = rowInfo.Split(",");
		float noteOffset = -3f;
		int i = 0;
		foreach (string noteString in noteInfoList) {
			int.TryParse(noteString, out int noteInt);
			if (noteInt != 0) {
				Transform noteObjectTransform = Instantiate(prefabList[1]);
				NoteObject noteObject = noteObjectTransform.GetComponent<NoteObject>();

				noteObject.transform.parent = rowParent.transform;
				noteObject.transform.localPosition = new Vector3(noteOffset, 0, 0);

				rowParent.noteColumnInfoDict.Add(i, noteObject);
			}	
			i++;
			noteOffset += 2f;
		}
	}
	private string[] GetHeader(string[] noteMapInfoArray) {
		if (File.Exists(noteMapFile)) {
			List<float> headerInfoList = new List<float> { };
			string headerInfoString = noteMapInfoArray[0];
			string[] headerInfoArray = headerInfoString.Split(",");
			foreach (string headerInfo in headerInfoArray) {
				float.TryParse(headerInfo, out float headerInfoFloat);
				headerInfoList.Add(headerInfoFloat);
			}
			rowFrequency = headerInfoList[0];
			rowSpawnOffset = headerInfoList[1];
			return noteMapInfoArray[1..] ;
		} else {
			Debug.Log("File does not exist!");
			return null;
		}
	}

	private string[] GetNoteMapInfoArray() {
		if (File.Exists(noteMapFile)) {
			string[] rowInfoArray = File.ReadAllLines(noteMapFile);
			return rowInfoArray;
		}
		Debug.Log("File does not exist!");
		return null;
	}

}

