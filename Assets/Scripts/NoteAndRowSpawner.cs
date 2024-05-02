using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAndRowSpawner : MonoBehaviour {

	[SerializeField] List<Transform> prefabList;
	[SerializeField] GameInput gameInput;
	[SerializeField] BoardController boardController;

	static readonly string textFile = Application.streamingAssetsPath + @"/NoteMaps/NoteMap1.txt";

	private string[] rowObjectArray, rowObjectArrayWithoutHeader;
	private float rowSpawnOffset;
	private float rowFrequency;
	private float rowApproachRate = 12f;

	private void Awake() {
		Debug.Log(textFile);
		rowObjectArray = GetRowObjectArray();
		rowObjectArrayWithoutHeader = GetHeader(rowObjectArray);
		RowSpawner(rowObjectArrayWithoutHeader);
	}


	private void RowSpawner(string[] rowInfoArray) {
		foreach (string rowInfo in rowInfoArray) {
			Transform rowObjectTransform = Instantiate(prefabList[0]);
			RowObject rowObject = rowObjectTransform.GetComponent<RowObject>();
			boardController.AddRowObjectSubscriber(rowObject);
			rowObject.SetRowData(rowApproachRate, boardController);
			if (rowSpawnOffset == float.PositiveInfinity) {
				Debug.Log("inf");
			}
			rowObject.transform.position = new Vector3(0, rowSpawnOffset, 0);
			NoteSpawner(rowInfo, rowObject);
			Debug.Log(rowApproachRate);
			Debug.Log(rowFrequency);
			Debug.Log(rowApproachRate / rowFrequency);
			rowSpawnOffset += rowApproachRate/rowFrequency;
		}
	}

	private void NoteSpawner(string rowInfo, RowObject rowParent) {
		string[] noteList = rowInfo.Split(",");
		float noteOffset = -3f;
		int i = 0;
		foreach (string noteString in noteList) {
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

	private string[] GetRowObjectArray() {
		if (File.Exists(textFile)) {
			string[] rowObjectArray = File.ReadAllLines(textFile);
			return rowObjectArray;
		}
		Debug.Log("File does not exist!");
		return null;
	}

	private string[] GetHeader(string[] rowObjectArray) {
		List<float> headerInfoList = new List<float> { };
		string headerInfoString = rowObjectArray[0];
		string[] headerInfoArray = headerInfoString.Split(",");
		foreach (string headerInfo in headerInfoArray) {
			float.TryParse(headerInfo, out float headerInfoCharacter);
			headerInfoList.Add(headerInfoCharacter);
		}
		rowFrequency = headerInfoList[0];
		rowSpawnOffset = headerInfoList[1];
		return rowObjectArray[1..] ;
	}
}

