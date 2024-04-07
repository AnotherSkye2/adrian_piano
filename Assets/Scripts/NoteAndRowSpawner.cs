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
	private float rowSpawnOffset;

	private void Awake() {
		rowObjectArray = GetRowObjectArray();
		RowSpawner(rowObjectArray);
	}


	private void RowSpawner(string[] rowObjectArray) {
		int i = 0;
		foreach (string rowInfo in rowObjectArray) {
			Transform rowObjectTransform = Instantiate(prefabList[0]);
			RowObject rowObject = rowObjectTransform.GetComponent<RowObject>();
			rowObject.SetBoardControllerSubscriber(boardController);
			rowObject.SetRowId(i);
			boardController.AddRowObjectSubscriber(rowObject);

			rowObject.transform.position = new Vector3(0, rowSpawnOffset, 0);

			NoteSpawner(rowInfo, rowObject);
			rowSpawnOffset += 3f;
			Debug.Log(rowSpawnOffset);
			i++;
		}
	}

	private void NoteSpawner(string rowInfo, RowObject rowParent) {
		string[] noteList = rowInfo.Split(",");
		float noteOffset = -4f;
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

	public string[] GetRowObjectArray() {
		if (File.Exists(textFile)) {
			// Read a text file line by line.
			string[] rowObjectArray = File.ReadAllLines(textFile);
			return rowObjectArray;
		}
		Debug.Log("File does not exist!");
		return null;
	}


}
