using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarScript : MonoBehaviour {

    private EnemyScript enemyScript;
    private GameObject myLifeBar;
    private float fullLife;
    private float currentLife;

    void Start() {
        enemyScript = transform.root.GetComponent<EnemyScript>();

        myLifeBar = transform.GetChild(0).gameObject;

        fullLife = currentLife = enemyScript.health;
    }
    
    void Update() {
        if(enemyScript.health != currentLife) {
            currentLife = enemyScript.health;

            Vector3 lifeBarScale = myLifeBar.transform.localScale;

            float lifePorcent = currentLife / fullLife;

            float NewPosX = (lifePorcent - 1) / 2;

            myLifeBar.transform.localScale = new Vector3(lifePorcent,
                                                            lifeBarScale.y,
                                                            lifeBarScale.z);

            myLifeBar.transform.localPosition = new Vector3(NewPosX, 0,0);

            if (lifePorcent <= 0.3f)
                myLifeBar.GetComponent<SpriteRenderer>().color = Color.red;
            else
                myLifeBar.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
