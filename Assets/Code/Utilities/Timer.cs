using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Timer
{
	private float timeFactor = 1;
	private bool isActive;
	private int startAmountInSeconds;
	private string currentFormattedTime;
	private Routine routine;
	private Action<string> setTime;
	private StringBuilder sbSeconds;

	public string CurrentFormattedTime { get { return sbSeconds.ToString(); } }
	public bool IsPaused { get { return routine.CurrentState == Routine.State.Paused; } }
	public bool IsActive { get { return isActive; } }

	public Timer(MonoBehaviour monoOwner, Action<string> setTime) {
		routine = new Routine(monoOwner);
		this.setTime = setTime;
		sbSeconds = new StringBuilder();
	}

	public void StartCountdown(int startAmountInSeconds, System.Action countdownFinishedEvent = null) {
		this.startAmountInSeconds = startAmountInSeconds;
		routine.Assign(TimerSequence(), countdownFinishedEvent);
		routine.Start();
	}

	public void AddTime(int amount) {
		startAmountInSeconds += amount;
	}

	public void ToggleTimerPause(bool shouldPause) {
		if (shouldPause) {
			routine.Pause();
		} else {
			routine.Resume();
		}
	}

	public void StopTimer(bool forceEvent) {
		routine.Stop(forceEvent);
	}

	int GetMinutes(int seconds) {
		return Mathf.FloorToInt(seconds / 60);
	}

	int GetSeconds(int seconds) {
		return seconds < 60 ? seconds : seconds % 60;
	}

	IEnumerator TimerSequence() {
		isActive = true;
		float deltaTimeElapsed = 0;
		bool isCounting = true;
		int minute = 0;
		int seconds = 0;
		int currentTime = startAmountInSeconds;
		float secondsCount = 1;
		while (isCounting) {
			if (deltaTimeElapsed <= startAmountInSeconds) {
				sbSeconds.Length = 0;
				currentTime = startAmountInSeconds - (int)deltaTimeElapsed;
				minute = GetMinutes(currentTime);
				seconds = GetSeconds(currentTime);
				secondsCount += Time.deltaTime;
				if (secondsCount >= 1f){
					sbSeconds.Append(seconds);
					if (seconds < 10) {
						sbSeconds.Insert(0, "0");
					}
					sbSeconds.Insert(0, ":");
					sbSeconds.Insert(0, minute);
					secondsCount = 0;
					if (setTime != null) setTime(sbSeconds.ToString());
				}
			} else {
				isCounting = false;
				if (setTime != null) setTime("0:00");
			}
			deltaTimeElapsed += Time.deltaTime * timeFactor;
			yield return null;
		}
		isActive = false;
	}

}
