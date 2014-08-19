using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Routine
{
	private bool isForcingEvent;
	private IEnumerator coroutine;
	private MonoBehaviour mono;
	private State state;
	public System.Action RoutineFinishedEvent;

	public enum State {
		Running,
		Paused,
		Stopped
	}

	public State CurrentState {
		get {
			return state;
		}
	}

	public Routine(MonoBehaviour mono) {
		this.mono = mono;
	}

	public Routine(MonoBehaviour mono, IEnumerator coroutine) : this(mono) {
		this.coroutine = coroutine;
	}

	public Routine(MonoBehaviour mono, IEnumerator coroutine, System.Action finishedEvent) : this(mono, coroutine) {
		RoutineFinishedEvent = finishedEvent;
	}

	public void Start() {
		if (CheckMono()) {
			if (CheckCoroutine()) {
				state = State.Running;
				mono.StartCoroutine(Run());
			}
		}
	}

	public void Assign(IEnumerator coroutine) {
		if (CheckMono()) {
			this.coroutine = coroutine;
		}
	}

	public void Assign(IEnumerator coroutine, System.Action finishedEvent) {
		if (CheckMono()) {
			this.coroutine = coroutine;
			RoutineFinishedEvent = finishedEvent;
		}
	}

	public void Pause() {
		state = State.Paused;
	}

	public void Resume() {
		if (state == State.Paused) {
			state = State.Running;
		}
	}

	public void Stop(bool forceEvent = false) {
		state = State.Stopped;
		isForcingEvent = forceEvent;
	}

	IEnumerator Run() {
		bool isRunning = true;
		while (state != State.Stopped && isRunning) {
			if (state == State.Running) {
				if (coroutine.MoveNext()) {
					yield return coroutine.Current;
				} else {
					isRunning = false;
				}
			} else if (state == State.Paused) {
				yield return null;
			}
		}
		if (state != State.Stopped || isForcingEvent) {
			state = State.Stopped;
			if (RoutineFinishedEvent != null) {
				RoutineFinishedEvent();
			}
		}
		RoutineFinishedEvent = null;
	}

	bool CheckMono() {
		if (mono) {
			return true;
		} else {
			Debug.LogWarning("The MonoBehaviour specified for Routine does not exist anymore");
			return false;
		}
	}

	bool CheckCoroutine() {
		if (coroutine != null) {
			return true;
		} else {
				Debug.LogWarning("A coroutine has not yet been provided to Routine on " + mono.name, mono.gameObject);
			return false;
		}
	}

}
