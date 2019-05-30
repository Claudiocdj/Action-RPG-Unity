using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Image screenTransition;

    public Text text;
    
    void Update() {
        if (Input.GetButtonDown("Fire2"))
            StartCoroutine(LoadScene());
    }

    public void setText(string n) {
        text.text = n;
    }

    private IEnumerator LoadScene() {

        for (int i = 1; i <= 20; i++) {
            screenTransition.color = new Color(screenTransition.color.r,
                                               screenTransition.color.g,
                                               screenTransition.color.b,
                                               i * .05f);

            yield return new WaitForSeconds(.02f);
        }

        SceneManager.LoadScene("StartScene");
    }
}
