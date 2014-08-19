using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Range
{
	[SerializeField] private int min;
	[SerializeField] private int max;

	public int Min { get { return min; } }
	public int Max { get { return max; } }
	public int Volume { get { return max - min; } }

	public void Set(int min, int max) {
		this.min = min;
		this.max = max;
	}

	public bool IsInRange(int number) {
		return number >= min && number <= max;
	}

	public void ShiftUp(int number) {
		min += number;
		max += number;
	}

	public void ShiftDown(int number) {
		min -= number;
		max -= number;
	}

}
