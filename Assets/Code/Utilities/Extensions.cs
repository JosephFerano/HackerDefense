using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Extensions
{

	public static Vector3 GetPointInBounds(this BoxCollider boxCollider) {
		float x = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
		float y = Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y);
		float z = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);
		return new Vector3(x, y, z);
	}

	public static SpriteRenderer AddToScene(this Sprite sprite) {
		GameObject test = new GameObject(sprite.name);
		var spriteRend = test.AddComponent<SpriteRenderer>();
		spriteRend.sprite = sprite;
		return spriteRend;
	}

	public static void TestPosition(this Vector3 testPos, bool shouldBreak = true) {
		GameObject test = new GameObject("Testing Vector3: " + testPos);
		test.transform.position = testPos;
		if (shouldBreak) {
			Debug.Break();
		}
	}

	public static T FindClosest<T>(this Transform transform, IEnumerable<T> array) where T : Component {
		var closest = array
			.OrderBy(item => (item.transform.position - transform.position).normalized)
			.FirstOrDefault();
		return closest;
	}

	public static Transform[] GetChildren(this Transform transform) {
		var children = new Transform[transform.childCount];
		for (int i = 0; i < children.Length; i++) {
			children[i] = transform.GetChild(i);
		}
		return children;
	}

	public static string GetWithPrependedZeros(this int number, int placesToTheLeft) {
		StringBuilder sb = new StringBuilder("");
		for (int i = placesToTheLeft; i >= 0; i--) {
			if (number < Mathf.Pow(10, i - 1)) {
				sb.Append('0');
			}
		}
		sb.Append(number);
		return sb.ToString();
	}

	public static string GetNumberWithComma(this int number) {
		string numberWithComas = number.ToString();
		if (number > 999) {
			numberWithComas = numberWithComas.Insert(numberWithComas.Length - 3, ",");
		}
		if (number > 999999) {
			numberWithComas = numberWithComas.Insert(numberWithComas.Length - 7, ",");
		}
		return numberWithComas;
	}

	public static void AddNoDuplicates<T>(this List<T> list, T item) {
		if (!list.Contains(item)) list.Add(item);
	}

	public static void AddRangeNoDuplicates<T>(this List<T> list, List<T> range) {
		foreach (var item in range) {
			if (!list.Contains(item)) list.Add(item);
		}
	}

	public static void Randomize<T>(this List<T> list) {
		if (list.Count == 0) return;
		int startCount = list.Count;
		for (int i = startCount; i >= 0; i--) {
			int random = UnityEngine.Random.Range(0, i);
			list.Add(list[random]);
			list.RemoveAt(random);
		}
	}

}
