using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SpriteFader : MonoBehaviour
{
	[SerializeField] private bool fadeIn;
	[SerializeField] private bool fadeOut;
	[SerializeField] private float activeTime;
	[SerializeField] private float fadeInSpeed;
	[SerializeField] private float fadeOutSpeed;
	[SerializeField] private bool shouldDestroy;
	[SerializeField] private bool shouldDisable;

	private List<SpriteRenderer> spriteRends;

	void OnEnable() {
		spriteRends = new List<SpriteRenderer>();
		var spriteR = GetComponent<SpriteRenderer>();
		if (spriteR) spriteRends.Add(spriteR);
		spriteRends.AddRange(GetComponentsInChildren<SpriteRenderer>());
		Color color = new Color(1, 1, 1, 0);
		if (fadeIn) {
			foreach (var spriteRenderer in spriteRends) {
				spriteRenderer.color = color;
			}
		}
		StartCoroutine(Schedule());
	}

	IEnumerator Schedule () {
		if (fadeIn) yield return StartCoroutine(FadeSequence(fadeInSpeed, true));
		yield return new WaitForSeconds(activeTime);
		if (fadeOut) yield return StartCoroutine(FadeSequence(fadeOutSpeed, false));
		if (shouldDestroy) Destroy(gameObject);
		if (shouldDisable) gameObject.SetActive(false);
	}

	IEnumerator FadeSequence(float fadeTime, bool isFadingIn) {
		float timeElapsed = 0;
		float speed = 1.0f / fadeTime;
		Color newColor = new Color(1, 1, 1);
		int baseAlpha = isFadingIn ? 0 : 1;
		int i;
		while (timeElapsed * speed <= 1) {
			timeElapsed += Time.deltaTime;
			newColor.a = Mathf.Abs(baseAlpha - timeElapsed * speed);
			for (i = 0; i < spriteRends.Count; i++) {
				spriteRends[i].color = newColor;
			}
			yield return null;
		}
	}

}
