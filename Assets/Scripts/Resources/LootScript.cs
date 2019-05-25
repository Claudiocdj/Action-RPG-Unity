using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour {

    public GameObject lootObject;

    public void InstantiateLoot() {
        Instantiate(lootObject, transform.position, Quaternion.identity);
    }

}
