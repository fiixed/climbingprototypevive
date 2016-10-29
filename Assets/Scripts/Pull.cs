using UnityEngine;
using System.Collections;

public class Pull : MonoBehaviour {

    public SteamVR_TrackedObject controller;
    [HideInInspector]
    public Vector3 prevPos;

    [HideInInspector]
    public bool canGrip;

	// Use this for initialization
	void Start () {
        prevPos = controller.transform.localPosition;
	}

    void OnTriggerEnter() {
        canGrip = true;
    }

    void OnTriggerExit() {
        canGrip = false;
    }
}
