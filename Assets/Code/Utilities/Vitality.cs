using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Vitality : MonoX
{
	[SerializeField] private int maxAmount;
	[SerializeField] private int currentAmount;

	public delegate void VitalityEvent(MonoX sender, Vitality receiver);
	public event VitalityEvent Healed;
	public event VitalityEvent Damaged;
	public event VitalityEvent Depleted;

	public bool IsDead { get { return currentAmount == 0; } }
	public int CurrentAmount { get { return currentAmount; } }
	public int MaxAmount { get { return maxAmount; } }
	public float Percentage { get { return (float)currentAmount / (float)maxAmount; } }
	public int PercentageInt { get { return Mathf.CeilToInt(((float)currentAmount / (float)maxAmount) * 100); } }

	void Awake() {
		currentAmount = maxAmount;
	}

	public void Heal(int healAmount, MonoX healer) {
		currentAmount += healAmount;
		if (currentAmount > maxAmount) {
			currentAmount = maxAmount;
		}
		if (Healed != null) {
			Healed(healer, this);
		}
	}

	public void Damage(int damageAmount, MonoX adversary) {
		if (!IsDead) {
			if (currentAmount - damageAmount <= 0) {
				Deplete(adversary);
			} else {
				currentAmount -= damageAmount;
				if (Damaged != null) {
					Damaged(adversary, this);
				}
			}
		}
	}

	public void Deplete(MonoX adversary) {
		currentAmount = 0;
		if (Depleted != null) {
			Depleted(adversary, this);
		}
	}

	public void IncreaseMaxAmount(int amount, bool shouldResetCurrent, bool shouldIncrementBy) {
		if (shouldIncrementBy) {
			maxAmount += amount;
		} else {
			maxAmount = amount;
		}
		if (shouldResetCurrent) {
			currentAmount = maxAmount;
		}
	}

}
