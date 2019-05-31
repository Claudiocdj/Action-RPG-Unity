using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public Image screenTransition;

    private void OnEnable() {
        Time.timeScale = 0f;

        if (GameObject.Find("Player"))
            GameObject.Find("Player").GetComponent<InputsMove>().enabled = false;
    }

    private void OnDisable() {
        Time.timeScale = 1f;

        if(GameObject.Find("Player"))
            GameObject.Find("Player").GetComponent<InputsMove>().enabled = true;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            StartCoroutine(LoadScene());
        }
    }

    private IEnumerator LoadScene() {
        Time.timeScale = 1f;

        for (int i = 1; i <= 20; i++) {
            screenTransition.color = new Color(screenTransition.color.r,
                                               screenTransition.color.g,
                                               screenTransition.color.b,
                                               i * .05f);

            yield return new WaitForSeconds(.02f);
        }

        GameObject player = GameObject.Find("Player");

        if (player) {
            player.GetComponent<PlayerGameOver>().enabled = false;

            Destroy(player);
        }
        
        SceneManager.LoadScene("StartScene");
    }
}
