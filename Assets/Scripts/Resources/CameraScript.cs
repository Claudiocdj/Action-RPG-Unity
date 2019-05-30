using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraScript : MonoBehaviour {

    public float smoothing;

    public Tilemap initialMap;

    public Vector2 minPos;
    public Vector2 maxPos;

    private Transform playerTransform;
    private float halfHeightCamera;
    private float halfWidthCamera;

    void Start () {
        playerTransform = GameObject.Find("Player").transform;

        halfHeightCamera = Camera.main.orthographicSize;
        halfWidthCamera = halfHeightCamera * Camera.main.aspect;

        minPos = initialMap.localBounds.min;
        maxPos = initialMap.localBounds.max;
    }

    private void LateUpdate() {
        if (GameObject.Find("Player") && transform.position != playerTransform.position) {
            Vector3 newPosition = new Vector3(playerTransform.position.x,
                                              playerTransform.position.y,
                                              transform.position.z);

            newPosition.x = Mathf.Clamp(newPosition.x,
                                        minPos.x + halfWidthCamera,
                                        maxPos.x - halfWidthCamera);

            newPosition.y = Mathf.Clamp(newPosition.y,
                                        minPos.y + halfHeightCamera,
                                        maxPos.y - halfHeightCamera);

            transform.position = Vector3.Lerp(transform.position,
                                            newPosition,
                                            smoothing);
        }
    }
}
