using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class ObjectsMap : MonoBehaviour {

    [Serializable]
    public class Count {
        public int minimum;     
        
        public int maximum;            

        public Count(int min, int max) {
            minimum = min;

            maximum = max;
        }
    }

    public GameObject prefab;
    public List<Vector2> pos;
    public Count count;

    private List<GameObject> objsOnMap;

    private void Start() {
        objsOnMap = new List<GameObject>();
    }

    public void InstantiateEnemies() {
        int enemyNum = Random.Range(count.minimum, count.maximum+1);

        List<Vector2> posAux = new List<Vector2>(pos);

        for (int i =0; i < enemyNum; i++) {
            int randIndex = Random.Range(0, posAux.Count);

            GameObject obj = Instantiate(prefab, posAux[randIndex], Quaternion.identity);

            objsOnMap.Add(obj);

            posAux.RemoveAt(randIndex);
        }
    }

    public void DestroyObjectsOnMap() {
        foreach (var obj in objsOnMap)
            Destroy(obj);

        objsOnMap = new List<GameObject>();
    }
}
