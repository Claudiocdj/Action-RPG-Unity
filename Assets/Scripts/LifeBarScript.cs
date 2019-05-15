using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarScript : MonoBehaviour {

    private CreaturesScript creatureScript;
    private GameObject myLifeBar;
    private float fullLife;
    private float currentLife;

    void Start() {
        creatureScript = transform.root.GetComponent<CreaturesScript>();

        myLifeBar = transform.GetChild(0).gameObject;

        fullLife = currentLife = creatureScript.health;
    }
    
    void Update() {
        if(creatureScript.health != currentLife) {
            currentLife = creatureScript.health;

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
