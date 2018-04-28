using UnityEngine;
using System.Collections;

public class timetodestroy : MonoBehaviour {
	private float currentTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime > 25f) {
			Destroy (this.gameObject);
		}

	}
}
