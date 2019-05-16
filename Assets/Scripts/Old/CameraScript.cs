using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float smoothing;

    public Vector2 minPos;
    public Vector2 maxPos;

    private Transform playerTransform;

	void Start () {
        playerTransform = GameObject.Find("Player").transform;
	}

    private void LateUpdate() {
        if (transform.position != playerTransform.position) {
            Vector3 newPosition = new Vector3(playerTransform.position.x,
                                              playerTransform.position.y,
                                              transform.position.z);

            newPosition.x = Mathf.Clamp(newPosition.x, minPos.x, maxPos.x);

            newPosition.y = Mathf.Clamp(newPosition.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position,
                                            newPosition,
                                            smoothing);
        }
    }
}
