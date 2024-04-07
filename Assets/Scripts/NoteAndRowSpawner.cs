using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAndRowSpawner : MonoBehaviour {

	[SerializeField] Dictionary<int,Transform> prefabDict;
	[SerializeField] GameInput gameInput;
	[SerializeField] Transform rowPrefab;
	[SerializeField] Transform notePrefab;
	
	static readonly string textFile = @".\NoteMaps\NoteMap1.txt";

	private string[] rowObjectArray;
	private float rowSpawnOffset;

	private void Awake() {
		rowObjectArray = GetRowObjectArray();
		RowSpawner(rowObjectArray);		
	}

	private void Start () {
	}


	private void RowSpawner(string[] rowObjectArray) {
		foreach (string row in rowObjectArray) {
			Transform rowObjectTransform = Instantiate(rowPrefab);
			RowObject rowObject = rowObjectTransform.GetComponent<RowObject>();
			rowObject.SetGameInput(gameInput);

			rowObject.transform.position = new Vector3(0, rowSpawnOffset, 0);

			NoteSpawner(row, rowObject);
			rowSpawnOffset++;
			Debug.Log(rowSpawnOffset);
		}
	}

	private void NoteSpawner(string row, RowObject rowParent) {
		string[] noteList = row.Split(",");
		float noteOffset = -4f;
		foreach (string noteString in noteList) {
			int.TryParse(noteString, out int noteInt);
			if (noteInt != 0) {
				Transform noteObjectTransform = Instantiate(notePrefab);
				NoteObject noteObject = noteObjectTransform.GetComponent<NoteObject>();
				noteObject.SetRowObject(rowParent);

				noteObject.transform.parent = rowParent.transform;
				noteObject.transform.localPosition = new Vector3(noteOffset, 0, 0);

			}
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
