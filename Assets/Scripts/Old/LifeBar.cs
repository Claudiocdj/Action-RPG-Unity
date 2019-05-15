using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {
    
    private int fullLife;

	// Use this for initialization
	void Start () {
        fullLife = GetComponentInParent<Enemy>().health;
    }

    public void setLifeBar(int life) {
        
        Vector3 newScale = transform.localScale;
        newScale.x = (0.8f * life) / fullLife;

        transform.localScale = newScale;
    }
}
