using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class StartMenu : MonoBehaviour {

    public Image screenTransition;

    private bool clicked = false;

    private void Start() {
        if(GameObject.Find("Canvas"))
            Destroy(GameObject.Find("Canvas"));
    }

    void Update() {
        if (Input.anyKey && !clicked) {

            StartCoroutine(LoadGame());

            clicked = true;
        }
    }

    private IEnumerator LoadGame() {
        for (int i = 1; i <= 20; i++) {
            screenTransition.color = new Color(screenTransition.color.r,
                                               screenTransition.color.g,
                                               screenTransition.color.b,
                                               i*.05f);

            yield return new WaitForSeconds(.02f);
        }

        SceneManager.LoadScene("TheGame");
    }
}
