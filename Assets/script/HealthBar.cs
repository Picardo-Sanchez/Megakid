using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Vector3 offset;

	private GameObject mainCamera;
	private Transform mainCameraTrans;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main.gameObject;
		mainCameraTrans = mainCamera.transform;
		// offset so it's to the side of the camera view
		offset = new Vector3 (-10f, 2f, 10f);
	}

	// Update is called once per frame
	void Update () {
		try{
			transform.position = mainCameraTrans.position + offset;
		} catch {
			mainCamera = Camera.main.gameObject;
		}
	}
}
