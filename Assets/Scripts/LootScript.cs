using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour {

    public GameObject lootObject;

    private void OnDestroy() {
        Instantiate(lootObject, transform.position, Quaternion.identity);
    }

}
