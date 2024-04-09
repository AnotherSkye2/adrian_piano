using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAndRowSpawner : MonoBehaviour {

	[SerializeField] List<Transform> prefabList;
	[SerializeField] GameInput gameInput;
	[SerializeField] BoardController boardController;
	
	static readonly string textFile = @".\NoteMaps\NoteMap1.txt";

	private string[] rowObjectArray;
	private float rowSpawnOffset = 6f;
	private float rowFrequency;
	private float rowApproachRate = 5f;

	private void Awake() {
		rowObjectArray = GetRowObjectArray();
		rowObjectArray = GetHeader(rowObjectArray);
		RowSpawner(rowObjectArray);
	}


	private void RowSpawner(string[] rowObjectArray) {
		foreach (string rowInfo in rowObjectArray) {
			Transform rowObjectTransform = Instantiate(prefabList[0]);
			RowObject rowObject = rowObjectTransform.GetComponent<RowObject>();
			boardController.AddRowObjectSubscriber(rowObject);
			rowObject.SetRowData(rowApproachRate, boardController);

			rowObject.transform.position = new Vector3(0, rowSpawnOffset, 0);

			NoteSpawner(rowInfo, rowObject);
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
		List<int> headerInfoIntigerList = new List<int> { };
		string headerInfoString = rowObjectArray[0];
		string[] headerInfoArray = headerInfoString.Split(",");
		foreach (string headerInfo in headerInfoArray) {
			int.TryParse(headerInfo, out int headerInfoIntiger);
			headerInfoIntigerList.Add(headerInfoIntiger);
		}
		rowFrequency = headerInfoIntigerList[0];
		return rowObjectArray[1..] ;
	}
}

