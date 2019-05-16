using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {

    private float totalLife;

    private GameObject myLifeBar;
    private SpriteRenderer mySpriteRenderer;

    private void Start() {
        myLifeBar = transform.GetChild(0).gameObject;

        mySpriteRenderer = myLifeBar.GetComponent<SpriteRenderer>();
    }

    public void SetTotalLife(int n) {
        totalLife = n;
    }

    public void Actualize(int currentLife) {
        Vector3 lifeBarScale = myLifeBar.transform.localScale;

        float lifePorcent = currentLife / totalLife;

        if (lifePorcent <= 0.3f) mySpriteRenderer.color = Color.red;
        else                     mySpriteRenderer.color = Color.green;

        float NewPosX = (lifePorcent - 1) / 2;

        myLifeBar.transform.localScale = new Vector3(lifePorcent,
                                                            lifeBarScale.y,
                                                            lifeBarScale.z);

        Vector3 pos = myLifeBar.transform.localPosition;

        myLifeBar.transform.localPosition = new Vector3(NewPosX,
                                                        pos.y,
                                                        pos.z);
    }

}
