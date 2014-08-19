using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AutoRotate : MonoBehaviour
{
	[SerializeField] private float rotationSpeed;
	[SerializeField] [Range(-1, 1)] private float xRot;
	[SerializeField] [Range(-1, 1)] private float yRot;
	[SerializeField] [Range(-1, 1)] private float zRot;

	private Transform tf;
	private float x;
	private float y;
	private float z;

	void Awake() {
		tf = transform;
	}

	void Update() {
		x = rotationSpeed * xRot * Time.deltaTime;
		y = rotationSpeed * yRot * Time.deltaTime;
		z = rotationSpeed * zRot * Time.deltaTime;
		tf.Rotate(x, y, z);
	}

}
