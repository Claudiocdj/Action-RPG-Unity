using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTransiterScript : MonoBehaviour {

    public MapScript nextMap;

    public Vector3 newPlayerPos;

    private CameraScript cam;

    void Start() {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<CameraScript>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player")) {

            cam.minPos = nextMap.bottomLeftPos;
            cam.maxPos = nextMap.topRightPos;

            collider.transform.position += newPlayerPos;
        }
    }
}
