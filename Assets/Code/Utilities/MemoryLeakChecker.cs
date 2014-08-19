using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MemoryLeakChecker : MonoBehaviour
{
	[SerializeField] private string fileName;
	[SerializeField] private string fileToDestroy;

	[ContextMenu("Check Leak")]
	public void CheckLeak() {
		Texture[] textures = Resources.FindObjectsOfTypeAll<Texture>();
		foreach (var t in textures) {
			if (t.name.Contains(fileName)) {
				Debug.Log(t, t);
			}
		}
	}

	[ContextMenu("Destroy Leak")]
	public void DestroyLeak() {
		Texture[] textures = Resources.FindObjectsOfTypeAll<Texture>();
		foreach (var t in textures) {
			if (t.name.Contains(fileToDestroy)) {
				Destroy(t);
			}
		}
	}

}
