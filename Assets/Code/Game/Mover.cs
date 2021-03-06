using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float moveInterval;

	public Action<Mover> StoppedMoving;
	private bool isMoving;

	public bool IsMoving { get { return isMoving; } }

	void OnEnable() {
		isMoving = false;
	}

	public void Move(Vector2 direction) {
		if (!isMoving) {
			isMoving = true;
			StartCoroutine(MoveUpdate(direction));
		}
	}

	IEnumerator MoveUpdate(Vector2 direction) {
		float timeElapsed = 0f;
		if (direction == Vector2.right) {
			transform.localScale = new Vector2(-1, 1);
		}
		while (IsMoving) {
			if (timeElapsed <= moveInterval) {
				timeElapsed += Time.deltaTime;
			} else {
				transform.Translate(direction * moveSpeed * Time.deltaTime);
				timeElapsed = 0;
			}
			yield return null;
		}
		if (StoppedMoving != null) StoppedMoving(this);
	}

	[ContextMenu("ForceMove")]
	void ForceMove() {
		Move(-Vector2.right);
	}

}
