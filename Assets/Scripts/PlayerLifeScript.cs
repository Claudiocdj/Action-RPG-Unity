using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeScript : MonoBehaviour {

    private PlayerScript playerScript;
    private GameObject myLifeBar;
    private float fullLife;
    private float currentLife;

    void Start() {
        playerScript = transform.root.GetComponent<PlayerScript>();

        myLifeBar = transform.GetChild(0).gameObject;

        fullLife = currentLife = playerScript.health;
    }

    void Update() {
        if (playerScript.health != currentLife) {
            currentLife = playerScript.health;

            Vector3 lifeBarScale = myLifeBar.transform.localScale;

            float lifePorcent = currentLife / fullLife;

            float NewPosX = (lifePorcent - 1) / 2;

            myLifeBar.transform.localScale = new Vector3(lifePorcent,
                                                            lifeBarScale.y,
                                                            lifeBarScale.z);

            myLifeBar.transform.localPosition = new Vector3(NewPosX, 0, 0);

            if (lifePorcent <= 0.3f)
                myLifeBar.GetComponent<SpriteRenderer>().color = Color.red;
            else
                myLifeBar.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
