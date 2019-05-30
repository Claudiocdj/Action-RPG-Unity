using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerGameOver : MonoBehaviour {
    
    private void OnDestroy() {
        GameObject gameOver = Resources.FindObjectsOfTypeAll(typeof(GameObject))
                             .Cast<GameObject>().Where(g => g.tag == "GameOverUI")
                             .ToList()[0];

        if(gameOver != null)
            gameOver.SetActive(true);
    }
}
