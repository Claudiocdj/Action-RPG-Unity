using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

    public GameObject pause;

    private void Start() {
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            pause.SetActive(!pause.activeInHierarchy);
        }
    }
}
