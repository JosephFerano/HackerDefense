using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{
	[SerializeField] public float updateInterval = 0.1f;

	private int framesDrawn;
	private float framesAccumulated;
	private float timeLeft;
	private string currentFPS;

	void Awake() {
		timeLeft = updateInterval;
	}

	void Update() {
		timeLeft -= Time.deltaTime;
		framesAccumulated += Time.timeScale / Time.deltaTime;
		framesDrawn++;
		if (timeLeft <= 0.0) {
			float fps = framesAccumulated / framesDrawn;
			currentFPS = System.String.Format("{0:F2} FPS",fps);
			timeLeft = updateInterval;
			framesAccumulated = 0.0f;
			framesDrawn = 0;
		}
	}

	void OnGUI() {
		GUI.Button(new Rect(Screen.width * 0.5f - 40, 10, 80, 40), currentFPS);
	}

}
