using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAndRowSpawner : MonoBehaviour {


	static readonly string textFile = @".\NoteMaps\NoteMap1.txt";

	private string[] rowObjectArray;


	private void Start () {
		rowObjectArray = GetRowObjectArray();
	}

	private void Update () {
		RowSpawner(rowObjectArray);
	}

	private void RowSpawner(string[] rowObjectArray) {
		foreach (var row in rowObjectArray) {
			Debug.Log(row);
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
