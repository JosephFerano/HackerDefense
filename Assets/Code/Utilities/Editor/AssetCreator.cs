using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;

public static class AssetCreator
{
	
	[MenuItem("Assets/Create/Asset from ScriptableObject")]
	public static void CreateAsset() {
		if (Selection.activeObject) {
			if (Selection.activeObject.GetType() == typeof(MonoScript)) {
				MonoScript monoScript = (MonoScript)Selection.activeObject;
				CreateAsset(monoScript);
			} else {
				Debug.Log("Selected asset is not a ScriptableObject");
			}
		}
	}
	
	public static void CreateAsset(MonoScript monoScript) {
		System.Type monoType = monoScript.GetClass();
		if (monoType.IsSubclassOf(typeof(ScriptableObject))) {
			MethodInfo methodInfo = typeof(AssetCreator).GetMethod("Create", new System.Type[] {});
			methodInfo = methodInfo.MakeGenericMethod(monoType);
			methodInfo.Invoke(null, null);
		} else {
			Debug.Log("Selected asset is not a ScriptableObject");
		}
	}
	
	public static T Create<T> () where T : ScriptableObject {
		string assetPath;
		return Create<T>(out assetPath);
	}

	public static T Create<T> (out string assetPath) where T : ScriptableObject {
		T asset = ScriptableObject.CreateInstance<T>();
		assetPath = "Assets/New " + typeof(T).ToString() + ".asset";
		AssetDatabase.CreateAsset(asset, assetPath);
		AssetDatabase.SaveAssets();
		EditorUtility.FocusProjectWindow();
		return asset;
	}

}