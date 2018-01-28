using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class LocalizedTextEditor : EditorWindow {

	public LocalizationData localizationData;

	[MenuItem ("Window/localized Text Editor")]
	static void Init(){
		EditorWindow.GetWindow (typeof(LocalizedTextEditor)).Show ();
	}

	private void OnGUI(){
		if (localizationData != null) {
			SerializedObject serialzedObject = new SerializedObject (this);
			SerializedProperty serializedProperty = serialzedObject.FindProperty("localizationData");
			EditorGUILayout.PropertyField (serializedProperty, true);
			serialzedObject.ApplyModifiedProperties ();

			if (GUILayout.Button ("Saved data")) {
				SaveGameData ();
			}
		}

		if (GUILayout.Button ("Load data")) {
			LoadGameData ();
		}

		if (GUILayout.Button ("Create new data")) {
			createNewData ();
		}
	}

	private void LoadGameData(){
		string filePath = EditorUtility.OpenFilePanel ("Select localization data file", Application.streamingAssetsPath, "json");

		if (!string.IsNullOrEmpty (filePath)) {
			string dataAsJson = File.ReadAllText (filePath);

			localizationData = JsonUtility.FromJson<LocalizationData> (dataAsJson);
		}
	}


	private void SaveGameData(){
		string filePath = EditorUtility.SaveFilePanel ("Save localization data file", Application.streamingAssetsPath, "", "json");

		if(!string .IsNullOrEmpty(filePath)){
			string dataAsJson = JsonUtility.ToJson(localizationData);
			File.WriteAllText (filePath, dataAsJson);
		}
	}

	private void createNewData(){
		localizationData = new LocalizationData ();

	}
}
