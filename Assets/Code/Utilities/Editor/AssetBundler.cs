using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundler
{

	[MenuItem("Assets/Create/Asset Bundle")]
	static void Bundle() {
		string mainAssetPath = EditorUtility.OpenFilePanel("File for Main Asset", "Assets/", "");
		string path = EditorUtility.SaveFilePanel("Save Asset Bundle", "Assets/", "New Asset Bundle", "unity3d");
		if (path.Length > 0 && Selection.objects.Length > 0) {
			mainAssetPath = "Assets" + mainAssetPath.Replace(Application.dataPath, "");
			Object mainAsset = null;
			if (!string.IsNullOrEmpty(mainAssetPath)) {
				mainAsset = AssetDatabase.LoadAssetAtPath(mainAssetPath, typeof(Object));
			}
			if (!mainAsset) mainAsset = Selection.activeObject;
			BuildAssetBundleOptions bundleOptions = BuildAssetBundleOptions.CompleteAssets;
			BuildTarget buildSettings = EditorUserBuildSettings.activeBuildTarget;
			BuildPipeline.BuildAssetBundle(mainAsset, Selection.objects, path, bundleOptions, buildSettings);
		}
	}

}
