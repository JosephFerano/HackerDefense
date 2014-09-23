using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Text.RegularExpressions;

public class BatchRename : EditorWindow
{
	public string newName;
	public bool shouldClose;
	
	
	[MenuItem("Enhancements/Batch Rename &r")]
	public static void Init() {
		BatchRename popup = (BatchRename)EditorWindow.GetWindow(typeof(BatchRename));
		int width = 240;
		int height = 90;
		popup.title = "Batch Rename";
		popup.position = new Rect(Screen.width / 2, Screen.height / 2, width, height);
		if (Selection.activeGameObject) {
			popup.newName = Selection.activeGameObject.name;
		} else {
			popup.newName = "";
		}
		popup.Focus();
	}
	
	void OnGUI() {
		GUI.SetNextControlName("newName");
		newName = EditorGUILayout.TextField("New Name: ", newName);
		if (GUILayout.Button("Accept")) {
			Rename();
			this.Close();
		}
		if (GUILayout.Button("Cancel")) {
			this.Close();
		}
		GUILayout.Label("Use # followed by a digit to add a counter");
		GUI.FocusControl("newName");
		if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) {
			Rename();
			shouldClose = true;
		}
		if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Escape) {
			shouldClose = true;
		}
	}
	
	void Rename() {
		int counter = 0;
		bool hasCounter = false;
		string countAdjustedName = string.Empty;
		if (Selection.gameObjects.Length > 0) {
			if (Regex.IsMatch(newName, "#\\d"))
			{
				hasCounter = true;
			}
			foreach (var go in Selection.gameObjects) {
				if (hasCounter) 
				{
					countAdjustedName = Regex.Match(newName, "#(\\d*)").Value;
					Debug.Log(countAdjustedName);
					int newAmount = System.Convert.ToInt32(countAdjustedName.Replace("#", "")) + counter;
					go.name = newName.Replace(countAdjustedName, newAmount.ToString());
					counter++;
				}
				else
				{
					go.name = newName;
				}
			}
		}
	}
	
	void Update() {
		if (shouldClose) {
			this.Close();
			if (SceneView.currentDrawingSceneView) {
				SceneView.currentDrawingSceneView.Focus();
			}
		}
	}
}
