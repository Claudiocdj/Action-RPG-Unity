using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour {

    public int coins;

    private CoinsMenu coinsMenu;

    private void Start() {
        coinsMenu = GameObject.Find("CoinsMenu").GetComponent<CoinsMenu>();
    }

    public void AddCoin(int quant) {
        coins += quant;

        if (coins > 999) coins = 999;

        coinsMenu.SetCoins(coins);
    }

    public void RemoveCoins(int quant) {
        coins -= quant;

        if (coins < 0) coins = 0;

        coinsMenu.SetCoins(coins);
    }
}
