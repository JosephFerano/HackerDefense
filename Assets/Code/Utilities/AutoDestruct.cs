using UnityEngine;
using System;
using System.Collections;

public class AutoDestruct : MonoBehaviour
{
	[SerializeField] private float destructTime;
	[SerializeField] private bool keep;
	[SerializeField] private bool fadeOut;
	[SerializeField] private bool shouldFloat;
	[SerializeField] private float fadeTime;

	public Action onDestruct;

	void OnEnable() {
		if (fadeOut) {
			StartCoroutine(FadeAndDestructSequence());
		} else {
			StartCoroutine(DestructSequence());
		}
	}

	void Update() {
		if (shouldFloat) transform.Translate(0, 0.05f * Time.deltaTime, 0);
	}

	IEnumerator DestructSequence() {
		yield return new WaitForSeconds(destructTime);
		if (onDestruct != null) onDestruct();
		DestroyAfter();
	}

	IEnumerator FadeAndDestructSequence() {
		yield return new WaitForSeconds(destructTime);
		float timeElapsed = 0;
		float speed = 1.0f / fadeTime;
		var spriteRend = GetComponent<SpriteRenderer>();
		Color newColor = spriteRend.color;
		while (timeElapsed * speed <= 1 && spriteRend) {
			timeElapsed += Time.deltaTime;
			newColor.a = 1 - timeElapsed * speed;
			spriteRend.color = newColor;
			yield return null;
		}
		DestroyAfter();
	}

	void DestroyAfter() {
		if (keep) {
			gameObject.SetActive(false);
			onDestruct = null;
		}
		else Destroy(gameObject);
	}

}
