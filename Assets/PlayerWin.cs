using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerWin : MonoBehaviour {

    private void OnDestroy() {
        GameObject gameOver = Resources.FindObjectsOfTypeAll(typeof(GameObject))
                             .Cast<GameObject>().Where(g => g.tag == "GameOverUI")
                             .ToList()[0];

        gameOver.GetComponent<GameOver>().setText("YOU ARE GREAT");

        GameObject player = GameObject.Find("Player");

        if (player) {
            player.GetComponent<PlayerGameOver>().enabled = false;

            Destroy(player);
        }
        
        if (gameOver != null)
            gameOver.SetActive(true);
    }
}
