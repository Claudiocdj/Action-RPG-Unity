using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMenu : MonoBehaviour {

    public Text[] arrows;
    public Text[] price;

    private int currentArrow;

    private PlayerCoins playerCoins;
    private PlayerAttack playerAttack;
    private Life playerLife;
    private InputsMove playerMove;

    void Start() {
        playerCoins = GameObject.Find("Player").GetComponent<PlayerCoins>();
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        playerLife = GameObject.Find("Player").GetComponent<Life>();
        playerMove = GameObject.Find("Player").GetComponent<InputsMove>();
    }

    public void ResetArrows() {
        foreach (var arrow in arrows)
            arrow.enabled = false;

        arrows[0].enabled = true;

        currentArrow = 0;
    }

    private void OnEnable() {
        ResetArrows();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentArrow > 0) {
            arrows[currentArrow].enabled = false;

            currentArrow--;

            arrows[currentArrow].enabled = true;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentArrow < arrows.Length - 1) {
            arrows[currentArrow].enabled = false;

            currentArrow++;

            arrows[currentArrow].enabled = true;
        }

        else if (Input.GetButtonDown("Fire2")) {
            if(currentArrow == 0 && playerCoins.coins >= int.Parse(price[0].text)) {
                playerCoins.RemoveCoins(int.Parse(price[0].text));

                playerAttack.attackForce++;

                price[0].text = (int.Parse(price[0].text) * 2f).ToString();
            }
            else if(currentArrow == 1 && playerCoins.coins >= int.Parse(price[1].text)) {
                playerCoins.RemoveCoins(int.Parse(price[1].text));

                playerMove.speed++;

                price[1].text = (int.Parse(price[1].text) * 2f).ToString();
            }
            else if (currentArrow == 2 && playerCoins.coins >= int.Parse(price[2].text)) {
                playerCoins.RemoveCoins(int.Parse(price[2].text));

                playerLife.life += 2;

                price[2].text = (int.Parse(price[2].text) * 2f).ToString();
            }
            else if (currentArrow == 3 && playerCoins.coins >= int.Parse(price[3].text)) {
                playerCoins.RemoveCoins(int.Parse(price[3].text));

                playerLife.Heal(playerLife.life);

                price[3].text = (int.Parse(price[3].text) * 2f).ToString();
            }
            else if (currentArrow == 4 && playerCoins.coins >= int.Parse(price[4].text)) {
                playerCoins.RemoveCoins(int.Parse(price[4].text));

                price[3].text = (int.Parse(price[3].text) * 9f).ToString();
            }

        }
    }
}
