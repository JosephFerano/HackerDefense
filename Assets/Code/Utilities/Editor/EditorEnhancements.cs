using UnityEngine;
using UnityEditor;

public class EditorEnhancements
{

	[MenuItem("Enhancements/Audio/Batch Convert 2D Audio")]
	public static void Convert2D() {
		foreach (Object obj in Selection.objects) {
			if (obj.GetType() == typeof(AudioClip)) {
				string path = AssetDatabase.GetAssetPath(obj);
				AudioImporter audioImporter = (AudioImporter)AssetImporter.GetAtPath(path);
				audioImporter.threeD = false;
				AssetDatabase.ImportAsset(path);
			}
		}
	}

	[MenuItem("Enhancements/Audio/Convert to 128 Audio")]
	public static void Convert128() {
		foreach (Object obj in Selection.objects) {
			if (obj.GetType() == typeof(AudioClip)) {
				string path = AssetDatabase.GetAssetPath(obj);
				AudioImporter audioImporter = (AudioImporter)AssetImporter.GetAtPath(path);
				audioImporter.compressionBitrate = 32000;
				AssetDatabase.ImportAsset(path);
			}
		}
	}

	[MenuItem("Assets/Get Path")]
	public static void GetPathToFile() {
		foreach (var obj in Selection.objects) {
			Debug.Log(AssetDatabase.GetAssetPath(obj));
		}
	}

}
