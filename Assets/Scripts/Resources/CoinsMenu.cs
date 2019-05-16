using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsMenu : MonoBehaviour {

    public Image num1, num2, num3;

    public Sprite[] sprites;

    public void SetCoins(int val) {
        if(val < 100)
            num1.sprite = sprites[0];
        else
            num1.sprite = sprites[val / 100];

        if(val < 10)
            num2.sprite = sprites[0];
        else
            num2.sprite = sprites[(val % 100) / 10];

        num3.sprite = sprites[val % 10 ];
    }
}
